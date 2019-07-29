using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddInspectionSpecificationForItemForm
    {
        #region property
        /// <summary>
        /// set or get InspectionItemId
        /// </summary>
        public int InspectionItemId { get; set; }

        /// <summary>
        /// set or get InspectionItemCode
        /// </summary>
        public string InspectionItemCode { get; set; }

        /// <summary>
        /// set or get InspectionItemName
        /// </summary>
        public string InspectionItemName { get; set; }
        
        /// <summary>
        /// set or get InspectionItemDataType
        /// </summary>
        public int InspectionItemDataType { get; set; }

        #endregion

        #region Variables 

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private string mode;

        /// <summary>
        /// set inspectionspecificationid
        /// </summary>
        public int inspectionspecificationid;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly InspectionSpecificationVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// inspectionformat details table
        /// </summary>
        private DataTable inspectionitemDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInspectionSpecificationForItemForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// 
        /// </summary>
        string previousValueFrom = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        string previousValueTo = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private int cursorStart;

        /// <summary>
        /// set InspectionSpecificationCode
        /// </summary>
        private string InspectionSpecificationCode;

        /// <summary>
        /// set InspectionProcessId
        /// </summary>
        public int InspectionProcessId;

        #endregion

        #region Constructor 
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddInspectionSpecificationForItemForm(string pmode, InspectionSpecificationVo userItem = null)
        {

            InitializeComponent();

            mode = pmode;
            updateData = userItem;
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
            if (InspectionSpecificationText_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionSpecificationText_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionSpecificationText_txt.Focus();

                return false;
            }
            if (Operator_cmb.SelectedIndex < 0 && (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DATETIME.GetValue())
                || InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_NUMBER.GetValue())
                || InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DECIMAL.GetValue())))
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, OperatorFrom_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Operator_cmb.Focus();

                return false;
            }
            if (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_NUMBER.GetValue()))
            {
                string value_name = string.Empty;
                try
                {
                    value_name = ValueFrom_lbl.Text;
                    ValueFrom_txt.Text = Convert.ToInt32(ValueFrom_txt.Text).ToString();
                    if (!string.IsNullOrEmpty(ValueTo_txt.Text.Trim()))
                    {
                        value_name = ValueTo_lbl.Text;
                        ValueTo_txt.Text = Convert.ToInt32(ValueTo_txt.Text).ToString();
                    }
                }
                catch (Exception ex)
                {
                    messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, value_name);
                    popUpMessage.Warning(messageData, Text);
                    ValueFrom_txt.Focus();
                    return false;
                }
            }
            if (InspectionItemDataType != Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DATETIME.GetValue()) && string.IsNullOrEmpty(ValueFrom_txt.Text))
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ValueFrom_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Operator_cmb.Focus();

                return false;
            }
            if (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DATETIME.GetValue())
                                                        && DateTo_dtp.Enabled == true && DateTo_dtp.Value < DateFrom_dtp.Value)
            {
                messageData = new MessageData("mmci00030", Properties.Resources.mmci00030);
                popUpMessage.Warning(messageData, Text);

                Operator_cmb.Focus();

                return false;
            }
            if (ValueFrom_txt.Text != string.Empty && Convert.ToInt32(Operator_cmb.SelectedIndex) == 0)
            {
                if (!string.IsNullOrEmpty(ValueTo_txt.Text) && Convert.ToDecimal("0" + ValueTo_txt.Text) <= Convert.ToDecimal(ValueFrom_txt.Text))
                {
                    messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, ValueTo_lbl.Text);
                    popUpMessage.Warning(messageData, Text);

                    ValueTo_txt.Focus();

                    return false;
                }
            }
            //if (InspectionItem_cmb.Text == string.Empty || InspectionItem_cmb.SelectedIndex < 0)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionItem_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    InspectionItem_cmb.Focus();

            //    return false;
            //}
            if (SpecificationResultJudgeType_cmb.Text == string.Empty || SpecificationResultJudgeType_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, SpecificationResultJudgeType_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                SpecificationResultJudgeType_cmb.Focus();

                return false;
            }
            return true;
        }

        /// <summary>
        /// Loads selected data from data grid
        /// </summary>
        /// <param name="dgvInspectionSpecification"></param>
        private void LoadInspectionSpecificationData(InspectionSpecificationVo dgvInspectionSpecification)
        {
            if (dgvInspectionSpecification != null)
            {
                this.InspectionSpecificationText_txt.Text = dgvInspectionSpecification.InspectionSpecificationText;

                if (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DATETIME.GetValue()))
                {
                    if (!string.IsNullOrEmpty(dgvInspectionSpecification.ValueFrom))
                    {
                        DateFrom_dtp.Value = Convert.ToDateTime(dgvInspectionSpecification.ValueFrom);
                    }
                    if (!string.IsNullOrEmpty(dgvInspectionSpecification.ValueTo))
                    {
                        DateTo_dtp.Value = Convert.ToDateTime(dgvInspectionSpecification.ValueTo);
                    }
                }
                else
                {
                    this.ValueFrom_txt.Text = dgvInspectionSpecification.ValueFrom.ToString();

                    if (!string.IsNullOrEmpty(dgvInspectionSpecification.ValueTo))
                    {
                        this.ValueTo_txt.Text = dgvInspectionSpecification.ValueTo;
                    }
                }
                this.Unit_txt.Text = dgvInspectionSpecification.Unit;
                if (!string.IsNullOrEmpty(dgvInspectionSpecification.OperatorFrom))
                {
                    Operator_cmb.SelectedValue = Convert.ToInt32(dgvInspectionSpecification.OperatorFrom);
                }
                if (dgvInspectionSpecification.OperatorTo == GlobalMasterDataTypeEnum.OPERATOR_LESSTHAN.GetValue())
                {
                    this.OperatorTo_txt.Text = GlobalMasterDataTypeEnum.OPERATOR_LESSTHAN.ToString();
                }
                //this.InspectionItem_cmb.SelectedValue = Convert.ToInt32(dgvInspectionSpecification.InspectionItemId.ToString());

                this.InspectionItem_cmb.Text = InspectionItemName;

                this.SpecificationResultJudgeType_cmb.SelectedValue = Convert.ToInt32(dgvInspectionSpecification.SpecificationResultJudgeType.ToString());

                inspectionspecificationid = dgvInspectionSpecification.InspectionSpecificationId;

                InspectionSpecificationCode = dgvInspectionSpecification.InspectionSpecificationCode;

                Delete_btn.Enabled = true;

                if (Operator_cmb.SelectedValue != null && Operator_cmb.SelectedValue.ToString() == GlobalMasterDataTypeEnum.OPERATOR_GREATERTHAN.GetValue())
                {
                    ValueTo_txt.ReadOnly = false;
                    DateTo_dtp.Enabled = true;
                }
            }
        }

        private void VisibleControlBasedonDataType()
        {
            if (InspectionItemDataType > 0)
            {
                if (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DATETIME.GetValue()))
                {
                    ItemDataType_txt.Text = GlobalMasterDataTypeEnum.DATATYPE_DATETIME.ToString();
                    Value_pnl.Visible = false;
                    DateTime_pnl.Visible = true;
                    DateTo_dtp.Clear();
                }
                else if (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DECIMAL.GetValue()))
                {
                    ItemDataType_txt.Text = GlobalMasterDataTypeEnum.DATATYPE_DECIMAL.ToString();
                }
                else if (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_OK_NG.GetValue()))
                {
                    ItemDataType_txt.Text = GlobalMasterDataTypeEnum.DATATYPE_OK_NG.ToString();
                    Operator_cmb.Enabled = false;
                    ValueFrom_txt.ReadOnly = true;
                    ValueFrom_txt.Text = "0";
                }
                else if (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_STRING.GetValue()))
                {
                    ItemDataType_txt.Text = GlobalMasterDataTypeEnum.DATATYPE_STRING.ToString();
                    Operator_cmb.Enabled = false;
                    ValueFrom_txt.ReadOnly = true;
                    ValueFrom_txt.Text = "0";
                }
                else if (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_IMAGE.GetValue()))
                {
                    ItemDataType_txt.Text = GlobalMasterDataTypeEnum.DATATYPE_IMAGE.ToString();
                    Operator_cmb.Enabled = false;
                    ValueFrom_txt.ReadOnly = true;
                    ValueFrom_txt.Text = "0";
                }
                else if (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_NUMBER.GetValue()))
                {
                    ItemDataType_txt.Text = GlobalMasterDataTypeEnum.DATATYPE_NUMBER.ToString();
                }
                else if (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_SELECTION.GetValue()))
                {
                    ItemDataType_txt.Text = GlobalMasterDataTypeEnum.DATATYPE_SELECTION.ToString();
                    Operator_cmb.Enabled = false;
                    ValueFrom_txt.ReadOnly = true;
                    ValueFrom_txt.Text = "0";
                }
            }
        }

        /// <summary>
        /// Loads inspectionitem details to datatable
        /// </summary>
        private void FormDatatableFromVo()
        {
            inspectionitemDatatable = new DataTable();
            inspectionitemDatatable.Columns.Add("Id");
            inspectionitemDatatable.Columns.Add("Name");

            ValueObjectList<InspectionItemVo> inspectionItemOutVo = null;
            InspectionItemVo inVo = new InspectionItemVo();
            //inVo.InspectionProcessId = InspectionProcessId;

            try
            {

                inspectionItemOutVo = (ValueObjectList<InspectionItemVo>)base.InvokeCbm(new GetInspectionItemMasterCbm(), inVo, false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (inspectionItemOutVo == null || inspectionItemOutVo.GetList() == null || inspectionItemOutVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            foreach (InspectionItemVo fac in inspectionItemOutVo.GetList())
            {
                inspectionitemDatatable.Rows.Add(fac.InspectionItemId, fac.InspectionItemName);
            }

        }

        /// <summary>
        /// For binding Country and Language controls from XML file
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind(ComboBox pCombo, DataTable pDatasource, string pDisplay, string pValue)
        {
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.DataSource = pDatasource;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        /// <summary>
        /// Load Data type
        /// </summary>
        /// <param name="pCombo"></param>
        private void LoadJudgeTypeCombo(ComboBox pCombo)
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "AUTO");
            comboSource.Add(2, "MANUAL");

            pCombo.DisplayMember = "Value";
            pCombo.ValueMember = "Key";
            pCombo.DataSource = new BindingSource(comboSource, null);
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        /// <summary>
        /// checks duplicate Inspection Specification code
        /// </summary>
        /// <returns></returns>
        private InspectionSpecificationVo DuplicateCheck(InspectionSpecificationVo InsSpecVo)
        {
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

            return outVo;
        }

        /// <summary>
        /// To get the Format Id based on item id
        /// </summary>
        /// <param name="inspectionprocessid"></param>
        /// <returns></returns>
        private InspectionFormatVo FormFormatVo(int inspectionitemid)
        {
            InspectionFormatVo outVo = null;
            CopyInspectionFormatVo inVo = new CopyInspectionFormatVo();
            inVo.InspectionItemId = inspectionitemid;
            try
            {
                outVo = (InspectionFormatVo)base.InvokeCbm(new GetInspectionFormatDetailForCopyFunctionMasterMntCbm(), inVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            if (outVo != null && outVo.InspectionFormatId > 0)
            {
                outVo.InspectionFormatCode = outVo.InspectionFormatCode.Substring(0, outVo.InspectionFormatCode.Length - 6);
                outVo.InspectionFormatIdCopy = outVo.InspectionFormatId;
            }
            return outVo;
        }

        #endregion

        #region ButtonClick
        /// <summary>
        /// inserts new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            InspectionSpecificationVo inVo = new InspectionSpecificationVo();
            var sch = StringCheckHelper.GetInstance();
            if (!CheckMandatory()) return;

            inVo.InspectionSpecificationText = InspectionSpecificationText_txt.Text.Trim();

            if (InspectionItemDataType == Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DATETIME.GetValue()) && DateTime_pnl.Visible)
            {
                inVo.ValueFrom = DateFrom_dtp.Value.ToString();
                if (!string.IsNullOrEmpty(DateTo_dtp.Text.Trim()))
                {
                    inVo.ValueTo = DateTo_dtp.Value.ToString();
                }
            }
            else
            {
                inVo.ValueFrom = ValueFrom_txt.Text;
                if (!string.IsNullOrWhiteSpace(ValueTo_txt.Text.Trim()))
                {
                    inVo.ValueTo = ValueTo_txt.Text;
                }
            }

            inVo.Unit = Unit_txt.Text.Trim();

            if (Operator_cmb.SelectedIndex > -1)
            {
                inVo.OperatorFrom = Operator_cmb.SelectedValue.ToString();
            }
            if (!string.IsNullOrWhiteSpace(OperatorTo_txt.Text.Trim()))
            {
                inVo.OperatorTo = GlobalMasterDataTypeEnum.OPERATOR_LESSTHAN.GetValue();
            }

            //inVo.InspectionItemId = Convert.ToInt32(InspectionItem_cmb.SelectedValue.ToString());

            inVo.InspectionItemId = InspectionItemId;

            inVo.SpecificationResultJudgeType = Convert.ToInt32(SpecificationResultJudgeType_cmb.SelectedValue.ToString());

            if (mode.Equals(CommonConstants.MODE_UPDATE))
            {
                inVo.InspectionSpecificationId = inspectionspecificationid;
            }

            inVo.Mode = mode;

            //InspectionSpecificationVo checkVo = DuplicateCheck(inVo);
            //if (checkVo != null && checkVo.AffectedCount > 0)
            //{
            //    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionSpecificationCode_lbl.Text + " : " + InspectionSpecificationCode_txt.Text +
            //                                                        Environment.NewLine + " OR " + Environment.NewLine + InspectionItem_lbl.Text + " : " + InspectionItem_cmb.Text);
            //    logger.Info(messageData);
            //    popUpMessage.ConfirmationOkCancel(messageData, Text);

            //    return;
            //}


            if (string.Equals(mode, CommonConstants.MODE_ADD) || string.Equals(mode, CommonConstants.MODE_SELECT))
            {
                inVo.InspectionSpecificationCode = InspectionItemCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + GlobalMasterDataTypeEnum.SPECIFICATION_CODE.GetValue();

                UpdateResultVo outVo = null;
                try
                {
                    outVo = (UpdateResultVo)base.InvokeCbm(new AddInspectionSpecificationMasterMntCbm(), inVo, false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                if (outVo == null) return;
                IntSuccess = outVo.AffectedCount;
            }
            else if (mode.Equals(CommonConstants.MODE_UPDATE))
            {
                inVo.InspectionSpecificationCode = InspectionSpecificationCode;

                //InspectionSpecificationVo outVo = (InspectionSpecificationVo)base.InvokeCbm(new UpdateInspectionSpecificationMasterMntCbm(), inVo, false);


                string message = string.Format(Properties.Resources.mmci00037, "Inspection Specification", InspectionSpecificationText_txt.Text);
                StartProgress(message);

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                InspectionFormatVo passformatVo = FormFormatVo(inVo.InspectionItemId);
                if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                inVoList.add(passformatVo);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(inVo);
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
                    IntSuccess = outVo.AffectedCount;
                    InspectionItemId = outVo.InspectionItemId;
                }
            }
            if ((IntSuccess > 0))
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                this.Close();
            }
        }



        /// <summary>
        /// form close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            InspectionItemId = -1;
            Close();
        }

        #endregion

        #region FormEvents 
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddInspectionProcessForm_Load(object sender, EventArgs e)
        {
            //FormDatatableFromVo();

            //ComboBind(InspectionItem_cmb, inspectionitemDatatable, "Name", "Id");

            InspectionItem_cmb.Text = InspectionItemName;

            LoadJudgeTypeCombo(SpecificationResultJudgeType_cmb);

            LoadOperatorCombo();

            VisibleControlBasedonDataType();

            InspectionSpecificationText_txt.Select();

            if (CheckDataExist()) return;

            //InspectionItem_cmb.SelectedValue = InspectionItemId;
        }

        private void ValueFrom_txt_TextChanged(object sender, EventArgs e)
        {
            if (ValueFrom_txt.Text == string.Empty)
            {
                previousValueFrom = string.Empty;
            }

            if (!Regex.IsMatch(ValueFrom_txt.Text, @"^\d{0,12}(\.\d{0,3})?$"))
            {
                ValueFrom_txt.Text = previousValueFrom;
                ValueFrom_txt.SelectionStart = cursorStart;
            }
            else
            {
                previousValueFrom = ValueFrom_txt.Text;
            }
        }

        private void LoadOperatorCombo()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.OPERATOR_GREATERTHAN.GetValue()), GlobalMasterDataTypeEnum.OPERATOR_GREATERTHAN.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.OPERATOR_LESSTHAN.GetValue()), GlobalMasterDataTypeEnum.OPERATOR_LESSTHAN.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.OPERATOR_EQUAL.GetValue()), GlobalMasterDataTypeEnum.OPERATOR_EQUAL.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.OPERATOR_MIN.GetValue()), GlobalMasterDataTypeEnum.OPERATOR_MIN.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.OPERATOR_MAX.GetValue()), GlobalMasterDataTypeEnum.OPERATOR_MAX.ToString());
            //comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.OPERATOR_OK_NG.GetValue()), GlobalMasterDataTypeEnum.OPERATOR_OK_NG.ToString());

            Operator_cmb.DataSource = new BindingSource(comboSource, null);
            Operator_cmb.DisplayMember = "Value";
            Operator_cmb.ValueMember = "Key";
            Operator_cmb.SelectedIndex = -1;
        }

        private void ValueFrom_txt_KeyDown(object sender, KeyEventArgs e)
        {
            cursorStart = ((TextBox)sender).SelectionStart;
        }

        private void ValueTo_txt_TextChanged(object sender, EventArgs e)
        {
            if (ValueTo_txt.Text == string.Empty)
            {
                previousValueTo = string.Empty;
            }

            if (!Regex.IsMatch(ValueTo_txt.Text, @"^\d{0,12}(\.\d{0,3})?$"))
            {
                ValueTo_txt.Text = previousValueTo;
                ValueTo_txt.SelectionStart = cursorStart;
            }
            else
            {
                previousValueTo = ValueTo_txt.Text;
            }
        }

        private void ValueTo_txt_KeyDown(object sender, KeyEventArgs e)
        {
            cursorStart = ((TextBox)sender).SelectionStart;
        }

        private bool CheckDataExist()
        {
            InspectionSpecificationVo inVo = new InspectionSpecificationVo();
            inVo.InspectionItemId = InspectionItemId;

            ValueObjectList<InspectionSpecificationVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionSpecificationVo>)base.InvokeCbm(new GetInspectionSpecificationMasterMntCbm(), inVo, false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
            {
                return false;
            }
            mode = CommonConstants.MODE_UPDATE;
            LoadInspectionSpecificationData(outVo.GetList()[0]);
            return true;
        }

        #endregion

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (!CheckMandatory()) return;
            if (inspectionspecificationid <= 0)
            {
                messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, "InspectionSpecificationId");
                popUpMessage.Warning(messageData, Text);
                return;
            }
            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, InspectionSpecificationText_txt.Text);
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {

                InspectionSpecificationVo inVo = new InspectionSpecificationVo();

                inVo.InspectionSpecificationId = inspectionspecificationid;
                inVo.InspectionItemId = InspectionItemId;
                inVo.DeleteFlag = true;

                string message = string.Format(Properties.Resources.mmci00038, "Inspection Specification", InspectionSpecificationText_txt.Text);
                StartProgress(message);

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                InspectionFormatVo passformatVo = FormFormatVo(InspectionItemId);
                if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                inVoList.add(passformatVo);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(inVo);
                inVoList.add(null);
                inVoList.add(null);

                InspectionReturnVo outVo = new InspectionReturnVo();

                try
                {
                     outVo = (InspectionReturnVo)base.InvokeCbm(new UpdateAllInspectionFunctionMasterMntCbm(), inVoList, false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }
                finally
                {
                    CompleteProgress();
                }
                if (outVo == null) { return; }
                InspectionItemId = outVo.InspectionItemId;

                this.messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                logger.Info(this.messageData);
                popUpMessage.Information(this.messageData, Text);

                this.Close();
                //try
                //{

                //    InspectionSpecificationVo outVo = (InspectionSpecificationVo)base.InvokeCbm(new DeleteInspectionSpecificationMasterMntCbm(), inVo, false);

                //    if (outVo.AffectedCount > 0)
                //    {
                //        this.messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                //        logger.Info(this.messageData);
                //        popUpMessage.Information(this.messageData, Text);
                //    }
                //    else if (outVo.AffectedCount == 0)
                //    {
                //        messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                //        logger.Info(messageData);
                //        popUpMessage.Information(messageData, Text);
                //    }
                //}
                //catch (Framework.ApplicationException exception)
                //{
                //    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                //    logger.Error(exception.GetMessageData());
                //}

            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //do something else
            }
        }

        private void Operator_cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Operator_cmb.SelectedIndex < 0) return;
            if (Operator_cmb.SelectedValue.ToString() == GlobalMasterDataTypeEnum.OPERATOR_GREATERTHAN.GetValue())
            {
                OperatorTo_txt.Text = GlobalMasterDataTypeEnum.OPERATOR_LESSTHAN.ToString();
                ValueTo_txt.ReadOnly = false;
                ValueFrom_txt.ReadOnly = false;
                DateTo_dtp.Enabled = true;
            }
            else
            {
                OperatorTo_txt.Text = string.Empty;
                ValueTo_txt.Text = string.Empty;
                ValueTo_txt.ReadOnly = true;
                ValueFrom_txt.ReadOnly = false;
                DateTo_dtp.Enabled = false;
                DateTo_dtp.Clear();
            }
        }
    }
}
