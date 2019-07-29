using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddInspectionTestInstructionForItemForm
    {

        #region Variables 

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private string mode;

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
        private DataTable inspectionitemDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInspectionTestInstructionForItemForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// set InspectionTestInstructionId
        /// </summary>
        public int InspectionTestInstructionId;

        /// <summary>
        /// set InspectionTestInstructionCode
        /// </summary>
        private string InspectionTestInstructionCode;

        /// <summary>
        /// set InspectionItemId
        /// </summary>
        public int InspectionItemId;

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
        public AddInspectionTestInstructionForItemForm(string pmode, InspectionTestInstructionVo userItem = null)
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
            if (InspectionTestInstructionText_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionTestInstructionText_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionTestInstructionText_txt.Focus();

                return false;
            }

            //if (InspectionItem_cmb.Text == string.Empty || InspectionItem_cmb.SelectedIndex < 0)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionItem_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    InspectionItem_cmb.Focus();

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
                this.InspectionTestInstructionText_txt.Text = dgvInspectionTestInstruction.InspectionTestInstructionText;

                //this.InspectionItem_cmb.SelectedValue = dgvInspectionTestInstruction.InspectionItemId.ToString();

                this.InspectionItem_cmb.Text = updateData.InspectionItemName;

                InspectionTestInstructionId = dgvInspectionTestInstruction.InspectionTestInstructionId;

                InspectionTestInstructionCode = dgvInspectionTestInstruction.InspectionTestInstructionCode;

                Detail_btn.Enabled = delete_btn.Enabled = true;

                mode = CommonConstants.MODE_UPDATE;
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
            //pCombo.Text = string.Empty;
        }

        /// <summary>
        /// checks duplicate Inspection Specification code
        /// </summary>
        /// <returns></returns>
        private InspectionTestInstructionVo DuplicateCheck(InspectionTestInstructionVo InsSpecVo)
        {
            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo();

            try
            {
                outVo = (InspectionTestInstructionVo)base.InvokeCbm(new CheckInspectionTestInstructionMasterMntCbm(), InsSpecVo, false);
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
            InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();
            var sch = StringCheckHelper.GetInstance();
            if (!CheckMandatory()) return;

            inVo.InspectionTestInstructionText = InspectionTestInstructionText_txt.Text.Trim();

            //inVo.InspectionItemId = Convert.ToInt32(InspectionItem_cmb.SelectedValue.ToString());

            inVo.InspectionItemId = updateData.InspectionItemId;

            inVo.Mode = mode;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                inVo.InspectionTestInstructionId = InspectionTestInstructionId;
            }

            //InspectionTestInstructionVo checkVo = DuplicateCheck(inVo);
            //if (checkVo != null && checkVo.AffectedCount > 0)
            //{
            //    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionTestInstructionCode_lbl.Text + " : " + InspectionTestInstructionCode_txt.Text +
            //                                                                Environment.NewLine + " OR " + Environment.NewLine + InspectionItem_lbl.Text + " : " + InspectionItem_cmb.Text);
            //    logger.Info(messageData);
            //    popUpMessage.ConfirmationOkCancel(messageData, Text);

            //    return;
            //}
            if (string.Equals(mode, CommonConstants.MODE_ADD))
            {
                InspectionTestInstructionCode = updateData.InspectionItemCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + GlobalMasterDataTypeEnum.TEST_INST_CODE.GetValue();
                inVo.InspectionTestInstructionCode = InspectionTestInstructionCode;

                InspectionTestInstructionVo outVo = null;

                try
                {
                    outVo = (InspectionTestInstructionVo)base.InvokeCbm(new AddInspectionTestInstructionMasterMntCbm(), inVo, false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                if (outVo == null) return;
                IntSuccess = outVo.InspectionTestInstructionId;
                InspectionTestInstructionId = outVo.InspectionTestInstructionId;
                mode = CommonConstants.MODE_UPDATE;
            }
            else if (mode.Equals(CommonConstants.MODE_UPDATE))
            {
                inVo.InspectionTestInstructionCode = InspectionTestInstructionCode;

                // InspectionTestInstructionVo outVo = (InspectionTestInstructionVo)base.InvokeCbm(new UpdateInspectionTestInstructionMasterMntCbm(), inVo, false);

                string message = string.Format(Properties.Resources.mmci00037, "Inspection Test Instruction", InspectionTestInstructionText_txt.Text);
                StartProgress(message);

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                InspectionFormatVo passformatVo = FormFormatVo(inVo.InspectionItemId);
                if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                inVoList.add(passformatVo);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(inVo);
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
                    updateData.InspectionItemId = InspectionItemId;
                    InspectionTestInstructionId = outVo.InspectionTestInstructionId;
                    //FormDatatableFromVo();
                    //ComboBind(InspectionItem_cmb, inspectionitemDatatable, "Name", "Id");
                    //InspectionItem_cmb.SelectedValue = InspectionItemId;
                }
            }
            if ((IntSuccess > 0))
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                popUpMessage.Information(messageData, Text);
                Detail_btn.Enabled = delete_btn.Enabled = true;
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
        private void AddInspectionTestInstructionbyItemForm_Load(object sender, EventArgs e)
        {
            //FormDatatableFromVo();

            //ComboBind(InspectionItem_cmb, inspectionitemDatatable, "Name", "Id");

            InspectionItem_cmb.Text = updateData.InspectionItemName;

            InspectionTestInstructionText_txt.Select();

            if (CheckDataExist()) return;

            //InspectionItem_cmb.SelectedValue = updateData.InspectionItemId;
            mode = CommonConstants.MODE_ADD;
        }
        private bool CheckDataExist()
        {
            InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();
            inVo.InspectionItemId = updateData.InspectionItemId;

            ValueObjectList<InspectionTestInstructionVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionTestInstructionVo>)base.InvokeCbm(new GetInspectionTestInstructionMasterMntCbm(), inVo, false);

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
            LoadInspectionTestInstructionData(outVo.GetList()[0]);
            return true;
        }

        #endregion

        private void Detail_btn_Click(object sender, EventArgs e)
        {
            if (InspectionTestInstructionId <= 0)
            {
                messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, "InspectionTestInstructionId");
                popUpMessage.Warning(messageData, Text);
                return;
            }
            //updateData
            InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();
            inVo.InspectionTestInstructionId = InspectionTestInstructionId;
            inVo.InspectionTestInstructionText = InspectionTestInstructionText_txt.Text.Trim();
            inVo.InspectionTestInstructionCode = InspectionTestInstructionCode;

            InspectionTestInstructionDetailForm frm = new GlobalMasterMaintenance.InspectionTestInstructionDetailForm(inVo);
            frm.ShowDialog();
            if (frm.InspectionTestInstructionId > 0)
            {
                InspectionFormatProcessBuzzLogic getprocessid = new InspectionFormatProcessBuzzLogic();
                InspectionReturnVo invo = new InspectionReturnVo();
                invo.InspectionTestInstructionId = frm.InspectionTestInstructionId;
                InspectionTestInstructionId = frm.InspectionTestInstructionId;
                InspectionReturnVo getInspectionVo = getprocessid.RefreshAllFormGrid(invo);
                if (getInspectionVo != null && getInspectionVo.InspectionItemId > 0)
                {
                    InspectionItemId = getInspectionVo.InspectionItemId;
                    updateData.InspectionItemId = InspectionItemId;
                    //FormDatatableFromVo();
                    //ComboBind(InspectionItem_cmb, inspectionitemDatatable, "Name", "Id");
                    //InspectionItem_cmb.SelectedValue = InspectionItemId;
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (!CheckMandatory()) return;
            if (InspectionTestInstructionId <= 0)
            {
                messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, "InspectionTestInstructionId");
                popUpMessage.Warning(messageData, Text);
                return;
            }
            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, InspectionTestInstructionText_txt.Text);
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();

                inVo.InspectionTestInstructionId = InspectionTestInstructionId;
                inVo.InspectionItemId = updateData.InspectionItemId;
                inVo.DeleteFlag = true;

                string message = string.Format(Properties.Resources.mmci00038, "Inspection Test Instruction", InspectionTestInstructionText_txt.Text);
                StartProgress(message);

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                InspectionFormatVo passformatVo = FormFormatVo(updateData.InspectionItemId);
                if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                inVoList.add(passformatVo);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(inVo);
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
                }
                finally
                {
                    CompleteProgress();
                }
                if (outVo == null) { return; }
                 InspectionItemId = outVo.InspectionItemId;

                messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                this.Close();

                //inVo.InspectionTestInstructionCode = InspectionTestInstructionText_txt.Text.Trim();
                //try
                //{

                //    InspectionTestInstructionVo outVo = (InspectionTestInstructionVo)base.InvokeCbm(new DeleteInspectionTestInstructionMasterMntNewCbm(), inVo, false);

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
                // this.Close();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //do something else
            }

        }

    }
}
