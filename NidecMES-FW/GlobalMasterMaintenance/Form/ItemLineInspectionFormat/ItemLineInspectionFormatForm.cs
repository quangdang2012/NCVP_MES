using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class ItemLineInspectionFormatForm
    {
        #region Variables

        /// <summary>
        /// for loading equipment details
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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ItemLineInspectionFormatForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        ///  get message data
        /// </summary>
        private const string ItemLineInspectionFormat = "ItemLineInspectionFormat";

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        #endregion

        #region Constructor 

        /// <summary>
        /// constructor
        /// </summary>
        public ItemLineInspectionFormatForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods 

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(ItemLineInspectionFormatVo conditionInVo)
        {
            if (conditionInVo == null)
            {
                return;
            }

            ItemLineInspectionFormatDetails_dgv.DataSource = null;

            ValueObjectList<ItemLineInspectionFormatVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<ItemLineInspectionFormatVo>)base.InvokeCbm(new GetItemLineInspectionFormatMasterMntCbm(), conditionInVo, false);

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
            ItemLineInspectionFormatDetails_dgv.AutoGenerateColumns = false;

            BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                ItemLineInspectionFormatDetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            ItemLineInspectionFormatDetails_dgv.ClearSelection();

            Update_btn.Enabled = false;

            Delete_btn.Enabled = false;
        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private ItemLineInspectionFormatVo FormConditionVo()
        {
            ItemLineInspectionFormatVo inVo = new ItemLineInspectionFormatVo();

            if (ItemId_cmb.SelectedIndex > -1)
            {
                inVo.ItemId = Convert.ToInt32(ItemId_cmb.SelectedValue.ToString());
            }

            if (LineId_cmb.SelectedIndex > -1)
            {
                inVo.LineId = Convert.ToInt32(LineId_cmb.SelectedValue.ToString());
            }

            if (InspectionFormatId_cmb.SelectedIndex > -1)
            {
                inVo.InspectionFormatId = Convert.ToInt32(InspectionFormatId_cmb.SelectedValue.ToString());
            }

            return inVo;

        }

        /// <summary>
        /// Handles Combobox loading for Country,Language and Factory
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
        /// passing update data to update form
        /// </summary>
        private void BindUpdateInspectionProcessData()
        {
            int selectedrowindex = ItemLineInspectionFormatDetails_dgv.SelectedCells[0].RowIndex;

            ItemLineInspectionFormatVo inspProcessVo = (ItemLineInspectionFormatVo)ItemLineInspectionFormatDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddItemLineInspectionFormatForm newAddForm = new AddItemLineInspectionFormatForm(CommonConstants.MODE_UPDATE, inspProcessVo);

            newAddForm.ShowDialog(this);

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
            else if (newAddForm.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// Loads data table for inspectionformat 
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

        #endregion

        #region ButtonClick 

        /// <summary>
        /// insert  the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddItemLineInspectionFormatForm newAddForm = new AddItemLineInspectionFormatForm(CommonConstants.MODE_ADD, null);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// clear the condition control values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ItemId_cmb.SelectedIndex = -1;

            LineId_cmb.SelectedIndex = -1;

            InspectionFormatId_cmb.SelectedIndex = -1;

            ItemLineInspectionFormatDetails_dgv.DataSource = null;

            Update_btn.Enabled = Delete_btn.Enabled = false;

            ItemId_cmb.Select();
        }


        /// <summary>
        /// fetch record from db by condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InspectionFormatId_cmb.Text) && !(InspectionFormatId_cmb.SelectedIndex > -1))
            {
                messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, InspectionFormatId_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                InspectionFormatId_cmb.Focus();
                return;
            }

            GridBind(FormConditionVo());
        }

        /// <summary>
        /// open the update form with selected record bind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateInspectionProcessData();
        }

        /// <summary>
        /// delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = ItemLineInspectionFormatDetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = ItemLineInspectionFormatDetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colItemName"].Value.ToString());
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {

                ItemLineInspectionFormatVo inVo = new ItemLineInspectionFormatVo();

                inVo.ItemLineInspectionFormatId = Convert.ToInt32(selectedRow.Cells["colItemLineInspectionFormatId"].Value.ToString());
                inVo.ItemId = Convert.ToInt32(selectedRow.Cells["colItemId"].Value.ToString());
                inVo.LineId = Convert.ToInt32(selectedRow.Cells["colLineId"].Value.ToString());
                inVo.InspectionFormatId = Convert.ToInt32(selectedRow.Cells["colInspectionFormatId"].Value.ToString());

                try
                {

                    ItemLineInspectionFormatVo outVo = (ItemLineInspectionFormatVo)base.InvokeCbm(new DeleteItemLineInspectionFormatMasterMntCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        this.messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(this.messageData);
                        popUpMessage.Information(this.messageData, Text);

                        GridBind(FormConditionVo());
                    }
                    else if (outVo.AffectedCount == 0)
                    {
                        messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        GridBind(FormConditionVo());
                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //do something else
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

        #endregion

        #region ControlEvents

        /// <summary>
        /// update, delete button enable  based on the record selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionProcessDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ItemLineInspectionFormatDetails_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// open update form on double click on the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionProcessDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ItemLineInspectionFormatDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateInspectionProcessData();
            }
        }

        #endregion

        #region FormEvents 
        /// <summary>
        /// load  the form with  combobox bind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionProcessForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(InspectionFormatId_cmb, inspectionformatDatatable, "Name", "Id");
            ComboBind(ItemId_cmb, itemDatatable, "Name", "Id");
            ComboBind(LineId_cmb, lineDatatable, "Name", "Id");
            Update_btn.Enabled = Delete_btn.Enabled = false;
            ItemId_cmb.Select();
        }

        #endregion

        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<ItemLineInspectionFormatVo> outVo)
        {
            ItemLineInspectionFormatDetails_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                ItemLineInspectionFormatDetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            ItemLineInspectionFormatDetails_dgv.ClearSelection();
        }

        private void ItemLineInspectionFormatDetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = ItemLineInspectionFormatDetails_dgv.Columns[e.ColumnIndex];

            if (ItemLineInspectionFormatDetails_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)ItemLineInspectionFormatDetails_dgv.DataSource;

            List<ItemLineInspectionFormatVo> dataSourceVo = (List<ItemLineInspectionFormatVo>)currentDatagridSource.DataSource;

            if (!string.IsNullOrEmpty(column.DataPropertyName) && dataSourceVo.Count > 0 &&
                                                   column.CellType != typeof(DataGridViewButtonCell))
            {
                switch (sortDirection)
                {
                    case SortOrder.None:
                        sortDirection = SortOrder.Ascending;
                        break;
                    case SortOrder.Ascending:
                        sortDirection = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        sortDirection = SortOrder.Ascending;
                        break;
                }

                if (sortDirection == SortOrder.Ascending)
                {
                    dataSourceVo = dataSourceVo.OrderBy(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
                }
                else if (sortDirection == SortOrder.Descending)
                {
                    dataSourceVo = dataSourceVo.OrderByDescending(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
                }

                BindDataSource(dataSourceVo);
                ItemLineInspectionFormatDetails_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }
    }
}
