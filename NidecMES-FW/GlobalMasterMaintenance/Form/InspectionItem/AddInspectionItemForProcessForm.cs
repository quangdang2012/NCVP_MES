using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.Framework;
using System.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddInspectionItemForProcessForm
    {
        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly InspectionItemVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// Check for copy function used or not
        /// </summary>
        public bool is_Copied = false;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInspectionItemForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// get Running Number
        /// </summary>
        private int RunningNumber;

        /// <summary>
        /// 
        /// </summary>
        private bool isNewValue;

        public int ReturnProcessId;

        /// <summary>
        /// 
        /// </summary>
        private int InspectionItemCopyId;

        /// <summary>
        /// 
        /// </summary>
        private string InspectionItemCode;

        //private InspectionItemSelectionDatatypeValueVo getSelectionValueresultVo = null;

        #endregion

        #region Constructor
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="InspectionItem"></param>
        public AddInspectionItemForProcessForm(string pmode, InspectionItemVo InspectionItem = null)
        {
            InitializeComponent();

            mode = pmode;
            updateData = InspectionItem;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }

        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (InspectionItemName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionItemName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionItemName_txt.Focus();

                return false;
            }
            if (InspectionItemDataType_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionItemDataType_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionItemDataType_cmb.Focus();

                return false;
            }
            if (mode.Equals(CommonConstants.MODE_UPDATE) && !InspectionItemDataType_cmb.SelectedValue.Equals(updateData.InspectionItemDataType))
            {
                if (CheckInspectionSpecificationRecord())
                {
                    messageData = new MessageData("mmci00029", Properties.Resources.mmci00029);
                    popUpMessage.Warning(messageData, Text);

                    InspectionItemDataType_cmb.Focus();
                    return false;
                }
            }

            if (InspectionItemDisplayOrder_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionItemDisplayOrder_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionItemDisplayOrder_txt.Focus();

                return false;
            }

            if (InspectionItemDataType_cmb.SelectedIndex > -1 &&
                            InspectionItemDataType_cmb.SelectedValue.ToString() == GlobalMasterDataTypeEnum.DATATYPE_SELECTION.GetValue().ToString() && !isNewValue)
            {
                if (mode == CommonConstants.MODE_UPDATE) { return true; }
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Value_btn.Text);
                popUpMessage.Warning(messageData, Text);

                Value_btn.Focus();

                return false;
            }
            return true;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="InspectioninVo"></param>
        private void LoadInspectionItemData(InspectionItemVo InspectioninVo)
        {
            if (InspectioninVo != null)
            {
                InspectionItemName_txt.Text = InspectioninVo.InspectionItemName;
                ParentItemCode_cmb.SelectedValue = InspectioninVo.ParentInspectionItemId;
                //InspectionProcess_cmb.SelectedValue = InspectioninVo.InspectionProcessId;
                InspectionProcess_cmb.Text = InspectioninVo.InspectionProcessName;
                InspectionItemDisplayOrder_txt.Text = InspectioninVo.DisplayOrder.ToString();
                InspectionItemMandatory_chk.Checked = Convert.ToBoolean(InspectioninVo.InspectionItemMandatory);
                InspectionEmployeeMandatory_chk.Checked = Convert.ToBoolean(InspectioninVo.InspectionEmployeeMandatory);
                InspectionMachineMandatory_chk.Checked = Convert.ToBoolean(InspectioninVo.InspectionMachineMandatory);
                InspectionItemDataType_cmb.SelectedValue = Convert.ToInt32(InspectioninVo.InspectionItemDataType);
                if (InspectionItemDataType_cmb.SelectedValue.ToString() == GlobalMasterDataTypeEnum.DATATYPE_DECIMAL.GetValue().ToString())
                {
                    ResultItemDecimalDigits_txt.ReadOnly = false;
                    if (InspectioninVo.InspectionResultItemDecimalDigits > 0)
                    {
                        ResultItemDecimalDigits_txt.Text = InspectioninVo.InspectionResultItemDecimalDigits.ToString();
                    }
                }



            }
        }

        /// <summary>
        /// Load Inspection Process
        /// </summary>
        private void LoadInspectionProcessCombo()
        {
            ValueObjectList<InspectionProcessVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionProcessVo>)base.InvokeCbm(new GetInsepctionProcessMasterMntCbm(), new InspectionProcessVo(), false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }
            InspectionProcess_cmb.DisplayMember = "InspectionProcessName";
            InspectionProcess_cmb.ValueMember = "InspectionProcessId";
            InspectionProcess_cmb.DataSource = outVo.GetList();
            InspectionProcess_cmb.SelectedValue = updateData.InspectionProcessId;
        }

        /// <summary>
        /// Load Parent Inspection Data
        /// </summary>
        private void LoadParentInspectionCombo()
        {
            InspectionItemVo inVo = new InspectionItemVo();
            inVo.InspectionItemId = updateData.InspectionItemId;
            inVo.InspectionProcessId = updateData.InspectionProcessId;

            ValueObjectList<InspectionItemVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionItemVo>)base.InvokeCbm(new GetParentInspectionItemIdMasterMntCbm(), inVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
            {
                return;
            }

            ParentItemCode_cmb.DisplayMember = "InspectionItemName";
            ParentItemCode_cmb.ValueMember = "InspectionItemId";
            ParentItemCode_cmb.DataSource = outVo.GetList();
            ParentItemCode_cmb.SelectedIndex = -1;
        }


        /// <summary>
        /// Load Data type
        /// </summary>
        /// <param name="pCombo"></param>
        private void LoadDataTypeCombo(ComboBox pCombo)
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DECIMAL.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_DECIMAL.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_OK_NG.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_OK_NG.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_STRING.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_STRING.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_IMAGE.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_IMAGE.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_NUMBER.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_NUMBER.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DATETIME.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_DATETIME.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_SELECTION.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_SELECTION.ToString());

            pCombo.DisplayMember = "Value";
            pCombo.ValueMember = "Key";
            pCombo.DataSource = new BindingSource(comboSource, null);
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        /// <summary>
        /// checks Inspection Specification code Exists
        /// </summary>
        /// <returns></returns>
        private bool CheckInspectionSpecificationRecord()
        {
            InspectionSpecificationVo InsSpecVo = new InspectionSpecificationVo();
            InsSpecVo.InspectionItemId = updateData.InspectionItemId;

            InspectionSpecificationVo outVo = new InspectionSpecificationVo();

            try
            {
                outVo = (InspectionSpecificationVo)base.InvokeCbm(new CheckInspectionSpecificationMasterMntCbm(), InsSpecVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            if (outVo != null && outVo.AffectedCount > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// checks duplicate Inspection item
        /// </summary>
        /// <param name="InspectionVo"></param>
        /// <returns></returns>
        private InspectionItemVo DuplicateCheck(InspectionItemVo InspectionVo)
        {
            InspectionItemVo outVo = new InspectionItemVo();

            try
            {
                outVo = (InspectionItemVo)base.InvokeCbm(new CheckInspectionItemMasterMntCbm(), InspectionVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        /// <summary>
        /// To get the Format Id based on item id
        /// </summary>
        /// <param name="inspectionprocessid"></param>
        /// <returns></returns>
        private InspectionFormatVo FormFormatVo(int inspectionitemid)
        {
            InspectionFormatProcessBuzzLogic getFormatdetails = new InspectionFormatProcessBuzzLogic();
            CopyInspectionFormatVo inVo = new CopyInspectionFormatVo();
            inVo.InspectionItemId = inspectionitemid;
            return getFormatdetails.getFormatDetails(inVo);
        }

        /// <summary>
        /// checks duplicate Display Record
        /// </summary>
        /// <param name="defectVo"></param>
        /// <returns></returns>
        private InspectionItemVo DuplicateDisplayCheck(InspectionItemVo defectVo)
        {
            InspectionItemVo outVo = new InspectionItemVo();

            try
            {
                outVo = (InspectionItemVo)base.InvokeCbm(new CheckInspectionItemWorkDisplayOrderCbm(), defectVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        private void checkRunningCount(InspectionItemVo inVo)
        {
            InspectionItemVo outVo = new InspectionItemVo();

            try
            {
                outVo = (InspectionItemVo)base.InvokeCbm(new GetInspectionItemSeqCbm(), inVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            RunningNumber = 1;

            if (outVo != null && outVo.InspectionItemCode != null)
            {
                string strTemp;
                strTemp = outVo.InspectionItemCode;
                if (strTemp.LastIndexOf(GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue()) > 0)
                {
                    strTemp = strTemp.Substring(strTemp.LastIndexOf(GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue()) + 1);
                    if (strTemp.All(Char.IsDigit))
                    {
                        RunningNumber = Convert.ToInt32(strTemp) + 1;
                    }
                }
            }
        }

        private bool CheckDataExist(int inspectionItemId)
        {
            InspectionSpecificationVo inSpecVo = new InspectionSpecificationVo();
            inSpecVo.InspectionItemId = inspectionItemId;

            ValueObjectList<InspectionSpecificationVo> outSpecVo = null;
            try
            {
                outSpecVo = (ValueObjectList<InspectionSpecificationVo>)base.InvokeCbm(new GetInspectionSpecificationMasterMntCbm(), inSpecVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                //popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            
            InspectionTestInstructionVo inTestInstVo = new InspectionTestInstructionVo();
            inTestInstVo.InspectionItemId = inspectionItemId;

            ValueObjectList<InspectionTestInstructionVo> outTestInstVo = null;
            try
            {
                outTestInstVo = (ValueObjectList<InspectionTestInstructionVo>)base.InvokeCbm(new GetInspectionTestInstructionMasterMntCbm(), inTestInstVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                //popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if ((outTestInstVo == null || outTestInstVo.GetList() == null || outTestInstVo.GetList().Count == 0) && 
                                                (outSpecVo == null || outSpecVo.GetList() == null || outSpecVo.GetList().Count == 0))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region FormEvents

        /// <summary>
        /// load data from db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddInspectionItemForm_Load(object sender, EventArgs e)
        {

            if (updateData != null && updateData.InspectionItemIdCopy > 0)
            {
                InspectionItemCopyId = updateData.InspectionItemIdCopy;

                CopyItem_txt.Text = updateData.InspectionItemName;
            }

            //LoadInspectionProcessCombo();
            InspectionProcess_cmb.Text = updateData.InspectionProcessName;

            LoadParentInspectionCombo();

            LoadDataTypeCombo(InspectionItemDataType_cmb);

            InspectionItemName_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadInspectionItemData(updateData);
                CopyItem_txt.Enabled = false;
                CopyItem_btn.Enabled = false;
            }
            else
            {
                try
                {
                    InspectionItemVo outVo = (InspectionItemVo)base.InvokeCbm(new GetInspectionItemDisplayOrderNextValCbm(), updateData, false);
                    if (outVo != null && outVo.DisplayOrder > 0)
                    {
                        InspectionItemDisplayOrder_txt.Text = outVo.DisplayOrder.ToString();
                    }
                    else
                    {
                        InspectionItemDisplayOrder_txt.Text = "1";
                    }

                    InspectionItemVo inVo = new InspectionItemVo();
                    inVo.InspectionProcessId = updateData.InspectionProcessId;
                    inVo.ParentInspectionItemId = updateData.ParentInspectionItemId;
                    checkRunningCount(inVo);

                    InspectionItemCode = updateData.InspectionProcessCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + GlobalMasterDataTypeEnum.ITEM_CODE.GetValue() + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + RunningNumber;

                    UpdateResultVo updateResultVo = (UpdateResultVo)base.InvokeCbm(new DeleteInspectionItemSelectionValueCbm(), null, false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }
            }
        }

        private void InspectionItemDataType_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InspectionItemDataType_cmb.SelectedIndex > -1 && InspectionItemDataType_cmb.SelectedValue.ToString() == GlobalMasterDataTypeEnum.DATATYPE_DECIMAL.GetValue().ToString())
            {
                ResultItemDecimalDigits_txt.ReadOnly = false;
            }
            else
            {
                ResultItemDecimalDigits_txt.ReadOnly = true;
                ResultItemDecimalDigits_txt.Text = string.Empty;
            }
            if (InspectionItemDataType_cmb.SelectedIndex > -1 &&
                InspectionItemDataType_cmb.SelectedValue.ToString() == GlobalMasterDataTypeEnum.DATATYPE_SELECTION.GetValue().ToString())
            {
                Value_btn.Visible = true;
            }
            else
            {
                Value_btn.Visible = false;
            }
        }

        /// <summary>
        /// to input value for selection datatype
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Value_btn_Click(object sender, EventArgs e)
        {
            InspectionSelectionDatetypeValueForItemForm frm = new InspectionSelectionDatetypeValueForItemForm(updateData);
            frm.InspectionItemCode = InspectionItemCode;
            frm.InspectionItemName = InspectionItemName_txt.Text;
            frm.ShowDialog();
            isNewValue = frm.IsNewSelectionValue;
            //getSelectionValueresultVo = frm.UpdateInspectionItemSelectionDatatypeValueVo;
            if(frm.InspectionItemId > 0 &&  frm.InspectionProcessId > 0)
            {
                updateData.InspectionItemId = frm.InspectionItemId;
                updateData.InspectionProcessId = frm.InspectionProcessId;
                ReturnProcessId = frm.InspectionProcessId;
            }
        }

        private void ParentItemCode_cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ParentItemCode_cmb.SelectedIndex == -1) return;
            InspectionItemVo inVo = new InspectionItemVo();
            inVo.InspectionProcessId = updateData.InspectionProcessId;
            inVo.ParentInspectionItemId = Convert.ToInt32(ParentItemCode_cmb.SelectedValue);
            try
            {
                InspectionItemVo outVo = (InspectionItemVo)base.InvokeCbm(new GetInspectionItemDisplayOrderNextValCbm(), inVo, false);
                if (outVo != null && outVo.DisplayOrder > 0)
                {
                    InspectionItemDisplayOrder_txt.Text = outVo.DisplayOrder.ToString();
                }
                else
                {
                    InspectionItemDisplayOrder_txt.Text = "1";
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// update data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            var sch = StringCheckHelper.GetInstance();

            InspectionItemVo inVo = new InspectionItemVo();

            if (CheckMandatory())
            {
                inVo.InspectionItemName = InspectionItemName_txt.Text.Trim();

                if (ParentItemCode_cmb.SelectedIndex > -1)
                {
                    inVo.ParentInspectionItemId = Convert.ToInt32(ParentItemCode_cmb.SelectedValue.ToString());
                }
                //if (InspectionProcess_cmb.SelectedIndex > -1)
                //{
                //    inVo.InspectionProcessId = Convert.ToInt32(InspectionProcess_cmb.SelectedValue);
                //}

                inVo.InspectionProcessId = updateData.InspectionProcessId;

                inVo.InspectionItemMandatory = Convert.ToInt32(InspectionItemMandatory_chk.Checked);

                inVo.InspectionEmployeeMandatory = Convert.ToInt32(InspectionEmployeeMandatory_chk.Checked);

                inVo.InspectionMachineMandatory = Convert.ToInt32(InspectionMachineMandatory_chk.Checked);

                inVo.InspectionItemDataType = Convert.ToInt32(InspectionItemDataType_cmb.SelectedValue);

                inVo.DisplayOrder = Convert.ToInt32(InspectionItemDisplayOrder_txt.Text);

                if (!string.IsNullOrEmpty(ResultItemDecimalDigits_txt.Text))
                {
                    inVo.InspectionResultItemDecimalDigits = Convert.ToInt32(ResultItemDecimalDigits_txt.Text);
                }

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    InspectionItemVo checkVo = DuplicateCheck(inVo);
                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionItemName_lbl.Text + " : " + InspectionItemName_txt.Text);
                        popUpMessage.Information(messageData, Text);

                        return;
                    }

                    InspectionItemVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                    if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionItemDisplayOrder_lbl.Text + " : " + InspectionItemDisplayOrder_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        InspectionItemDisplayOrder_txt.Focus();
                        return;
                    }

                }
                else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    if (updateData.InspectionItemName != InspectionItemName_txt.Text)
                    {
                        InspectionItemVo checkVo = DuplicateCheck(inVo);
                        if (checkVo != null && checkVo.AffectedCount > 0)
                        {
                            messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionItemName_lbl.Text + " : " + InspectionItemName_txt.Text);
                            popUpMessage.Information(messageData, Text);

                            return;
                        }
                    }

                    if (updateData.DisplayOrder != Convert.ToInt32(InspectionItemDisplayOrder_txt.Text))
                    {
                        InspectionItemVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                        if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                        {
                            messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionItemDisplayOrder_lbl.Text + " : " + InspectionItemDisplayOrder_txt.Text);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);
                            InspectionItemDisplayOrder_txt.Focus();
                            return;
                        }
                    }
                }
                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    inVo.InspectionItemCode = InspectionItemCode;

                    if (InspectionItemCopyId == 0)
                    {   
                        InspectionItemVo outVo = null;
                        try
                        {
                            outVo = (InspectionItemVo)base.InvokeCbm(new AddInspectionItemMasterMntCbm(), inVo, false);
                        }
                        catch (Framework.ApplicationException exception)
                        {
                            popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                            logger.Error(exception.GetMessageData());
                            return;
                        }
                        if (outVo == null && outVo.InspectionItemId == 0) return;

                        IntSuccess = outVo.InspectionItemId;

                        //
                        if (InspectionItemDataType_cmb.SelectedIndex > -1 &&
                            InspectionItemDataType_cmb.SelectedValue.ToString() == GlobalMasterDataTypeEnum.DATATYPE_SELECTION.GetValue().ToString())
                        {
                            InspectionItemSelectionDatatypeValueVo inspectionItemSelectionDatatypeValueVo = new InspectionItemSelectionDatatypeValueVo();
                            inspectionItemSelectionDatatypeValueVo.InspectionItemCode = InspectionItemCode;
                            inspectionItemSelectionDatatypeValueVo.InspectionItemId = outVo.InspectionItemId;
                            try
                            {
                                UpdateResultVo updateResultVo = (UpdateResultVo)base.InvokeCbm(new UpdateInspectionItemIdForSelectionValueCbm(), inspectionItemSelectionDatatypeValueVo, false);
                            }
                            catch (Framework.ApplicationException exception)
                            {
                                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                                logger.Error(exception.GetMessageData());
                                return;
                            }
                        }
                    }
                    else
                    {
                        inVo.InspectionItemIdCopy = InspectionItemCopyId;
                        //InspectionFormatVo getformatvo = inspectionFormatOutVo.GetList().Where(t => t.InspectionFormatId == inVo.InspectionFormatId).FirstOrDefault();
                        //if (getformatvo == null) return;

                        if (!CheckDataExist(InspectionItemCopyId))
                        {
                            messageData = new MessageData("mmci00048", Properties.Resources.mmci00048.ToString(), CopyItem_txt.Text);
                            logger.Info(messageData);
                            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);
                            if (dialogResult != DialogResult.OK)
                            {
                                return;
                            }
                        }

                        string message = string.Format(Properties.Resources.mmci00045, CopyItem_txt.Text);
                        base.StartProgress(message);

                        inVo.InspectionProcessCode = updateData.InspectionProcessCode; // getformatvo.InspectionFormatCode;
                        //inVo.SequenceNo = RunningNumber;

                        ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                        inVoList.add(null);
                        inVoList.add(null);
                        inVoList.add(inVo);
                        inVoList.add(null);
                        inVoList.add(null);
                        inVoList.add(null);
                        inVoList.add(null);
                        InspectionReturnVo OutVo = null;
                        try
                        {
                            OutVo = (InspectionReturnVo)base.InvokeCbm(new CopyInspectionItemFromItemAllCbm(), inVoList, false);
                        }
                        catch (Framework.ApplicationException exception)
                        {
                            popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                            logger.Error(exception.GetMessageData());
                            return;
                        }
                        finally
                        {
                            CompleteProgress();
                        }
                        if (OutVo != null && OutVo.AffectedCount > 0)
                        {
                            IntSuccess = OutVo.InspectionItemId;
                            ReturnProcessId = OutVo.InspectionProcessId;
                            is_Copied = true;
               

                        }
                    }
                }
                else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    inVo.InspectionItemId = updateData.InspectionItemId;

                    string message = string.Format(Properties.Resources.mmci00037, "Inspection Item", InspectionItemName_txt.Text);
                    StartProgress(message);

                    ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                    InspectionFormatVo passformatVo = FormFormatVo(updateData.InspectionItemId);
                    if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                    inVoList.add(passformatVo);
                    inVoList.add(null);
                    inVoList.add(inVo);
                    inVoList.add(null);
                    inVoList.add(null);
                    inVoList.add(null);
                    inVoList.add(null);

                    InspectionReturnVo outVo = null;

                    try
                    {
                        outVo = (InspectionReturnVo)base.InvokeCbm(new UpdateAllInspectionFunctionMasterMntCbm(), inVoList, false);
                    }
                    catch (Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                        return;
                    }
                    finally
                    {
                        CompleteProgress();
                    }
                    if (outVo != null && outVo.AffectedCount > 0)
                    {
                        IntSuccess = outVo.InspectionItemId;
                        ReturnProcessId = outVo.InspectionProcessId;
                    }

                    //InspectionItemVo outVo = (InspectionItemVo)base.InvokeCbm(new UpdateInspectionItemMasterMntCbm(), inVo, false);
                }

                if (IntSuccess > 0)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Item Copy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyItem_btn_Click(object sender, EventArgs e)
        {
            InspectionItemListForm frm = new InspectionItemListForm();
            frm.ShowDialog();

            InspectionItemCopyId = frm.InspectionItemId;

            CopyItem_txt.Text = frm.InspectionItemName;
        }

        #endregion
        
    }
}
