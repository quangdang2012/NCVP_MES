using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System.IO;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.GA1ModelCbm;

namespace System.Windows.Forms
{
    public partial class PassForm : Form
    {
        Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.NoiseCheckForm noiseform = new Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.NoiseCheckForm();
        public PassForm(Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.NoiseCheckForm noiseform_)
        {
            InitializeComponent();
            noiseform = noiseform_;
        }
        bool status;
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblUser.Text != "" && lblUser.Text != "User ID not found")
                {
                    if (File.Exists(@"D:\Noise Check Barcode Data\HistoryChangeConnector.txt"))
                    {
                        Writer();
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter(@"D:\Noise Check Barcode Data\HistoryChangeConnector.txt");
                        sw.Write("Teachnican;Datetime Change Connector");
                        sw.Close();
                        Writer();
                    }
                    status = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không đúng User ID !", "Info", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + System.Environment.NewLine + ex.Message, "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Writer()
        {
            StreamReader sr = new StreamReader(@"D:\Noise Check Barcode Data\HistoryChangeConnector.txt");
            string a = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new StreamWriter(@"D:\Noise Check Barcode Data\HistoryChangeConnector.txt");
            sw.Write(a);
            sw.Write(sw.NewLine);
            sw.Write(lblUser.Text + ";" + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            sw.Close();
        }

        private void PassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (status)
            {
                noiseform.apcept = true;
            }
            else
            {
                noiseform.apcept = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            status = false;
            this.Close();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text.Length > 9)
                {
                    GA1ModelVo user = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchUserNameNoiseCbm(), new GA1ModelVo() { UserCd = txtID.Text });
                    if (!string.IsNullOrEmpty(user.UserName))
                    {
                        lblUser.Text = user.UserName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + System.Environment.NewLine + ex.Message, "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
