using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddInspectionTestInstructionDetailForm
    {

        #region property

        /// <summary>
        /// get or set InspectionTestInstructionId
        /// </summary>
        public int InspectionTestInstructionId { get; set; }        

        /// <summary>
        /// get or set InspectionTestInstructionCode
        /// </summary>
        public string InspectionTestInstructionCode { get; set; }

        /// <summary>
        /// get or set InspectionTestInstructionCode
        /// </summary>
        public string InspectionTestInstructionText { get; set; }
        
        #endregion


        #region Variables 

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly InspectionTestInstructionVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// inspectionformat details table
        /// </summary>
        private DataTable inspectionTestInstructionDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInspectionTestInstructionDetailForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// get Running Number
        /// </summary>
        private int RunningNumber;

        #endregion

        #region Constructor 
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddInspectionTestInstructionDetailForm(string pmode, InspectionTestInstructionVo userItem = null)
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
            //if (InspectionTestInstructionId_cmb.Text == string.Empty || InspectionTestInstructionId_cmb.SelectedIndex < 0)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionTestInstructionId_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    InspectionTestInstructionId_cmb.Focus();

            //    return false;
            //}

            if (InspectionTestInstructionDetailText_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionTestInstructionDetailText_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionTestInstructionDetailText_txt.Focus();

                return false;
            }

            if (InspectionTestInstructionDetailResultCount_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionTestInstructionDetailResultCount_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionTestInstructionDetailResultCount_txt.Focus();

                return false;
            }
            //if (InspectionTestInstructionDetailMachine_txt.Text == string.Empty)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionTestInstructionDetailMachine_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    InspectionTestInstructionDetailMachine_txt.Focus();

            //    return false;
            //}                   

            return true;
        }

        /// <summary>
        /// Loads selected data from data grid
        /// </summary>
        /// <param name="dgvInspectionTestInstruction"></param>
        private void LoadInspectionTestInstructionData(InspectionTestInstructionVo dgvInspectionTestInstruction)
        {
            if (dgvInspectionTestInstruction != null)
            {
                //this.InspectionTestInstructionId_cmb.SelectedValue = dgvInspectionTestInstruction.InspectionTestInstructionId;
                InspectionTestInstructionId = dgvInspectionTestInstruction.InspectionTestInstructionId;

                this.InspectionTestInstructionDetailText_txt.Text = dgvInspectionTestInstruction.InspectionTestInstructionDetailText;

                this.InspectionTestInstructionDetailResultCount_txt.Text = dgvInspectionTestInstruction.InspectionTestInstructionDetailResultCount.ToString();

                this.InspectionTestInstructionDetailMachine_txt.Text = dgvInspectionTestInstruction.InspectionTestInstructionDetailMachine.ToString();
            }
        }

        /// <summary>
        /// Loads inspectionitem details to datatable
        /// </summary>
        private void FormDatatableFromVo()
        {
            inspectionTestInstructionDatatable = new DataTable();
            inspectionTestInstructionDatatable.Columns.Add("Id");
            inspectionTestInstructionDatatable.Columns.Add("Name");

            ValueObjectList<InspectionTestInstructionVo> inspectionTestInstructionOutVo = null;

            try
            {
                inspectionTestInstructionOutVo = (ValueObjectList<InspectionTestInstructionVo>)base.InvokeCbm(new GetInspectionTestInstructionMasterCbm(), new InspectionTestInstructionVo(), false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (inspectionTestInstructionOutVo == null || inspectionTestInstructionOutVo.GetList() == null || inspectionTestInstructionOutVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            foreach (InspectionTestInstructionVo fac in inspectionTestInstructionOutVo.GetList())
            {
                inspectionTestInstructionDatatable.Rows.Add(fac.InspectionTestInstructionId, fac.InspectionTestInstructionText);
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
        private void LoadDataTypeCombo(ComboBox pCombo)
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DECIMAL.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_DECIMAL.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_OK_NG.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_OK_NG.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_STRING.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_STRING.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_IMAGE.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_IMAGE.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_NUMBER.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_NUMBER.ToString());
            comboSource.Add(Convert.ToInt32(GlobalMasterDataTypeEnum.DATATYPE_DATETIME.GetValue()), GlobalMasterDataTypeEnum.DATATYPE_DATETIME.ToString());

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
        private InspectionTestInstructionVo DuplicateCheck(InspectionTestInstructionVo InsTestInstructionVo)
        {
            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo();

            try
            {
                outVo = (InspectionTestInstructionVo)base.InvokeCbm(new CheckInspectionTestInstructionDetailMasterMntCbm(), InsTestInstructionVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        private void checkRunningCount(InspectionTestInstructionVo inVo)
        {
            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo();

            try
            {
                outVo = (InspectionTestInstructionVo)base.InvokeCbm(new GetInspectionTestInstructionDetailSeqCbm(), inVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            RunningNumber = 1;

            if (outVo != null && outVo.InspectionTestInstructionDetailCode != null)
            {
                string strTemp;
                strTemp = outVo.InspectionTestInstructionDetailCode;
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

        /// <summary>
        /// To get the Format Id based on Test Instruction
        /// </summary>
        /// <param name="inspectionprocessid"></param>
        /// <returns></returns>
        private InspectionFormatVo FormFormatVo(int testinstructionid)
        {
            InspectionFormatVo outVo = null;
            CopyInspectionFormatVo inVo = new CopyInspectionFormatVo();
            inVo.InspectionTestInstructionId = testinstructionid;
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
            InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();
            var sch = StringCheckHelper.GetInstance();
            if (!CheckMandatory()) return;

            //inVo.InspectionTestInstructionId = Convert.ToInt32(InspectionTestInstructionId_cmb.SelectedValue.ToString());

            inVo.InspectionTestInstructionId = InspectionTestInstructionId;

            inVo.InspectionTestInstructionDetailText = InspectionTestInstructionDetailText_txt.Text.Trim();

            inVo.InspectionTestInstructionDetailResultCount = Convert.ToInt32(InspectionTestInstructionDetailResultCount_txt.Text.ToString());

            inVo.InspectionTestInstructionDetailMachine = InspectionTestInstructionDetailMachine_txt.Text.Trim();

            if (string.Equals(mode, CommonConstants.MODE_ADD))
            {
                InspectionTestInstructionVo checkVo = DuplicateCheck(inVo);

                if (checkVo != null && checkVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionTestInstructionDetailText_lbl.Text + " : " + InspectionTestInstructionDetailText_txt.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);

                    return;
                }
            }
            if (string.Equals(mode, CommonConstants.MODE_ADD))
            {
                inVo.InspectionTestInstructionDetailCode = InspectionTestInstructionCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + GlobalMasterDataTypeEnum.DETAIL_CODE.GetValue() + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + RunningNumber;
                UpdateResultVo outVo = null;
                try
                {
                    outVo = (UpdateResultVo)base.InvokeCbm(new AddInspectionTestInstructionDetailMasterMntCbm(), inVo, false);
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
                if (updateData.InspectionTestInstructionDetailText != InspectionTestInstructionDetailText_txt.Text)
                {
                    InspectionTestInstructionVo checkVo = DuplicateCheck(inVo);
                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionTestInstructionDetailText_lbl.Text + " : " + InspectionTestInstructionDetailText_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                        return;
                    }
                }

                inVo.InspectionTestInstructionDetailId = updateData.InspectionTestInstructionDetailId;
                inVo.InspectionTestInstructionDetailCode = updateData.InspectionTestInstructionDetailCode;

                //InspectionTestInstructionVo outVo = (InspectionTestInstructionVo)base.InvokeCbm(new UpdateInspectionTestInstructionDetailMasterMntCbm(), inVo, false);

                string message = string.Format(Properties.Resources.mmci00037, "Inspection Test Instruction Detail", InspectionTestInstructionDetailText_txt.Text);
                StartProgress(message);

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                InspectionFormatVo passformatVo = FormFormatVo(inVo.InspectionTestInstructionId);
                if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                inVoList.add(passformatVo);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(inVo);

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
                    InspectionTestInstructionId = outVo.InspectionTestInstructionId;
                }
            }

            if (IntSuccess > 0)
            {
                //messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                //popUpMessage.Information(messageData, Text);
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
            Close();
        }

        #endregion

        #region FormEvents 
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddInspectionTestInstructionDetailForm_Load(object sender, EventArgs e)
        {
            //FormDatatableFromVo();

            //ComboBind(InspectionTestInstructionId_cmb, inspectionTestInstructionDatatable, "Name", "Id");

            InspectionTestInstructionId_cmb.Text = InspectionTestInstructionText;

            InspectionTestInstructionId_cmb.Enabled = false;

            InspectionTestInstructionDetailText_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadInspectionTestInstructionData(updateData);
            }
            if (string.Equals(mode, CommonConstants.MODE_ADD))
            {
                //this.InspectionTestInstructionId_cmb.SelectedValue = InspectionTestInstructionId;

                InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();
                inVo.InspectionTestInstructionId = InspectionTestInstructionId;
                checkRunningCount(inVo);

            }
        }

        private void InspectionTestInstructionId_cmb_Leave(object sender, EventArgs e)
        {
            InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();
            //inVo.InspectionTestInstructionId = Convert.ToInt32(InspectionTestInstructionId_cmb.SelectedValue.ToString());

            inVo.InspectionTestInstructionId = InspectionTestInstructionId;

            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo();

            try
            {
                outVo = (InspectionTestInstructionVo)base.InvokeCbm(new CheckInspectionTestInstructionDetailResultCountCbm(), inVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (outVo != null && outVo.AffectedCount > 0)
            {
                InspectionTestInstructionDetailResultCount_txt.Text = outVo.AffectedCount.ToString();
                InspectionTestInstructionDetailResultCount_txt.Enabled = false;
            }
            else
            {
                InspectionTestInstructionDetailResultCount_txt.Text = string.Empty;
                InspectionTestInstructionDetailResultCount_txt.Enabled = true;
            }
        }

        //private void InspectionTestInstructionDetailResultCount_txt_Leave(object sender, EventArgs e)
        //{
        //    if (updateData != null && updateData.InspectionTestInstructionDetailResultCount != Convert.ToInt32("0" + InspectionTestInstructionDetailResultCount_txt.Text))
        //    {
        //        messageData = new MessageData("mmci00023", Properties.Resources.mmci00023, InspectionTestInstructionDetailResultCount_txt.Text, updateData.InspectionTestInstructionDetailResultCount.ToString());
        //        popUpMessage.Information(messageData, Text);
        //    }
        //}

        #endregion

    }
}
