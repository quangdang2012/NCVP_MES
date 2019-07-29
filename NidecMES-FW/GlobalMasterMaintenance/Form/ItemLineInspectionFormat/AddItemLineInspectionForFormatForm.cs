using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddItemLineInspectionForFormatForm
    {
        #region property
        /// <summary>
        /// get or set FormatId
        /// </summary>
        public int FormatId { get; set; }
        #endregion


        #region Variables 

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly ItemLineInspectionFormatVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        public int ItemLineInspectionFormatId;

        /// <summary>
        /// inspectionformat details table
        /// </summary>
        private DataTable inspectionformatDatatable;

        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable itemDatatable;

        /// <summary>
        /// datatable for line data
        /// </summary>
        private DataTable lineDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddItemLineInspectionForFormatForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor 
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddItemLineInspectionForFormatForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods 

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (ItemId_cmb.Text == string.Empty || ItemId_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemId_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ItemId_cmb.Focus();

                return false;
            }

            if (LineId_cmb.Text == string.Empty || LineId_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LineId_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                LineId_cmb.Focus();

                return false;
            }

            if (InspectionFormat_cmb.Text == string.Empty || InspectionFormat_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionFormat_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionFormat_cmb.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Loads selected data from data grid
        /// </summary>
        /// <param name="dgvInspectionProcess"></param>
        private void LoadInspectionProcessData(ItemLineInspectionFormatVo dgvInspectionProcess)
        {
            if (dgvInspectionProcess != null)
            {
                this.ItemId_cmb.SelectedValue = dgvInspectionProcess.SapItemCode.ToString();

                this.LineId_cmb.SelectedValue = dgvInspectionProcess.LineId.ToString();

                this.InspectionFormat_cmb.SelectedValue = dgvInspectionProcess.InspectionFormatId.ToString();

                ItemLineInspectionFormatId = dgvInspectionProcess.ItemLineInspectionFormatId;

                Delete_btn.Enabled = true;
            }
        }

        /// <summary>
        /// Loads inspectionformat details to datatable
        /// </summary>
        private void FormDatatableFromVo()
        {
            //InspectionformatDatatable
            inspectionformatDatatable = new DataTable();
            inspectionformatDatatable.Columns.Add("Id");
            inspectionformatDatatable.Columns.Add("Name");

            ValueObjectList<InspectionFormatVo> inspectionFormatOutVo = null;

            try
            {

                inspectionFormatOutVo = (ValueObjectList<InspectionFormatVo>)base.InvokeCbm(new GetInspectionFormatMasterMntCbm(), new InspectionFormatVo(), false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (inspectionFormatOutVo == null || inspectionFormatOutVo.GetList() == null || inspectionFormatOutVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            foreach (InspectionFormatVo fac in inspectionFormatOutVo.GetList())
            {
                inspectionformatDatatable.Rows.Add(fac.InspectionFormatId, fac.InspectionFormatName);
            }

            //ItemDatatable
            itemDatatable = new DataTable();
            itemDatatable.Columns.Add("Id");
            itemDatatable.Columns.Add("Name");

            GlobalItemVo globalItemVo = null;

            try
            {

                // itemOutVo = (ValueObjectList<ItemVo>)base.InvokeCbm(new GetItemMasterCbm(), new ItemVo(), false);
                globalItemVo = (GlobalItemVo)base.InvokeCbm(new GetGlobalItemMasterMntCbm(), new GlobalItemVo(), false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (globalItemVo == null || globalItemVo.GlobalItemListVo == null || globalItemVo.GlobalItemListVo.Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            foreach (GlobalItemVo fac in globalItemVo.GlobalItemListVo)
            {
                itemDatatable.Rows.Add(fac.GlobalItemId, fac.GlobalItemCode + "-" + fac.GlobalItemName);
            }

            //LineDatatable
            lineDatatable = new DataTable();
            lineDatatable.Columns.Add("Id");
            lineDatatable.Columns.Add("Name");

            ValueObjectList<LineVo> lineOutVo = null;

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

            foreach (LineVo fac in lineOutVo.GetList())
            {
                lineDatatable.Rows.Add(fac.LineId, fac.LineCode + "-" + fac.LineName);
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
        /// checks duplicate Item line inspection format code
        /// </summary>
        /// <returns></returns>
        private ItemLineInspectionFormatVo DuplicateCheck(ItemLineInspectionFormatVo InsProcessVo)
        {
            ItemLineInspectionFormatVo outVo = new ItemLineInspectionFormatVo();

            try
            {
                outVo = (ItemLineInspectionFormatVo)base.InvokeCbm(new CheckItemLineInspectionFormatMasterMntCbm(), InsProcessVo, false);
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
            ItemLineInspectionFormatVo inVo = new ItemLineInspectionFormatVo();
            var sch = StringCheckHelper.GetInstance();
            if (CheckMandatory() == true)
            {
                inVo.ItemId = Convert.ToInt32(ItemId_cmb.SelectedValue.ToString());
                inVo.LineId = Convert.ToInt32(LineId_cmb.SelectedValue.ToString());
                inVo.InspectionFormatId = Convert.ToInt32(InspectionFormat_cmb.SelectedValue.ToString());
                inVo.Mode = mode;

                if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    inVo.ItemLineInspectionFormatId = ItemLineInspectionFormatId;
                }

                ItemLineInspectionFormatVo checkVo = DuplicateCheck(inVo);

                if (checkVo != null && checkVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, Environment.NewLine + ItemId_lbl.Text + " : " + ItemId_cmb.Text + " AND " + LineId_lbl.Text +
                                                " : " + LineId_cmb.Text + Environment.NewLine + " OR " + Environment.NewLine + InspectionFormat_lbl.Text + " : " + InspectionFormat_cmb.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);

                    return;
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        ItemLineInspectionFormatVo outVo = (ItemLineInspectionFormatVo)base.InvokeCbm(new AddItemLineInspectionFormatMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        ItemLineInspectionFormatVo outVo = (ItemLineInspectionFormatVo)base.InvokeCbm(new UpdateItemLineInspectionFormatMasterMntCbm(), inVo, false);

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
        protected void AddItemLineInspectionForFormatForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            Cursor = Cursors.WaitCursor;
            FormDatatableFromVo();
            ComboBind(InspectionFormat_cmb, inspectionformatDatatable, "Name", "Id");
            ComboBind(ItemId_cmb, itemDatatable, "Name", "Id");
            ComboBind(LineId_cmb, lineDatatable, "Name", "Id");
            Cursor = Cursors.Default;

            if (CheckItemLineInspectionDataExist()) return;

            InspectionFormat_cmb.SelectedValue = FormatId;
            mode = CommonConstants.MODE_ADD;

        }

        private bool CheckItemLineInspectionDataExist()
        {
            ItemLineInspectionFormatVo inVo = new ItemLineInspectionFormatVo();
            inVo.InspectionFormatId = FormatId;

            ValueObjectList<ItemLineInspectionFormatVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<ItemLineInspectionFormatVo>)base.InvokeCbm(new GetItemLineInspectionFormatMasterMntCbm(), inVo, false);

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
            LoadInspectionProcessData(outVo.GetList()[0]);
            mode = CommonConstants.MODE_UPDATE;
            return true;
        }

        #endregion

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (!CheckMandatory()) return;
            if (ItemLineInspectionFormatId <= 0)
            {
                messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, "ItemLineInspectionFormatId");
                popUpMessage.Warning(messageData, Text);
                return;
            }
            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, ItemId_cmb.Text);
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                ItemLineInspectionFormatVo inVo = new ItemLineInspectionFormatVo();

                inVo.ItemLineInspectionFormatId = ItemLineInspectionFormatId;

                try
                {

                    ItemLineInspectionFormatVo outVo = (ItemLineInspectionFormatVo)base.InvokeCbm(new DeleteItemLineInspectionFormatMasterMntCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        this.messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(this.messageData);
                        popUpMessage.Information(this.messageData, Text);
                    }
                    else if (outVo.AffectedCount == 0)
                    {
                        messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }
                this.Close();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //do something else
            }
        }
    }
}
