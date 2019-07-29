using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.GA1ModelCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class NoiseCheckForm : FormCommonNCVP
    {
        public NoiseCheckForm()
        {
            InitializeComponent();
        }

        public string mc = "MC";
        private void NoiseCheckForm_Load(object sender, EventArgs e)
        {
            try
            {
                loadMachine();
                timer1.Enabled = true;
                if (Directory.Exists(@"D:\Noise Check Barcode Data"))
                {
                    if (File.Exists(@"D:\Noise Check Barcode Data\login.txt"))
                    {
                        using (var reader = new StreamReader(@"D:\Noise Check Barcode Data\login.txt"))
                        {
                            string[] path = reader.ReadLine().Split(';');
                            txtBrowser.Text = path[0];
                            if (path.Length >= 2) { mc = path[1]; }
                            reader.Close();
                        }
                    }
                    if (File.Exists(@"D:\Noise Check Barcode Data\count.txt"))
                    {
                        using (var reader = new StreamReader(@"D:\Noise Check Barcode Data\count.txt"))
                        {
                            string path = reader.ReadLine();
                            if (!string.IsNullOrEmpty(path))
                            {
                                lblCount.Text = path;

                                if (int.Parse(path) >= 1899 && int.Parse(path) <= 2000)
                                {
                                    lblCount.BackColor = System.Drawing.Color.Yellow;
                                }
                                else if (int.Parse(path) > 2000)
                                {
                                    MessageBox.Show("Hãy gọi kĩ thuật thay connector !", "Thông Báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    lblCount.BackColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    lblCount.BackColor = System.Drawing.Color.FromArgb(242, 247, 236);
                                }
                            }
                            reader.Close();
                        }
                    }
                    else
                    {

                    }
                    if (File.Exists(@"D:\Noise Check Barcode Data\HistoryChangeConnector.txt"))
                    {
                        using (var reader = new StreamReader(@"D:\Noise Check Barcode Data\HistoryChangeConnector.txt"))
                        {
                            string line = "";
                            string[] array = new string[2];
                            array[0] = "-"; array[1] = "-";
                            while ((line = reader.ReadLine()) != null)
                            {
                                array = line.Split(';');
                            }
                            lbldatetime.Text = "- " + array[0].ToString();
                            lblteach.Text = "- " + array[1].ToString();

                            reader.Close();
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(@"D:\Noise Check Barcode Data");
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        
        public void loadMachine()
        {
            try
            {
                ValueObjectList<GA1ModelVo> MachineVo = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new GetMachineNoiseCbm(), new GA1ModelVo() {});
                cmb_Machine.DisplayMember = "Noise_eq_id";
                cmb_Machine.DataSource = MachineVo.GetList();
                cmb_Machine.Text = "";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            try
            {
                string file = DateTime.Now.ToString("yyyyMMdd") + "_InspectionResult.txt";
                if (File.Exists(txtBrowser.Text + "\\" + file))
                {
                    string sourceFile = txtBrowser.Text + "\\" + file;
                    
                    string folderDate = @"D:\Noise Check Barcode Data\"+ DateTime.Now.ToString("yyyyMMdd");

                    if (!Directory.Exists(@"D:\Noise Check Barcode Data\" + folderDate))
                    {
                        Directory.CreateDirectory(folderDate);
                    }

                    string destFile = folderDate + @"\Barcode_" + txtBarcode.Text + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";

                    if (txtBarcode.Text.Length == 8)
                    {
                        //Thread.Sleep(1000);
                        System.IO.File.Move(sourceFile, destFile);

                        if (File.Exists(destFile))
                        {
                            DataTable dt = new DataTable();
                            using (var reader = new StreamReader(destFile))
                            {
                                string[] headers = reader.ReadLine().Split(',');
                                foreach (string header in headers)
                                {
                                    dt.Columns.Add(header);
                                }
                                dt.Columns.Add("barcode");
                                dt.Columns.Add("registration_user_cd");
                                dt.Columns.Add("registration_date_time");
                                dt.Columns.Add("factory_cd");
                                while (!reader.EndOfStream)
                                {
                                    string[] rows = reader.ReadLine().Split(',');
                                    DataRow dr = dt.NewRow();
                                    for (int i = 0; i < headers.Length; i++)
                                    {
                                        dr[i] = rows[i].Trim();

                                        if (i == 2)//cot line
                                        {
                                            dr[i] = "L0" + rows[i].Trim();//neu line < 10
                                            if (rows[i].Trim().Length > 1)//neu line >= 10
                                            {
                                                dr[i] = "L" + rows[i].Trim();
                                            }
                                        }

                                        if (i == 5)
                                        {
                                            dr[i] = rows[i].Substring(1, 4) + "/" + rows[i].Substring(5, 2) + "/" + rows[i].Substring(7, 2) + " " + rows[i].Substring(9, 2) + ":" + rows[i].Substring(11, 2) + ":" + rows[i].Substring(13, 2);
                                        }
                                    }
                                    dr["barcode"] = txtBarcode.Text;
                                    dr["registration_user_cd"] = UserData.GetUserData().UserName;
                                    dr["registration_date_time"] = DateTime.Now.ToString();
                                    dr["factory_cd"] = UserData.GetUserData().FactoryCode; ;
                                    dt.Rows.Add(dr);
                                }
                                reader.Close();
                            }
                            dgvNoise.DataSource = dt;

                            if (dgvNoise.RowCount > 0)
                            {
                                GA1ModelVo NoiseVo = new GA1ModelVo()
                                {
                                    Noise_eq_id = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells["EQ_ID"].Value.ToString(),
                                    Noise_model = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" MODEL"].Value.ToString(),
                                    Noise_line = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" LINE_ID"].Value.ToString(),
                                    Noise_serial_id = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" SERIAL_ID"].Value.ToString(),
                                    Noise_id = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" ID"].Value.ToString(),
                                    Noise_date_check = DateTime.Parse(dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" DATE"].Value.ToString()),
                                    Noise_judgment = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" JUDGMENT"].Value.ToString(),
                                    Noise_l1_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" L1_V_CW"].Value.ToString(),
                                    Noise_l1_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" L1_V_CCW"].Value.ToString(),
                                    Noise_e1_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E1_V_CW"].Value.ToString(),
                                    Noise_e2_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E2_V_CW"].Value.ToString(),
                                    Noise_e3_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E3_V_CW"].Value.ToString(),
                                    Noise_e4_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E4_V_CW"].Value.ToString(),
                                    Noise_e5_v_cw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E5_V_CW"].Value.ToString(),
                                    Noise_e1_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E1_V_CCW"].Value.ToString(),
                                    Noise_e2_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E2_V_CCW"].Value.ToString(),
                                    Noise_e3_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E3_V_CCW"].Value.ToString(),
                                    Noise_e4_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E4_V_CCW"].Value.ToString(),
                                    Noise_e5_v_ccw = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" E5_V_CCW"].Value.ToString(),
                                    Noise_barcode = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells["barcode"].Value.ToString(),
                                    Noise_registration_user_cd = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells["registration_user_cd"].Value.ToString(),
                                    Noise_factory_cd = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells["factory_cd"].Value.ToString(),
                                };

                                GA1ModelVo addNoiseVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new AddGA1ModelNoiseCbm(), NoiseVo);
                                GA1ModelVo updateNoiseVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new UpdateGA1ModelNoiseCbm(), new GA1ModelVo()
                                {
                                    A90Barcode = txtBarcode.Text,
                                    A90NoiseStatus = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" JUDGMENT"].Value.ToString().Substring(0, 2),
                                });
                                int t = updateNoiseVo.AffectedCount;
                                //UpdateGA1ModelNoiseCbm

                                ValueObjectList<GA1ModelVo> ThurtVo = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new SearchThusrtByBarcodeCbm(),
                                    new GA1ModelVo()
                                    {
                                        A90Barcode = txtBarcode.Text,
                                    });
                                if (ThurtVo.GetList().Count == 0)//neu barcode no data o thurst
                                {
                                    lblThurst.Text = "No data";
                                    lblThurst.BackColor = System.Drawing.Color.Yellow;
                                }
                                else //neu barcode CO data o thurst
                                {
                                    lblThurst.Text = ThurtVo.GetList()[0].A90ThurstStatus;
                                    if (lblThurst.Text == "OK") { lblThurst.BackColor = System.Drawing.Color.Green; }
                                    else { lblThurst.BackColor = System.Drawing.Color.Red; }
                                }
                                if (addNoiseVo.AffectedCount == 1)
                                {
                                    MoveFile();
                                    txtBarcode.Clear();
                                    lblNoise.Text = dgvNoise.Rows[dgvNoise.RowCount - 1].Cells[" JUDGMENT"].Value.ToString().Substring(0, 2);
                                    count();
                                    if (lblNoise.Text == "OK") { lblNoise.BackColor = System.Drawing.Color.Green; }
                                    else { lblNoise.BackColor = System.Drawing.Color.Red; }                                    
                                }
                                timerOff.Enabled = true;
                            }
                        }
                    }
                    else // barcode < 8 character
                    {
                        txtBarcode.BackColor = System.Drawing.Color.Red;
                        System.IO.File.Move(sourceFile, destFile);
                        if (File.Exists(destFile))
                        {
                            timerOffBarcodenull.Enabled = true;
                        }
                    }
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        public void count()
        {
            if (File.Exists(@"D:\Noise Check Barcode Data\count.txt"))
            {
                using (var reader = new StreamReader(@"D:\Noise Check Barcode Data\count.txt"))
                {
                    string path = reader.ReadLine();
                    if (!string.IsNullOrEmpty(path))
                    {
                        string text = path;
                        int count = int.Parse(text);
                        //if (count == 2000)
                        //{
                        //    count = 0;
                        //}
                        if (count >= 1899 && count <= 2000)
                        {
                            lblCount.BackColor = System.Drawing.Color.Yellow;
                        }
                        else if (count > 2000)
                        {
                            MessageBox.Show("Hãy gọi kĩ thuật thay connector !", "Thông Báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lblCount.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            lblCount.BackColor = System.Drawing.Color.FromArgb(242, 247, 236);
                        }
                        string textnew = (count + 1).ToString();
                        text = text.Replace(text, textnew);
                        reader.Close();
                        File.WriteAllText(@"D:\Noise Check Barcode Data\count.txt", text);
                        lblCount.Text = textnew;
                    }
                }
            }
            else
            {
                using (FileStream fs = File.Create(@"D:\Noise Check Barcode Data\count.txt"))
                {
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                    fs.Close();
                }

                File.WriteAllText(@"D:\Noise Check Barcode Data\count.txt", "1");
                lblCount.Text = "1";
            }
        }
        private void timerOffBarcodenull_Tick(object sender, EventArgs e)
        {
            txtBarcode.BackColor = System.Drawing.Color.White;
            timerOffBarcodenull.Enabled = false;
        }
        private void timerOff_Tick(object sender, EventArgs e)
        {
            lblThurst.Text = "";
            lblThurst.BackColor = System.Drawing.Color.FromArgb(242, 247, 236);
            lblcountThurst.BackColor = System.Drawing.Color.FromArgb(242, 247, 236);

            lblNoise.Text = "";
            lblNoise.BackColor = System.Drawing.Color.FromArgb(242, 247, 236);
            DataTable dt = new DataTable();
            dgvNoise.DataSource = dt;
            timerOff.Enabled = false;
        }
        private string directorySave = "";
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.SelectedPath = "C:\\";
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                txtBrowser.Text = fl.SelectedPath;
                directorySave = txtBrowser.Text;

                if (!File.Exists(@"D:\Noise Check Barcode Data\login.txt"))
                {
                    using (var fs = File.Create(@"D:\Noise Check Barcode Data\login.txt"))
                    {
                        // Add some text to file    
                        Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                        fs.Write(title, 0, title.Length);
                        fs.Close();
                    }
                }
                else
                {
                    using (var reader = new StreamReader(@"D:\Noise Check Barcode Data\login.txt"))
                    {
                        string[] a = reader.ReadToEnd().Split(';');
                        string mc = "";
                        if (a.Length > 1)
                        {
                            mc = ";" + a[1];
                        }
                        directorySave = txtBrowser.Text + mc;
                        reader.Close();
                    }
                }
                using (var writer = new StreamWriter(@"D:\Noise Check Barcode Data\login.txt"))
                {
                    writer.Write(directorySave);
                    writer.Close();
                }

            }
        }

        private void NoiseCheckForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            timerOff.Enabled = false;
            timerOffBarcodenull.Enabled = false;
        }
        bool sound;
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern int mciSendString(String command,

           StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        private string aliasName = "MediaFile";
        private void soundAlarm()
        {
            string currentDir = System.Environment.CurrentDirectory;
            string fileName = currentDir + @"\warning.mp3";
            string cmd;

            if (sound)
            {
                cmd = "stop " + aliasName;
                mciSendString(cmd, null, 0, IntPtr.Zero);
                cmd = "close " + aliasName;
                mciSendString(cmd, null, 0, IntPtr.Zero);
                sound = false;
            }

            cmd = "open \"" + fileName + "\" type mpegvideo alias " + aliasName;
            if (mciSendString(cmd, null, 0, IntPtr.Zero) != 0) return;
            cmd = "play " + aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
            sound = true;
        }
        public void MoveFile()
        {
            if (Directory.GetDirectories(txtBrowser.Text).Length > 0)
            {
                string datetimeNow = DateTime.Now.ToString("yyyyMMdd");
                string destFilebin = @"D:\Noise Check Barcode Data\Audio\" + DateTime.Now.ToString("yyyy") + @"\" + DateTime.Now.ToString("MM") + @"\" + datetimeNow + @"\" + mc;
                if (!Directory.Exists(destFilebin)) { Directory.CreateDirectory(destFilebin); }

                string destFiledata = @"D:\Noise Check Barcode Data\Data\" + DateTime.Now.ToString("yyyy") + @"\" + DateTime.Now.ToString("MM") + @"\" + datetimeNow + @"\" + mc;
                if (!Directory.Exists(destFiledata)) { Directory.CreateDirectory(destFiledata); }

                string destFiledataServer = @"\\192.168.145.7\noisedata$\" + DateTime.Now.ToString("yyyy") + @"\" + DateTime.Now.ToString("MM") + @"\" + datetimeNow + @"\" + mc;
                if (!Directory.Exists(destFiledataServer)) { Directory.CreateDirectory(destFiledataServer); }

                string folder = Directory.GetDirectories(txtBrowser.Text)[0];
                if (Directory.GetFiles(folder).Length >= 3)
                {
                    foreach (var file in Directory.GetFiles(folder))
                    {
                        string name = Path.GetFileName(file);
                        if (file.Contains("bin"))
                        {
                            File.Move(file, destFilebin + @"\" + txtBarcode.Text + "_" + name);
                        }
                        else if (file.Contains("txt"))
                        {
                            File.Copy(file, destFiledata + @"\" + txtBarcode.Text + "_" + name);
                            File.Move(file, destFiledataServer + @"\" + txtBarcode.Text + "_" + name);
                        }
                    }
                }
                Directory.Delete(folder, true);
            }
        }
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length == 8)
            {
                if (Directory.Exists(txtBrowser.Text)) { Directory.Delete(txtBrowser.Text, true); }
                
                ValueObjectList<GA1ModelVo> ThurtVo = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new SearchThusrtByBarcodeCbm(),
                                    new GA1ModelVo()
                                    {
                                        A90Barcode = txtBarcode.Text,
                                    });
                if (ThurtVo.GetList().Count == 0)
                {
                    lblThurst.Text = "No data";
                    lblThurst.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    GA1ModelVo CountThurtVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchCountThurstCbm(),
                                    new GA1ModelVo()
                                    {
                                        A90Barcode = txtBarcode.Text,
                                    });
                    lblThurst.Text = ThurtVo.GetList()[0].A90ThurstStatus;
                    lblcountThurst.Text = CountThurtVo.AffectedCount.ToString() + " times";
                    if (CountThurtVo.AffectedCount > 20)
                    {
                        lblcountThurst.BackColor = System.Drawing.Color.Yellow;
                    }
                    if (lblThurst.Text == "OK") { lblThurst.BackColor = System.Drawing.Color.Green; }
                    else { lblThurst.BackColor = System.Drawing.Color.Red; }
                }
            }
            else
            {
                lblThurst.Text = "";
                lblThurst.BackColor = System.Drawing.Color.FromArgb(242, 247, 236);
                lblcountThurst.Text = "";
                lblcountThurst.BackColor = System.Drawing.Color.FromArgb(242, 247, 236);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            GrindExport();
            Common.Excel_Class ex = new Common.Excel_Class();

            if (dgv.Rows.Count > 0) { ex.ExportToExcel(dgv); }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, "No Data");
                popUpMessage.Information(messageData, Text);
            }
        }
        public DataTable dgv;
        public void GrindExport()
        {
            try
            {
                dgv = new DataTable();
                GA1ModelVo dgvVo = new GA1ModelVo()
                {
                    DateFrom = DateTime.Parse(dtp_From.Text),
                    DateTo = DateTime.Parse(dtp_To.Text),
                    Noise_eq_id = cmb_Machine.Text
                };

                GA1ModelVo Exportvo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new SearchExportNoiseCbm(), dgvVo);

                dgv = Exportvo.dt;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        public bool apcept;
        private void btnResetCount_Click(object sender, EventArgs e)
        {
            PassForm passform = new PassForm(this);
            passform.ShowDialog();
            if (apcept)
            {
                if (File.Exists(@"D:\Noise Check Barcode Data\count.txt"))
                {
                    using (var writer = new StreamWriter(@"D:\Noise Check Barcode Data\count.txt"))
                    {
                        writer.Write("0");
                        writer.Close();
                        lblCount.Text = "0";
                        lblCount.BackColor = System.Drawing.Color.FromArgb(242, 247, 236);
                    }
                }
                if (File.Exists(@"D:\Noise Check Barcode Data\HistoryChangeConnector.txt"))
                {
                    using (var reader = new StreamReader(@"D:\Noise Check Barcode Data\HistoryChangeConnector.txt"))
                    {
                        string line = "";
                        string[] array = new string[2];
                        array[0] = "-"; array[1] = "-";
                        while ((line = reader.ReadLine()) != null)
                        {
                            array = line.Split(';');
                        }
                        lbldatetime.Text = "- " + array[0].ToString();
                        lblteach.Text = "- " + array[1].ToString();

                        reader.Close();
                    }
                }
            }
        }
    }
}
