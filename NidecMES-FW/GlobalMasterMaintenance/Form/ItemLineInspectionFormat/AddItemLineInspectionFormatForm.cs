using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddItemLineInspectionFormatForm
    {
        #region Variables 

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly ItemLineInspectionFormatVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddItemLineInspectionFormatForm));

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
        public AddItemLineInspectionFormatForm(string pmode, ItemLineInspectionFormatVo userItem = null)
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
                this.ItemId_cmb.SelectedValue = dgvInspectionProcess.ItemId.ToString();

                this.LineId_cmb.SelectedValue = dgvInspectionProcess.LineId.ToString();

                this.InspectionFormat_cmb.SelectedValue = dgvInspectionProcess.InspectionFormatId.ToString();
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

            ValueObjectList<ItemVo> itemOutVo = null;

            try
            {

                itemOutVo = (ValueObjectList<ItemVo>)base.InvokeCbm(new GetItemMasterCbm(), new ItemVo(), false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (itemOutVo == null || itemOutVo.GetList() == null || itemOutVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            foreach (ItemVo fac in itemOutVo.GetList())
            {
                itemDatatable.Rows.Add(fac.ItemId, fac.ItemCode + "-" + fac.ItemName);
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
                    inVo.ItemLineInspectionFormatId = updateData.ItemLineInspectionFormatId;
                }  
                                                
                ItemLineInspectionFormatVo checkVo = DuplicateCheck(inVo);

                if (checkVo != null && checkVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, Environment.NewLine + ItemId_lbl.Text + " : " + ItemId_cmb.Text + " AND " + LineId_lbl.Text + 
                                                " : " + LineId_cmb.Text + Environment.NewLine + " OR " + Environment.NewLine + InspectionFormat_lbl.Text + " : " + InspectionFormat_cmb.Text);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

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
        private void AddItemLineInspectionFormatForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(InspectionFormat_cmb, inspectionformatDatatable, "Name", "Id");
            ComboBind(ItemId_cmb, itemDatatable, "Name", "Id");
            ComboBind(LineId_cmb, lineDatatable, "Name", "Id");

            ItemId_cmb.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadInspectionProcessData(updateData);

                ItemId_cmb.Enabled = false;
                LineId_cmb.Enabled = false;
                InspectionFormat_cmb.Select();          
            }
        }

        #endregion
        
    }
}
