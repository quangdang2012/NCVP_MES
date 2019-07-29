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
    public partial class InspectionItemForm
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(InspectionItemForm));

        /// <summary>
        /// get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor
        /// </summary>
        public InspectionItemForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all inspection Item records to gridview control
        /// </summary>
        private void GridBind(InspectionItemVo conditionInVo)
        {
            InspectionItem_dgv.DataSource = null;

            try
            {
                ValueObjectList<InspectionItemVo> outVo = (ValueObjectList<InspectionItemVo>)base.InvokeCbm(new GetInspectionItemMasterMntCbm(), conditionInVo, false);
                if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }

                BindingList<List<UserVo>> userBind = new BindingList<List<UserVo>>();

                InspectionItem_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);

                if (bindingSource1 != null && bindingSource1.Count > 0)
                {
                    InspectionItem_dgv.DataSource = bindingSource1;
                }
                InspectionItem_dgv.ClearSelection();

                Update_btn.Enabled = Delete_btn.Enabled =InspectionSpecification_btn.Enabled = InspectionTestInstruction_btn.Enabled = false;

               
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private InspectionItemVo FormConditionVo()
        {
            InspectionItemVo inVo = new InspectionItemVo();

            if (InspectionItemCode_txt.Text != string.Empty)
            {
                inVo.InspectionItemCode = InspectionItemCode_txt.Text;
            }

            if (InspectionItemName_txt.Text != string.Empty)
            {
                inVo.InspectionItemName = InspectionItemName_txt.Text;
            }

            if (ParentItemCode_cmb.SelectedIndex > -1)
            {
                inVo.ParentInspectionItemId = Convert.ToInt32(ParentItemCode_cmb.SelectedValue);
            }

            if (InspectionProcess_cmb.SelectedIndex > -1)
            {
                inVo.InspectionProcessId = Convert.ToInt32(InspectionProcess_cmb.SelectedValue);
            }
            return inVo;

        }

        /// <summary>
        /// selects inspection record for updation and show Inspection form
        /// </summary>
        private void BindUpdateInspectionItemData()
        {
            int selectedrowindex = InspectionItem_dgv.SelectedCells[0].RowIndex;

            InspectionItemVo InspectionUpdateVo = (InspectionItemVo)InspectionItem_dgv.Rows[selectedrowindex].DataBoundItem;

            AddInspectionItemForm newAddForm = new AddInspectionItemForm(CommonConstants.MODE_UPDATE, InspectionUpdateVo);

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
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<InspectionItemVo> outVo)
        {
            InspectionItem_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionItem_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            InspectionItem_dgv.ClearSelection();
        }

        /// <summary>
        /// Load Parent Inspection Data
        /// </summary>
        private void LoadParentInspectionCombo()
        {
            ValueObjectList<InspectionItemVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionItemVo>)base.InvokeCbm(new GetParentInspectionItemIdMasterMntCbm(), new InspectionItemVo(), false);
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
            ParentItemCode_cmb.DataSource = outVo.GetList();
            ParentItemCode_cmb.DisplayMember = "InspectionItemCode";
            ParentItemCode_cmb.ValueMember = "InspectionItemId";
            ParentItemCode_cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// Load Inspection Process
        /// </summary>
        private void LoadInspectionProcessCombo()
        {
            ValueObjectList<InspectionProcessVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionProcessVo>)base.InvokeCbm(new GetInsepctionProcessMasterMntCbm(), new InspectionProcessVo(), false);
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
            InspectionProcess_cmb.DataSource = outVo.GetList();
            InspectionProcess_cmb.DisplayMember = "InspectionProcessName";
            InspectionProcess_cmb.ValueMember = "InspectionProcessId";
            InspectionProcess_cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// checks Inspection relation to other tables in DB
        /// </summary>
        /// <param name="autVo"></param>
        /// <returns></returns>
        private InspectionItemVo CheckRelation(InspectionItemVo InspVo)
        {
            InspectionItemVo outVo = new InspectionItemVo();

            try
            {
                outVo = (InspectionItemVo)base.InvokeCbm(new CheckInspectionItemRelationCbm(), InspVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        #endregion

        #region FormEvents

        /// <summary>
        /// form load event,loads data table and binds combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionItemForm_Load(object sender, EventArgs e)
        {

            LoadInspectionProcessCombo();

            LoadParentInspectionCombo();

            InspectionItemCode_txt.Select();

            Update_btn.Enabled = InspectionSpecification_btn.Enabled = InspectionTestInstruction_btn.Enabled = Delete_btn.Enabled = false;
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// clear the search condition control values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            InspectionItemName_txt.Text = string.Empty;

            InspectionItemCode_txt.Text = string.Empty;

            ParentItemCode_cmb.SelectedIndex = -1;

            InspectionProcess_cmb.SelectedIndex = -1;

            InspectionItem_dgv.DataSource = null;

            InspectionItemCode_txt.Select();
            Update_btn.Enabled = InspectionSpecification_btn.Enabled = InspectionTestInstruction_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// search data using condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// load add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddInspectionItemForm newAddForm = new AddInspectionItemForm(CommonConstants.MODE_ADD);

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
        /// load update screen with selected add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateInspectionItemData();
        }

        /// <summary>
        /// delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = InspectionItem_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = InspectionItem_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colInspectionItemCode"].Value.ToString());
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                InspectionItemVo inVo = new InspectionItemVo
                {
                    InspectionItemCode = selectedRow.Cells["colInspectionItemCode"].Value.ToString(),
                };

                try
                {
                    InspectionItemVo checkVo = CheckRelation(inVo);

                    if (checkVo != null && checkVo.InspectionItemId > 0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, "[INSPECTION SPECIFICATION, INSPECTION INSTRUCTION]");
                        popUpMessage.Information(messageData, Text);
                        return;
                    }

                    InspectionItemVo outVo = (InspectionItemVo)base.InvokeCbm(new DeleteInspectionItemMasterMntCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

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

        #region Control Events

        /// <summary>
        /// enable update,delete button on cell click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionItem_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionItem_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = InspectionSpecification_btn.Enabled = InspectionTestInstruction_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = InspectionSpecification_btn.Enabled = InspectionTestInstruction_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// load update screen on cell double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionItem_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionItem_dgv.SelectedRows.Count > 0)
            {
                BindUpdateInspectionItemData();
            }
        }
        private void InspectionSpecification_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = InspectionItem_dgv.SelectedCells[0].RowIndex;
            InspectionItemVo InspectionAddVo = (InspectionItemVo)InspectionItem_dgv.Rows[selectedrowindex].DataBoundItem;
            AddInspectionSpecificationForItemForm newAddForm = new AddInspectionSpecificationForItemForm(CommonConstants.MODE_ADD, null);
            newAddForm.InspectionItemId = InspectionAddVo.InspectionItemId;
            newAddForm.ShowDialog();
        }
        private void InspectionTestInstruction_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = InspectionItem_dgv.SelectedCells[0].RowIndex;
            InspectionItemVo InspectionAddVo = (InspectionItemVo)InspectionItem_dgv.Rows[selectedrowindex].DataBoundItem;
            AddInspectionTestInstructionForItemForm newAddForm = new AddInspectionTestInstructionForItemForm(CommonConstants.MODE_ADD, null);
            newAddForm.ShowDialog();
        }

        /// <summary>
        /// sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionItem_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = InspectionSpecification_btn.Enabled = InspectionTestInstruction_btn.Enabled = false;

            DataGridViewColumn column = InspectionItem_dgv.Columns[e.ColumnIndex];

            if (InspectionItem_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)InspectionItem_dgv.DataSource;

            List<InspectionItemVo> dataSourceVo = (List<InspectionItemVo>)currentDatagridSource.DataSource;

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
                InspectionItem_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        #endregion


    }
}
