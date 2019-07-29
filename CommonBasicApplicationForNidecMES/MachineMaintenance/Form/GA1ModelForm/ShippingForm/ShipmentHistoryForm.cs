using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.GA1ModelCbm.Shipping;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Windows.Forms;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.GA1ModelForm.ShippingForm
{
    public partial class ShipmentHistoryForm : Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.FormCommonNCVP
    {
        DataTable dtHistory_GA1;
        public ShipmentHistoryForm()
        {
            InitializeComponent();
        }
        private void defineDatatable(ref DataTable dt)
        {
            dt.Columns.Add("BoxID", Type.GetType("System.String"));
            dt.Columns.Add("Serial", Type.GetType("System.String"));
            dt.Columns.Add("Model", Type.GetType("System.String"));
            dt.Columns.Add("ShipDate", Type.GetType("System.DateTime"));
            dt.Columns.Add("Status", Type.GetType("System.String"));
        }
        private void ShipmentHistoryForm_Load(object sender, EventArgs e)
        {
            dtHistory_GA1 = new DataTable();
            defineDatatable(ref dtHistory_GA1);
        }

        private void updateDataGridViews(DataTable dt, ref DataGridView dgv1)
        {
            dgvHistory_GA1.DataSource = dt;
            // Show row number to the row header
            for (int i = 0; i < dgv1.Rows.Count; i++)
                dgv1.Rows[i].HeaderCell.Value = (i + 1).ToString();

            // Adjust the width of the row header
            dgv1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            // Show the bottom of the datagridview
            if (dgv1.Rows.Count >= 1)
                dgv1.FirstDisplayedScrollingRowIndex = dgv1.Rows.Count - 1;
        }

        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Disenalbe the extbox to block scanning
                txtSerial.Enabled = false;

                string serno = txtSerial.Text;
                if (serno != String.Empty)
                {
                    DataTable dt1 = new DataTable();

                    GA1ModelVo ship = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchShipmentHistoryCbm(), new GA1ModelVo
                    {
                        A90Barcode = serno
                    });

                    dt1 = ship.dt;

                    //DataView dv = new DataView(dt1);

                    ////System.Diagnostics.Debug.Print(System.Environment.NewLine);
                    //printDataView(dv);
                    //DataTable dt2 = dv.ToTable();

                    // Even when no tester data is found, the module have to appear in the datagridview
                    DataRow newrow = dtHistory_GA1.NewRow();
                    newrow["serial"] = serno;

                    // If tester data exists, show it in the datagridview
                    if (dt1.Rows.Count != 0)
                    {
                        string boxid = dt1.Rows[0][0].ToString();
                        string model = dt1.Rows[0][2].ToString();
                        DateTime ship_date = DateTime.Parse(dt1.Rows[0][3].ToString());
                        string status = dt1.Rows[0][4].ToString();

                        newrow["boxid"] = boxid;
                        newrow["model"] = model;
                        newrow["shipdate"] = ship_date;
                        newrow["status"] = status;
                    }

                    // Add the row to the datatable
                    dtHistory_GA1.Rows.Add(newrow);

                    // ƒf[ƒ^ƒOƒŠƒbƒgƒrƒ…[‚ÌXV
                    updateDataGridViews(dtHistory_GA1, ref dgvHistory_GA1);
                }

                txtSerial.Enabled = true;
                txtSerial.Focus();
                txtSerial.SelectAll();
            }
        }

        private void printDataView(DataView dv)
        {
            foreach (DataRowView drv in dv)
            {
                System.Diagnostics.Debug.Print(drv["model"].ToString() + ": " + drv["ship_date"].ToString() + ": " + drv["status"].ToString());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)dgvHistory_GA1.DataSource;
            Excel_Class xl = new Excel_Class();
            xl.ExportToExcel(dt1);
        }
    }
}
