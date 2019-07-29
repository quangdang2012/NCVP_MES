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
    public partial class InspectionTestInstructionForm
    {
        #region Variables

        /// <summary>
        /// for loading equipment details
        /// </summary>
        private DataTable inspectionitemDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(InspectionTestInstructionForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        ///  get message data
        /// </summary>
        private const string InspectionItem = "InspectionItem";

        #endregion

        #region Constructor 

        /// <summary>
        /// constructor
        /// </summary>
        public InspectionTestInstructionForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;
        #endregion

        #region PrivateMethods 

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(InspectionTestInstructionVo conditionInVo)
        {
            if (conditionInVo == null)
            {
                return;
            }

            InspectionTestInstruction_dgv.DataSource = null;

            ValueObjectList<InspectionTestInstructionVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionTestInstructionVo>)base.InvokeCbm(new GetInspectionTestInstructionMasterMntCbm(), conditionInVo, false);

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
            InspectionTestInstruction_dgv.AutoGenerateColumns = false;

            BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionTestInstruction_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
          InspectionTestInstruction_dgv.ClearSelection();

          Update_btn.Enabled = Detail_btn.Enabled = Delete_btn.Enabled = false;

        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private InspectionTestInstructionVo FormConditionVo()
        {
            InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();

            if (InspectionTestInstructionCode_txt.Text != string.Empty) { inVo.InspectionTestInstructionCode = InspectionTestInstructionCode_txt.Text; }

            if (InspectionTestInstructionText_txt.Text != string.Empty)
            {
                inVo.InspectionTestInstructionText = InspectionTestInstructionText_txt.Text;
            }

            if (InspectionItemId_cmb.SelectedIndex > -1)
            {
                inVo.InspectionItemId = Convert.ToInt32(InspectionItemId_cmb.SelectedValue.ToString());
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
        private void BindUpdateInspectionTestInstructionData()
        {
            int selectedrowindex = InspectionTestInstruction_dgv.SelectedCells[0].RowIndex;

            InspectionTestInstructionVo inspTestInstructionVo = (InspectionTestInstructionVo)InspectionTestInstruction_dgv.Rows[selectedrowindex].DataBoundItem;

            AddInspectionTestInstructionForm newAddForm = new AddInspectionTestInstructionForm(CommonConstants.MODE_UPDATE, inspTestInstructionVo);

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

        #endregion

        #region ButtonClick 

        /// <summary>
        /// insert  the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddInspectionTestInstructionForm newAddForm = new AddInspectionTestInstructionForm(CommonConstants.MODE_ADD, null);

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
            InspectionTestInstructionCode_txt.Text = string.Empty;

            InspectionTestInstructionText_txt.Text = string.Empty;

            InspectionItemId_cmb.SelectedIndex = -1;

            InspectionTestInstruction_dgv.DataSource = null;

            Update_btn.Enabled = Delete_btn.Enabled = Detail_btn.Enabled = false;

            InspectionTestInstructionCode_txt.Select();
        }


        /// <summary>
        /// fetch record from db by condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InspectionItemId_cmb.Text) && !(InspectionItemId_cmb.SelectedIndex > -1))
            {
                messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, InspectionItemId_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                InspectionItemId_cmb.Focus();
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
            BindUpdateInspectionTestInstructionData();
        }

        /// <summary>
        /// delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = InspectionTestInstruction_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = InspectionTestInstruction_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colInspectionTestInstructionCode"].Value.ToString());
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {

                InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();

                inVo.InspectionTestInstructionId = Convert.ToInt32(selectedRow.Cells["colInspectionTestInstructionId"].Value.ToString());
                inVo.InspectionTestInstructionCode = selectedRow.Cells["colInspectionTestInstructionCode"].Value.ToString();
                try
                {

                    InspectionTestInstructionVo outVo = (InspectionTestInstructionVo)base.InvokeCbm(new DeleteInspectionTestInstructionMasterMntNewCbm(), inVo, false);

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

        /// <summary>
        /// Detail screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detail_btn_Click(object sender, EventArgs e)
        {
            if (InspectionTestInstruction_dgv.Rows.Count == 0 || InspectionTestInstruction_dgv.SelectedRows.Count == 0) return;
            int selectedrowindex = InspectionTestInstruction_dgv.SelectedCells[0].RowIndex;
            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)InspectionTestInstruction_dgv.Rows[selectedrowindex].DataBoundItem;

            InspectionTestInstructionDetailForm newdetailform = new InspectionTestInstructionDetailForm(inVo);
            newdetailform.ShowDialog();
            GridBind(FormConditionVo());
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// update, delete button enable  based on the record selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionTestInstruction_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionTestInstruction_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = Detail_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = Detail_btn.Enabled = false;
            }
        }

        /// <summary>
        /// open update form on double click on the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionTestInstruction_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionTestInstruction_dgv.SelectedRows.Count > 0)
            {
                BindUpdateInspectionTestInstructionData();
            }
        }

        #endregion

        #region FormEvents 
        /// <summary>
        /// load  the form with  combobox bind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionTestInstructionForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(InspectionItemId_cmb, inspectionitemDatatable, "Name", "Id");

            Update_btn.Enabled = Delete_btn.Enabled = Detail_btn.Enabled = false;

            InspectionTestInstructionCode_txt.Select();
        }

        #endregion
        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<InspectionTestInstructionVo> outVo)
        {
            InspectionTestInstruction_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionTestInstruction_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            InspectionTestInstruction_dgv.ClearSelection();
        }
        private void InspectionTestInstruction_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Detail_btn.Enabled = Delete_btn.Enabled = Update_btn.Enabled = false;
            DataGridViewColumn column = InspectionTestInstruction_dgv.Columns[e.ColumnIndex];

            if (InspectionTestInstruction_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)InspectionTestInstruction_dgv.DataSource;

            List<InspectionTestInstructionVo> dataSourceVo = (List<InspectionTestInstructionVo>)currentDatagridSource.DataSource;

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
                InspectionTestInstruction_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }
    }
}
