using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class DefectiveReasonForm
    {

        #region Variables

        private DataTable defectiveCategoryDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefectiveReasonForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        ///  get message data
        /// </summary>
        private const string DefectiveReason = "ProcessWorkDefectiveReason";

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
        public DefectiveReasonForm()
        {
            InitializeComponent();

        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(DefectiveReasonVo conditionInVo)
        {
            DefectiveReason_dgv.DataSource = null;
            isExcelUpload = false;

            try
            {
                DefectiveReasonVo outVo = (DefectiveReasonVo)base.InvokeCbm(new GetDefectiveReasonMasterMntCbm(), conditionInVo, false);

                DefectiveReason_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.DefectiveReasonListVo, null);

                if (bindingSource1 != null && bindingSource1.Count > 0)
                {
                    DefectiveReason_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"defective reason"
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                DefectiveReason_dgv.ClearSelection();
                DefectiveReason_dgv.Columns["colRemarks"].Visible = false;

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;

                AddExcel_btn.Enabled = false;

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
        private DefectiveReasonVo FormConditionVo()
        {
            DefectiveReasonVo inVo = new DefectiveReasonVo();

            if (DefectiveReasonCode_txt.Text != string.Empty)
            {
                inVo.DefectiveReasonCode = DefectiveReasonCode_txt.Text;
            }

            if (DefectiveReasonName_txt.Text != string.Empty)
            {
                inVo.DefectiveReasonName = DefectiveReasonName_txt.Text;

            }
            if (DefectiveCategory_cmb.SelectedIndex > -1)
            {
                inVo.DefectiveCategoryId = Convert.ToInt32(DefectiveCategory_cmb.SelectedValue);
            }

            return inVo;

        }

        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = DefectiveReason_dgv.SelectedCells[0].RowIndex;

            DefectiveReasonVo selectedData = (DefectiveReasonVo)DefectiveReason_dgv.Rows[selectedrowindex].DataBoundItem;

            AddDefectiveReasonNewForm newAddForm = new AddDefectiveReasonNewForm(CommonConstants.MODE_UPDATE, selectedData);

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
        /// To idenctify the relation ship with tables
        /// </summary>
        private DefectiveReasonVo CheckDefectiveRelation(DefectiveReasonVo inVo)
        {
            DefectiveReasonVo outVo = new DefectiveReasonVo();

            try
            {
                outVo = (DefectiveReasonVo)base.InvokeCbm(new CheckDefectiveReasonRelationCbm(), inVo, false);
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
        /// checks duplicate Display Record
        /// </summary>
        /// <param name="defectVo"></param>
        /// <returns></returns>
        private DefectiveReasonVo DuplicateDisplayCheck(DefectiveReasonVo defectVo)
        {
            DefectiveReasonVo outVo = new DefectiveReasonVo();

            try
            {
                outVo = (DefectiveReasonVo)base.InvokeCbm(new CheckDisplayRecordMasterMntCbm(), defectVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        /// <summary>
        /// checks duplicate Defective reason Code
        /// </summary>
        /// <param name="defectVo"></param>
        /// <returns></returns>
        private DefectiveReasonVo DuplicateCheck(DefectiveReasonVo defectVo)
        {
            DefectiveReasonVo outVo = new DefectiveReasonVo();

            try
            {
                outVo = (DefectiveReasonVo)base.InvokeCbm(new CheckDefectiveReasonMasterMntCbm(), defectVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        private void FormDatatableFromVo()
        {
            defectiveCategoryDatatable = new DataTable();
            defectiveCategoryDatatable.Columns.Add("id");
            defectiveCategoryDatatable.Columns.Add("name");

            try
            {
                DefectiveCategoryVo defectiveCategoryOutVo = (DefectiveCategoryVo)base.InvokeCbm(new GetDefectiveCategoryMasterMntCbm(), new DefectiveCategoryVo(), false);

                foreach (DefectiveCategoryVo defectiveCategory in defectiveCategoryOutVo.DefectiveCategoryListVo)
                {
                    defectiveCategoryDatatable.Rows.Add(defectiveCategory.DefectiveCategoryId, defectiveCategory.DefectiveCategoryName);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void ComboBind(ComboBox pCombo, DataTable pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        private bool ValidateProcessWorkCodeInExcel(DataTable excelUploadData, string defectiveReasonCode)
        {
            if (processWorkList.Count == 0)
            {
                GetProcessWork();
            }

            bool IsProcessWorkCodeValid = false;

            DataRow[] processWorkCodeList = excelUploadDt.Select("DefectiveReasonCode = '" + defectiveReasonCode + "'");

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
        private void DefectiveReasonForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();
            ComboBind(DefectiveCategory_cmb, defectiveCategoryDatatable, "name", "id");
            AddExcel_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;
            DefectiveReasonCode_txt.Select();
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
            DefectiveReasonCode_txt.Text = string.Empty;
            DefectiveReasonName_txt.Text = string.Empty;
            DefectiveCategory_cmb.SelectedIndex = -1;
            DefectiveReason_dgv.DataSource = null;

            AddExcel_btn.Enabled = Delete_btn.Enabled = Update_btn.Enabled = false;
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
            AddDefectiveReasonNewForm newAddForm = new AddDefectiveReasonNewForm(CommonConstants.MODE_ADD, null);

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

            int selectedrowindex = DefectiveReason_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = DefectiveReason_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colDefectiveReasonCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                DefectiveReasonVo inVo = new DefectiveReasonVo();

                inVo.DefectiveReasonId = Convert.ToInt32(selectedRow.Cells["colDefectiveReasonId"].Value);

                try
                {
                    inVo.DefectiveReasonCode = selectedRow.Cells["colDefectiveReasonCode"].Value.ToString();
                    DefectiveReasonVo tableCount = CheckDefectiveRelation(inVo);
                    if (tableCount.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, DefectiveReason.ToString());
                        popUpMessage.Information(messageData, Text);
                        return;
                    }


                    DefectiveReasonVo outVo = (DefectiveReasonVo)base.InvokeCbm(new DeleteDefectiveReasonMasterMntNewCbm(), inVo, false);

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
        /// Download Defective Reason master excel template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Download_btn_Click(object sender, EventArgs e)
        {
            //string xlsFileName = Application.StartupPath + "\\" + Properties.Settings.Default.TEMPLATE_FILE_MASTER;
            string xlsFileName = Application.StartupPath + "\\" + Properties.Settings.Default.TEMPLATE_FILE_DEFECTIVE;
            if (!File.Exists(xlsFileName))
            {
                messageData = new MessageData("mmci00011", Properties.Resources.mmci00011, Properties.Settings.Default.TEMPLATE_FILE_DEFECTIVE);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            ExcelExport_sfdlg.FileName = string.Empty;
            ExcelExport_sfdlg.Filter = "Excel Files(*.xls) |*.xls";

            if (ExcelExport_sfdlg.ShowDialog() == DialogResult.OK)
            {
                //base.StartProgress(Properties.Resources.mmci00009);
                try
                {
                    File.Copy(xlsFileName, ExcelExport_sfdlg.FileName, true);

                    messageData = new MessageData("mmci00021", Properties.Resources.mmci00021, Properties.Settings.Default.TEMPLATE_FILE_DEFECTIVE);
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

                //ExportExcelProcess exportTemplate = new ExportExcelProcess();

                //exportTemplate.DownloadExcel(ExcelExport_sfdlg.FileName, Properties.Settings.Default.EXCEL_SHEET_DEFECTIVE_REASON);

                //this.CompleteProgress();
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

        /// <summary>
        /// upload excel and insert to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelUpload_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog_dlg = new OpenFileDialog();

            openDialog_dlg.Filter = "Excel Files(*.xls) |*.xls";

            if (openDialog_dlg.ShowDialog() == DialogResult.OK)
            {
                this.StartProgress(Properties.Resources.mmci00009);
                
                try
                {
                    excelUploadDt = new ExcelUpload().ReadExcel(openDialog_dlg.FileName, Properties.Settings.Default.EXCEL_SHEET_DEFECTIVE_REASON);

                }
                catch (Framework.ApplicationException exception)
                {
                    this.CompleteProgress();
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }

                DefectiveReasonVo defectiveReasonInVo = new DefectiveReasonVo();

                ProcessDefectiveReasonVo processDefectiveReasonInVo = new ProcessDefectiveReasonVo();

                int displayOrder = 0;
                DefectiveReason_dgv.DataSource = null;
                excelUploadDt.Columns.Add("Remarks");
                var sch = StringCheckHelper.GetInstance();
                bool inputDataNG = false;


                foreach (DataRow row in excelUploadDt.Rows)
                {
                    
                    if (row["DefectiveReasonCode"] == null || string.IsNullOrWhiteSpace(row["DefectiveReasonCode"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00011, DefectiveReasonCode_lbl.Text); 
                        inputDataNG = true;
                        continue;
                    }

                    if (!sch.IsASCII(row["DefectiveReasonCode"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmci00017, DefectiveReasonCode_lbl.Text);
                        inputDataNG = true;
                        continue;
                    }

                    var duplicates = excelUploadDt.AsEnumerable().GroupBy(r => r["DefectiveReasonCode"]).Where(gr => gr.Count() > 1).ToList();

                    if (duplicates.Any() && duplicates.Select(dupl => dupl.Key).ToList().FirstOrDefault().ToString() == row["DefectiveReasonCode"].ToString())
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00009, DefectiveReasonCode_lbl.Text + " : " + row["DefectiveReasonCode"].ToString());
                        inputDataNG = true;
                        continue;
                    }

                    if (row["DefectiveReasonName"] == null || string.IsNullOrWhiteSpace(row["DefectiveReasonName"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00011, DefectiveReasonName_lbl.Text);
                        inputDataNG = true;
                        continue;
                    }

                    if (row["DisplayOrder"] == null || string.IsNullOrWhiteSpace(row["DisplayOrder"].ToString()))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00011, colDisplayOrder.HeaderText); 
                        inputDataNG = true;
                        continue;
                    }

                    if (!int.TryParse(row["DisplayOrder"].ToString(), out displayOrder) || displayOrder <= 0)
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmci00018, colDisplayOrder.HeaderText); 
                        inputDataNG = true;
                        continue;
                    }

                    var duplicateDisplayOrder = excelUploadDt.AsEnumerable().GroupBy(r => r["DisplayOrder"]).Where(gr => gr.Count() > 1).ToList();

                    if (duplicateDisplayOrder.Any() && duplicateDisplayOrder.Select(dupl => dupl.Key).ToList().FirstOrDefault().ToString() == row["DisplayOrder"].ToString())
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00009, colDisplayOrder.HeaderText + " : " + row["DisplayOrder"].ToString());
                        inputDataNG = true;
                        continue;
                    }

                    defectiveReasonInVo = new DefectiveReasonVo();
                    processDefectiveReasonInVo = new ProcessDefectiveReasonVo();

                    defectiveReasonInVo.DefectiveReasonCode = row["DefectiveReasonCode"].ToString();
                    defectiveReasonInVo.DefectiveReasonName = row["DefectiveReasonName"].ToString();
                    defectiveReasonInVo.DefectiveCategoryId = 0;
                    defectiveReasonInVo.DisplayOrder = Convert.ToInt32(row["DisplayOrder"].ToString());
                    if (!ValidateProcessWorkCodeInExcel(excelUploadDt, defectiveReasonInVo.DefectiveReasonCode))
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmci00019);
                        inputDataNG = true;
                        continue;
                    }


                    DefectiveReasonVo checkVo = DuplicateCheck(defectiveReasonInVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00012, DefectiveReasonCode_lbl.Text + " : " + defectiveReasonInVo.DefectiveReasonCode);
                        inputDataNG = true;
                        continue;
                    }

                    DefectiveReasonVo checkDisplayVo = DuplicateDisplayCheck(defectiveReasonInVo);
                    if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                    {
                        row["Remarks"] = string.Format(Properties.Resources.mmce00012, colDisplayOrder.HeaderText + " : " + defectiveReasonInVo.DisplayOrder.ToString());
                        inputDataNG = true;
                        continue;
                    }
                }

                DefectiveReason_dgv.AutoGenerateColumns = false;
                isExcelUpload = true;
                DefectiveReason_dgv.Columns["colRemarks"].Visible = true;
                DefectiveReason_dgv.DataSource = excelUploadDt;

                if (inputDataNG)
                {
                    AddExcel_btn.Enabled = false;
                }
                else
                {
                    AddExcel_btn.Enabled = true;
                }

                this.CompleteProgress();
            }
        }

        /// <summary>
        /// save excel data to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddExcel_btn_Click(object sender, EventArgs e)
        {
            if (DefectiveReason_dgv.RowCount > 0 && DefectiveReason_dgv.Columns["colRemarks"].Visible == true)
            {
                bool isRemarksNG = false;
                foreach (DataGridViewRow row in DefectiveReason_dgv.Rows)
                {
                    if (DefectiveReason_dgv["colRemarks", row.Index].Value != null &&
                        !string.IsNullOrWhiteSpace(DefectiveReason_dgv["colRemarks", row.Index].Value.ToString()))
                    {
                        row.Cells["colRemarks"].Style.ForeColor = Color.Red;
                        isRemarksNG = true;
                    }
                }

                if (isRemarksNG)
                {
                    messageData = new MessageData("mmci00015", Properties.Resources.mmci00015, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }

                string previousReasonCode = string.Empty;
                int uploadedCount = 0;
                int insertedCount = 0;

                DefectiveReasonVo defectiveReasonInVo = new DefectiveReasonVo();

                ProcessDefectiveReasonVo processDefectiveReasonInVo = new ProcessDefectiveReasonVo();

                if (processWorkList.Count == 0)
                {
                    GetProcessWork();
                }

                this.StartProgress(Properties.Resources.mmci00009);

                foreach (DataRow row in excelUploadDt.Rows)
                {
                    if (!string.IsNullOrEmpty(row["DefectiveReasonCode"].ToString()) && previousReasonCode != row["DefectiveReasonCode"].ToString())
                    {
                        defectiveReasonInVo = new DefectiveReasonVo();
                        processDefectiveReasonInVo = new ProcessDefectiveReasonVo();

                        defectiveReasonInVo.DefectiveReasonCode = row["DefectiveReasonCode"].ToString();
                        defectiveReasonInVo.DefectiveReasonName = row["DefectiveReasonName"].ToString();
                        defectiveReasonInVo.DefectiveCategoryId = 0;
                        defectiveReasonInVo.DisplayOrder = Convert.ToInt32(row["DisplayOrder"].ToString());

                        uploadedCount += 1;

                        DataRow[] processWorkCodeList = excelUploadDt.Select("DefectiveReasonCode = '" + defectiveReasonInVo.DefectiveReasonCode + "'");

                        foreach (DataRow item in processWorkCodeList)
                        {
                            ProcessDefectiveReasonVo addVo = new ProcessDefectiveReasonVo();
                            ProcessWorkVo processWorkVo = processWorkList.Where(t => t.ProcessWorkCode == item["ProcessWorkCode"].ToString()).FirstOrDefault();

                            if (processWorkVo != null && processWorkVo.ProcessWorkId > 0)
                            {
                                addVo.ProcessWorkId = processWorkList.Where(t => t.ProcessWorkCode == item["ProcessWorkCode"].ToString()).FirstOrDefault().ProcessWorkId;
                                processDefectiveReasonInVo.ProcessDefectiveReasonListVo.Add(addVo);
                            }
                        }

                        ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();

                        inVoList.add(defectiveReasonInVo);
                        inVoList.add(processDefectiveReasonInVo);

                        DefectiveReasonVo outVo = null;

                        try
                        {
                            outVo = (DefectiveReasonVo)base.InvokeCbm(new AddDefectiveReasonMasterMntNewCbm(), inVoList, false);
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

                    previousReasonCode = row["DefectiveReasonCode"].ToString();
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
        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefectiveReason_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DefectiveReason_dgv.SelectedCells.Count > 0 && isExcelUpload == false)
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
        private void DefectiveReason_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DefectiveReason_dgv.SelectedCells.Count > 0 && isExcelUpload == false)
            {
                BindUpdateUserData();
            }
        }


        #endregion

        
    }
}
