using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.IPQCCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.IPQCForm
{
    public partial class Manual : FormCommonNCVP
    {
        public delegate void RefreshEventHandler(object sender, EventArgs e);
        public event RefreshEventHandler RefreshEvent;

        private delegate void Delegate_RcvDataToBufferDataTable(string data);

        int vAdr;
        int hAdr;

        DataGridViewButtonColumn Open;

        string command, instrument;
        double upp;
        double low;
        DataTable dtBuffer;
        DataTable dtHistory;
        int clmSet = 5;
        int rowSet = 1;
        ValueObjectList<IPQCVo> volist = null;
        IPQCVo vo = null;
        public static readonly string connectionIPQC = "Server=192.168.145.4;Port=5432;UserId=pqm;Password=dbuser;Database=ip_pqmdb;";

        public Manual()
        {
            InitializeComponent();
        }

        private void frmManual_Load(object sender, EventArgs e)
        {
            this.Left = 300;
            this.Top = 15;

            dtpSet10daysBefore(dtpLotFrom);

            dtpRoundUpHour(dtpLotTo);

            dtpRounddownHour(dtpLotInput);

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            readDtHistory();
            updateDataGripViews(dtBuffer, dtHistory, ref dgvBuffer, ref dgvHistory);
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
            instrument = volist.GetList()[0].Instrument;
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
            btnRegister.Text = "Register";
            dtpLotInput.Enabled = true;

            colorViewReset(ref dgvHistory);
            colorViewReset(ref dgvBuffer);

            dtBuffer.Clear();

            int rowSet2;
            List<string> list1 = new List<string> { "BRAKET05", "CASE07" };
            bool specialItem = txtInspect.Text == "METALSLOP";
            if (list1.Contains(txtInspect.Text))
            {
                rowSet2 = 3;

                for (int i = 1; i <= rowSet2; i++)
                {
                    DataRow dr = dtBuffer.NewRow();
                    dr["inspect"] = txtInspect.Text;
                    dr["lot"] = dtpLotInput.Value;
                    dr["inspectdate"] = DateTime.Now;
                    dr["line"] = cmbLine.Text;
                    dr["qc_user"] = txtUser.Text;
                    dr["status"] = txtStatus.Text;

                    if (i == 1) dr["qc_user"] = "1. Upper";
                    else if (i == 2) dr["qc_user"] = "2. Lower";
                    else if (i == 3) dr["qc_user"] = txtUser.Text;

                    dtBuffer.Rows.Add(dr);
                }
            }
            else if (specialItem)
            {
                rowSet2 = 5;

                for (int i = 1; i <= rowSet2; i++)
                {
                    DataRow dr = dtBuffer.NewRow();
                    dr["inspect"] = txtInspect.Text;
                    dr["lot"] = dtpLotInput.Value;
                    dr["inspectdate"] = DateTime.Now;
                    dr["line"] = cmbLine.Text;
                    dr["qc_user"] = txtUser.Text;
                    dr["status"] = txtStatus.Text;
                    if (specialItem && i == 1) dr["qc_user"] = "Point 1";
                    else if (specialItem && i == 2) dr["qc_user"] = "Point 2";
                    else if (specialItem && i == 3) dr["qc_user"] = "Point 3";
                    else if (specialItem && i == 4) dr["qc_user"] = "Point 4";
                    else if (specialItem && i == 5) dr["qc_user"] = txtUser.Text;

                    dtBuffer.Rows.Add(dr);
                }
            }
            else
            {
                rowSet2 = rowSet;

                for (int i = 1; i <= rowSet2; i++)
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
            }

            updateDataGripViews(dtBuffer, dtHistory, ref dgvBuffer, ref dgvHistory);
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

        // サブプロシージャ：編集中の行をマーキングする
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

        // サブプロシージャ：マーキングをクリアする
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

        // サブプロシージャ：スペック外のセルをマーキングする（履歴テーブル）
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

        // 編集完了時、スペック外のセルをマーキングする（一時テーブル）
        private void dgvBuffer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            List<string> list2 = new List<string> { "BRAKET05", "CASE07" };
            if (txtInspect.Text == "METALSLOP")
            {
                if (dgv[e.ColumnIndex, 0].Value.ToString() != string.Empty &&
                        dgv[e.ColumnIndex, 1].Value.ToString() != string.Empty &&
                        dgv[e.ColumnIndex, 2].Value.ToString() != string.Empty &&
                        dgv[e.ColumnIndex, 3].Value.ToString() != string.Empty)
                {
                    double min, max;
                    int i;
                    double d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0;
                    double.TryParse(dgv[e.ColumnIndex, 0].Value.ToString(), out d1);
                    double.TryParse(dgv[e.ColumnIndex, 1].Value.ToString(), out d2);
                    double.TryParse(dgv[e.ColumnIndex, 2].Value.ToString(), out d3);
                    double.TryParse(dgv[e.ColumnIndex, 3].Value.ToString(), out d4);
                    double[] mang = new double[] { d1, d2, d3, d4 };

                    min = max = mang[0];

                    for (i = 0; i <= 3; i++)
                    {
                        if (min > mang[i]) min = mang[i];
                        if (max < mang[i]) max = mang[i];
                    }
                    d5 = Math.Round(Math.Abs(max - min), 4);
                    dgv[e.ColumnIndex, 4].Value = d5;

                    if (d5 >= low && d5 <= upp)
                        dgv[e.ColumnIndex, 4].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    else
                        dgv[e.ColumnIndex, 4].Style.BackColor = Color.Red;
                }
            }
            else if (list2.Contains(txtInspect.Text))
            {
                if (dgv[e.ColumnIndex, 0].Value.ToString() != string.Empty &&
                        dgv[e.ColumnIndex, 1].Value.ToString() != string.Empty)
                {
                    double d1 = 0, d2 = 0, d3 = 0;
                    double.TryParse(dgv[e.ColumnIndex, 0].Value.ToString(), out d1);
                    double.TryParse(dgv[e.ColumnIndex, 1].Value.ToString(), out d2);

                    d3 = Math.Round(Math.Abs(d1 - d2), 4);
                    dgv[e.ColumnIndex, 2].Value = d3;

                    if (d3 >= low && d3 <= upp)
                        dgv[e.ColumnIndex, 2].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    else
                        dgv[e.ColumnIndex, 2].Style.BackColor = Color.Red;
                }
            }
            else
            {
                double d = 0;
                double.TryParse(dgv[e.ColumnIndex, e.RowIndex].Value.ToString(), out d);

                if (d >= low && d <= upp)
                    dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                else
                    dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
            }
        }
            

        // 測定値の列のみ編集可能とする
        private void dgvBuffer_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            List<string> list2 = new List<string> { "BRAKET05", "CASE07" };
            //編集できるか判断する（特定の検査項目は、ＵＰＰＥＲ・ＬＯＷＥＲ・差異を入力、差異は直接入力不可）
            if (e.ColumnIndex <= 5 || e.ColumnIndex >= 11 || (txtInspect.Text == "METALSLOP" && e.RowIndex == 5) || (list2.Contains(txtInspect.Text) && e.RowIndex == 3))
            {
                //編集できないようにする
                e.Cancel = true;
            }
        }

        // 測定値の取り込みが終わったら、データベースへ登録する
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

        // サブプロシージャ: データテーブル内部で、平均とレンジ（最大－最小）を求め、格納する
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

        // 削除ボタン押下時の処理
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

        // サブサブプロシージャ：ＤＡＴＥＴＩＭＥＰＩＣＫＥＲの分以下を下げる
        private void dtpRounddownHour(DateTimePicker dtp)
        {
            DateTime dt = dtp.Value;
            int hour = dt.Hour;
            int minute = dt.Minute;
            int second = dt.Second;
            int millisecond = dt.Millisecond;
            dtp.Value = dt.AddMinutes(-minute).AddSeconds(-second).AddMilliseconds(-millisecond);
        }

        // ＸＲグラフ作成ボタン押下時の処理     
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

        // サブサブプロシージャ：ＸＲ管理図用データテーブルの生成      
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