using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddInspectionProcessForFormatForm
    {
        #region Variables 

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly InspectionProcessVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// inspectionformat details table
        /// </summary>
        private DataTable inspectionformatDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInspectionProcessForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// get Running Number
        /// </summary>
        private int RunningNumber;

        /// <summary>
        /// InspectionFormatId
        /// </summary>
        public int InspectionprocessId;

        /// <summary>
        /// For update and delete
        /// </summary>
        public int ReturnFormatId;

        ///// <summary>
        ///// InspectionFormatVo
        ///// </summary>
        //private ValueObjectList<InspectionFormatVo> inspectionFormatOutVo = null;

        #endregion

        #region Constructor 
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddInspectionProcessForFormatForm(string pmode, InspectionProcessVo userItem = null)
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
            if (InspectionProcessName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionProcessName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionProcessName_txt.Focus();

                return false;
            }

            //if (InspectionFormat_cmb.Text == string.Empty || InspectionFormat_cmb.SelectedIndex < 0)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionFormat_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    InspectionFormat_cmb.Focus();

            //    return false;
            //}

            if (InspectionProcessDisplayOrder_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionProcessDisplayOrder_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionProcessDisplayOrder_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Loads selected data from data grid
        /// </summary>
        /// <param name="dgvInspectionProcess"></param>
        private void LoadInspectionProcessData(InspectionProcessVo dgvInspectionProcess)
        {
            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.InspectionProcessName_txt.Text = dgvInspectionProcess.InspectionProcessName;

                //this.InspectionFormat_cmb.SelectedValue = dgvInspectionProcess.InspectionFormatId.ToString();
                this.InspectionFormat_cmb.Text = updateData.InspectionFormatName;

                this.InspectionProcessDisplayOrder_txt.Text = dgvInspectionProcess.DisplayOrder.ToString();
            }
            else
            {
                //this.InspectionFormat_cmb.SelectedValue = dgvInspectionProcess.InspectionFormatId.ToString();
                this.InspectionFormat_cmb.Text = updateData.InspectionFormatName;
            }
        }

        ///// <summary>
        ///// Loads inspectionformat details to datatable
        ///// </summary>
        //private void FormDatatableFromVo()
        //{
        //    inspectionformatDatatable = new DataTable();
        //    inspectionformatDatatable.Columns.Add("Id");
        //    inspectionformatDatatable.Columns.Add("Name");

        //    try
        //    {
        //        inspectionFormatOutVo = (ValueObjectList<InspectionFormatVo>)base.InvokeCbm(new GetInspectionFormatMasterMntCbm(), new InspectionFormatVo(), false);
        //    }
        //    catch (Framework.ApplicationException exception)
        //    {
        //        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
        //        logger.Error(exception.GetMessageData());
        //    }

        //    if (inspectionFormatOutVo == null || inspectionFormatOutVo.GetList() == null || inspectionFormatOutVo.GetList().Count == 0)
        //    {
        //        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
        //        logger.Info(messageData);
        //        popUpMessage.Information(messageData, Text);
        //        return;
        //    }

        //    foreach (InspectionFormatVo fac in inspectionFormatOutVo.GetList())
        //    {
        //        inspectionformatDatatable.Rows.Add(fac.InspectionFormatId, fac.InspectionFormatName);
        //    }

        //}

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
        /// checks duplicate Inspection Process code
        /// </summary>
        /// <returns></returns>
        private InspectionProcessVo DuplicateCheck(InspectionProcessVo InsProcessVo)
        {
            InspectionProcessVo outVo = new InspectionProcessVo();

            try
            {
                outVo = (InspectionProcessVo)base.InvokeCbm(new CheckInspectionProcessMasterMntCbm(), InsProcessVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        /// <summary>
        /// checks duplicate Display Record
        /// </summary>
        /// <param name="defectVo"></param>
        /// <returns></returns>
        private InspectionProcessVo DuplicateDisplayCheck(InspectionProcessVo defectVo)
        {
            InspectionProcessVo outVo = new InspectionProcessVo();

            try
            {
                outVo = (InspectionProcessVo)base.InvokeCbm(new CheckInspectionProcessWorkDisplayOrderCbm(), defectVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        private void checkRunningCount(InspectionProcessVo inVo)
        {
            InspectionProcessVo outVo = new InspectionProcessVo();

            try
            {
                outVo = (InspectionProcessVo)base.InvokeCbm(new GetInspectionProcessSeqCbm(), inVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            RunningNumber = 1;

            if (outVo != null && outVo.InspectionProcessCode != null)
            {
                string strTemp;
                strTemp = outVo.InspectionProcessCode;
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
        /// To get the Format Id based on Process id
        /// </summary>
        /// <param name="inspectionprocessid"></param>
        /// <returns></returns>
        private InspectionFormatVo FormFormatVo(int inspectionprocessid)
        {
            InspectionFormatVo outVo = null;
            CopyInspectionFormatVo inVo = new CopyInspectionFormatVo();
            inVo.InspectionProcessId = inspectionprocessid;
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
            InspectionProcessVo inVo = new InspectionProcessVo();
            var sch = StringCheckHelper.GetInstance();
            if (!CheckMandatory()) return;

            inVo.InspectionProcessName = InspectionProcessName_txt.Text.Trim();

            inVo.InspectionFormatId = updateData.InspectionFormatId; // Convert.ToInt32(InspectionFormat_cmb.SelectedValue.ToString());

            inVo.DisplayOrder = Convert.ToInt32(InspectionProcessDisplayOrder_txt.Text);

            if (string.Equals(mode, CommonConstants.MODE_ADD))
            {
                InspectionProcessVo checkVo = DuplicateCheck(inVo);
                if (checkVo != null && checkVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionProcessName_lbl.Text + " : " + InspectionProcessName_txt.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }

                InspectionProcessVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionProcessDisplayOrder_lbl.Text + " : " + InspectionProcessDisplayOrder_txt.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    InspectionProcessDisplayOrder_txt.Focus();
                    return;
                }

                if (InspectionprocessId == 0)
                {
                    inVo.InspectionProcessCode = updateData.InspectionFormatCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + GlobalMasterDataTypeEnum.PROCESS_CODE.GetValue() + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + RunningNumber;
                    InspectionProcessVo outVo = null;
                    try
                    {
                        outVo = (InspectionProcessVo)base.InvokeCbm(new AddInspectionProcessMasterMntCbm(), inVo, false);
                    }
                    catch (Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                        return;
                    }
                    if (outVo == null) return;
                    IntSuccess = outVo.InspectionProcessId;
                }
                else
                {
                    inVo.InspectionProcessIdCopy = InspectionprocessId;
                    //InspectionFormatVo getformatvo = inspectionFormatOutVo.GetList().Where(t => t.InspectionFormatId == inVo.InspectionFormatId).FirstOrDefault();
                    //if (getformatvo == null) return;

                    string message = string.Format(Properties.Resources.mmci00036, CopyProcess_txt.Text);
                    base.StartProgress(message);

                    inVo.InspectionFormatCode = updateData.InspectionFormatCode; // getformatvo.InspectionFormatCode;
                    inVo.SequenceNo = RunningNumber;

                    ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                    inVoList.add(null);
                    inVoList.add(inVo);
                    inVoList.add(null);
                    inVoList.add(null);
                    inVoList.add(null);
                    inVoList.add(null);
                    inVoList.add(null);
                    InspectionReturnVo OutVo = null;
                    try
                    {
                        OutVo = (InspectionReturnVo)base.InvokeCbm(new CopyInspectionFormatMasterMntCbm(), inVoList, false);
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
                        IntSuccess = OutVo.InspectionProcessId;
                        ReturnFormatId = OutVo.InspectionFormatId;
                    }
                }

            }
            else if (mode.Equals(CommonConstants.MODE_UPDATE))
            {
                if (InspectionProcessName_txt.Text == updateData.InspectionProcessName && InspectionProcessDisplayOrder_txt.Text == updateData.DisplayOrder.ToString())
                {
                    return;
                }
                if (InspectionProcessName_txt.Text != updateData.InspectionProcessName)
                {
                    InspectionProcessVo checkVo = DuplicateCheck(inVo);
                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionProcessName_lbl.Text + " : " + InspectionProcessName_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                        return;
                    }
                }
                if (InspectionProcessDisplayOrder_txt.Text != updateData.DisplayOrder.ToString())
                {
                    InspectionProcessVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                    if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionProcessDisplayOrder_lbl.Text + " : " + InspectionProcessDisplayOrder_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        InspectionProcessDisplayOrder_txt.Focus();
                        return;
                    }
                }

                inVo.InspectionProcessId = updateData.InspectionProcessId;
                inVo.InspectionProcessCode = updateData.InspectionProcessCode;

                string message = string.Format(Properties.Resources.mmci00037, "Inspection Process", InspectionProcessName_txt.Text);
                StartProgress(message);

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                InspectionFormatVo passformatVo = FormFormatVo(updateData.InspectionProcessId);
                if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                inVoList.add(passformatVo);
                inVoList.add(inVo);
                inVoList.add(null);
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
                    IntSuccess = outVo.InspectionProcessId;
                    ReturnFormatId = outVo.InspectionFormatId;
                }
            }
            if (IntSuccess > 0)
            {
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
        private void AddInspectionProcessForm_Load(object sender, EventArgs e)
        {
            //FormDatatableFromVo();

            //ComboBind(InspectionFormat_cmb, inspectionformatDatatable, "Name", "Id");

            if (updateData != null && updateData.InspectionProcessIdCopy > 0)
            {
                InspectionprocessId = updateData.InspectionProcessIdCopy;

                CopyProcess_txt.Text = updateData.InspectionProcessName;
            }

            InspectionProcessName_txt.Select();
            if (updateData != null)
            {
                LoadInspectionProcessData(updateData);
            }

            if (string.Equals(mode, CommonConstants.MODE_ADD))
            {
                InspectionProcessVo outVo = (InspectionProcessVo)base.InvokeCbm(new GetInspectionProcessDisplayOrderNextValCbm(), updateData, false);
                if (outVo != null && outVo.DisplayOrder > 0)
                {
                    InspectionProcessDisplayOrder_txt.Text = outVo.DisplayOrder.ToString();
                }
                else
                {
                    InspectionProcessDisplayOrder_txt.Text = "1";
                }

                InspectionProcessVo inVo = new InspectionProcessVo();
                inVo.InspectionFormatId = updateData.InspectionFormatId;
                checkRunningCount(inVo);
            }
            else
            {
                CopyProcess_btn.Enabled = false;
                CopyProcess_txt.ReadOnly = true;
                CopyProcess_txt.Enabled = false;
            }
        }

        private void CopyFormat_btn_Click(object sender, EventArgs e)
        {
            InspectionProcessListForm frm = new InspectionProcessListForm();
            frm.ShowDialog();

            InspectionprocessId = frm.InspectionProcessId;

            CopyProcess_txt.Text = frm.InspectionProcessName;
        }

        #endregion


    }
}
