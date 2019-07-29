using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.GA1ModelCbm.Shipping;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.GA1ModelForm.ShippingForm
{
    public partial class ReplaceSerialForm : FormCommonNCVP
    {
        public ReplaceSerialForm(string boxid)
        {
            InitializeComponent();
            lblBoxID.Text = "BoxID: " + boxid;
        }

        private void txtOldSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtNewSerial.Focus();
        }
        private void txtNewSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Disenalbe the textbox to block scanning
                if (txtNewSerial.Text.Length != 8) return;

                DataTable dt = new DataTable();
                defineDataTable(ref dt);
                DataTable dt1 = new DataTable();
                GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchBoxIDProductCbm(), new GA1ModelVo
                {
                    A90Barcode = txtNewSerial.Text
                });
                dt1 = getList.dt;

                // Even when no tester data is found, the module have to appear in the datagridview
                DataRow newrow = dt.NewRow();

                string serial = txtNewSerial.Text;
                string lot = VBStrings.Left(txtNewSerial.Text, 5);
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
                dt.Rows.Add(newrow);
                dgvNewSerial.DataSource = dt;
                txtNewSerial.SelectAll();
                bool col = colorViewForFailAndBlank(ref dgvNewSerial);
                if (!col) btnReplace.Enabled = true;
            }
        }
        private bool colorViewForFailAndBlank(ref DataGridView dgv)
        {
            int rowCount = dgv.BindingContext[dgv.DataSource, dgv.DataMember].Count;
            bool res = false;
            for (int i = 0; i < rowCount; i++)
            {
                if (dgv["Thurst", i].Value.ToString() == "NG" || dgv["Thurst", i].Value.ToString() == String.Empty)
                {
                    dgv["Thurst", i].Style.BackColor = Color.Red;
                    res = true;
                }
                if (dgv["Noise", i].Value.ToString() == "NG" || dgv["Noise", i].Value.ToString() == String.Empty)
                {
                    dgv["Noise", i].Style.BackColor = Color.Red;
                    res = true;
                }
                else
                {
                    dgv["Thurst", i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
            }
            return res;
        }
        private void defineDataTable(ref DataTable dt)
        {
            dt.Columns.Add("Serial", Type.GetType("System.String"));
            dt.Columns.Add("Model", Type.GetType("System.String"));
            dt.Columns.Add("Line", Type.GetType("System.String"));
            dt.Columns.Add("Lot", Type.GetType("System.String"));
            dt.Columns.Add("Thurst", Type.GetType("System.String"));
            dt.Columns.Add("Thurst_MC", Type.GetType("System.String"));
            dt.Columns.Add("Noise", Type.GetType("System.String"));
            dt.Columns.Add("Noise_MC", Type.GetType("System.String"));
        }
        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (lblBoxID.Text == "BoxID:") return;

            GA1ModelVo getList = (GA1ModelVo)DefaultCbmInvoker.Invoke(new UpdateSerialCbm(), new GA1ModelVo
            {
                ReplaceSerial = dgvNewSerial["Serial", 0].Value.ToString(),
                LineCode = dgvNewSerial["Line", 0].Value.ToString(),
                A90ThurstStatus = dgvNewSerial["Thurst", 0].Value.ToString(),
                Thurst_MC = dgvNewSerial["Thurst_MC", 0].Value.ToString(),
                A90NoiseStatus = dgvNewSerial["Noise", 0].Value.ToString(),
                Noise_eq_id = dgvNewSerial["Noise_MC", 0].Value.ToString(),
                Lot = dgvNewSerial["Lot", 0].Value.ToString(),
                A90Barcode = txtOldSerial.Text
            });
            ResetControlValues.ResetControlValue(this);
            dgvNewSerial.DataSource = null;
            txtOldSerial.Focus();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}