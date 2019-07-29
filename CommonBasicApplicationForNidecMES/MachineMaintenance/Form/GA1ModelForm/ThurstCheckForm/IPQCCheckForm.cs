using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using System.Drawing;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.GA1ModelCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class IPQCCheckForm : FormCommonNCVP
    {
        public IPQCCheckForm()
        {
            InitializeComponent();
        }
        DataTable dtOv = new DataTable();
        void callModel()
        {
            ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            cmb_model.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            cmb_model.DataSource = b1;
            cmb_model.Text = "LDP_5SG";
        }
        private void IPQCCheckForm_Load(object sender, EventArgs e)
        {
            callModel();
            txt_barcode.SelectNextControl(txt_barcode, true, false, true, true);
            pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
            pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
            pnlThurst.BackgroundImage = Properties.Resources.STANDBY;
            pnlNoise.BackgroundImage = Properties.Resources.STANDBY;
            dtOv.Columns.Add("Serial");
            dtOv.Columns.Add("Lot");
        }
        bool Checkdata()
        {
            if (cmb_model.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_model.Text);
                popUpMessage.Warning(messageData, Text);
                cmb_model.Focus();
                return false;
            }

            if (txt_barcode.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_barcode.Text);
                popUpMessage.Warning(messageData, Text);
                txt_barcode.Focus();
                return false;
            }
            return true;
        }
        int count = 0;
        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode != Keys.Enter) return;

            if (txt_barcode.Text == string.Empty) return;

            if (txt_barcode.ReadOnly == true) return;
            

            //Check Thurst, Noise, TestTime
            bool res1 = checkTestTimes(txt_barcode.Text);
            if (!res1) return;

            bool res = checkThurstNoise(txt_barcode.Text);
            if (!res) return;

            //Count lot
            DataRow newrow = dtOv.NewRow();
            string serial = txt_barcode.Text;
            string lot = VBStrings.Left(txt_barcode.Text, 5);

            newrow["Serial"] = serial;
            newrow["Lot"] = lot;
            dtOv.Rows.Add(newrow);
            dgvLot.DataSource = dtOv;
            updateDataGripViewsSub(dtOv, ref dgvDateCode);

            //Output
            GA1ModelVo check = (GA1ModelVo)DefaultCbmInvoker.Invoke(new CheckIBarcodeDuplicateCbm(), new GA1ModelVo
            {
                A90Barcode = txt_barcode.Text
            });

            bool dup = checkDuplicate();

            if (check.AffectedCount > 0)
            {
                if (dup)
                {
                    MessageBox.Show("Duplicate barcode!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                return;
            }

            GA1ModelVo outVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new AddBarcodeCheckCmb(), new GA1ModelVo
            {
                A90Barcode = txt_barcode.Text,
                ModelCode = cmb_model.Text,
                LineCode = dgvTestTimeThurst["line", 0].Value.ToString()
            });
            count = count + 1;
            lblCounter.Text = count.ToString();
        }
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
                    dr[criteria[i]] = dgvDateCode.Rows.Count;
                    //dr[criteria[i - 1]] = dgvProductSerial.Rows.Count - total;
                }
            }
            dt1.Rows.Add(dr);

            dgv.Columns.Clear();
            dgv.DataSource = dt1;
            dgv.AllowUserToAddRows = false; // remove the null line
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.Columns[dgv.ColumnCount - 1].Visible = false;
        }
        private bool checkDuplicate()
        {
            GA1ModelVo checkI = (GA1ModelVo)DefaultCbmInvoker.Invoke(new CheckDuplicateCbm(), new GA1ModelVo
            {
                A90Barcode = txt_barcode.Text
            });

            if (checkI.AffectedCount > 0)
            {
                txt_barcode.ReadOnly = true;
                txt_barcode.BackColor = Color.Red;
                return true;
            }
            else return false;
        }
        private bool checkThurstNoise(string id)
        {
            string scanTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            GA1ModelVo inVo = new GA1ModelVo
            {
                A90Barcode = id,
                A90Model = cmb_model.Text
            };

            ValueObjectList<GA1ModelVo> outVo = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new SearchThurstDGVCbm(), inVo);
            
            bool result = false;

            if (outVo.GetList().Count > 0)
            {
                //Check Thurst
                switch (outVo.GetList()[0].A90ThurstStatus)
                {
                    case "OK":
                        pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlThurst.BackgroundImage = Properties.Resources.OK_BEAR;
                        //checkDuplicate();

                        result = true;

                        txt_barcode.SelectAll();
                        break;
                    case "NG":
                        pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlThurst.BackgroundImage = Properties.Resources.NG_BEAR;
                        //checkDuplicate();

                        result = false;//Đẳng sửa true -> false

                        txt_barcode.ReadOnly = true;
                        txt_barcode.BackColor = Color.Red;
                        break;
                    default:
                        pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlThurst.BackgroundImage = Properties.Resources.NoDaTa;

                        result = true;

                        txt_barcode.ReadOnly = false;//Đẳng sửa true -> false
                        txt_barcode.BackColor = Color.Red;
                        break;
                }

                if (!result) { return false; } //Đẳng add

                //Check Noise
                switch (outVo.GetList()[0].A90NoiseStatus)
                {
                    case "OK":
                        pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlNoise.BackgroundImage = Properties.Resources.OK_BEAR;
                        //checkDuplicate();

                        result = true;

                        txt_barcode.SelectAll();
                        break;
                    case "NG":
                        pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlNoise.BackgroundImage = Properties.Resources.NG_BEAR;
                        //checkDuplicate();

                        result = false;//Đẳng sửa true -> false

                        txt_barcode.ReadOnly = true;
                        txt_barcode.BackColor = Color.Red;
                        break;
                    default:
                        pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlNoise.BackgroundImage = Properties.Resources.NoDaTa;

                        result = false;//Đẳng sửa true -> false

                        txt_barcode.ReadOnly = true;
                        txt_barcode.BackColor = Color.Red;
                        break;
                }
                if (!result) { return false; } //Đẳng add

                //Check OQC_Data Đẳng add
                switch (outVo.GetList()[0].A90OQCData)
                {
                    case "NG":
                        pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlThurst.BackgroundImage = Properties.Resources.NG_BEAR;
                        //checkDuplicate();

                        result = false;//Đẳng sửa true -> false

                        txt_barcode.ReadOnly = true;
                        txt_barcode.BackColor = Color.Red;
                        break;
                    default:
                        pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
                        pnlThurst.BackgroundImage = Properties.Resources.OK_BEAR;

                        result = true;
                        break;
                }
                if (!result) { return false; } //Đẳng add
            }
            else
            {
                pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
                pnlThurst.BackgroundImage = Properties.Resources.NoDaTa;
                pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
                pnlNoise.BackgroundImage = Properties.Resources.NoDaTa;
                txt_barcode.ReadOnly = true;
                txt_barcode.BackColor = Color.Red;
                result = false;
            }
            return result;
        }
        private void colorViewForFailAndBlank(ref DataGridViewCommon dgv)
        {
            int rowCount = dgv.BindingContext[dgv.DataSource, dgv.DataMember].Count;
            for (int i = 0; i < rowCount; i++)
            {
                if (dgv["thurst", i].Value.ToString() == "NG" || dgv["Thurst", i].Value.ToString() == String.Empty)
                {
                    dgv["thurst", i].Style.BackColor = Color.Red;
                }
                if (dgv["noise", i].Value.ToString() == "NG" || dgv["Noise", i].Value.ToString() == String.Empty)
                {
                    dgv["noise", i].Style.BackColor = Color.Red;
                }
            }
        }
        private bool checkTestTimes(string serial)
        {
            GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new GetTestTimeCbm(), new GA1ModelVo
            {
                A90Barcode = serial
            });
            GA1ModelVo getListNoise = (GA1ModelVo)DefaultCbmInvoker.Invoke(new GetTestTimeNoiseCbm(), new GA1ModelVo
            {
                A90Barcode = serial
            });
            dgvTestTimeThurst.DataSource = getList.dt;
            dgvTestTimeNoise.DataSource = getListNoise.dt;
            ShowRowNumber(dgvTestTimeThurst);
            ShowRowNumber(dgvTestTimeNoise);
            colorViewForFailAndBlank(ref dgvTestTimeThurst);
            lblTestTime.Text = "Test Times Thurst: " + dgvTestTimeThurst.RowCount;

            bool kq = false;
            if (dgvTestTimeThurst.RowCount > 20)
            {
                lblTestTime.BackColor = Color.Red;
                txt_barcode.BackColor = Color.Red;
                txt_barcode.ReadOnly = true;
                kq = false;
            }
            else
            {
                lblTestTime.BackColor = Color.LightGreen;
                kq = true;
            }
            return kq;
        }
        public void ShowRowNumber(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();

            // Show the bottom of the datagridview
            if (dgv.Rows.Count >= 1)
                dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            pnlThurst.BackgroundImageLayout = ImageLayout.Zoom;
            pnlNoise.BackgroundImageLayout = ImageLayout.Zoom;
            pnlThurst.BackgroundImage = Properties.Resources.STANDBY;
            pnlNoise.BackgroundImage = Properties.Resources.STANDBY;

            lblTestTime.ResetText();
            dgvTestTimeThurst.DataSource = null;
            dgvTestTimeNoise.DataSource = null;
            txt_barcode.ResetText();
            txt_barcode.ReadOnly = false;
            txt_barcode.BackColor = Color.White;
            txt_barcode.Focus();
        }
    }
}