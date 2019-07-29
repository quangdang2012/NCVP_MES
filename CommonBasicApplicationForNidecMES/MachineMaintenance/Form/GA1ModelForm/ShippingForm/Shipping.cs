using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using System.Globalization;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.GA1ModelForm.ShippingForm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.GA1ModelCbm.Shipping;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class Shipping : FormCommonNCVP
    {
        string directory = @"\\192.168.145.7\ncvp\print\";

        public Shipping()
        {
            InitializeComponent();
            dgvBoxId.AutoGenerateColumns = false;
        }

        DataGridViewButtonColumn openBoxId;
        DataGridViewButtonColumn editShipDate;
        DataTable dtOverall;
        GA1ModelVo getList;
        bool res;

        private void ShippingForm_Load(object sender, EventArgs e)
        {
            selectdata();
            addButtonsToDataGridView(dgvBoxId);
        }

        #region CLICK EVENT

        private void btnSearchBoxId_Click(object sender, EventArgs e)
        {
            if (rdbPrintDate.Checked == true)
            {
                getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchBoxIDCbm(), new GA1ModelVo
                {
                    PrintDate = DateTime.Parse(dtpPrintDate.Value.ToShortDateString()),
                    Format = true
                });
            }

            if (rdbShipDate.Checked == true)
            {
                getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchBoxIDCbm(), new GA1ModelVo
                {
                    ShipDate = dtpShipDate.Value.Date,
                    Format = false
                });
            }
            dgvBoxId.DataSource = getList.dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            defineDataTable(ref dt);

            ResetControlValues.ResetControlValue(tableLayoutPanel2);
            ResetControlValues.ResetControlValue(tableLayoutPanel3);
            dgvProductSerial.DataSource = dt;
            dgvDateCode.DataSource = null;
            splMain.Panel2.Enabled = false;
            splMain.Panel1Collapsed = false;
        }

        private void btnAddBox_Click(object sender, EventArgs e)
        {
            new AddBoxID().Show();
        }

        private void btnScanSample_Click(object sender, EventArgs e)
        {
            dtOverall = new DataTable();
            defineDataTable(ref dtOverall);
            splMain.Panel2.Enabled = true;
            txtProduct.Enabled = true;
            txtUser.Enabled = false;
            splMain.Panel1Collapsed = true;
            btnRegisterBoxId.Visible = false;
            res = true;
        }

        private void btnRegisterBoxId_Click(object sender, EventArgs e)
        {
            string boxIdNew;

            boxIdNew = txtBoxId.Text;
            // Print barcode
            printBarcode(directory, boxIdNew, txtModel.Text, dgvDateCode, ref dgvDateCode2, ref txtBoxIdPrint);

            //txtBoxId.Text = boxIdNew;
            dtpPrintDate.Value = DateTime.ParseExact(VBStrings.Mid(boxIdNew, 5, 6), "yyMMdd", CultureInfo.InvariantCulture);

        }

        private void dgvBoxId_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnRegisterBoxId.Visible == false) btnRegisterBoxId.Visible = true;
            int currentRow = int.Parse(e.RowIndex.ToString());
            DataTable dt_temp = new DataTable();
            // OPEN button generate frmModule by view mode without delegate event
            if (dgvBoxId.Columns[e.ColumnIndex] == openBoxId && currentRow >= 0)
            {
                txtBoxId.Text = dgvBoxId["boxid", currentRow].Value.ToString();
                dtpPrint.Value = DateTime.Parse(dgvBoxId["printdate", currentRow].Value.ToString());
                txtUser.Text = dgvBoxId["suser", currentRow].Value.ToString();
                txtModel.Text = dgvBoxId["child_model", currentRow].Value.ToString();

                GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new GetSerialBoxCbm(), new GA1ModelVo
                {
                    BoxID = txtBoxId.Text
                });
                defineDataTable(ref dt_temp);
                dt_temp = getList.dt;
                dgvProductSerial.DataSource = dt_temp;
                splMain.Panel2.Enabled = true;
                txtProduct.Enabled = false;
                txtUser.Enabled = false;
                txtModel.Enabled = false;
                btnDeleteBoxId.Enabled = true;
                btnRegisterBoxId.Text = "Re-Print";
                btnRegisterBoxId.Enabled = true;
                txtOkCount.Text = dgvProductSerial.RowCount.ToString() + "/" + dgvProductSerial.RowCount.ToString();
                res = false;
                updateDataGripViewsSub(dt_temp, ref dgvProductSerial);
            }

            // SHIP button edit the shipping date for box id
            if (dgvBoxId.Columns[e.ColumnIndex] == editShipDate && currentRow >= 0)
            {
                string boxId = dgvBoxId["boxid", currentRow].Value.ToString();
                bool ship = false;
                if (dgvBoxId.CurrentRow.Cells["shipdate"].Value.ToString() != String.Empty) { ship = true; }
                DateTime shipdate = dtpShipDate.Value;

                DialogResult result1 = MessageBox.Show("Do you want to update the shipping date of as follows:" + System.Environment.NewLine +
                    boxId + ": " + shipdate, "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result1 == DialogResult.Yes)
                {
                    GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new UpdateShipdateCbm(), new GA1ModelVo
                    {
                        BoxID = dgvBoxId["boxid", currentRow].Value.ToString(),
                        ShipDate = shipdate,
                        ShipStatus = txtType.Text,
                        A90Shipping = ship
                    });
                    selectdata();
                }
            }
        }

        private void btnDeleteBoxId_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to delete this box ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                DialogResult res1 = MessageBox.Show("Are you sure to delete this box ? Please click 'NO' if you are not sure!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res1 == DialogResult.Yes)
                {
                    GA1ModelVo deleteBox;
                    try
                    {
                        deleteBox = (GA1ModelVo)DefaultCbmInvoker.Invoke(new DeleteBoxIDCbm(), new GA1ModelVo
                        {
                            BoxID = txtBoxId.Text
                        });
                        popUpMessage.Information(new MessageData("mmci00003", Properties.Resources.mmci00003), Text);
                    }
                    catch (Framework.ApplicationException ex)
                    {
                        logger.Error(ex.GetMessageData());
                        popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                        return;
                    }
                }
            }
            btnClose.PerformClick();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            new ReplaceSerialForm(txtBoxId.Text).Show();
        }

        private void btnShipmentSN_Click(object sender, EventArgs e)
        {
            new ShipmentHistoryForm().ShowDialog();
        }

        private void btnExportSN_Click(object sender, EventArgs e)
        {
            GA1ModelVo getSN = (GA1ModelVo)DefaultCbmInvoker.Invoke(new GetShipSerialCbm(), new GA1ModelVo
            {
                ShipDate = DateTime.Parse(dtpShipDate.Value.ToShortDateString())
            });
            new Excel_Class().ExportToExcel(getSN.dt);
        }
        #endregion

        #region VOID

        // Sub procedure: Add button to datagridview
        private void addButtonsToDataGridView(DataGridView dgv)
        {
            // Set OPEN button
            openBoxId = new DataGridViewButtonColumn();
            openBoxId.HeaderText = "Open";
            openBoxId.Text = "Open";
            openBoxId.UseColumnTextForButtonValue = true;
            openBoxId.Width = 80;
            dgv.Columns.Add(openBoxId);

            // Set SHIPPING button
            editShipDate = new DataGridViewButtonColumn();
            editShipDate.HeaderText = "Ship";
            editShipDate.Text = "Ship";
            editShipDate.UseColumnTextForButtonValue = true;
            editShipDate.Width = 80;
            dgv.Columns.Add(editShipDate);
        }
        private void selectdata()
        {
            GA1ModelVo getList = null;
            try
            {
                getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new GetBoxIDCbm(), new GA1ModelVo
                {
                    PrintDate = DateTime.Today
                });
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            dgvBoxId.DataSource = getList.dt;
        }

        // Sub procedure: Print barcode, by generating a text file in shared folder and let another application print it
        private void printBarcode(string dir, string id, string m_model, DataGridView dgv1, ref DataGridView dgv2, ref TextBox txt)
        {
            //PrintLabel tf = new PrintLabel();
            //tf.createBoxidFiles(dir, id, m_model, dgv1, ref dgv2, ref txt);
        }
        private void defineDataTable(ref DataTable dt)
        {
            string boxId = txtBoxId.Text;
            dt.Columns.Add("Serial", Type.GetType("System.String"));
            dt.Columns.Add("Model", Type.GetType("System.String"));
            dt.Columns.Add("Line", Type.GetType("System.String"));
            dt.Columns.Add("Lot", Type.GetType("System.String"));
            dt.Columns.Add("Thurst", Type.GetType("System.String"));
            dt.Columns.Add("Thurst_MC", Type.GetType("System.String"));
            dt.Columns.Add("Noise", Type.GetType("System.String"));
            dt.Columns.Add("Noise_MC", Type.GetType("System.String"));
        }

        // Sub procedure: Count the without-duplicate OK records
        private int getOkCount(DataTable dt)
        {
            if (dt.Rows.Count <= 0) return 0;
            DataTable distinct = dt.DefaultView.ToTable(true, new string[] { "Serial", "Thurst", "Noise" });
            DataRow[] dr = distinct.Select("Thurst = 'OK' and Noise = 'OK'");
            int dist = dr.Length;
            return dist;
        }

        // Sub procedure: Bind main datatable to the datagridview and make summary datatables
        private void updateDataGripViewsSub(DataTable dt1, ref DataGridView dgv1)
        {
            string[] criteriaDateCode = getLotArray(dt1);
            makeDatatableSummary(dt1, ref dgvDateCode, criteriaDateCode, "Lot");
        }

        // Sub procedure: Make lot summary
        private string[] getLotArray(DataTable dt0)
        {
            DataTable dt1 = dt0.Copy();
            DataView dv = dt1.DefaultView;
            dv.Sort = "Lot";
            DataTable dt2 = dv.ToTable(true, "Lot");
            string[] array = new string[dt2.Rows.Count + 1];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                array[i] = dt2.Rows[i]["Lot"].ToString();
            }
            array[dt2.Rows.Count] = "Total";
            return array;
        }

        // Sub procedure: Make the summary datatables and bind them to the summary datagridviews
        public void makeDatatableSummary(DataTable dt0, ref DataGridView dgv, string[] criteria, string header)
        {
            DataTable dt1 = new DataTable();
            DataRow dr = dt1.NewRow();
            Int32 count;
            Int32 total = 0;
            string condition;

            for (int i = 0; i < criteria.Length; i++)
            {
                dt1.Columns.Add(criteria[i], typeof(Int32));
                condition = header + " = '" + criteria[i] + "'";
                count = dt0.Select(condition).Length;
                total += count;
                dr[criteria[i]] = (i != criteria.Length - 1 ? count : total);
                if (criteria[i] == "Total" && header == "Lot")
                {
                    dr[criteria[i]] = dgvProductSerial.Rows.Count;
                    //dr[criteria[i - 1]] = dgvProductSerial.Rows.Count - total;
                }
            }
            dt1.Rows.Add(dr);

            dgv.Columns.Clear();
            dgv.DataSource = dt1;
            dgv.AllowUserToAddRows = false; // remove the null line
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion


    }
}