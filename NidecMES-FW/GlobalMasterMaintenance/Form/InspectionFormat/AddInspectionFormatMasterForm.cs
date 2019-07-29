using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddInspectionFormatMasterForm
    {

        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        public string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        public InspectionFormatVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInspectionFormatMasterForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// Vo for item data
        /// </summary>
        public ValueObjectList<SapItemSearchVo> sapItemVo = null;

        /// <summary>
        /// Vo for line data
        /// </summary>
        public ValueObjectList<LineVo> lineOutVo = null;

        /// <summary>
        /// InspectionFormatId
        /// </summary>
        public int InspectionFormatId;

        /// <summary>
        ///  get sapitem value
        /// </summary>
        private SapItemSearchVo sapItemSearchVo = null;

        #endregion

        #region Constructor
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="factoryItem"></param>
        public AddInspectionFormatMasterForm(string pmode, InspectionFormatVo InspectionFormatItem = null)
        {
            InitializeComponent();

            mode = pmode;
            updateData = InspectionFormatItem;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;

                sapItemSearchVo = new SapItemSearchVo();
                sapItemSearchVo.SapItemCode = updateData.SapItemCode;
                sapItemSearchVo.SapItemName = updateData.SapItemName;
                sapItemSearchVo.SapMaterialGroupId = updateData.SapMaterialGroupId;
            }
        }
        public AddInspectionFormatMasterForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        protected bool CheckMandatory()
        {
            //if (ItemId_cmb.Text == string.Empty || ItemId_cmb.SelectedIndex < 0)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemId_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    ItemId_cmb.Focus();

            //    return false;
            //}

            if(ItemCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemId_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ItemCode_txt.Select();

                return false;
            }

            if (LineId_cmb.Text == string.Empty || LineId_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LineId_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                LineId_cmb.Focus();

                return false;
            }

            if (InspectionFormatName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionFormatName_txt.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionFormatName_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// For setting selected factory record into respective controls(textbox and combobox) for update operation
        /// passing selected factory data as parameter 
        /// </summary>
        /// <param name="dgvInspectionFormat"></param>
        private void LoadInspectionFormatData(InspectionFormatVo dgvInspectionFormat)
        {
            if (dgvInspectionFormat != null)
            {
                SampleName_lbl.Text = dgvInspectionFormat.InspectionFormatName;
                if (dgvInspectionFormat.InspectionFormatCode.Length > 5)
                {
                    this.InspectionFormatName_txt.Text = dgvInspectionFormat.InspectionFormatName.Replace(dgvInspectionFormat.InspectionFormatCode.Substring(0, dgvInspectionFormat.InspectionFormatCode.Length - 5), "");
                }
                else
                {
                    this.InspectionFormatName_txt.Text = dgvInspectionFormat.InspectionFormatName;
                }
                //this.ItemId_cmb.SelectedValue = dgvInspectionFormat.SapItemCode;
                this.ItemCode_txt.Text = dgvInspectionFormat.SapItemCode; // + " - " + dgvInspectionFormat.SapItemName;
                this.LineId_cmb.SelectedValue = dgvInspectionFormat.LineCode;
            }
        }

        /// <summary>
        /// checks duplicate FactoryCode
        /// </summary>
        /// <param name="InspFormatVo"></param>
        /// <returns></returns>
        protected InspectionFormatVo DuplicateCheck(InspectionFormatVo InspFormatVo)
        {
            InspectionFormatVo outVo = new InspectionFormatVo();

            try
            {
                outVo = (InspectionFormatVo)base.InvokeCbm(new CheckInspectionFormatforItemLineMasterMntCbm(), InspFormatVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        /// <summary>
        /// checks duplicate FactoryCode
        /// </summary>
        /// <param name="InspFormatVo"></param>
        /// <returns></returns>
        protected InspectionFormatVo DuplicateCheckForUpdate(InspectionFormatVo InspFormatVo)
        {
            InspectionFormatVo outVo = new InspectionFormatVo();

            try
            {
                outVo = (InspectionFormatVo)base.InvokeCbm(new CheckInspectionFormatMasterMntCbm(), InspFormatVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }



        /// <summary>
        /// Loads inspectionformat details to Combo box
        /// </summary>
        private void LoadCombo()
        {
            //StartProgress(Properties.Resources.mmci00009);
            //try
            //{
            //    sapItemVo = (ValueObjectList<SapItemGlobalVo>)base.InvokeCbm(new GetSapItemMasterMntCbm(), new SapItemGlobalVo(), false);
            //    if (sapItemVo == null || sapItemVo.GetList() == null || sapItemVo.GetList().Count == 0)
            //    {
            //        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
            //        logger.Info(messageData);
            //        popUpMessage.Information(messageData, Text);
            //        return;
            //    }
            //    //sapItemVo.GetList().ForEach(t => t.SapItemName = t.SapItemCode + "-" + t.SapItemName);

            //    ItemId_cmb.DisplayMember = "SapItemName";
            //    ItemId_cmb.ValueMember = "SapItemCode";
            //    ItemId_cmb.DataSource = sapItemVo.GetList();
            //    ItemId_cmb.SelectedIndex = -1;
            //}
            //catch (Framework.ApplicationException exception)
            //{
            //    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
            //    logger.Error(exception.GetMessageData());
            //}
            //finally
            //{
            //    CompleteProgress();
            //}          

            try
            {
                lineOutVo = (ValueObjectList<LineVo>)base.InvokeCbm(new GetLineMasterCbm(), new LineVo(), false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (lineOutVo == null || lineOutVo.GetList() == null || lineOutVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            //lineOutVo.GetList().ForEach(t => t.LineName = t.LineCode + "-" + t.LineName);

            LineId_cmb.DisplayMember = "LineName";
            LineId_cmb.ValueMember = "LineCode";
            LineId_cmb.DataSource = lineOutVo.GetList();
            LineId_cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// get sap group id
        /// </summary>
        /// <returns></returns>
        private string getSapItemGroupId()
        {
            Dictionary<string, string> getSapItemGroupName = new Dictionary<string, string>();
            getSapItemGroupName.Add(GlobalMasterDataTypeEnum.CODE_COMMON.GetValue(), GlobalMasterDataTypeEnum.CODE_COMMON.ToString());
            getSapItemGroupName.Add(GlobalMasterDataTypeEnum.CODE_MMC.GetValue(), GlobalMasterDataTypeEnum.CODE_MMC.ToString());
            getSapItemGroupName.Add(GlobalMasterDataTypeEnum.CODE_MDCM.GetValue(),GlobalMasterDataTypeEnum.CODE_MDCM.ToString());
            getSapItemGroupName.Add(GlobalMasterDataTypeEnum.CODE_CMC.GetValue(), GlobalMasterDataTypeEnum.CODE_CMC.ToString());
            getSapItemGroupName.Add(GlobalMasterDataTypeEnum.CODE_FAN.GetValue(), GlobalMasterDataTypeEnum.CODE_FAN.ToString());
            getSapItemGroupName.Add(GlobalMasterDataTypeEnum.CODE_PSC.GetValue(), GlobalMasterDataTypeEnum.CODE_PSC.ToString());

            if (sapItemSearchVo != null && !string.IsNullOrEmpty(sapItemSearchVo.SapMaterialGroupId))
            {
                return getSapItemGroupName[sapItemSearchVo.SapMaterialGroupId];
            }
            else
            {
                ValueObjectList<SapItemSearchVo> outVo = new ValueObjectList<SapItemSearchVo>();
                SapItemSearchVo ItemInVo = new SapItemSearchVo();
                ItemInVo.SapItemCode = ItemCode_txt.Text;

                try
                {
                    outVo = (ValueObjectList<SapItemSearchVo>)DefaultCbmInvoker.Invoke(new GetSapItemSearchCbm(), ItemInVo);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }
                if (outVo != null && outVo.GetList() != null && outVo.GetList().Count > 0 && !string.IsNullOrEmpty(outVo.GetList()[0].SapMaterialGroupId))
                {
                    return getSapItemGroupName[outVo.GetList()[0].SapMaterialGroupId];
                }
            }            

            return null;
        }

        #endregion

        #region FormEvent
        /// <summary>
        /// load screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionFormatMasterForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;            
            LoadCombo();
            //ItemId_cmb.Select();
            ItemCode_txt.Select();

            if (updateData != null && updateData.InspectionFormatIdCopy > 0)
            {
                InspectionFormatId = updateData.InspectionFormatIdCopy;

                CopyFormat_txt.Text = updateData.InspectionFormatName;
            }

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadInspectionFormatData(updateData);

                //ItemId_cmb.Enabled = false;
                ItemSearch_btn.Enabled = false;

                LineId_cmb.Enabled = false;

                CopyFormat_btn.Enabled = false;

                InspectionFormatName_txt.Select();

                ItemCode_txt.Enabled = false;

                CopyFormat_txt.Enabled = false;
            }
            this.Activate();
        }
        #endregion

        #region ButtonClick
        /// <summary>
        /// update data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Ok_btn_Click(object sender, EventArgs e)
        {
            InspectionFormatVo inVo = new InspectionFormatVo();

            if (CheckMandatory())
            {
                if (LineId_cmb.SelectedIndex > -1)
                {
                    inVo.LineCode = LineId_cmb.SelectedValue.ToString();
                    inVo.LineId = lineOutVo.GetList().Where(t => t.LineCode == inVo.LineCode).FirstOrDefault().LineId;
                }
                //if (ItemId_cmb.SelectedIndex > -1)
                //{
                //    inVo.SapItemCode = ItemId_cmb.SelectedValue.ToString();
                //    // inVo.ItemId = globalItemVo.GlobalItemListVo.Where(t => t.GlobalItemCode == inVo.ItemCode).FirstOrDefault().GlobalItemId;
                //}
                if (ItemCode_txt.Text.Trim() != string.Empty)
                {
                    inVo.SapItemCode = ItemCode_txt.Text; // sapItemGlobalVo.SapItemCode;
                }

                string SapitemGroupName = getSapItemGroupId();
                if (SapitemGroupName == null)
                {
                    messageData = new MessageData("mmci00041", Properties.Resources.mmci00041, ItemId_cmb.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }

                inVo.InspectionFormatCode = SapitemGroupName + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + inVo.SapItemCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + inVo.LineCode;
                inVo.InspectionFormatName = inVo.InspectionFormatCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + InspectionFormatName_txt.Text.Trim();

                if (string.Equals(mode, CommonConstants.MODE_ADD.ToString()))
                {
                    GlobalMasterMaintenance.Vo.InspectionFormatVo checkVo = DuplicateCheck(inVo);
                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00040", Properties.Resources.mmci00040, "ITEM LINE", "FORMAT NAME");
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        return;
                    }
                }
                if (string.Equals(mode, CommonConstants.MODE_ADD.ToString()))
                {
                    if (InspectionFormatId == 0)
                    {
                        GlobalMasterMaintenance.Vo.InspectionFormatVo outVo = null;
                        try
                        {
                            outVo = (InspectionFormatVo)base.InvokeCbm(new AddInspectionFormatAndItemLineFormatCbm(), inVo, false);
                        }
                        catch (Framework.ApplicationException exception)
                        {
                            popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                            logger.Error(exception.GetMessageData());
                            return;
                        }
                        if (outVo == null) { return; }
                        IntSuccess = outVo.InspectionFormatId;
                    }
                    else
                    {
                        inVo.InspectionFormatIdCopy = InspectionFormatId;

                        string message = string.Format(Properties.Resources.mmci00042, CopyFormat_txt.Text);
                        base.StartProgress(message);

                        ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                        inVoList.add(inVo);
                        inVoList.add(null);
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
                        if (OutVo == null) { return; }
                        //IntSuccess = OutVo.AffectedCount;
                        IntSuccess = OutVo.InspectionFormatId;
                    }
                }
                else if (string.Equals(mode, CommonConstants.MODE_UPDATE.ToString()))
                {
                    //if (updateData != null) { inVo.InspectionFormatCode = updateData.InspectionFormatCode; }

                    if (InspectionFormatName_txt.Text.Trim() == updateData.InspectionFormatName.Replace(updateData.InspectionFormatCode.Substring(0, updateData.InspectionFormatCode.Length - 5), ""))
                    {
                        return;
                    }
                    GlobalMasterMaintenance.Vo.InspectionFormatVo checkVo = DuplicateCheckForUpdate(inVo);
                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00044", Properties.Resources.mmci00044, InspectionFormatName_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        return;
                    }
                    //inVo.InspectionFormatId = updateData.InspectionFormatId;
                    //inVo.InspectionFormatCode = updateData.InspectionFormatCode;
                    //inVo.InspectionFormatName = inVo.InspectionFormatCode.Substring(0, inVo.InspectionFormatCode.Length - 5)
                    //    + InspectionFormatName_txt.Text.Trim();

                    inVo.InspectionFormatIdCopy = updateData.InspectionFormatId;
                    inVo.Mode = GlobalMasterMaintenance.CommonConstants.MODE_UPDATE;

                    string message = string.Format(Properties.Resources.mmci00043, "Inspection Format", InspectionFormatName_txt.Text);
                    base.StartProgress(message);

                    ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                    inVoList.add(inVo);
                    inVoList.add(null);
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
                    if (outVo == null) { return; }
                    //IntSuccess = outVo.AffectedCount;
                    IntSuccess = outVo.InspectionFormatId;
                }
                if ((IntSuccess > 0))
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Window close when Exit button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BrowseFormat_btn_Click(object sender, EventArgs e)
        {
            InspectionFormatListForm frm = new InspectionFormatListForm();
            frm.ShowDialog();

            InspectionFormatId = frm.InspectionFormatId;

            CopyFormat_txt.Text = frm.InspectionFormatName;

        }

        /// <summary>
        /// Item search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemSearch_btn_Click(object sender, EventArgs e)
        {
            ItemSearchForm newAddForm = new ItemSearchForm();
            newAddForm.ShowDialog();
            sapItemSearchVo = newAddForm.sapItemSearchVo;

            if (sapItemSearchVo != null)
            {
                ItemCode_txt.Text = sapItemSearchVo.SapItemCode; // + " - " + sapItemGlobalVo.SapItemName;
            }
            else
            {
                ItemCode_txt.Text = string.Empty;
            }
        }

        #endregion

    }
}
