using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Linq;
using System.Drawing;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class InspectionProcessForFormatForm
    {
        #region Variables

        /// <summary>
        /// for loading equipment details
        /// </summary>
        private DataTable inspectionformatDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(InspectionProcessForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        ///  get message data
        /// </summary>
        private const string InspectionItem = "InspectionItem";

        /// <summary>
        /// 
        /// </summary>
        public int FormatId;

        /// <summary>
        /// 
        /// </summary>
        public string FormatCode;

        /// <summary>
        /// 
        /// </summary>
        public string FormatName;

        #endregion

        #region Constructor 

        /// <summary>
        /// constructor
        /// </summary>
        public InspectionProcessForFormatForm()
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
        /// Loads data table for inspectionformat 
        /// </summary>
        private void FormDatatableFromVo()
        {
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

        }

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind()
        {

            InspectionItem_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;

            InspectionProcessVo inVo = new InspectionProcessVo();
            inVo.InspectionFormatId = FormatId;
            InspectionProcessDetails_dgv.DataSource = null;

            ValueObjectList<InspectionProcessVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionProcessVo>)base.InvokeCbm(new GetInspectionProcessMasterMntCbm(), inVo, false);

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
                //popUpMessage.Information(messageData, Text);
                return;
            }
            InspectionProcessDetails_dgv.AutoGenerateColumns = false;

            BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionProcessDetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            ChangeGridDataColorForRelationDataCheck();
            InspectionProcessDetails_dgv.ClearSelection();

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
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.DataSource = pDatasource;
            pCombo.SelectedValue = FormatId;
            //pCombo.Text = string.Empty;
        }

        /// <summary>
        /// passing update data to update form
        /// </summary>
        private void BindUpdateInspectionProcessData()
        {
            int selectedrowindex = InspectionProcessDetails_dgv.SelectedCells[0].RowIndex;

            InspectionProcessVo inspProcessVo = (InspectionProcessVo)InspectionProcessDetails_dgv.Rows[selectedrowindex].DataBoundItem;
            
            AddInspectionProcessForFormatForm newAddForm = new AddInspectionProcessForFormatForm(CommonConstants.MODE_UPDATE, inspProcessVo);

            newAddForm.ShowDialog(this);

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                if (newAddForm.ReturnFormatId > 0) FormatId = newAddForm.ReturnFormatId;
                //FormDatatableFromVo();
                //ComboBind(InspectionFormatId_cmb, inspectionformatDatatable, "Name", "Id");
                //InspectionFormatId_cmb.SelectedValue = FormatId;
                GridBind();
            }
            else if (newAddForm.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                //GridBind();
            }

            InspectionProcessDetails_dgv.Rows[selectedrowindex].Selected = true;
            InspectionProcessDetails_dgv_CellClick(this, new DataGridViewCellEventArgs(0, selectedrowindex));
            InspectionProcessDetails_dgv.FirstDisplayedScrollingRowIndex = selectedrowindex;
        }

        /// <summary>
        /// To idenctify the relation ship with tables
        /// </summary>
        private InspectionProcessVo CheckInspectionProcessRelationCbm(InspectionProcessVo inVo)
        {
            InspectionProcessVo outVo = new InspectionProcessVo();

            try
            {
                outVo = (InspectionProcessVo)base.InvokeCbm(new CheckInspectionProcessRelationCbm(), inVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }


        private void ChangeGridDataColorForRelationDataCheck()
        {
            foreach (DataGridViewRow row in InspectionProcessDetails_dgv.Rows)
            {
                InspectionProcessVo InspectionUpdateVo = (InspectionProcessVo)row.DataBoundItem;
                if (InspectionUpdateVo.InspectionItemId == 0)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.Cells["Comments"].Value = Properties.Resources.mmci00026;
                }

            }
        }

        /// <summary>
        /// To get the Format Id based on item id
        /// </summary>
        /// <param name="inspectionprocessid"></param>
        /// <returns></returns>
        private InspectionFormatVo FormFormatVo(int inspectionprocessid)
        {
            InspectionFormatProcessBuzzLogic getFormatdetails = new InspectionFormatProcessBuzzLogic();
            CopyInspectionFormatVo inVo = new CopyInspectionFormatVo();
            inVo.InspectionProcessId = inspectionprocessid;
            return getFormatdetails.getFormatDetails(inVo);
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
            InspectionProcessVo inspProcessVo = new InspectionProcessVo();
            inspProcessVo.InspectionFormatId = FormatId;
            inspProcessVo.InspectionFormatCode = FormatCode;
            inspProcessVo.InspectionFormatName = FormatName;
            AddInspectionProcessForFormatForm newAddForm = new AddInspectionProcessForFormatForm(CommonConstants.MODE_ADD, inspProcessVo);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind();

                if (InspectionProcessDetails_dgv.Rows.Count > 0 && InspectionProcessDetails_dgv.Columns.Count > 0 &&
                                                                        InspectionProcessDetails_dgv.Columns["colInspectionProcessId"] != null)
                {
                    int searchProcessId;
                    if (newAddForm.IntSuccess > 0)
                    {
                        searchProcessId = newAddForm.IntSuccess;
                    }
                    else
                    {
                        return;
                    }

                    DataGridViewRow row = InspectionProcessDetails_dgv.Rows
                        .Cast<DataGridViewRow>()
                        .FirstOrDefault(r => r.Cells["colInspectionProcessId"].Value.ToString().Equals(searchProcessId.ToString()));

                    if (row == null) { return; }

                    InspectionProcessDetails_dgv.Rows[row.Index].Selected = true;                    
                    InspectionProcessDetails_dgv_CellClick(sender, new DataGridViewCellEventArgs(0, row.Index));
                    InspectionProcessDetails_dgv.FirstDisplayedScrollingRowIndex = row.Index;
                }
            }

        }

        private void InspectionItem_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = InspectionProcessDetails_dgv.SelectedCells[0].RowIndex;
            InspectionProcessVo inspProcessVo = (InspectionProcessVo)InspectionProcessDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            InspectionItemForProcessForm frm = new GlobalMasterMaintenance.InspectionItemForProcessForm();
            frm.InspectionProcessId = inspProcessVo.InspectionProcessId;
            frm.InspectionProcessCode = inspProcessVo.InspectionProcessCode;
            frm.InspectionProcessName = inspProcessVo.InspectionProcessName;
            frm.InspectionFormatId = FormatId;
            frm.ShowDialog();
            if (frm.InspectionProcessId > 0)
            {
                InspectionFormatProcessBuzzLogic getprocessid = new InspectionFormatProcessBuzzLogic();
                InspectionReturnVo invo = new InspectionReturnVo();
                invo.InspectionProcessId = frm.InspectionProcessId;
                InspectionReturnVo getInspectionVo = getprocessid.RefreshAllFormGrid(invo);
                if (getInspectionVo != null && getInspectionVo.InspectionFormatId > 0)
                {
                    FormatId = getInspectionVo.InspectionFormatId;
                    //FormDatatableFromVo();
                    //ComboBind(InspectionFormatId_cmb, inspectionformatDatatable, "Name", "Id");
                    //InspectionFormatId_cmb.SelectedValue = FormatId;
                }
            }
            GridBind();

            if (InspectionProcessDetails_dgv.Rows.Count > 0 && InspectionProcessDetails_dgv.Columns.Count > 0 &&
                                                                        InspectionProcessDetails_dgv.Columns["colInspectionProcessId"] != null)
            {
                int searchProcessId;
                if (frm.InspectionProcessId > 0)
                {
                    searchProcessId = frm.InspectionProcessId;
                }
                else
                {
                    searchProcessId = inspProcessVo.InspectionProcessId;
                }

                DataGridViewRow row = InspectionProcessDetails_dgv.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["colInspectionProcessId"].Value.ToString().Equals(searchProcessId.ToString()));

                if (row == null) { return; }

                InspectionProcessDetails_dgv.Rows[row.Index].Selected = true;

                InspectionProcessDetails_dgv_CellClick(sender, new DataGridViewCellEventArgs(0, row.Index));
            }

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
            int selectedrowindex = InspectionProcessDetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = InspectionProcessDetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colInspectionProcessName"].Value.ToString());
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                InspectionProcessVo inVo = new InspectionProcessVo();

                inVo.InspectionProcessId = Convert.ToInt32(selectedRow.Cells["colInspectionProcessId"].Value.ToString());
                inVo.DeleteFlag = true;
                //inVo.InspectionProcessCode = selectedRow.Cells["colInspectionProcessCode"].Value.ToString();

                string message = string.Format(Properties.Resources.mmci00038, "Inspection Process", selectedRow.Cells["colInspectionProcessName"].Value.ToString());
                StartProgress(message);

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                InspectionFormatVo passformatVo = FormFormatVo(inVo.InspectionProcessId);
                if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                inVoList.add(passformatVo);
                inVoList.add(inVo);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);

                InspectionReturnVo outVo = new InspectionReturnVo();

                try
                {
                    outVo = (InspectionReturnVo)base.InvokeCbm(new UpdateAllInspectionFunctionMasterMntCbm(), inVoList, false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }
                finally
                {
                    CompleteProgress();
                }

                if (outVo == null) { return; }
                if (outVo.InspectionFormatId > 0) FormatId = outVo.InspectionFormatId;
                //FormDatatableFromVo();
                //ComboBind(InspectionFormatId_cmb, inspectionformatDatatable, "Name", "Id");
                //InspectionFormatId_cmb.SelectedValue = FormatId;
                GridBind();
                this.messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                logger.Info(this.messageData);
                popUpMessage.Information(this.messageData, Text);



                //try
                //{

                //    InspectionProcessVo tableCount = CheckInspectionProcessRelationCbm(inVo);
                //    if (tableCount.InspectionProcessId > 0)
                //    {
                //        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, InspectionItem.ToString());
                //        popUpMessage.Information(messageData, Text);
                //        return;
                //    }

                //    InspectionProcessVo outVo = (InspectionProcessVo)base.InvokeCbm(new DeleteInspectionProcessMasterMntCbm(), inVo, false);

                //    if (outVo.AffectedCount > 0)
                //    {
                //        this.messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                //        logger.Info(this.messageData);
                //        popUpMessage.Information(this.messageData, Text);

                //        GridBind();
                //    }
                //    else if (outVo.AffectedCount == 0)
                //    {
                //        messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                //        logger.Info(messageData);
                //        popUpMessage.Information(messageData, Text);
                //        GridBind();
                //    }
                //}
                //catch (Framework.ApplicationException exception)
                //{
                //    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                //    logger.Error(exception.GetMessageData());
                //}
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
            if (InspectionProcessDetails_dgv.SelectedRows.Count > 0)
            {
                InspectionItem_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                InspectionItem_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// open update form on double click on the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionProcessDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionProcessDetails_dgv.SelectedRows.Count > 0)
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
            //FormDatatableFromVo();
            //ComboBind(InspectionFormatId_cmb, inspectionformatDatatable, "Name", "Id");
            //InspectionFormatId_cmb.SelectedValue = FormatId;
            InspectionFormatId_cmb.Text = FormatName;
            InspectionItem_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;
            GridBind();
        }

        #endregion

        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<InspectionProcessVo> outVo)
        {
            InspectionProcessDetails_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionProcessDetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            ChangeGridDataColorForRelationDataCheck();
            InspectionProcessDetails_dgv.ClearSelection();
        }

        private void InspectionProcessDetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            DataGridViewColumn column = InspectionProcessDetails_dgv.Columns[e.ColumnIndex];

            if (InspectionProcessDetails_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)InspectionProcessDetails_dgv.DataSource;

            List<InspectionProcessVo> dataSourceVo = (List<InspectionProcessVo>)currentDatagridSource.DataSource;

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
                InspectionProcessDetails_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        private void InspectionProcessDetails_dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || InspectionProcessDetails_dgv.RowCount == 0 || InspectionProcessDetails_dgv.SelectedCells.Count == 0)
                return;

            DataGridView.HitTestInfo hti = InspectionProcessDetails_dgv.HitTest(e.X, e.Y);
            if (hti.RowIndex < 0 || hti.ColumnIndex < 0)
                return;

            if (InspectionProcessDetails_dgv.CurrentRow.Cells["colInspectionProcessId"].Value != null)
            {
                ProcessCopy_cntxMnu.Items.Clear();
                ProcessCopy_cntxMnu.Items.Add("Copy");
                Point relativeMousePosition = InspectionProcessDetails_dgv.PointToClient(Cursor.Position);
                ProcessCopy_cntxMnu.Show(InspectionProcessDetails_dgv, relativeMousePosition);
            }
        }

        private void ProcessCopy_cntxMnu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.ClickedItem.Text) || InspectionProcessDetails_dgv.Rows.Count == 0)
            {
                return;
            }

            if (InspectionProcessDetails_dgv.SelectedRows.Count > 0)
            {
                ProcessCopy_cntxMnu.Items.Clear();

                this.Cursor = Cursors.WaitCursor;

                int selectedrowindex = InspectionProcessDetails_dgv.SelectedCells[0].RowIndex;

                InspectionProcessVo InspectionCopyVo = (InspectionProcessVo)InspectionProcessDetails_dgv.Rows[selectedrowindex].DataBoundItem;

                InspectionProcessVo inspProcessVo = new InspectionProcessVo();
                inspProcessVo.InspectionFormatId = FormatId;
                inspProcessVo.InspectionFormatCode = FormatCode;
                inspProcessVo.InspectionFormatName = FormatName;
                inspProcessVo.InspectionProcessIdCopy = InspectionCopyVo.InspectionProcessId;
                inspProcessVo.InspectionProcessName = InspectionCopyVo.InspectionProcessName;

                AddInspectionProcessForFormatForm newAddForm = new AddInspectionProcessForFormatForm(CommonConstants.MODE_ADD, inspProcessVo);

                newAddForm.ShowDialog();

                if (newAddForm.IntSuccess > 0)
                {
                    messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);

                    GridBind();

                    if (InspectionProcessDetails_dgv.Rows.Count > 0 && InspectionProcessDetails_dgv.Columns.Count > 0 &&
                                                                            InspectionProcessDetails_dgv.Columns["colInspectionProcessId"] != null)
                    {
                        int searchProcessId;
                        if (newAddForm.IntSuccess > 0)
                        {
                            searchProcessId = newAddForm.IntSuccess;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            return;
                        }

                        DataGridViewRow row = InspectionProcessDetails_dgv.Rows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(r => r.Cells["colInspectionProcessId"].Value.ToString().Equals(searchProcessId.ToString()));

                        if (row == null) { this.Cursor = Cursors.Default; return; }

                        InspectionProcessDetails_dgv.Rows[row.Index].Selected = true;
                        InspectionProcessDetails_dgv_CellClick(sender, new DataGridViewCellEventArgs(0, row.Index));
                        InspectionProcessDetails_dgv.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                }

                this.Cursor = Cursors.Default;
            }
        }
    }
}
