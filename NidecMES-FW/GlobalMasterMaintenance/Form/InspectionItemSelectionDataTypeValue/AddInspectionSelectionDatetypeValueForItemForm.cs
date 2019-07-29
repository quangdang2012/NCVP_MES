using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddInspectionSelectionDatetypeValueForItemForm
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
        /// set or get InspectionItemId
        /// </summary>
        public int InspectionProcessId { get; set; }

        ///// <summary>
        ///// set or get InspectionItemDataType
        ///// </summary>
        //public int InspectionItemDataType { get; set; }

        ///// <summary>
        ///// set or get InspectionItemName
        ///// </summary>
        //public string InspectionItemName { get; set; }

        #endregion

        #region Variables 

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private string mode;       

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly InspectionItemSelectionDatatypeValueVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInspectionSelectionDatetypeValueForItemForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;
        
        /// <summary>
        /// get Running Number
        /// </summary>
        private int RunningNumber;      

        /// <summary>
        /// inspectionformat details table
        /// </summary>
        private DataTable inspectionitemDatatable;

        /// <summary>
        /// 
        /// </summary>
        public InspectionItemSelectionDatatypeValueVo UpdateInspectionItemSelectionDatatypeValueVo { get; set; }

        #endregion

        #region Constructor 
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddInspectionSelectionDatetypeValueForItemForm(string pmode, InspectionItemSelectionDatatypeValueVo userItem = null)
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
            if (SelectionDatatypeValueText_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, SelectionDatatypeValueText_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                SelectionDatatypeValueText_txt.Focus();

                return false;
            }
          
            //if (InspectionItem_cmb.Text == string.Empty || InspectionItem_cmb.SelectedIndex < 0)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionItem_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    InspectionItem_cmb.Focus();

            //    return false;
            //}

            if (InspectionItemDisplayOrder_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionItemDisplayOrder_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionItemDisplayOrder_txt.Focus();

                return false;
            }

            return true;
        }

  
        /// <summary>
        /// checks duplicate Inspection Specification code
        /// </summary>
        /// <returns></returns>
        private InspectionItemSelectionDatatypeValueVo DuplicateCheck(InspectionItemSelectionDatatypeValueVo InsSelectedValueVo)
        {
            InspectionItemSelectionDatatypeValueVo outVo = new InspectionItemSelectionDatatypeValueVo();

            try
            {
                outVo = (InspectionItemSelectionDatatypeValueVo)base.InvokeCbm(new CheckInspectionItemSelectionDatatypeValueCbm(), InsSelectedValueVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        private void checkRunningCount(InspectionItemSelectionDatatypeValueVo inVo)
        {
            InspectionItemSelectionDatatypeValueVo outVo = new InspectionItemSelectionDatatypeValueVo();

            try
            {
                outVo = (InspectionItemSelectionDatatypeValueVo)base.InvokeCbm(new GetInspectionItemSelectionDatatypeValueSeqCbm(), inVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            RunningNumber = 1;

            if (outVo != null && outVo.InspectionItemSelectionDatatypeValueCode != null)
            {
                string strTemp;
                strTemp = outVo.InspectionItemSelectionDatatypeValueCode;
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
        /// checks duplicate Display Record
        /// </summary>
        /// <param name="defectVo"></param>
        /// <returns></returns>
        private InspectionItemSelectionDatatypeValueVo DuplicateDisplayCheck(InspectionItemSelectionDatatypeValueVo defectVo)
        {
            InspectionItemSelectionDatatypeValueVo outVo = new InspectionItemSelectionDatatypeValueVo();

            try
            {
                outVo = (InspectionItemSelectionDatatypeValueVo)base.InvokeCbm(new CheckInspectionItemSelectionDatatypeValueDisplayOrderCbm(), defectVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
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
            InspectionItemSelectionDatatypeValueVo inVo = new InspectionItemSelectionDatatypeValueVo();
            var sch = StringCheckHelper.GetInstance();
            if (CheckMandatory() == true)
            {
                inVo.InspectionItemSelectionDatatypeValueText = SelectionDatatypeValueText_txt.Text.Trim();

                inVo.DisplayOrder = Convert.ToInt32(InspectionItemDisplayOrder_txt.Text);

                if (InspectionItem_cmb.SelectedValue != null && InspectionItem_cmb.SelectedIndex >= 0)
                {
                    inVo.InspectionItemId = Convert.ToInt32(InspectionItem_cmb.SelectedValue.ToString());
                }

                if (updateData != null)
                {
                    inVo.InspectionItemId = updateData.InspectionItemId;
                }

                if (mode.Equals(CommonConstants.MODE_UPDATE))
                {
                    inVo.InspectionItemSelectionDatatypeValueId = updateData.InspectionItemSelectionDatatypeValueId;                    
                }

                inVo.Mode = mode;

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD) || string.Equals(mode, CommonConstants.MODE_SELECT))
                    {
                        InspectionItemSelectionDatatypeValueVo checkVo = DuplicateCheck(inVo);
                        if (checkVo != null && checkVo.AffectedCount > 0)
                        {
                            messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, SelectionDatatypeValueText_lbl.Text + " : " + SelectionDatatypeValueText_txt.Text);
                            popUpMessage.Information(messageData, Text);

                            return;
                        }

                        InspectionItemSelectionDatatypeValueVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                        if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                        {
                            messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionItemDisplayOrder_lbl.Text + " : " + InspectionItemDisplayOrder_txt.Text);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);
                            InspectionItemDisplayOrder_txt.Focus();
                            return;
                        }

                        inVo.InspectionItemSelectionDatatypeValueCode = InspectionItemCode 
                                                                        + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() 
                                                                        + GlobalMasterDataTypeEnum.SELECTION_VALUE_CODE.GetValue() + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + RunningNumber;

                        UpdateResultVo outVo = (UpdateResultVo)base.InvokeCbm(new AddInspectionItemSelectionDatatypeValueCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        if(SelectionDatatypeValueText_txt.Text == updateData.InspectionItemSelectionDatatypeValueText && updateData.DisplayOrder == Convert.ToInt32(InspectionItemDisplayOrder_txt.Text))
                        {
                            return;
                        }
                        if (updateData.InspectionItemSelectionDatatypeValueText != SelectionDatatypeValueText_txt.Text)
                        {
                            InspectionItemSelectionDatatypeValueVo checkVo = DuplicateCheck(inVo);
                            if (checkVo != null && checkVo.AffectedCount > 0)
                            {
                                messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, SelectionDatatypeValueText_lbl.Text + " : " + SelectionDatatypeValueText_txt.Text);
                                popUpMessage.Information(messageData, Text);

                                return;
                            }
                        }

                        if (updateData.DisplayOrder != Convert.ToInt32(InspectionItemDisplayOrder_txt.Text))
                        {
                            InspectionItemSelectionDatatypeValueVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                            if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                            {
                                messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionItemDisplayOrder_lbl.Text + " : " + InspectionItemDisplayOrder_txt.Text);
                                logger.Info(messageData);
                                popUpMessage.Information(messageData, Text);
                                InspectionItemDisplayOrder_txt.Focus();
                                return;
                            }
                        }
                        
                        if (updateData == null)
                        {
                            UpdateResultVo outResultVo = (UpdateResultVo)base.InvokeCbm(new UpdateInspectionItemSelectionDatatypeValueCbm(), inVo, false);
                            if (outResultVo == null) { return; }
                            IntSuccess = outResultVo.AffectedCount;
                        }
                        else
                        {
                            string message = string.Format(Properties.Resources.mmci00037, "Inspection Item Selection Datatype Value", SelectionDatatypeValueText_txt.Text);
                            StartProgress(message);

                            ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                            InspectionFormatVo passformatVo = FormFormatVo(updateData.InspectionItemId);
                            if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                            inVoList.add(passformatVo);
                            inVoList.add(null);
                            inVoList.add(null);
                            inVoList.add(inVo);
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
                                IntSuccess = outVo.AffectedCount;
                                InspectionItemId = outVo.InspectionItemId;

                                InspectionFormatProcessBuzzLogic getprocessid = new InspectionFormatProcessBuzzLogic();
                                InspectionReturnVo invo = new InspectionReturnVo();
                                invo.InspectionItemId = outVo.InspectionItemId;
                                InspectionReturnVo getInspectionVo = getprocessid.RefreshAllFormGrid(invo);
                                if (getInspectionVo != null && getInspectionVo.InspectionProcessId > 0)
                                {
                                    InspectionProcessId = getInspectionVo.InspectionProcessId;
                                }
                            }
                        }
                        //UpdateInspectionItemSelectionDatatypeValueVo = new InspectionItemSelectionDatatypeValueVo();

                        //UpdateInspectionItemSelectionDatatypeValueVo = inVo;
                        //this.Close();                        
                    }

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }

                if ((IntSuccess > 0))
                {
                    //messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                    //logger.Info(messageData);
                    //popUpMessage.Information(messageData, Text);
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
        private void AddInspectionSelectionDatetypeValueForItemForm_Load(object sender, EventArgs e)
        {
            if (string.Equals(mode, CommonConstants.MODE_ADD))
            {
                InspectionItemSelectionDatatypeValueVo inVo = new InspectionItemSelectionDatatypeValueVo();

                if (updateData != null)
                {
                    inVo.InspectionItemId = updateData.InspectionItemId;
                }                

                InspectionItemSelectionDatatypeValueVo outVo = (InspectionItemSelectionDatatypeValueVo)base.InvokeCbm(new GetInspItemSelectionDatatypeValueDisplayOrderNextValCbm(), inVo, false);
                if (outVo != null && outVo.DisplayOrder > 0)
                {
                    InspectionItemDisplayOrder_txt.Text = outVo.DisplayOrder.ToString();
                }
                else
                {
                    InspectionItemDisplayOrder_txt.Text = "1";
                }
                
                checkRunningCount(inVo);
            }

            SelectionDatatypeValueText_txt.Select();

            if (mode == CommonConstants.MODE_ADD)
            {
                return;
            }
            this.InspectionItem_cmb.Text = updateData.InspectionItemName;

            this.SelectionDatatypeValueText_txt.Text = updateData.InspectionItemSelectionDatatypeValueText;

            this.InspectionItemDisplayOrder_txt.Text = updateData.DisplayOrder.ToString();

            this.InspectionItem_cmb.Text = updateData.InspectionItemName;
        }

        #endregion

    }
}
