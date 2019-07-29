using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{

    public enum ProcessWorkRelationTables
    {
        ProcessWorkDefectiveReason = 0,
        ItemProcessWork = 1,
        ProcessWorkSupplier = 2
    };
    public partial class ProcessWorkForm
    {

        #region Variables

        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable processDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ProcessWorkForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public ProcessWorkForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(ProcessWorkVo conditionInVo)
        {
            ProcessWorkVo inVo = new ProcessWorkVo();

            ProcessWork_dgv.DataSource = null;

            try
            {
                ProcessWorkVo outVo = (ProcessWorkVo)base.InvokeCbm(new GetProcessWorkMasterMntCbm(), conditionInVo, false);

                ProcessWork_dgv.AutoGenerateColumns = false;

                foreach (ProcessWorkVo itemList in outVo.ProcessWorkListVo)
                {
                    ProcessWorkVo bindVo = new ProcessWorkVo();

                    bindVo.ProcessWorkId = Convert.ToInt32(itemList.ProcessWorkId);
                    bindVo.ProcessWorkCode = itemList.ProcessWorkCode.ToString();
                    bindVo.ProcessWorkName = itemList.ProcessWorkName.ToString();
                    bindVo.ProcessId = Convert.ToInt32(itemList.ProcessId);
                    bindVo.ProcessCode = itemList.ProcessCode.ToString();
                    bindVo.ProcessName = itemList.ProcessName.ToString();
                    bindVo.IsPhantomDisplay = itemList.IsPhantomDisplay.ToString();
                    
                    if (itemList.LineMachineSelection == 1)
                    {
                        bindVo.LineMachineSelectionDisplay = "SingleLine";
                    }

                   else if (itemList.LineMachineSelection == 2)
                    {
                        bindVo.LineMachineSelectionDisplay = "SingleMachine";
                    }

                    else if (itemList.LineMachineSelection == 3)
                    {
                        bindVo.LineMachineSelectionDisplay = "SingleLineandSingleMachine";
                    }

                    bindVo.DisplayOrder = Convert.ToInt32(itemList.DisplayOrder);

                    inVo.ProcessWorkListVo.Add(bindVo);
                }                

                BindingSource bindingSource1 = new BindingSource(inVo.ProcessWorkListVo, null);

                if (bindingSource1.Count > 0)
                {
                    ProcessWork_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //process work
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                ProcessWork_dgv.ClearSelection();

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;
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
        private ProcessWorkVo FormConditionVo()
        {
            ProcessWorkVo inVo = new ProcessWorkVo();

            if (ProcessWorkCode_txt.Text != string.Empty) { inVo.ProcessWorkCode = ProcessWorkCode_txt.Text; }

            if (ProcessWorkName_txt.Text != string.Empty)
            {
                inVo.ProcessWorkName = ProcessWorkName_txt.Text;
            }

            if (Process_cmb.SelectedIndex > -1)
            {
                inVo.ProcessId = Convert.ToInt32(Process_cmb.SelectedValue);
            }
            return inVo;
        }


        /// <summary>
        /// Handles Combobox loading for Item
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
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = ProcessWork_dgv.SelectedCells[0].RowIndex;

            ProcessWorkVo selectedMold = (ProcessWorkVo)ProcessWork_dgv.Rows[selectedrowindex].DataBoundItem;

            AddProcessWorkForm newAddForm = new AddProcessWorkForm();
            newAddForm.CreateForm(CommonConstants.MODE_UPDATE, selectedMold);
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
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            processDatatable = new DataTable();
            processDatatable.Columns.Add("id");
            processDatatable.Columns.Add("code");

            try
            {
                ProcessVo processOutVo = (ProcessVo)base.InvokeCbm(new GetProcessMasterMntCbm(), new ProcessVo(), false);

                foreach (ProcessVo process in processOutVo.ProcessListVo)
                {
                    processDatatable.Rows.Add(process.ProcessId, process.ProcessCode);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// To idenctify the relation ship with tables
        /// </summary>
        private ProcessWorkVo CheckProcessWorkRelation(ProcessWorkVo inVo)
        {
            ProcessWorkVo outVo = new ProcessWorkVo();

            try
            {
                outVo = outVo = (ProcessWorkVo)base.InvokeCbm(new CheckProcessWorkRelationCbm(), inVo, false);
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
        /// Loads Mold form
        /// Fill item combobox
        /// </summary>s
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessWorkForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                FormDatatableFromVo();

                ComboBind(Process_cmb, processDatatable, "code", "id");

                ProcessWorkCode_txt.Select();

                Update_btn.Enabled = Delete_btn.Enabled = false;
            }

        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Clear_btn_Click(object sender, EventArgs e)
        {
            ProcessWorkCode_txt.Text = string.Empty;

            ProcessWorkName_txt.Text = string.Empty;

            Process_cmb.SelectedIndex = -1;

            ProcessWork_dgv.DataSource = null;

            ProcessWorkCode_txt.Select();

            Delete_btn.Enabled = Update_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Add_btn_Click(object sender, EventArgs e)
        {
            AddProcessWorkForm newAddForm = new AddProcessWorkForm();
            newAddForm.CreateForm(CommonConstants.MODE_ADD, null);
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
        /// event to open the  updatescreen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateUserData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Delete_btn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = ProcessWork_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = ProcessWork_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colProcessWorkCode"].Value.ToString());
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                ProcessWorkVo inVo = new ProcessWorkVo
                {
                    ProcessWorkId = Convert.ToInt32(selectedRow.Cells["colProcessWorkId"].Value),
                    RegistrationDateTime = Convert.ToDateTime(DateTime.Now.ToString(UserData.GetUserData().DateTimeFormat)),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                };

                inVo.ProcessWorkCode = selectedRow.Cells["colProcessWorkCode"].Value.ToString();
                try
                {
                    ProcessWorkVo outCountVo = CheckProcessWorkRelation(inVo);

                    if (outCountVo != null)
                    {
                        StringBuilder message = new StringBuilder();

                        if (outCountVo.DefectiveIdCount > 0)
                        {
                            message.Append(ProcessWorkRelationTables.ProcessWorkDefectiveReason);
                        }
                        if (outCountVo.ItemProcessWorkIdCount > 0)
                        {
                            if (message.Length > 0)
                            {
                                message.Append("  And  ");
                            }

                            message.Append(ProcessWorkRelationTables.ItemProcessWork);
                        }
                        if (outCountVo.ProcessSupplierIdCount > 0)
                        {
                            if (message.Length > 0)
                            {
                                message.Append("  And  ");
                            }

                            message.Append(ProcessWorkRelationTables.ProcessWorkSupplier);
                        }
                        if (message.Length > 0)
                        {
                            messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, message.ToString());
                            popUpMessage.Information(messageData, Text);
                            return;
                        }
                    }
                    ProcessWorkVo outVo = (ProcessWorkVo)base.InvokeCbm(new DeleteProcessWorkMasterMntCbm(), inVo, false);

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
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ProcessWork_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProcessWork_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles update user form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ProcessWork_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProcessWork_dgv.SelectedRows.Count > 0)
            {
                BindUpdateUserData();
            }
        }

        #endregion

        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<ProcessWorkVo> outVo)
        {
            ProcessWork_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                ProcessWork_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            ProcessWork_dgv.ClearSelection();
        }

        protected virtual void ProcessWork_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = ProcessWork_dgv.Columns[e.ColumnIndex];

            if (ProcessWork_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)ProcessWork_dgv.DataSource;

            List<ProcessWorkVo> dataSourceVo = (List<ProcessWorkVo>)currentDatagridSource.DataSource;

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
                ProcessWork_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;

            }
        }
    }
}
