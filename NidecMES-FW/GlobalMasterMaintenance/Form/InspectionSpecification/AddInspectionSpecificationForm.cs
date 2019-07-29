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
    public partial class AddInspectionSpecificationForm
    {
        #region Variables 

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInspectionSpecificationForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        string previousValueFrom = string.Empty;

        string previousValueTo = string.Empty;

        private int cursorStart;

        #endregion

        #region Constructor 
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddInspectionSpecificationForm(string pmode, InspectionSpecificationVo userItem = null)
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
            if (InspectionSpecificationCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionSpecificationCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionSpecificationCode_txt.Focus();

                return false;
            }

            if (InspectionSpecificationText_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionSpecificationText_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionSpecificationText_txt.Focus();

                return false;
            }

            if (ValueFrom_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ValueFrom_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ValueFrom_txt.Focus();

                return false;
            }

            if (InspectionItem_cmb.Text == string.Empty || InspectionItem_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionItem_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionItem_cmb.Focus();

                return false;
            }

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
                this.InspectionSpecificationCode_txt.Text = dgvInspectionSpecification.InspectionSpecificationCode;

                this.InspectionSpecificationText_txt.Text = dgvInspectionSpecification.InspectionSpecificationText;

                this.ValueFrom_txt.Text = dgvInspectionSpecification.ValueFrom.ToString();

                //if (dgvInspectionSpecification.ValueTo != null)
                //{                   
                //    this.ValueTo_txt.Text = v1.ToString("#.000");
                //}

                this.Unit_txt.Text = dgvInspectionSpecification.Unit;

                this.OperatorFrom_txt.Text = dgvInspectionSpecification.OperatorFrom;

                this.OperatorTo_txt.Text = dgvInspectionSpecification.OperatorTo;

                this.InspectionItem_cmb.SelectedValue = Convert.ToInt32(dgvInspectionSpecification.InspectionItemId.ToString());

                this.SpecificationResultJudgeType_cmb.SelectedValue = Convert.ToInt32(dgvInspectionSpecification.SpecificationResultJudgeType.ToString());
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

            try
            {

                inspectionItemOutVo = (ValueObjectList<InspectionItemVo>)base.InvokeCbm(new GetInspectionItemMasterCbm(), new InspectionItemVo(), false);

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
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
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

            pCombo.DataSource = new BindingSource(comboSource, null);
            pCombo.DisplayMember = "Value";
            pCombo.ValueMember = "Key";
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
            if (CheckMandatory() == true)
            {
                if (string.IsNullOrEmpty(InspectionSpecificationCode_txt.Text) || string.IsNullOrEmpty(InspectionSpecificationText_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(InspectionSpecificationCode_txt.Text))
                    {
                        InspectionSpecificationCode_txt.Focus();
                    }
                    else if (string.IsNullOrEmpty(InspectionSpecificationText_txt.Text))
                    {
                        InspectionSpecificationText_txt.Focus();
                    }
                    return;
                }

                if (string.Equals(mode, CommonConstants.MODE_SELECT))
                {
                    if (InspectionSpecificationCode_txt.Text == updateData.InspectionSpecificationCode)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionSpecificationCode_lbl.Text + " : " + InspectionSpecificationCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);

                        return;
                    }
                    if (InspectionSpecificationText_txt.Text == updateData.InspectionSpecificationText)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionSpecificationText_lbl.Text + " : " + InspectionSpecificationText_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);

                        return;
                    }
                }

                inVo.InspectionSpecificationCode = InspectionSpecificationCode_txt.Text.Trim();

                inVo.InspectionSpecificationText = InspectionSpecificationText_txt.Text.Trim();

                // inVo.ValueFrom = Convert.ToDecimal(ValueFrom_txt.Text.Trim());

                if (!string.IsNullOrWhiteSpace(ValueTo_txt.Text.Trim()))
                {
                    //  inVo.ValueTo = Convert.ToDecimal(ValueTo_txt.Text.Trim());
                }

                if (!string.IsNullOrWhiteSpace(Unit_txt.Text.Trim()))
                {
                    inVo.Unit = Unit_txt.Text.Trim();
                }

                if (!string.IsNullOrWhiteSpace(OperatorFrom_txt.Text.Trim()))
                {
                    inVo.OperatorFrom = OperatorFrom_txt.Text.Trim();
                }

                if (!string.IsNullOrWhiteSpace(OperatorTo_txt.Text.Trim()))
                {
                    inVo.OperatorTo = OperatorTo_txt.Text.Trim();
                }

                inVo.InspectionItemId = Convert.ToInt32(InspectionItem_cmb.SelectedValue.ToString());

                inVo.SpecificationResultJudgeType = Convert.ToInt32(SpecificationResultJudgeType_cmb.SelectedValue.ToString());

                if (mode.Equals(CommonConstants.MODE_UPDATE))
                {
                    inVo.InspectionSpecificationId = updateData.InspectionSpecificationId;
                }

                inVo.Mode = mode;

                InspectionSpecificationVo checkVo = DuplicateCheck(inVo);

                if (checkVo != null && checkVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionSpecificationCode_lbl.Text + " : " + InspectionSpecificationCode_txt.Text +
                                                                        Environment.NewLine + " OR " + Environment.NewLine + InspectionItem_lbl.Text + " : " + InspectionItem_cmb.Text);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    return;
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD) || string.Equals(mode, CommonConstants.MODE_SELECT))
                    {
                        UpdateResultVo outVo = (UpdateResultVo)base.InvokeCbm(new AddInspectionSpecificationMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        InspectionSpecificationVo outVo = (InspectionSpecificationVo)base.InvokeCbm(new UpdateInspectionSpecificationMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }

                if ((IntSuccess > 0) || (IntSuccess == 0))
                {
                    this.Close();
                }

            }
        }


        /// <summary>
        /// form close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
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
            FormDatatableFromVo();

            ComboBind(InspectionItem_cmb, inspectionitemDatatable, "Name", "Id");

            LoadJudgeTypeCombo(SpecificationResultJudgeType_cmb);

            InspectionSpecificationCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadInspectionSpecificationData(updateData);

                InspectionSpecificationCode_txt.Enabled = false;

                InspectionSpecificationText_txt.Select();
            }
            else if (string.Equals(mode, CommonConstants.MODE_SELECT))
            {
                LoadInspectionSpecificationData(updateData);
            }
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

        #endregion

    }
}
