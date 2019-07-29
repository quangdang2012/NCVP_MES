using System;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class LineRestTimeForm
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(LineRestTimeForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;


        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        /// <summary>
        /// processWorkList
        /// </summary>
        private List<ProcessWorkVo> processWorkList = new List<ProcessWorkVo>();

        /// <summary>
        /// excel upload check
        /// </summary>
        private bool isExcelUpload = false;

        /// <summary>
        /// excel upload data
        /// </summary>
        private DataTable excelUploadDt = new DataTable();

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public LineRestTimeForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(LineVo conditionInVo)
        {
            LineDetails_dgv.DataSource = null;
            isExcelUpload = false;

            try
            {
                LineVo outVo = (LineVo)base.InvokeCbm(new GetLineMasterMntCbm(), conditionInVo, false);

                LineDetails_dgv.AutoGenerateColumns = false;

                BindingSource lineBindingSource = new BindingSource(outVo.LineListVo, null);

                if (lineBindingSource.Count > 0)
                {
                    LineDetails_dgv.DataSource = lineBindingSource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }

                LineDetails_dgv.ClearSelection();
                LineDetails_dgv.Columns["colRemarks"].Visible = false;

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;

                Save_btn.Enabled = false;

                DownloadExcel_btn.Enabled = true;

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private LineVo FormConditionVo()
        {
            LineVo inVo = new LineVo();


            if (LineCode_txt.Text != string.Empty)
            {
                inVo.LineCode = LineCode_txt.Text;
            }

            if (LineName_txt.Text != string.Empty)
            {
                inVo.LineName = LineName_txt.Text;
            }

            return inVo;
        }

        /// <summary>
        /// selects user record for updation and show Line form
        /// </summary>
        private void BindUpdateLineData()
        {
            int selectedrowindex = LineDetails_dgv.SelectedCells[0].RowIndex;

            LineVo selectedLine = (LineVo)LineDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddLineRestTimeForm newAddForm = new AddLineRestTimeForm(CommonConstants.MODE_UPDATE, selectedLine);

            newAddForm.ShowDialog(this);

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
            else if (newAddForm.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<LineVo> outVo)
        {
            LineDetails_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                LineDetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            LineDetails_dgv.ClearSelection();
        }

        private bool ValidateProcessWorkCodeInExcel(DataTable excelUploadData, string lineCode)
        {
            if (processWorkList.Count == 0)
            {
                GetProcessWork();
            }

            bool IsProcessWorkCodeValid = false;

            DataRow[] processWorkCodeList = excelUploadDt.Select("LineCode = '" + lineCode + "'");

            foreach (DataRow item in processWorkCodeList)
            {
                if (processWorkList.Where(t => t.ProcessWorkCode == item["ProcessWorkCode"].ToString()).FirstOrDefault() != null)
                {
                    IsProcessWorkCodeValid = true;
                }
            }

            return IsProcessWorkCodeValid;
        }

        #endregion

        #region FormEvents
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineRestTimeForm_Load(object sender, EventArgs e)
        {
            Save_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;
            LineCode_txt.Select();
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            LineCode_txt.Text = string.Empty;
            LineName_txt.Text = string.Empty;
            LineDetails_dgv.DataSource = null;
            Save_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = DownloadExcel_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddLineRestTimeForm newAddForm = new AddLineRestTimeForm(CommonConstants.MODE_ADD, null);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// event to open the  updatescreen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (isExcelUpload) return;

            BindUpdateLineData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (isExcelUpload) return;

            int selectedrowindex = LineDetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = LineDetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colLineName"].Value.ToString());
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                LineVo inVo = new LineVo
                {
                    LineId = Convert.ToInt32(selectedRow.Cells["colLineId"].Value)
                };

                try
                {
                    LineVo outVo = (LineVo)base.InvokeCbm(new DeleteLineMasterAndProcessworkCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                        GridBind(FormConditionVo());
                    }
                    else if (outVo.AffectedCount == 0)
                    {
                        messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        GridBind(FormConditionVo());
                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //do something else
            }
        }

        /// <summary>
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles factory record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LineDetails_dgv.SelectedCells.Count > 0 && isExcelUpload == false)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles update factory form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LineDetails_dgv.SelectedCells.Count > 0 && isExcelUpload == false)
            {
                BindUpdateLineData();
            }
        }

        private void LineDetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = LineDetails_dgv.Columns[e.ColumnIndex];

            if (isExcelUpload) { return; }
            if (LineDetails_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)LineDetails_dgv.DataSource;

            List<LineVo> dataSourceVo = (List<LineVo>)currentDatagridSource.DataSource;

            if (!string.IsNullOrEmpty(column.DataPropertyName) && dataSourceVo.Count > 0 &&
                                                   column.CellType != typeof(DataGridViewButtonCell))
            {
                switch (sortDirection)
                {
                    case SortOrder.None:
                        sortDirection = SortOrder.Ascending;
                        break;
                    case SortOrder.Ascending:
                        sortDirection = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        sortDirection = SortOrder.Ascending;
                        break;
                }

                if (sortDirection == SortOrder.Ascending)
                {
                    dataSourceVo = dataSourceVo.OrderBy(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
                }
                else if (sortDirection == SortOrder.Descending)
                {
                    dataSourceVo = dataSourceVo.OrderByDescending(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
                }

                BindDataSource(dataSourceVo);
                LineDetails_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        #endregion

        private void Upload_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog_dlg = new OpenFileDialog();

            openDialog_dlg.Filter = "Excel Files(*.xls) |*.xls";

            if (openDialog_dlg.ShowDialog() == DialogResult.OK)
            {
                this.StartProgress(Properties.Resources.mmci00009);

                try
                {
                    excelUploadDt = new ExcelUpload().ReadExcel(openDialog_dlg.FileName, Properties.Settings.Default.EXCEL_SHEET_LINE_MASTER);
                }
                catch (Framework.ApplicationException exception)
                {
                    this.CompleteProgress();
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }

                LineVo lineVo = new LineVo();

                ProcessWorkLineVo processWorkLineVo = new ProcessWorkLineVo();

                LineDetails_dgv.DataSource = null;
                excelUploadDt.Columns.Add("Remarks");
                var sch = StringCheckHelper.GetInstance();
                bool inputDataNG = false;

                foreach (DataRow row in excelUploadDt.Rows)
                {
                    if (row["LineCode"] == null || string.IsNullOrWhiteSpace(row["LineCode"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00011, LineCode_lbl.Text);
                        inputDataNG = true;
                        continue;
                    }

                    if (!sch.IsASCII(row["LineCode"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmci00017, LineCode_lbl.Text);
                        inputDataNG = true;
                        continue;
                    }

                    if (row["LineName"] == null || string.IsNullOrWhiteSpace(row["LineName"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00011, LineName_lbl.Text);
                        inputDataNG = true;
                        continue;
                    }

                    lineVo = new LineVo();
                    processWorkLineVo = new ProcessWorkLineVo();

                    lineVo.LineCode = row["LineCode"].ToString();
                    lineVo.LineName = row["LineName"].ToString();

                    if (!ValidateProcessWorkCodeInExcel(excelUploadDt, lineVo.LineCode))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmci00019);
                        inputDataNG = true;
                        continue;
                    }

                    LineVo checkVo = DuplicateCheck(lineVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00012, LineCode_lbl.Text + " : " + lineVo.LineCode);
                        inputDataNG = true;
                        continue;
                    }

                    var duplicates = excelUploadDt.AsEnumerable().GroupBy(r => r["LineCode"]).Where(gr => gr.Count() > 1).ToList();

                    if (duplicates.Any() && duplicates.Select(dupl => dupl.Key).ToList().FirstOrDefault().ToString() == row["LineCode"].ToString())
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00009, LineCode_lbl.Text + " : " + row["LineCode"].ToString());
                        inputDataNG = true;
                        continue;
                    }
                }

                LineDetails_dgv.AutoGenerateColumns = false;
                isExcelUpload = true;
                LineDetails_dgv.Columns["colRemarks"].Visible = true;
                LineDetails_dgv.DataSource = excelUploadDt;

                if (inputDataNG)
                {
                    Save_btn.Enabled = false;
                }
                else
                {
                    Save_btn.Enabled = true;
                }

                this.CompleteProgress();
                
            }
        }

        /// <summary>
        /// Loads processwork
        /// </summary>
        private void GetProcessWork()
        {
            try
            {
                ProcessWorkVo outVo = null;

                outVo = (ProcessWorkVo)DefaultCbmInvoker.Invoke(new GetProcessWorkMasterMntCbm(), new ProcessWorkVo());

                if (outVo != null && outVo.ProcessWorkListVo.Count > 0)
                {
                    processWorkList = outVo.ProcessWorkListVo;
                }

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Check for duplicate
        /// </summary>
        /// <returns></returns>
        private LineVo DuplicateCheck(LineVo pLineVo)
        {
            LineVo outVo = new LineVo();

            try
            {
                outVo = (LineVo)base.InvokeCbm(new CheckLineMasterMntCbm(), pLineVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            return outVo;
        }

        private void DownloadExcel_btn_Click(object sender, EventArgs e)
        {
            //string templateFileName = Application.StartupPath + "\\" + Properties.Settings.Default.TEMPLATE_FILE_MASTER;
            string templateFileName = Application.StartupPath + "\\" + Properties.Settings.Default.TEMPLATE_FILE_LINE;
            if (!File.Exists(templateFileName))
            {
                messageData = new MessageData("mmci00011", Properties.Resources.mmci00011, Properties.Settings.Default.TEMPLATE_FILE_LINE);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                return;
            }

            SaveFileDialog saveDialog_dlg = new SaveFileDialog();

            saveDialog_dlg.Filter = "Excel Files(*.xls) |*.xls";

            if (saveDialog_dlg.ShowDialog() == DialogResult.OK)
            {
                //this.StartProgress(Properties.Resources.mmci00009);

                try
                {
                    File.Copy(templateFileName, saveDialog_dlg.FileName, true);
                    messageData = new MessageData("mmci00021", Properties.Resources.mmci00021, Properties.Settings.Default.TEMPLATE_FILE_LINE);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                catch (IOException copyError)
                {
                    this.CompleteProgress();
                    messageData = new MessageData("mmcc00001", Properties.Resources.mmcc00001, copyError.Message);
                    popUpMessage.ApplicationError(messageData, Text);
                    logger.Error(messageData);
                    return;
                }

                ExportExcelProcess excelProcess = new ExportExcelProcess();

                excelProcess.DownloadExcel(saveDialog_dlg.FileName, Properties.Settings.Default.EXCEL_SHEET_LINE_MASTER);

                this.CompleteProgress();
            }

        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (LineDetails_dgv.RowCount > 0 && LineDetails_dgv.Columns["colRemarks"].Visible == true)
            {
                if (processWorkList.Count == 0)
                {
                    GetProcessWork();
                }

                this.StartProgress(Properties.Resources.mmci00009);
                string previousLineCode = string.Empty;
                int uploadedCount = 0;
                int insertedCount = 0;

                LineVo lineVo = new LineVo();

                ProcessWorkLineVo processWorkLineVo = new ProcessWorkLineVo();



                foreach (DataRow row in excelUploadDt.Rows)
                {
                    if (!string.IsNullOrEmpty(row["LineCode"].ToString()) && previousLineCode != row["LineCode"].ToString())
                    {
                        lineVo = new LineVo();
                        processWorkLineVo = new ProcessWorkLineVo();

                        lineVo.LineCode = row["LineCode"].ToString();
                        lineVo.LineName = row["LineName"].ToString();

                        uploadedCount += 1;

                        DataRow[] processWorkCodeList = excelUploadDt.Select("LineCode = '" + lineVo.LineCode + "'");

                        foreach (DataRow item in processWorkCodeList)
                        {
                            ProcessWorkLineVo addVo = new ProcessWorkLineVo();
                            ProcessWorkVo processWorkVo = processWorkList.Where(t => t.ProcessWorkCode == item["ProcessWorkCode"].ToString()).FirstOrDefault();

                            if (processWorkVo != null && processWorkVo.ProcessWorkId > 0)
                            {
                                addVo.ProcessWorkId = processWorkVo.ProcessWorkId;
                                processWorkLineVo.ProcessWorkLineListVo.Add(addVo);
                            }
                        }

                        ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();

                        inVoList.add(lineVo);
                        inVoList.add(processWorkLineVo);

                        LineVo outVo = null;

                        try
                        {
                            outVo = (LineVo)base.InvokeCbm(new AddLineMasterAndProcessworkCbm(), inVoList, false);
                        }
                        catch (Framework.ApplicationException exception)
                        {
                            this.CompleteProgress();
                            popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                            logger.Error(exception.GetMessageData());
                            return;
                        }

                        if (outVo != null && outVo.AffectedCount > 0)
                        {
                            insertedCount += outVo.AffectedCount;
                        }
                    }

                    previousLineCode = row["LineCode"].ToString();
                }

                this.CompleteProgress();

                if (insertedCount > 0 && uploadedCount > 0 && insertedCount == uploadedCount)
                {
                    messageData = new MessageData("mmci00010", Properties.Resources.mmci00010, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    GridBind(FormConditionVo());
                }

            }
            else
            {
                messageData = new MessageData("mmci00016", Properties.Resources.mmci00016, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }


        }
    }
}
