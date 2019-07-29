using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.IPQCCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.IPQCForm
{
    public partial class Hioki : FormCommonNCVP
    {
        public delegate void RefreshEventHandler(object sender, EventArgs e);
        public event RefreshEventHandler RefreshEvent;

        private delegate void Delegate_RcvDataToBufferDataTable(string data);

        int vAdr;
        int hAdr;

        DataGridViewButtonColumn Open;

        string command;
        double upp;
        double low;
        DataTable dtBuffer;
        DataTable dtHistory;
        int clmSet = 5;
        int rowSet = 1;
        ValueObjectList<IPQCVo> volist = null;
        IPQCVo vo = null;
        public static readonly string connectionIPQC = "Server=192.168.145.4;Port=5432;UserId=pqm;Password=dbuser;Database=ip_pqmdb;";
        public Hioki()
        {
            InitializeComponent();
        }

        private void frmHioki_Load(object sender, EventArgs e)
        {
            this.Left = 300;
            this.Top = 15;

            dtpSet10daysBefore(dtpLotFrom);

            dtpRoundUpHour(dtpLotTo);

            dtpRounddownHour(dtpLotInput);

            initializePort();

            dtBuffer = new DataTable();
            defineBufferAndHistoryTable(ref dtBuffer);
            dtHistory = new DataTable();
            defineBufferAndHistoryTable(ref dtHistory);
            readDtHistory();
            setLimitSetAndCommand();
            cmbLine.ResetText();
            updateDataGripViews(dtBuffer, dtHistory, ref dgvBuffer, ref dgvHistory);

            addButtonsToDataGridView(dgvHistory);
        }
        public void DisableSortMode(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        public void updateControls(string model, string process, string inspect)
        {
            txtModel.Text = model;
            txtProcess.Text = process;
            txtInspect.Text = inspect;
            txtUser.Text = UserData.GetUserData().UserCode;
            try
            {
                volist = (ValueObjectList<IPQCVo>)DefaultCbmInvoker.Invoke(new GetLineCbm(), new IPQCVo() { Model = model }, connectionIPQC);
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            cmbLine.DisplayMember = "Line";
            BindingSource b1 = new BindingSource(volist.GetList(), null);
            cmbLine.DataSource = b1;
            cmbLine.SelectedIndex = -1;
        }
        private void readDtHistory()
        {
            try
            {
                vo = (IPQCVo)DefaultCbmInvoker.Invoke(new ReadHistoryCbm(), new IPQCVo
                {
                    Model = txtModel.Text,
                    Process = txtProcess.Text,
                    Inspect = txtInspect.Text,
                    Lot = dtpLotFrom.Value,
                    LotLast = dtpLotTo.Value,
                    Line = cmbLine.Text
                }, connectionIPQC);
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            dtHistory = vo.dt;
        }

        private void defineBufferAndHistoryTable(ref DataTable dt)
        {
            dt.Columns.Add("inspect", Type.GetType("System.String"));
            dt.Columns.Add("lot", Type.GetType("System.DateTime"));
            dt.Columns.Add("inspectdate", Type.GetType("System.DateTime"));
            dt.Columns.Add("line", Type.GetType("System.String"));
            dt.Columns.Add("qc_user", Type.GetType("System.String"));
            dt.Columns.Add("status", Type.GetType("System.String"));
            dt.Columns.Add("m1", Type.GetType("System.Double"));
            dt.Columns.Add("m2", Type.GetType("System.Double"));
            dt.Columns.Add("m3", Type.GetType("System.Double"));
            dt.Columns.Add("m4", Type.GetType("System.Double"));
            dt.Columns.Add("m5", Type.GetType("System.Double"));
            dt.Columns.Add("x", Type.GetType("System.Double"));
            dt.Columns.Add("r", Type.GetType("System.Double"));
        }
        private void setLimitSetAndCommand()
        {
            try
            {
                volist = (ValueObjectList<IPQCVo>)DefaultCbmInvoker.Invoke(new GetInfoCbm(), new IPQCVo
                {
                    Model = txtModel.Text,
                    Process = txtProcess.Text,
                    Inspect = txtInspect.Text
                }, connectionIPQC);
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }

            upp = volist.GetList()[0].Upper;
            txtUsl.Text = upp.ToString();
            low = volist.GetList()[0].Lower;
            txtLsl.Text = low.ToString();
            rowSet = volist.GetList()[0].RowSet;
            clmSet = volist.GetList()[0].ClmSet;
        }
        private void updateDataGripViews(DataTable dt1, DataTable dt2, ref DataGridView dgv1, ref DataGridView dgv2)
        {
            dgv1.DataSource = dt1;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgv1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgv1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgv1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgv1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgv1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgv1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DisableSortMode(dgvBuffer);

            dgv2.DataSource = dt2;
            dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DisableSortMode(dgvHistory);

            colorHistoryViewBySpec(dtHistory, ref dgvHistory);
            if (dgv2.Rows.Count >= 1)
                dgv2.FirstDisplayedScrollingRowIndex = dgv2.Rows.Count - 1;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            readDtHistory();
            updateDataGripViews(dtBuffer, dtHistory, ref dgvBuffer, ref dgvHistory);
        }
        private void addButtonsToDataGridView(DataGridView dgv)
        {  
            Open = new DataGridViewButtonColumn();
            Open.Text = "Open";
            Open.UseColumnTextForButtonValue = true;
            Open.Width = 45;
            dgv.Columns.Add(Open);
        }
        private void btnMeasure_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbLine.Text))
            {
                dgvBuffer.Columns[10].ReadOnly = true;
                dgvBuffer.Columns[11].ReadOnly = true;
                btnRegister.Text = "Register";
                dtpLotInput.Enabled = true;

                colorViewReset(ref dgvHistory);
                colorViewReset(ref dgvBuffer);

                dtBuffer.Clear();

                for (int i = 1; i <= rowSet; i++)
                {
                    DataRow dr = dtBuffer.NewRow();
                    dr["inspect"] = txtInspect.Text;
                    dr["lot"] = dtpLotInput.Value;
                    dr["inspectdate"] = DateTime.Now;
                    dr["line"] = cmbLine.Text;
                    dr["qc_user"] = txtUser.Text;
                    dr["status"] = txtStatus.Text;
                    dtBuffer.Rows.Add(dr);
                }

                updateDataGripViews(dtBuffer, dtHistory, ref dgvBuffer, ref dgvHistory);
            }
        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRow = int.Parse(e.RowIndex.ToString());

            if (dgvHistory.Columns[e.ColumnIndex] == Open && curRow >= 0)
            {
                btnRegister.Text = "Update";
                dtpLotInput.Enabled = false;

                dtBuffer.Clear();

                try
                {
                    vo = (IPQCVo)DefaultCbmInvoker.Invoke(new ReadBufferCbm(), new IPQCVo
                    {
                        Model = txtModel.Text,
                        Inspect = dgvHistory["inspect", curRow].Value.ToString(),
                        Lot = (DateTime)dgvHistory["lot", curRow].Value,
                        Inspectdate = (DateTime)dgvHistory["inspectdate", curRow].Value,
                        Line = dgvHistory["line", curRow].Value.ToString()
                    }, connectionIPQC);
                }
                catch (Framework.ApplicationException ex)
                {
                    logger.Error(ex.GetMessageData());
                    popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                    return;
                }
                dtBuffer = vo.dt;

                updateDataGripViews(dtBuffer, dtHistory, ref dgvBuffer, ref dgvHistory);

                if (dgvHistory.Rows.Count >= 1)
                    dgvHistory.FirstDisplayedScrollingRowIndex = curRow;

                colorViewForEdit(ref dgvHistory, curRow);
                colorViewForEdit(ref dgvBuffer, 0);
            }
        }
        private void colorViewForEdit(ref DataGridView dgv, int row)
        {
            if (dgv.Rows.Count == 0) return;

            int rowCount = dgv.RowCount;
            int clmCount = dgv.ColumnCount;
            DateTime inspectdate = (DateTime)dgv["inspectdate", row].Value;

            for (int i = 0; i < rowCount; ++i)
            {
                if ((DateTime)dgv["inspectdate", i].Value == inspectdate)
                {
                    for (int j = 0; j < clmCount; ++j)
                        dgv[j, i].Style.BackColor = Color.Yellow;
                }
                else
                {
                    for (int k = 0; k < clmCount; ++k)
                        dgv[k, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
            }
        }
        private void colorViewReset(ref DataGridView dgv)
        {
            int rowCount = dgv.RowCount;
            int clmCount = dgv.ColumnCount;

            for (int i = 0; i < rowCount; ++i)
            {
                for (int k = 0; k < clmCount; ++k)
                    dgv[k, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
        }
        private void colorHistoryViewBySpec(DataTable dt, ref DataGridView dgv)
        {
            int rowCount = dgv.RowCount;
            int clmStart = 6;
            int clmEnd = 10;

            for (int i = 0; i < rowCount; ++i)
            {
                for (int j = clmStart; j <= clmEnd; ++j)
                {
                    double m = 0;
                    bool b = double.TryParse(dt.Rows[i][j].ToString(), out m);
                    if (m >= low && m <= upp)
                        dgv[j, i].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    else
                        dgv[j, i].Style.BackColor = Color.Red;
                }
            }
        }
        private void colorBufferViewBySpec(double value, ref DataGridView dgv)
        {
            if (value >= low && value <= upp)
                dgv[hAdr, vAdr].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
            else
                dgv[hAdr, vAdr].Style.BackColor = Color.Red;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (dtBuffer.Rows.Count <= 0) return;

            string model = txtModel.Text;
            string process = txtProcess.Text;
            string inspect = txtInspect.Text;
            string status = txtStatus.Text;
            DateTime lot = DateTime.Parse(dtBuffer.Rows[0]["lot"].ToString()); ;
            DateTime inspectdate = DateTime.Parse(dtBuffer.Rows[0]["inspectdate"].ToString()); ;
            string line = cmbLine.Text;

            calculateAverageAndRangeInDataTable(ref dtBuffer);

            bool res;
            try
            {
                vo = (IPQCVo)DefaultCbmInvoker.Invoke(new AddDataCbm(), new IPQCVo
                {
                    Model = model,
                    Process = process,
                    Inspect = inspect,
                    Lot = lot,
                    Inspectdate = inspectdate,
                    Line = line,
                    ins = 1,
                    dt = dtBuffer
                }, connectionIPQC);
                res = true;
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                res = false;
            }

            if (res)
            {
                DataTable dtTemp = new DataTable();
                dtTemp = dtBuffer.Copy();

                dtBuffer.Clear();
                readDtHistory();
                updateDataGripViews(dtBuffer, dtHistory, ref dgvBuffer, ref dgvHistory);

                btnRegister.Text = "Register";
                dtpLotInput.Enabled = true;
            }
        }
        private void calculateAverageAndRangeInDataTable(ref DataTable dt)
        {
            if (dt.Rows.Count == 0) return;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double[] ary = new double[5];
                double max = double.MinValue;
                double min = double.MaxValue;
                double sum = 0;
                double avg = 0;
                int cnt = 0;
                string idx = string.Empty;

                for (int j = 0; j < 5; j++)
                {
                    idx = "m" + (j + 1);
                    if (!string.IsNullOrEmpty(dt.Rows[i][idx].ToString()))
                    {
                        ary[j] = (double)dt.Rows[i][idx];
                        if (max < ary[j]) max = ary[j];
                        if (min > ary[j]) min = ary[j];
                        sum += ary[j];
                        cnt += 1;
                    }
                }
                avg = sum / cnt;
                dt.Rows[i]["x"] = Math.Round(avg, 4);
                dt.Rows[i]["r"] = Math.Abs(max - min);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtBuffer.Rows.Count <= 0) return;

            DialogResult result = MessageBox.Show("Do you really want to delete the selected row?",
                "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                MessageBox.Show("Delete process was canceled.",
                "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            else if (result == DialogResult.Yes)
            {
                try
                {
                    vo = (IPQCVo)DefaultCbmInvoker.Invoke(new AddDataCbm(), new IPQCVo
                    {
                        Model = txtModel.Text,
                        Inspect = txtInspect.Text,
                        Lot = DateTime.Parse(dtBuffer.Rows[0]["lot"].ToString()),
                        Inspectdate = DateTime.Parse(dtBuffer.Rows[0]["inspectdate"].ToString()),
                        Line = cmbLine.Text,
                        ins = 0
                    }, connectionIPQC);
                    messageData = new MessageData("mmci00003", Properties.Resources.mmci00003);
                    popUpMessage.Information(messageData, "Notice");
                }
                catch (Framework.ApplicationException ex)
                {
                    logger.Error(ex.GetMessageData());
                    popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                }

                DataTable dtTemp = new DataTable();
                dtTemp = dtBuffer.Copy();
                dtBuffer.Clear();

                readDtHistory();

                colorViewReset(ref dgvHistory);

                updateDataGripViews(dtBuffer, dtHistory, ref dgvBuffer, ref dgvHistory);

                btnRegister.Text = "Register";
                dtpLotInput.Enabled = true;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen == false) return;

            try
            {
                Thread.Sleep(100);

                string cmd = serialPort1.ReadExisting();
                Invoke(new Delegate_RcvDataToBufferDataTable(RcvDataToBufferDataTable), new Object[] { cmd });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RcvDataToBufferDataTable(string cmd)
        {
            vAdr = dgvBuffer.CurrentCell.RowIndex;
            hAdr = dgvBuffer.CurrentCell.ColumnIndex;

            string replaced = cmd.Replace("\r\n", string.Empty);
            double value = 0;
            double.TryParse(replaced, out value);
            //dtBuffer.Rows[vAdr][hAdr] = value;
            dgvBuffer.Rows[vAdr].Cells[hAdr].Value = value;
            dgvBuffer[hAdr, vAdr].Selected = false;
            dgvBuffer[hAdr + 1, vAdr].Selected = true;
            dgvBuffer.CurrentCell = dgvBuffer.Rows[vAdr].Cells[hAdr + 1];
            //dgvBuffer[hAdr + 1, vAdr]. = true;
            //dgvBuffer[i, j].Selected = true;

            updateDataGripViews(dtBuffer, dtHistory, ref dgvBuffer, ref dgvHistory);

            colorBufferViewBySpec(value, ref dgvBuffer);
        }
        private void initializePort()
        {
            string[] PortList = SerialPort.GetPortNames();

            cmbPortName.Items.Clear();

            foreach (string PortName in PortList)
                cmbPortName.Items.Add(PortName);

            if (cmbPortName.Items.Count > 0)
                cmbPortName.SelectedIndex = 0;
        }
        private void cmbPortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) return;

            serialPort1.PortName = cmbPortName.SelectedItem.ToString();
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Encoding = Encoding.ASCII;

            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmHioki_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }
        private void dtpSet10daysBefore(DateTimePicker dtp)
        {
            DateTime dt = dtp.Value.Date.AddDays(-10);
            dtp.Value = dt;
        }
        private void dtpRoundUpHour(DateTimePicker dtp)
        {
            DateTime dt = dtp.Value;
            int hour = dt.Hour;
            int minute = dt.Minute;
            int second = dt.Second;
            int millisecond = dt.Millisecond;
            dtp.Value = dt.AddHours(1).AddMinutes(-minute).AddSeconds(-second).AddMilliseconds(-millisecond);
        }
        private void dtpRounddownHour(DateTimePicker dtp)
        {
            DateTime dt = dtp.Value;
            int hour = dt.Hour;
            int minute = dt.Minute;
            int second = dt.Second;
            int millisecond = dt.Millisecond;
            dtp.Value = dt.AddMinutes(-minute).AddSeconds(-second).AddMilliseconds(-millisecond);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                vo = (IPQCVo)DefaultCbmInvoker.Invoke(new AddDataCbm(), new IPQCVo
                {
                    Inspect = txtInspect.Text
                }, connectionIPQC);
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
            }
            string sample = vo.Inspect;
            string descrip = vo.Description;
            Excel_Class xl = new Excel_Class();

            string dtpFrom = dtpLotFrom.Value.ToString("yyyy/MM/dd");
            string dtpTo = dtpLotTo.Value.ToString("yyyy/MM/dd");

            xl.exportExcelIPQC(txtModel.Text, cmbLine.Text, txtUser.Text, txtUsl.Text, txtLsl.Text, txtProcess.Text, txtInspect.Text, sample, descrip, dgvHistory, dtpFrom, dtpTo);
        }     
        private DataTable returnXrChartData()
        {
            DataTable dt = new DataTable();
            dt = ((DataTable)dgvHistory.DataSource).Copy();
            dt.Columns.Add("llim", Type.GetType("System.Double"));
            dt.Columns.Add("ulim", Type.GetType("System.Double"));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["llim"] = double.Parse(txtLsl.Text);
                dt.Rows[i]["ulim"] = double.Parse(txtUsl.Text);
            }

            return dt;
        }
        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }
    }
}