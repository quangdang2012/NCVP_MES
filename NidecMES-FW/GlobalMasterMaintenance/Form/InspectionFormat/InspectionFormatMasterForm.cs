using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class InspectionFormatMasterForm
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(InspectionFormatMasterForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// USER
        /// </summary>
        private const string USER = "USER";

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        /// <summary>
        ///  get sapitem value
        /// </summary>
        private SapItemSearchVo sapItemSearchVo = null;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public InspectionFormatMasterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        protected void GridBind(InspectionFormatVo conditionInVo)
        {
            if (conditionInVo == null)
            {
                return;
            }

            Process_btn.Enabled = false;
            Update_btn.Enabled = false;
            Delete_btn.Enabled = false;
          

            InspectionFormatDetails_dgv.DataSource = null;

            ValueObjectList<InspectionFormatVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionFormatVo>)base.InvokeCbm(new GetInspectionFormatMasterMntCbm(), conditionInVo, false);

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
            InspectionFormatDetails_dgv.AutoGenerateColumns = false;

            BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionFormatDetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }

            ChangeGridDataColorForRelationDataCheck();
            InspectionFormatDetails_dgv.ClearSelection();


        }

        private void ChangeGridDataColorForRelationDataCheck()
        {
            foreach (DataGridViewRow row in InspectionFormatDetails_dgv.Rows)
            {
                InspectionFormatVo InspectionUpdateVo = (InspectionFormatVo)row.DataBoundItem;
                if (InspectionUpdateVo.InspectionProcessId == 0)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    InspectionUpdateVo.InspectionProcessName = Properties.Resources.mmci00028;
                }
                if (InspectionUpdateVo.InspectionItemLineFormatId == 0)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    InspectionUpdateVo.InspectionItemLineName = Properties.Resources.mmci00027;
                }
            }
        }

        /// <summary>
        /// Loads inspectionformat details to ComboBox
        /// </summary>
        private void LoadCombo()
        {
           
            ValueObjectList<LineVo> lineOutVo = null;
            //ValueObjectList<SapItemGlobalVo> sapItemVo = null;

            //try
            //{
            //    sapItemVo = (ValueObjectList<SapItemGlobalVo>)base.InvokeCbm(new GetSapItemMasterMntCbm(), new SapItemGlobalVo(), false);

            //}
            //catch (Framework.ApplicationException exception)
            //{
            //    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
            //    logger.Error(exception.GetMessageData());
            //}

            //if (sapItemVo == null || sapItemVo.GetList() == null || sapItemVo.GetList().Count == 0)
            //{
            //    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
            //    logger.Info(messageData);
            //    popUpMessage.Information(messageData, Text);
            //    return;
            //}
            ////sapItemVo.GetList().ForEach(t => t.SapItemName = t.SapItemCode + "-" + t.SapItemName);

            //ItemId_cmb.DisplayMember = "SapItemName";
            //ItemId_cmb.ValueMember = "SapItemCode";
            //ItemId_cmb.DataSource = sapItemVo.GetList();
            //ItemId_cmb.SelectedIndex = -1;

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
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        protected InspectionFormatVo FormConditionVo()
        {
            InspectionFormatVo inVo = new InspectionFormatVo();


            if (InspectionFormatCode_txt.Text != string.Empty)
            {
                inVo.InspectionFormatCode = InspectionFormatCode_txt.Text;
            }

            if (InspectionFormatName_txt.Text != string.Empty)
            {
                inVo.InspectionFormatName = InspectionFormatName_txt.Text;
            }

            //if(ItemId_cmb.SelectedIndex > -1)
            //{
            //    inVo.SapItemCode = ItemId_cmb.SelectedValue.ToString();
            //}

            if (ItemCode_txt.Text != string.Empty) //  && sapItemGlobalVo != null
            {
                inVo.SapItemCode = ItemCode_txt.Text; // sapItemGlobalVo.SapItemCode;
            }                

            if (LineId_cmb.SelectedIndex > -1)
            {
                inVo.LineCode = LineId_cmb.SelectedValue.ToString();
            }

            return inVo;
        }

        /// <summary>
        /// selects user record for updation and show inspectionformat form
        /// </summary>
        private void BindUpdateInspectionFormatData()
        {
            int selectedrowindex = InspectionFormatDetails_dgv.SelectedCells[0].RowIndex;

            InspectionFormatVo selectedInspectionFormat = (InspectionFormatVo)InspectionFormatDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddInspectionFormatMasterForm newAddForm = new AddInspectionFormatMasterForm(CommonConstants.MODE_UPDATE, selectedInspectionFormat);

            newAddForm.ShowDialog(this);

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());

                InspectionFormatDetails_dgv.Rows[selectedrowindex].Selected = true;
                InspectionFormatDetails_dgv_CellClick(this, new DataGridViewCellEventArgs(0, selectedrowindex));
                InspectionFormatDetails_dgv.FirstDisplayedScrollingRowIndex = selectedrowindex;                
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
        private void BindDataSource(List<InspectionFormatVo> outVo)
        {
            InspectionFormatDetails_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionFormatDetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            ChangeGridDataColorForRelationDataCheck();
            InspectionFormatDetails_dgv.ClearSelection();
        }

        /// <summary>
        /// checks Inspection relation to other tables in DB
        /// </summary>
        /// <param name="InspVo"></param>
        /// <returns></returns>
        private InspectionFormatVo CheckRelation(InspectionFormatVo InspVo)
        {
            InspectionFormatVo outVo = new InspectionFormatVo();

            try
            {
                outVo = (InspectionFormatVo)base.InvokeCbm(new CheckInspectionFormatRelationCbm(), InspVo, false);
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
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionFormatMasterForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            Process_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;
            StartProgress(Properties.Resources.mmci00009);
            LoadCombo();
            CompleteProgress();
            //ItemId_cmb.Select();
            ItemCode_txt.Select();
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Clear_btn_Click(object sender, EventArgs e)
        {
            InspectionFormatCode_txt.Text = string.Empty;
            InspectionFormatName_txt.Text = string.Empty;
            //ItemId_cmb.SelectedIndex = LineId_cmb.SelectedIndex = -1;
            LineId_cmb.SelectedIndex = -1;
            InspectionFormatDetails_dgv.DataSource = null;
            //ItemId_cmb.Select();
            sapItemSearchVo = null;
            ItemCode_txt.Text = string.Empty;
            ItemCode_txt.Select();
            Process_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
        protected void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_btn_Click(object sender, EventArgs e)
        {
            AddInspectionFormatMasterForm newAddForm = new AddInspectionFormatMasterForm(CommonConstants.MODE_ADD, null);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());

                if (InspectionFormatDetails_dgv.Rows.Count > 0 && InspectionFormatDetails_dgv.Columns.Count > 0 && InspectionFormatDetails_dgv.Columns["colInspectionFormatId"] != null)
                {
                    int searchItemId;
                    if (newAddForm.IntSuccess > 0)
                    {
                        searchItemId = newAddForm.IntSuccess;
                    }
                    else
                    {
                        searchItemId = 0;
                    }

                    DataGridViewRow row = InspectionFormatDetails_dgv.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["colInspectionFormatId"].Value.ToString().Equals(searchItemId.ToString()));

                    if (row == null) { return; }

                    InspectionFormatDetails_dgv.Rows[row.Index].Selected = true;
                    InspectionFormatDetails_dgv_CellClick(sender, new DataGridViewCellEventArgs(0, row.Index));
                    InspectionFormatDetails_dgv.FirstDisplayedScrollingRowIndex = row.Index;
                }
            }
        }

        /// <summary>
        /// event to open the  updatescreen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateInspectionFormatData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Delete_btn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = InspectionFormatDetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = InspectionFormatDetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colInspectionFormatName"].Value.ToString());
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                InspectionFormatVo inVo = new InspectionFormatVo
                {
                    InspectionFormatId = Convert.ToInt32(selectedRow.Cells["colInspectionFormatId"].Value),
                    InspectionFormatCode = selectedRow.Cells["colInspectionFormatCode"].Value.ToString(),
                };

                try
                {

                   // InspectionFormatVo checkVo = CheckRelation(inVo);

                    //if (checkVo != null && checkVo.InspectionFormatId > 0)
                    //{
                    //    messageData = new MessageData("mmci00022", Properties.Resources.mmci00022, null);
                    //    popUpMessage.Information(messageData, Text);
                    //    return;
                    //}

                    UpdateResultVo outVo = (UpdateResultVo)base.InvokeCbm(new UpdateInspectionFormatDeleteFlagMasterMntCbm(), inVo, false);

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
        protected void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Process_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = InspectionFormatDetails_dgv.SelectedCells[0].RowIndex;

            InspectionFormatVo selectedInspectionFormat = (InspectionFormatVo)InspectionFormatDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            InspectionProcessForFormatForm frm = new InspectionProcessForFormatForm();
            frm.FormatId = selectedInspectionFormat.InspectionFormatId;
            frm.FormatCode = selectedInspectionFormat.InspectionFormatCode;
            frm.FormatName = selectedInspectionFormat.InspectionFormatName;
            frm.ShowDialog();
            GridBind(FormConditionVo());
        }

        protected void ItemLine_btn_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //int selectedrowindex = InspectionFormatDetails_dgv.SelectedCells[0].RowIndex;

            //InspectionFormatVo selectedInspectionFormat = (InspectionFormatVo)InspectionFormatDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            //AddItemLineInspectionForFormatForm frm = new AddItemLineInspectionForFormatForm();
            //frm.FormatId = selectedInspectionFormat.InspectionFormatId;
            //Cursor = Cursors.Default;
            //frm.ShowDialog();
            //GridBind(FormConditionVo());
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

        #region ControlEvents

        /// <summary>
        /// Handles inspectionformat record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InspectionFormatDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionFormatDetails_dgv.SelectedRows.Count > 0)
            {
                Process_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Process_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled  = false;
            }
        }

        /// <summary>
        /// Handles update inspectionformat form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InspectionFormatDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionFormatDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateInspectionFormatData();
            }
        }
        
        /// <summary>
        /// sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InspectionFormatDetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Process_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;

            DataGridViewColumn column = InspectionFormatDetails_dgv.Columns[e.ColumnIndex];

            if (InspectionFormatDetails_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)InspectionFormatDetails_dgv.DataSource;

            List<InspectionFormatVo> dataSourceVo = (List<InspectionFormatVo>)currentDatagridSource.DataSource;

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
                InspectionFormatDetails_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        #endregion

        private void FormatCopy_cntxMnu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.ClickedItem.Text) || InspectionFormatDetails_dgv.Rows.Count == 0)
            {
                return;
            }

            if (InspectionFormatDetails_dgv.SelectedRows.Count > 0)
            {
                FormatCopy_cntxMnu.Items.Clear();

                this.Cursor = Cursors.WaitCursor;

                int selectedrowindex = InspectionFormatDetails_dgv.SelectedCells[0].RowIndex;

                InspectionFormatVo InspectionCopyVo = (InspectionFormatVo)InspectionFormatDetails_dgv.Rows[selectedrowindex].DataBoundItem;

                InspectionFormatVo inspectionInVo = new InspectionFormatVo();
                inspectionInVo.InspectionFormatIdCopy = InspectionCopyVo.InspectionFormatId;
                inspectionInVo.InspectionFormatName = InspectionCopyVo.InspectionFormatName;

                AddInspectionFormatMasterForm newAddForm = new AddInspectionFormatMasterForm(CommonConstants.MODE_ADD, inspectionInVo);

                newAddForm.ShowDialog();

                if (newAddForm.IntSuccess > 0)
                {
                    messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);

                    GridBind(FormConditionVo());

                    if (InspectionFormatDetails_dgv.Rows.Count > 0 && InspectionFormatDetails_dgv.Columns.Count > 0 && InspectionFormatDetails_dgv.Columns["colInspectionFormatId"] != null)
                    {
                        int searchItemId;
                        if (newAddForm.IntSuccess > 0)
                        {
                            searchItemId = newAddForm.IntSuccess;
                        }
                        else
                        {
                            searchItemId = 0;
                        }

                        DataGridViewRow row = InspectionFormatDetails_dgv.Rows
                        .Cast<DataGridViewRow>()
                        .FirstOrDefault(r => r.Cells["colInspectionFormatId"].Value.ToString().Equals(searchItemId.ToString()));

                        if (row == null) { return; }

                        InspectionFormatDetails_dgv.Rows[row.Index].Selected = true;
                        InspectionFormatDetails_dgv_CellClick(sender, new DataGridViewCellEventArgs(0, row.Index));
                        InspectionFormatDetails_dgv.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void InspectionFormatDetails_dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || InspectionFormatDetails_dgv.RowCount == 0 || InspectionFormatDetails_dgv.SelectedCells.Count == 0)
                return;

            DataGridView.HitTestInfo hti = InspectionFormatDetails_dgv.HitTest(e.X, e.Y);
            if (hti.RowIndex < 0 || hti.ColumnIndex < 0)
                return;

            if (InspectionFormatDetails_dgv.CurrentRow.Cells["colInspectionFormatId"].Value != null)
            {
                FormatCopy_cntxMnu.Items.Clear();
                FormatCopy_cntxMnu.Items.Add("Copy");
                Point relativeMousePosition = InspectionFormatDetails_dgv.PointToClient(Cursor.Position);
                FormatCopy_cntxMnu.Show(InspectionFormatDetails_dgv, relativeMousePosition);
            }
        }
    }
}
