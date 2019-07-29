using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using System.Globalization;
using System.Drawing;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.GA1ModelCbm.Shipping;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class AddBoxID : FormCommonNCVP
    {
        string directory = @"\\192.168.145.7\ncvp\print\";

        public AddBoxID()
        {
            InitializeComponent();
        }

        DataGridViewButtonColumn openBoxId;
        DataGridViewButtonColumn editShipDate;
        DataTable dtOverall;
        bool res;

        private void ShippingForm_Load(object sender, EventArgs e)
        {
            dtOverall = new DataTable();
            defineDataTable(ref dtOverall);
        }

        #region CLICK EVENT
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeLimit_Click(object sender, EventArgs e)
        {
            if (btnChangeLimit.Text == "Change Limit")
            {
                btnChangeLimit.Text = "OK";
                txtLimit.Enabled = true;
            }
            else
            {
                btnChangeLimit.Text = "Change Limit";
                txtLimit.Enabled = false;
                limitOkChange();
            }
        }
        private void btnRegisterBoxId_Click(object sender, EventArgs e)
        {
            string boxIdNew;
            
            if (String.IsNullOrEmpty(txtUser.Text))
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lblUser.Text);
                popUpMessage.Warning(messageData, Text);
                txtUser.Focus();
                return;
            }

            // Check if the product serials had already registered in the database table
            string checkResult = CheckDuplicateBarcode(dtOverall);

            if (checkResult != String.Empty)
            {
                MessageBox.Show("The following serials are already registered with box id:" + Environment.NewLine +
                    checkResult + Environment.NewLine + "Please check and delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                btnRegisterBoxId.Enabled = true;
                btnDeleteSelection.Enabled = true;
                btnDeleteAll.Enabled = true;
                return;
            }

            // Issue new box id
            boxIdNew = getNewBoxId();
            GA1ModelVo outVo = new GA1ModelVo();
            outVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new AddBoxIDCbm(), new GA1ModelVo
            {
                BoxID = boxIdNew,
                User = txtUser.Text,
                ModelCode = cmbModel.Text
            });

            for (int i = 0; i < dgvProductSerial.Rows.Count; i++)
            {
                outVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new AddProductCbm(), new GA1ModelVo
                {
                    BoxID = boxIdNew,
                    A90Barcode = dgvProductSerial["Serial", i].Value.ToString(),
                    LineCode = dgvProductSerial["Line", i].Value.ToString(),
                    Lot = dgvProductSerial["Lot", i].Value.ToString(),
                    A90ThurstStatus = dgvProductSerial["Thurst", i].Value.ToString(),
                    A90NoiseStatus = dgvProductSerial["Noise", i].Value.ToString(),
                    Thurst_MC = dgvProductSerial["Thurst_MC", i].Value.ToString(),
                    Noise_eq_id = dgvProductSerial["Noise_MC", i].Value.ToString(),
                    ModelCode = dgvProductSerial["Model", i].Value.ToString()
                });
            }

            // Print barcode
            printBarcode(directory, boxIdNew, cmbModel.Text, dgvDateCode, ref dgvDateCode2, ref txtBoxIdPrint);

            // Clear the datatable
            dtOverall.Clear();

            txtBoxId.Text = boxIdNew;
            dtpPrint.Value = DateTime.ParseExact(VBStrings.Mid(boxIdNew, 5, 6), "yyMMdd", CultureInfo.InvariantCulture);
            MessageBox.Show("BoxID is registered", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvDateCode.DataSource = null;
            txtLimit.Text = "350";
            txtOkCount.Text = "0/350";
            txtProduct.Enabled = true;
            txtBoxId.ResetText();
        }

        // Delete all records on datagridview, by the user's click on the delete all button
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            int rowCount = dgvProductSerial.Rows.Count;
            if (rowCount != 0)
            {
                DialogResult result = MessageBox.Show("Do you really want to delete all the record?",
                    "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    dtOverall.Clear();
                    dtOverall.AcceptChanges();
                    //dgvProductSerial.Rows.Clear();
                    txtProduct.Focus();
                    //defineDataTable(ref dtOverall);
                    updateDataGripViewsSub(dtOverall, ref dgvProductSerial);
                    CountLot();
                }
            }
        }

        // Delete records on datagridview selected by the user
        private void btnDeleteSelection_Click(object sender, EventArgs e)
        {
            if (dgvProductSerial.Columns.GetColumnCount(DataGridViewElementStates.Selected) >= 2)
            {
                MessageBox.Show("Please select range with only one columns.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }

            DialogResult result = MessageBox.Show("Do you really want to delete the selected rows ?",
                "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewCell cell in dgvProductSerial.SelectedCells)
                {
                    int i = cell.RowIndex;
                    dtOverall.Rows[i].Delete();
                }
                dtOverall.AcceptChanges();
                colorViewForDuplicateSerial(ref dgvProductSerial);
                colorViewForFailAndBlank(ref dgvProductSerial);
               // if (cmbModel.Text == "LPD5SG-039") colorViewForThurst030(ref dgvProductSerial);
                limitOkChange();
                txtProduct.Focus();
                ShowRowNumber(dgvProductSerial);
                //defineDataTable(ref dtOverall);
                updateDataGripViewsSub(dtOverall, ref dgvProductSerial);
                CountLot();
            }
        }
        #endregion

        #region VOID

        //Check duplicate barcode
        public string CheckDuplicateBarcode(DataTable dt1)
        {
            string result = String.Empty;
            GA1ModelVo outVo = new GA1ModelVo();

            outVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new CheckBoxCbm(), new GA1ModelVo());
            DataTable dt2 = new DataTable();
            dt2 = outVo.dt;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string serial = dt1.Rows[i]["Serial"].ToString();
                DataRow[] dr = dt2.Select("serial_short = '" + serial + "'");
                if (dr.Length >= 1)
                {
                    string boxid = dr[0]["boxid"].ToString();
                    result += (i + 1 + ": " + serial + " / " + boxid + Environment.NewLine);
                }
            }

            if (result == String.Empty)
            {
                return String.Empty;
            }
            else
            {
                return result;
            }
        }
        // Sub procedure: Add button to datagridview
        private void addButtonsToDataGridView(DataGridView dgv)
        {
            // Set OPEN button for every user
            openBoxId = new DataGridViewButtonColumn();
            openBoxId.HeaderText = "Open";
            openBoxId.Text = "Open";
            openBoxId.UseColumnTextForButtonValue = true;
            openBoxId.Width = 80;
            dgv.Columns.Add(openBoxId);

            // Set SHIPPING button only for the super user
            //if (txtUser.Text == "User_9")
            //{
            editShipDate = new DataGridViewButtonColumn();
            editShipDate.HeaderText = "Ship";
            editShipDate.Text = "Ship";
            editShipDate.UseColumnTextForButtonValue = true;
            editShipDate.Width = 80;
            dgv.Columns.Add(editShipDate);
            //}
        }
        private void limitOkChange()
        {
            // Store the OK record count to the variable and show in the text box
            int okCount = getOkCount(dtOverall);
            txtOkCount.Text = okCount + "/" + txtLimit.Text;

            // If the OK record count has already reached to the capacity, disenable the scan text box
            if (okCount == int.Parse(txtLimit.Text))
                txtProduct.Enabled = false;
            else
                txtProduct.Enabled = true;

            // If the OK record coutn has already reached to the capacity, enable the register button
            if (okCount == int.Parse(txtLimit.Text) && dgvProductSerial.Rows.Count == int.Parse(txtLimit.Text))
                btnRegisterBoxId.Enabled = true;
            else
                btnRegisterBoxId.Enabled = false;
        }

        // Sub procedure: Issue new box id
        private string getNewBoxId()
        {
            ValueObjectList<GA1ModelVo> outd = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new GetNewBoxIDCbm(), new GA1ModelVo());

            string boxIdOld = outd.GetList()[0].BoxID;

            DateTime dateOld = new DateTime(0);
            long numberOld = 0;
            string boxIdNew;

            if (boxIdOld != string.Empty)
            {
                dateOld = DateTime.ParseExact(VBStrings.Mid(boxIdOld, 5, 6), "yyMMdd", CultureInfo.InvariantCulture);
                numberOld = long.Parse(VBStrings.Right(boxIdOld, 3));
            }

            if (dateOld != DateTime.Today)
            {
                boxIdNew = "GR1" + "-" + DateTime.Today.ToString("yyMMdd") + "001";
            }
            else
            {
                boxIdNew = "GR1" + "-" + DateTime.Today.ToString("yyMMdd") + (numberOld + 1).ToString("000");
            }

            return boxIdNew;
        }

        // Sub procedure: Print barcode, by generating a text file in shared folder and let another application print it
        private void printBarcode(string dir, string id, string m_model, DataGridView dgv1, ref DataGridView dgv2, ref TextBox txt)
        {
            //PrintLabel tf = new PrintLabel();
            //tf.createBoxidFiles(dir, id, m_model, dgv1, ref dgv2, ref txt);
        }

        // Sub procedure: Mark the test results with FAIL or missing test records
        private void colorViewForFailAndBlank(ref DataGridView dgv)
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Cells["Thurst"].Value.ToString() == "NG" || item.Cells["Thurst"].Value.ToString() == "") item.Cells["Thurst"].Style.BackColor = Color.Red;
                if (item.Cells["Noise"].Value.ToString() == "NG" || item.Cells["Noise"].Value.ToString() == "") item.Cells["Noise"].Style.BackColor = Color.Red;
            }
        }
        private void colorViewForThurst030(ref DataGridView dgv)
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Cells["Thurst_MC"].Value.ToString() == "380") item.Cells["Thurst_MC"].Style.BackColor = Color.Red;
            }
        }

        // Sub procesure: Mark product serials with duplicate or character length error
        private void colorViewForDuplicateSerial(ref DataGridView dgv)
        {
            DataTable dt = ((DataTable)dgv.DataSource).Copy();
            if (dt.Rows.Count <= 0) return;

            for (int i = 0; i < dtOverall.Rows.Count; i++)
            {
                string serial = dgv["Serial", i].Value.ToString();
                DataRow[] dr = dt.Select("Serial = '" + serial + "'");
                if (dr.Length >= 2)
                {
                    dgv[0, i].Style.BackColor = Color.Red;
                }
                else
                {
                    dgv[0, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
            }
        }

        // Sub procesure: Mark config with duplicate or character length error
        private void colorMixedConfig(DataTable dt, ref DataGridView dgv)
        {
            if (dt.Rows.Count <= 0) return;
            string line;
            DataTable distinct = dt.DefaultView.ToTable(true, new string[] { "Line" });

            if (distinct.Rows.Count == 1)
                line = distinct.Rows[0]["Line"].ToString();

            if (distinct.Rows.Count >= 2)
            {
                string A = distinct.Rows[0]["Line"].ToString();
                string B = distinct.Rows[1]["Line"].ToString();
                int a = distinct.Select("Line = '" + A + "'").Length;
                int b = distinct.Select("Line = '" + B + "'").Length;

                line = a > b ? A : B;

                string C = a < b ? A : B;
                int c = -1;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Line"].ToString() == C) { c = i; }
                }

                if (c != -1)
                {
                    dgv["Line", c].Style.BackColor = Color.Red;
                }
                else
                {
                    dgv.Columns["Line"].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
            }
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

        public void ShowRowNumber(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();

            // Show the bottom of the datagridview
            if (dgv.Rows.Count >= 1)
                dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1;
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
        public void CountLot()
        {
            lblLotCount.Text = dgvDateCode.ColumnCount.ToString();
            if (dgvDateCode.ColumnCount > 35) { lblLotCount.BackColor = Color.Red; }
            else { lblLotCount.BackColor = Color.LightGreen; }
        }
        #endregion
        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(cmbModel.Text))
                {
                    messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lblModel.Text);
                    popUpMessage.Warning(messageData, Text);
                    cmbModel.Focus();
                    return;
                }
                // Disenalbe the textbox to block scanning
                //txtProduct.Enabled = false;
                if (txtProduct.Text.Length != 8) return;

                DataTable dt1 = new DataTable();
                GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchBoxIDProductCbm(), new GA1ModelVo
                {
                    A90Barcode = txtProduct.Text
                });
                dt1 = getList.dt;

                // Even when no tester data is found, the module have to appear in the datagridview
                DataRow newrow = dtOverall.NewRow();

                string serial = txtProduct.Text;
                string lot = VBStrings.Left(txtProduct.Text, 5);
                // If tester data exists, show it in the datagridview
                if (dt1.Rows.Count != 0)
                {
                    string model = dt1.Rows[0][0].ToString();
                    string line = dt1.Rows[0][1].ToString();
                    string thurst = dt1.Rows[0][2].ToString();
                    string thurst_mc = dt1.Rows[0][3].ToString();
                    string noise = dt1.Rows[0][4].ToString();
                    string noise_mc = dt1.Rows[0][5].ToString();


                    newrow["Model"] = model;
                    newrow["Line"] = line;
                    newrow["Thurst"] = thurst;
                    newrow["Thurst_MC"] = thurst_mc;
                    newrow["Noise"] = noise;
                    newrow["Noise_MC"] = noise_mc;
                }

                newrow["Serial"] = serial;
                newrow["Lot"] = lot;

                // Add the row to the datatable
                dtOverall.Rows.Add(newrow);
                dgvProductSerial.DataSource = dtOverall;
                txtProduct.SelectAll();
                ShowRowNumber(dgvProductSerial);
                colorViewForFailAndBlank(ref dgvProductSerial);
                colorViewForDuplicateSerial(ref dgvProductSerial);
                //if (cmbModel.Text == "LPD5SG-039") colorViewForThurst030(ref dgvProductSerial);

                limitOkChange();
                updateDataGripViewsSub(dtOverall, ref dgvProductSerial);
                CountLot();
            }
        }
    }
}