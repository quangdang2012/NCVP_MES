using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.IO;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class MoldForm
    {
        #region Variables

        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable moldTypeDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(MoldForm));

        /// <summary>
        /// processWorkList
        /// </summary>
        private List<ProcessWorkVo> processWorkList = new List<ProcessWorkVo>();

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// Cavity
        /// </summary>
        private const string CAVITY = "CAVITY";

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

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
        public MoldForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(MoldVo conditionInVo)
        {
            Mold_dgv.DataSource = null;
            isExcelUpload = false;

            try
            {
                MoldVo outVo = (MoldVo)base.InvokeCbm(new GetMoldMasterMntCbm(), conditionInVo, false);

                Mold_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.MoldListVo, null);

                if (bindingSource1.Count > 0)
                {
                    Mold_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"mold"
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                Mold_dgv.ClearSelection();
                Mold_dgv.Columns["colRemarks"].Visible = false;

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
        private MoldVo FormConditionVo()
        {
            MoldVo inVo = new MoldVo();

            if (MoldCode_txt.Text != string.Empty) { inVo.MoldCode = MoldCode_txt.Text; }

            if (MoldName_txt.Text != string.Empty)
            {
                inVo.MoldName = MoldName_txt.Text;
            }

            if (MoldType_cmb.SelectedIndex > -1)
            {
                inVo.MoldTypeId = Convert.ToInt32(MoldType_cmb.SelectedValue);
            }

            return inVo;

        }


        /// <summary>
        /// Handles Combobox loading for Item
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind(ComboBox pCombo, DataTable pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = Mold_dgv.SelectedCells[0].RowIndex;

            MoldVo selectedMold = (MoldVo)Mold_dgv.Rows[selectedrowindex].DataBoundItem;

            AddMoldForm newAddForm = new AddMoldForm();

            newAddForm.CreateForm(CommonConstants.MODE_UPDATE, selectedMold);

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
        private void BindDataSource(List<MoldVo> outVo)
        {
            Mold_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                Mold_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            Mold_dgv.ClearSelection();
        }


        /// <summary>
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            moldTypeDatatable = new DataTable();
            moldTypeDatatable.Columns.Add("id");
            moldTypeDatatable.Columns.Add("code");

            try
            {
                MoldTypeVo moldTypeOutVo = (MoldTypeVo)base.InvokeCbm(new GetMoldTypeMasterMntCbm(), new MoldTypeVo(), false);

                foreach (MoldTypeVo moldType in moldTypeOutVo.MoldTypeListVo)
                {
                    moldTypeDatatable.Rows.Add(moldType.MoldTypeId, moldType.MoldTypeCode);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }


        /// <summary>
        /// checks mold relation to other tables in DB
        /// </summary>
        /// <param name="moVo"></param>
        /// <returns></returns>
        private MoldVo CheckRelation(MoldVo moVo)
        {
            MoldVo outVo = new MoldVo();

            try
            {
                outVo = (MoldVo)base.InvokeCbm(new CheckMoldRelationCbm(), moVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
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
        /// checks duplicate mold Code
        /// </summary>
        /// <returns></returns>
        private MoldVo DuplicateCheck(MoldVo checkInVo)
        {
            MoldVo outVo = new MoldVo();

            try
            {
                outVo = (MoldVo)base.InvokeCbm(new CheckMoldMasterMntCbm(), checkInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            return outVo;
        }

        private bool ValidateProcessWorkCodeInExcel(DataTable excelUploadData, string moldCode)
        {
            if (processWorkList.Count == 0)
            {
                GetProcessWork();
            }

            bool IsProcessWorkCodeValid = false;

            DataRow[] processWorkCodeList = excelUploadDt.Select("MoldCode = '" + moldCode + "'");

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
        /// Loads Mold form
        /// Fill item combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoldForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                FormDatatableFromVo();

                ComboBind(MoldType_cmb, moldTypeDatatable, "code", "id");

                MoldCode_txt.Select();

                Save_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Clear_btn_Click(object sender, EventArgs e)
        {
            MoldCode_txt.Text = string.Empty;

            MoldName_txt.Text = string.Empty;

            MoldType_cmb.SelectedIndex = -1;

            Mold_dgv.DataSource = null;

            MoldCode_txt.Select();
            Save_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Add_btn_Click(object sender, EventArgs e)
        {
            AddMoldForm newAddForm = new AddMoldForm();
            newAddForm.CreateForm(CommonConstants.MODE_ADD, null);

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
        protected virtual void Update_btn_Click(object sender, EventArgs e)
        {
            if (isExcelUpload) return;

            BindUpdateUserData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Delete_btn_Click(object sender, EventArgs e)
        {
            if (isExcelUpload) return;

            int selectedrowindex = Mold_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = Mold_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colMoldCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                MoldVo inVo = new MoldVo
                {
                    MoldId = Convert.ToInt32(selectedRow.Cells["colMoldId"].Value),
                    RegistrationDateTime = Convert.ToDateTime(DateTime.Now.ToString(UserData.GetUserData().DateTimeFormat)),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    MoldCode = selectedRow.Cells["colMoldCode"].Value.ToString()
                };

                try
                {
                    MoldVo checkVo = CheckRelation(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, CAVITY.ToString());
                        popUpMessage.Information(messageData, Text);
                        return;
                    }

                    MoldVo outVo = (MoldVo)base.InvokeCbm(new DeleteMoldMasterMntCbm(), inVo, false);

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
        /// Upload mold master excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Upload_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog_dlg = new OpenFileDialog();

            openDialog_dlg.Filter = "Excel Files(*.xls) |*.xls";

            if (openDialog_dlg.ShowDialog() == DialogResult.OK)
            {
                this.StartProgress(Properties.Resources.mmci00009);

                try
                {
                    excelUploadDt = new ExcelUpload().ReadExcel(openDialog_dlg.FileName, Properties.Settings.Default.EXCEL_SHEET_MOLD);
                }
                catch (Framework.ApplicationException exception)
                {
                    this.CompleteProgress();
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }

                MoldVo checkInVo = new MoldVo();

                ProcessWorkMoldVo processWorkMoldInVo = new ProcessWorkMoldVo();

                Mold_dgv.DataSource = null;
                excelUploadDt.Columns.Add("Remarks");
                excelUploadDt.Columns.Add("Comment");
                var sch = StringCheckHelper.GetInstance();
                bool inputDataNG = false;


                foreach (DataRow row in excelUploadDt.Rows)
                {
                    if (row["Comments"] != null && !string.IsNullOrWhiteSpace(row["Comments"].ToString()))
                    {
                        row["Comment"] = row["Comments"].ToString();
                    }

                    if (row["MoldCode"] == null || string.IsNullOrWhiteSpace(row["MoldCode"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00011, MoldCode_lbl.Text);
                        inputDataNG = true;
                        continue;
                    }

                    if (!sch.IsASCII(row["MoldCode"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmci00017, MoldCode_lbl.Text);
                        inputDataNG = true;
                        continue;
                    }

                    var duplicates = excelUploadDt.AsEnumerable().GroupBy(r => r["MoldCode"]).Where(gr => gr.Count() > 1).ToList();

                    if (duplicates.Any() && duplicates.Select(dupl => dupl.Key).ToList().FirstOrDefault().ToString() == row["MoldCode"].ToString())
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00009, MoldCode_lbl.Text + " : " + row["MoldCode"].ToString());
                        inputDataNG = true;
                        continue;
                    }

                    if (row["MoldName"] == null || string.IsNullOrWhiteSpace(row["MoldName"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmci00017, MoldName_lbl.Text);
                        inputDataNG = true;
                        continue;
                    }

                    checkInVo = new MoldVo();
                    processWorkMoldInVo = new ProcessWorkMoldVo();

                    checkInVo.MoldCode = row["MoldCode"].ToString();
                    checkInVo.MoldName = row["MoldName"].ToString();

                    if (!ValidateProcessWorkCodeInExcel(excelUploadDt, checkInVo.MoldCode))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmci00019);
                        inputDataNG = true;
                        continue;
                    }

                    MoldVo checkVo = DuplicateCheck(checkInVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00012, MoldCode_lbl.Text + " : " + checkInVo.MoldCode);
                        inputDataNG = true;
                        continue;
                    }

                }

                Mold_dgv.AutoGenerateColumns = false;
                isExcelUpload = true;
                Mold_dgv.Columns["colRemarks"].Visible = true;
                Mold_dgv.DataSource = excelUploadDt;

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
        /// Download Mold master excel template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Download_btn_Click(object sender, EventArgs e)
        {
            string xlsFileName = Application.StartupPath + "\\" + Properties.Settings.Default.TEMPLATE_FILE_MASTER;

            if (!File.Exists(xlsFileName))
            {
                messageData = new MessageData("mmci00011", Properties.Resources.mmci00011, Properties.Settings.Default.TEMPLATE_FILE_MASTER);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            ExcelExport_sfdlg.FileName = string.Empty;
            ExcelExport_sfdlg.Filter = "Excel Files(*.xls) |*.xls";

            if (ExcelExport_sfdlg.ShowDialog() == DialogResult.OK)
            {
                base.StartProgress(Properties.Resources.mmci00009);
                try
                {
                    File.Copy(xlsFileName, ExcelExport_sfdlg.FileName, true);
                }

                catch (IOException copyError)
                {
                    this.CompleteProgress();
                    messageData = new MessageData("mmcc00001", Properties.Resources.mmcc00001, copyError.Message);
                    popUpMessage.ApplicationError(messageData, Text);
                    logger.Error(messageData);
                    return;
                }

                ExportExcelProcess exportTemplate = new ExportExcelProcess();

                exportTemplate.DownloadExcel(ExcelExport_sfdlg.FileName, Properties.Settings.Default.EXCEL_SHEET_MOLD);

                this.CompleteProgress();
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

        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (Mold_dgv.RowCount > 0 && Mold_dgv.Columns["colRemarks"].Visible == true)
            {
                if (processWorkList.Count == 0)
                {
                    GetProcessWork();
                }

                this.StartProgress(Properties.Resources.mmci00009);

                string previousMoldCode = string.Empty;
                int uploadedCount = 0;
                int insertedCount = 0;

                MoldVo checkInVo = new MoldVo();

                ProcessWorkMoldVo processWorkMoldInVo = new ProcessWorkMoldVo();

                decimal width = 0;
                decimal depth = 0;
                decimal height = 0;
                decimal weight = 0;
                DateTime productionDate;
                int lifeShotCount = 0;

                foreach (DataRow row in excelUploadDt.Rows)
                {
                    if (!string.IsNullOrEmpty(row["MoldCode"].ToString()) && previousMoldCode != row["MoldCode"].ToString())
                    {

                        checkInVo = new MoldVo();
                        processWorkMoldInVo = new ProcessWorkMoldVo();

                        checkInVo.MoldCode = row["MoldCode"].ToString();
                        checkInVo.MoldName = row["MoldName"].ToString();

                        if (row["MoldTypeCode"] != null && !string.IsNullOrWhiteSpace(row["MoldTypeCode"].ToString()))
                        {
                            checkInVo.MoldTypeCode = row["MoldTypeCode"].ToString();
                        }
                        if (row["Width"] != null && !string.IsNullOrWhiteSpace(row["Width"].ToString()) && Decimal.TryParse(row["Width"].ToString(), out width))
                        {
                            checkInVo.Width = width;
                        }
                        if (row["Depth"] != null && !string.IsNullOrWhiteSpace(row["Depth"].ToString()) && Decimal.TryParse(row["Depth"].ToString(), out depth))
                        {
                            checkInVo.Depth = depth;
                        }
                        if (row["Height"] != null && !string.IsNullOrWhiteSpace(row["Height"].ToString()) && Decimal.TryParse(row["Height"].ToString(), out height))
                        {
                            checkInVo.Height = height;
                        }
                        if (row["Weight"] != null && !string.IsNullOrWhiteSpace(row["Weight"].ToString()) && Decimal.TryParse(row["Weight"].ToString(), out weight))
                        {
                            checkInVo.Weight = weight;
                        }
                        if (row["ProductionDate"] != null && !string.IsNullOrWhiteSpace(row["ProductionDate"].ToString()) && DateTime.TryParse(row["ProductionDate"].ToString(), out productionDate))
                        {
                            checkInVo.ProductionDate = productionDate;
                        }
                        if (row["LifeShotCount"] != null && !string.IsNullOrWhiteSpace(row["LifeShotCount"].ToString()) && int.TryParse(row["LifeShotCount"].ToString(), out lifeShotCount))
                        {
                            checkInVo.LifeShotCount = lifeShotCount;
                        }
                        if (row["Comments"] != null && !string.IsNullOrWhiteSpace(row["Comments"].ToString()))
                        {
                            checkInVo.Comment = row["Comments"].ToString();
                        }

                        uploadedCount += 1;

                        DataRow[] processWorkCodeList = excelUploadDt.Select("MoldCode = '" + checkInVo.MoldCode + "'");

                        foreach (DataRow item in processWorkCodeList)
                        {
                            ProcessWorkMoldVo addVo = new ProcessWorkMoldVo();

                            if (processWorkList.Where(t => t.ProcessWorkCode == item["ProcessWorkCode"].ToString()).FirstOrDefault() != null)
                            {
                                addVo.ProcessWorkId = processWorkList.Where(t => t.ProcessWorkCode == item["ProcessWorkCode"].ToString()).FirstOrDefault().ProcessWorkId;
                            }
                            processWorkMoldInVo.ProcessWorkMoldListVo.Add(addVo);
                        }

                        ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();

                        inVoList.add(checkInVo);
                        inVoList.add(processWorkMoldInVo);

                        MoldVo outVo = null;

                        try
                        {
                            //outVo = (MoldVo)base.InvokeCbm(new AddMoldMasterMntAndProcessworkCbm(), inVoList, false);
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

                    previousMoldCode = row["MoldCode"].ToString();
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
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Mold_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Mold_dgv.SelectedRows.Count > 0 && isExcelUpload == false)
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
        protected virtual void Mold_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Mold_dgv.SelectedRows.Count > 0 && isExcelUpload == false)
            {
                BindUpdateUserData();
            }
        }

        /// <summary>
        /// sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mold_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = Mold_dgv.Columns[e.ColumnIndex];

            if (Mold_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)Mold_dgv.DataSource;

            List<MoldVo> dataSourceVo = (List<MoldVo>)currentDatagridSource.DataSource;

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
                Mold_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }

        }

        #endregion


    }
}
