using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class MachineForm
    {

        #region Variabless
        private int test;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(MachineForm));

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
        public MachineForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(MachineVo conditionInVo)
        {
            Machine_dgv.DataSource = null;
            isExcelUpload = false;

            try
            {
                MachineVo outVo = (MachineVo)base.InvokeCbm(new GetMachineMasterMntCbm(), conditionInVo, false);

                Machine_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.MachineListVo, null);

                if (bindingSource1.Count > 0)
                {
                    Machine_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //process
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                Machine_dgv.ClearSelection();
                Machine_dgv.Columns["colRemarks"].Visible = false;

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;

                Save_btn.Enabled = false;
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
        private MachineVo FormConditionVo()
        {
            MachineVo inVo = new MachineVo();

            if (MachineCode_txt.Text != string.Empty)
            {
                inVo.MachineCode = MachineCode_txt.Text;
            }

            if (MachineName_txt.Text != string.Empty)
            {
                inVo.MachineName = MachineName_txt.Text;

            }

            return inVo;

        }

        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = Machine_dgv.SelectedCells[0].RowIndex;

            MachineVo selectedData = (MachineVo)Machine_dgv.Rows[selectedrowindex].DataBoundItem;

            AddMachineForm newAddForm = new AddMachineForm(CommonConstants.MODE_UPDATE, selectedData);

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
        private void BindDataSource(List<MachineVo> outVo)
        {
            Machine_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                Machine_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            Machine_dgv.ClearSelection();
        }

        private bool ValidateProcessWorkCodeInExcel(DataTable excelUploadData, string machineCode)
        {
            if (processWorkList.Count == 0)
            {
                GetProcessWork();
            }

            bool IsProcessWorkCodeValid = false;

            DataRow[] processWorkCodeList = excelUploadDt.Select("MachineCode = '" + machineCode + "'");

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
        /// form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessForm_Load(object sender, EventArgs e)
        {
            Save_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;
            MachineCode_txt.Select();
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
           MachineCode_txt.Text = string.Empty;

            MachineName_txt.Text = string.Empty;

            Machine_dgv.DataSource = null;

            Save_btn.Enabled = Delete_btn.Enabled = Update_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            AddMachineForm newAddForm = new AddMachineForm(CommonConstants.MODE_ADD, null);

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

            BindUpdateUserData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (isExcelUpload) return;

            int selectedrowindex = Machine_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = Machine_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colMachineCode"].Value.ToString());
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                MachineVo inVo = new MachineVo
                {
                    MachineId = Convert.ToInt32(selectedRow.Cells["colMachineId"].Value),
                };

                try
                {
                    MachineVo outVo = (MachineVo)base.InvokeCbm(new DeleteMachineMasterAndProcessworkCbm(), inVo, false);

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
            this.Close();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Process_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Machine_dgv.SelectedCells.Count > 0 && isExcelUpload == false)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles update user form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Process_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Machine_dgv.SelectedCells.Count > 0 && isExcelUpload == false)
            {
                BindUpdateUserData();
            }
        }



        private void Machine_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = Machine_dgv.Columns[e.ColumnIndex];

            if (isExcelUpload) { return; }
            if (Machine_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)Machine_dgv.DataSource;

            List<MachineVo> dataSourceVo = (List<MachineVo>)currentDatagridSource.DataSource;

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
                Machine_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
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
                    excelUploadDt = new ExcelUpload().ReadExcel(openDialog_dlg.FileName, Properties.Settings.Default.EXCEL_SHEET_MACHINE_MASTER);
                }
                catch (Framework.ApplicationException exception)
                {
                    this.CompleteProgress();
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }

                MachineVo machineVo = new MachineVo();

                ProcessWorkMachineVo processWorkMachineVo = new ProcessWorkMachineVo();

                Machine_dgv.DataSource = null;
                excelUploadDt.Columns.Add("Remarks");
                var sch = StringCheckHelper.GetInstance();
                bool inputDataNG = false;

                foreach (DataRow row in excelUploadDt.Rows)
                {
                    if (row["MachineCode"] == null || string.IsNullOrWhiteSpace(row["MachineCode"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00011, MachineCode_lbl.Text);
                        inputDataNG = true;
                        continue;
                    }

                    if (!sch.IsASCII(row["MachineCode"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmci00017, MachineCode_lbl.Text);
                        inputDataNG = true;
                        continue;
                    }

                    if (row["MachineName"] == null || string.IsNullOrWhiteSpace(row["MachineName"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00011, MachineName_lbl.Text);
                        inputDataNG = true;
                        continue;
                    }

                    var duplicates = excelUploadDt.AsEnumerable().GroupBy(r => r["MachineCode"]).Where(gr => gr.Count() > 1).ToList();

                    if (duplicates.Any() && duplicates.Select(dupl => dupl.Key).ToList().FirstOrDefault().ToString() == row["MachineCode"].ToString())
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00009, MachineCode_lbl.Text + " : " + row["MachineCode"].ToString());
                        inputDataNG = true;
                        continue;
                    }

                    machineVo = new MachineVo();
                    processWorkMachineVo = new ProcessWorkMachineVo();

                    machineVo.MachineCode = row["MachineCode"].ToString();
                    machineVo.MachineName = row["MachineName"].ToString();
                    if (!ValidateProcessWorkCodeInExcel(excelUploadDt, machineVo.MachineCode))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmci00019);
                        inputDataNG = true;
                        continue;
                    }

                    MachineVo checkVo = DuplicateCheck(machineVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00012, MachineCode_lbl.Text + " : " + machineVo.MachineCode);
                        inputDataNG = true;
                        continue;
                    }
                }

                Machine_dgv.AutoGenerateColumns = false;
                isExcelUpload = true;
                Machine_dgv.Columns["colRemarks"].Visible = true;
                Machine_dgv.DataSource = excelUploadDt;

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
        private MachineVo DuplicateCheck(MachineVo pMachineVo)
        {
            MachineVo outVo = new MachineVo();

            try
            {
                outVo = (MachineVo)base.InvokeCbm(new CheckMachineMasterMntCbm(), pMachineVo, false);
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
            string templateFileName = Application.StartupPath + "\\" + Properties.Settings.Default.TEMPLATE_FILE_MACHINE;
            if (!File.Exists(templateFileName))
            {
                messageData = new MessageData("mmci00011", Properties.Resources.mmci00011, Properties.Settings.Default.TEMPLATE_FILE_MACHINE);
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
                    messageData = new MessageData("mmci00021", Properties.Resources.mmci00021, Properties.Settings.Default.TEMPLATE_FILE_MACHINE);
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

                //ExportExcelProcess excelProcess = new ExportExcelProcess();

                //excelProcess.DownloadExcel(saveDialog_dlg.FileName, Properties.Settings.Default.EXCEL_SHEET_MACHINE_MASTER);

                //this.CompleteProgress();
            }

        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (Machine_dgv.RowCount > 0 && Machine_dgv.Columns["colRemarks"].Visible == true)
            {
                if (processWorkList.Count == 0)
                {
                    GetProcessWork();
                }

                this.StartProgress(Properties.Resources.mmci00009);

                string previousMachineCode = string.Empty;
                int uploadedCount = 0;
                int insertedCount = 0;

                MachineVo machineVo = new MachineVo();

                ProcessWorkMachineVo processWorkMachineVo = new ProcessWorkMachineVo();

                foreach (DataRow row in excelUploadDt.Rows)
                {
                    if (!string.IsNullOrEmpty(row["MachineCode"].ToString()) && previousMachineCode != row["MachineCode"].ToString())
                    {
                        machineVo = new MachineVo();

                        processWorkMachineVo = new ProcessWorkMachineVo();

                        machineVo.MachineCode = row["MachineCode"].ToString();
                        machineVo.MachineName = row["MachineName"].ToString();

                        uploadedCount += 1;

                        DataRow[] processWorkCodeList = excelUploadDt.Select("MachineCode = '" + machineVo.MachineCode + "'");

                        foreach (DataRow item in processWorkCodeList)
                        {
                            ProcessWorkMachineVo addVo = new ProcessWorkMachineVo();

                            if (processWorkList.Where(t => t.ProcessWorkCode == item["ProcessWorkCode"].ToString()).FirstOrDefault() != null)
                            {
                                addVo.ProcessWorkId = processWorkList.Where(t => t.ProcessWorkCode == item["ProcessWorkCode"].ToString()).FirstOrDefault().ProcessWorkId;
                                processWorkMachineVo.ProcessWorkMachineListVo.Add(addVo);
                            }
                        }

                        ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();

                        inVoList.add(machineVo);
                        inVoList.add(processWorkMachineVo);

                        MachineVo outVo = null;

                        try
                        {
                            outVo = (MachineVo)base.InvokeCbm(new AddMachineMasterAndProcessworkCbm(), inVoList, false);
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

                    previousMachineCode = row["MachineCode"].ToString();

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
