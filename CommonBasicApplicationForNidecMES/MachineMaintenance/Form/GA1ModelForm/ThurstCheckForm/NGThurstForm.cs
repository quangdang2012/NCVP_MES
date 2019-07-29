using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.GA1ModelCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class NGThurstForm : FormCommonNCVP
    {
        public NGThurstForm()
        {
            InitializeComponent();
            dgv_thurst.AutoGenerateColumns = false;
        }
        bool Checkdata()
        {
            if (txt_barcode.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_barcode.Text);
                popUpMessage.Warning(messageData, Text);
                txt_barcode.Focus();
                return false;
            }
            if (txt_barcode.Text.Length != 8)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_barcode.Text);
                popUpMessage.Warning(messageData, Text);
                txt_barcode.Focus();
                return false;
            }
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(txt_timer.Text) * 1000;
            lbl_status.Text = "WAITING";
            lbl_status.ForeColor = System.Drawing.Color.DarkGoldenrod;
            pb_NoData.Visible = false;
            pb_NG.Visible = false;
            timer1.Enabled = false;
        }
        private void NGThurstForm_Load(object sender, EventArgs e)
        {
            txt_barcode.SelectNextControl(txt_barcode, true, false, true, true);
            //dt = new DataTable();
            //dt.Columns.Add("Barcode", typeof(string));
            //dt.Columns.Add("Thurst Status", typeof(string));
            //dgv_thurst.DataSource = dt;
        }
        int i = 0;
        int del = 0;
        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            int count = 0;
            if (e.KeyCode == Keys.Enter)
            {
                Checkdata();
                if (del == 1)
                {
                    dgv_thurst.Rows.RemoveAt(0);
                    del = 0;
                }
                for (int j = 0; j < dgv_thurst.RowCount; j++)
                {
                    dgv_thurst.Rows[j].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
                    if (txt_barcode.Text.Length == 8)
                {
                    GA1ModelVo testbarcodeVo = new GA1ModelVo()
                    {
                        A90Barcode = txt_barcode.Text,
                    };

                    GA1ModelVo BarcodeVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchBarcodeandUpdateNGThurstCbm(), testbarcodeVo);
                    if (BarcodeVo.AffectedCount >= 1)//update thanh cong
                    {
                        i++;
                        pb_NG.Visible = true;
                        pb_NoData.Visible = false;
                        dgv_thurst.Rows.Add(i, txt_barcode.Text, "NG");
                        for (int j = 0; j < dgv_thurst.RowCount; j++)
                        {
                            count++;
                            if (j > 0)
                            {
                                if (dgv_thurst.Rows[dgv_thurst.RowCount - 1].Cells["Barcode"].Value.ToString() == dgv_thurst.Rows[j - 1].Cells["Barcode"].Value.ToString())
                                {
                                    count--;
                                    dgv_thurst.Rows[dgv_thurst.RowCount - 1].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                                    del = 1;
                                    dgv_thurst.Rows[j - 1].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                                }
                            }                            
                        }
                    }
                    else
                    {
                        pb_NG.Visible = false;
                        pb_NoData.Visible = true;
                    }
                    
                    timer1.Interval = int.Parse(txt_timer.Text) * 1000;
                    timer1.Enabled = true;
                }
                dgv_thurst.Sort(dgv_thurst.Columns["id"], ListSortDirection.Descending);
                lblCount.Text = dgv_thurst.Rows.Cast<DataGridViewRow>()
                           .Where(x => !x.IsNewRow)                   // either..
                           .Where(x => x.Cells["Barcode"].Value != null) //..or or both
                           .Select(x => x.Cells["Barcode"].Value.ToString())
                           .Distinct().Count().ToString();                
                txt_barcode.Clear();
            }
        }
    }
}
