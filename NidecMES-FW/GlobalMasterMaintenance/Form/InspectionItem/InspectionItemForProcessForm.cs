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
    public partial class InspectionItemForProcessForm
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

        /// <summary>
        /// 
        /// </summary>
        public int InspectionProcessId;

        /// <summary>
        /// 
        /// </summary>
        public string InspectionProcessCode;

        /// <summary>
        /// 
        /// </summary>
        public string InspectionProcessName;
        
        /// <summary>
        /// 
        /// </summary>
        public int InspectionFormatId;

        /// <summary>
        /// 
        /// </summary>
        public InspectionItemSelectionDatatypeValueVo UpdateInspectionItemSelectionDatatypeValueVo { get; set; }

        /// <summary>
        /// Check for copy function used or not
        /// </summary>
        private bool is_Copied = false;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor
        /// </summary>
        public InspectionItemForProcessForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all inspection Item records to gridview control
        /// </summary>
        private void GridBind()
        {
            Update_btn.Enabled = Delete_btn.Enabled = InspectionSpecification_btn.Enabled = InspectionTestInstruction_btn.Enabled = false;

            InspectionItemVo conditionInVo = new Vo.InspectionItemVo();
            conditionInVo.InspectionProcessId = InspectionProcessId;
            InspectionItem_dgv.DataSource = null;

            ValueObjectList<InspectionItemVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionItemVo>)base.InvokeCbm(new GetInspectionItemMasterMntCbm(), conditionInVo, false);
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
                // popUpMessage.Information(messageData, Text);
                return;
            }
            ValueObjectList<InspectionItemVo> FormattedoutVo = new ValueObjectList<InspectionItemVo>();

            FormattedoutVo = FormDisplayOrder(outVo, 0, new ValueObjectList<InspectionItemVo>());

            BindingList<List<UserVo>> userBind = new BindingList<List<UserVo>>();

            InspectionItem_dgv.AutoGenerateColumns = false;

            BindingSource bindingSource1 = new BindingSource(FormattedoutVo.GetList(), null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionItem_dgv.DataSource = bindingSource1;
            }
            ChangeGridDataColorForRelationDataCheck();
            InspectionItem_dgv.ClearSelection();
        }

        private ValueObjectList<InspectionItemVo> FormDisplayOrder(ValueObjectList<InspectionItemVo> outvo, int parentId, ValueObjectList<InspectionItemVo> formattedVo)
        {
            ValueObjectList<InspectionItemVo> returnformattedVo = formattedVo;
            List<InspectionItemVo> getChilditem = outvo.GetList().Where(t => t.ParentInspectionItemId == parentId).ToList();
            foreach (InspectionItemVo currvo in getChilditem)
            {
                if (currvo.ParentInspectionItemId == 0)
                {
                    currvo.FormattedDisplayOrder = currvo.DisplayOrder.ToString();
                }
                else
                {
                    InspectionItemVo getdisplayorderVo = returnformattedVo.GetList().Where(t => t.InspectionItemId == parentId).FirstOrDefault();

                    currvo.FormattedDisplayOrder = getdisplayorderVo.FormattedDisplayOrder + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + currvo.DisplayOrder;
                }
                returnformattedVo.add(currvo);
                FormDisplayOrder(outvo, currvo.InspectionItemId, returnformattedVo);
            }

            return returnformattedVo;
        }

        private void ChangeGridDataColorForRelationDataCheck()
        {
            foreach (DataGridViewRow row in InspectionItem_dgv.Rows)
            {
                InspectionItemVo InspectionUpdateVo = (InspectionItemVo)row.DataBoundItem;
                if (InspectionUpdateVo.InspectionSpecificationId == 0)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    InspectionUpdateVo.InspectionSpecificationText = Properties.Resources.mmci00024;
                }
                if (InspectionUpdateVo.InspectionTestInstructionId == 0)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    InspectionUpdateVo.InspectionTestInstructionText = Properties.Resources.mmci00025;
                }
                if (InspectionUpdateVo.InspectionTestInstructionDetailId == 0)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.Cells["colComments"].Value = Properties.Resources.mmci00035;
                }
            }
        }
        /// <summary>
        /// selects inspection record for updation and show Inspection form
        /// </summary>
        private void BindUpdateInspectionItemData()
        {
            int selectedrowindex = InspectionItem_dgv.SelectedCells[0].RowIndex;

            InspectionItemVo InspectionUpdateVo = (InspectionItemVo)InspectionItem_dgv.Rows[selectedrowindex].DataBoundItem;

            AddInspectionItemForProcessForm newAddForm = new AddInspectionItemForProcessForm(CommonConstants.MODE_UPDATE, InspectionUpdateVo);

            newAddForm.ShowDialog(this);

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
               
            }
            else if (newAddForm.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }

            if (newAddForm.ReturnProcessId > 0) InspectionProcessId = newAddForm.ReturnProcessId;
            //LoadInspectionProcessCombo();
            //InspectionProcess_cmb.SelectedValue = InspectionProcessId;
            GridBind();

            InspectionItem_dgv.Rows[selectedrowindex].Selected = true;
            InspectionItem_dgv_CellClick(this, new DataGridViewCellEventArgs(0, selectedrowindex));
            InspectionItem_dgv.FirstDisplayedScrollingRowIndex = selectedrowindex;

            if (InspectionItem_dgv.Rows[selectedrowindex].Cells["colInsSpecification"].Value != null && 
                                InspectionItem_dgv.Rows[selectedrowindex].Cells["colInsSpecification"].Value.ToString() == Properties.Resources.mmci00024)
            {
                InspectionSpecification_btn_Click(this, new EventArgs());
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
            ChangeGridDataColorForRelationDataCheck();
            InspectionItem_dgv.ClearSelection();
        }

        /// <summary>
        /// Load Inspection Process
        /// </summary>
        private void LoadInspectionProcessCombo()
        {
            ValueObjectList<InspectionProcessVo> outVo = null;
            InspectionProcessVo inVo = new InspectionProcessVo();
            //inVo.InspectionFormatId = InspectionFormatId;
            try
            {
                outVo = (ValueObjectList<InspectionProcessVo>)base.InvokeCbm(new GetInsepctionProcessMasterMntCbm(), inVo, false);
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
            InspectionProcess_cmb.DisplayMember = "InspectionProcessName";
            InspectionProcess_cmb.ValueMember = "InspectionProcessId";
            InspectionProcess_cmb.DataSource = outVo.GetList();
            InspectionProcess_cmb.SelectedValue = InspectionProcessId;
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

        /// <summary>
        /// To get the Format Id based on item id
        /// </summary>
        /// <param name="inspectionItemId"></param>
        /// <returns></returns>
        private InspectionFormatVo FormFormatVo(int inspectionitemid)
        {
            InspectionFormatProcessBuzzLogic getFormatdetails = new InspectionFormatProcessBuzzLogic();
            CopyInspectionFormatVo inVo = new CopyInspectionFormatVo();
            inVo.InspectionItemId = inspectionitemid;
            return getFormatdetails.getFormatDetails(inVo);
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
            //LoadInspectionProcessCombo();
            InspectionProcess_cmb.Text = InspectionProcessName;
            Update_btn.Enabled = InspectionSpecification_btn.Enabled = InspectionTestInstruction_btn.Enabled = Delete_btn.Enabled = false;
            GridBind();            
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// search data using condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        /// <summary>
        /// load add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            InspectionItemVo inspectionInVo = new InspectionItemVo();
            inspectionInVo.InspectionProcessId = InspectionProcessId;
            inspectionInVo.InspectionProcessCode = InspectionProcessCode;
            inspectionInVo.InspectionProcessName = InspectionProcessName;

            AddInspectionItemForProcessForm newAddForm = new AddInspectionItemForProcessForm(CommonConstants.MODE_ADD, inspectionInVo);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);                
            }

            is_Copied = newAddForm.is_Copied;

            GridBind();

            if (InspectionItem_dgv.Rows.Count > 0 && InspectionItem_dgv.Columns.Count > 0 && InspectionItem_dgv.Columns["ColInspectionItemId"] != null)
            {
                int searchItemId;
                if (newAddForm.IntSuccess > 0)
                {
                    searchItemId = newAddForm.IntSuccess;
                }
                else
                {
                    return;
                }

                DataGridViewRow row = InspectionItem_dgv.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["ColInspectionItemId"].Value.ToString().Equals(searchItemId.ToString()));

                if (row == null) { return; }

                InspectionItem_dgv.Rows[row.Index].Selected = true;
                InspectionItem_dgv_CellClick(sender, new DataGridViewCellEventArgs(0, row.Index));
                InspectionItem_dgv.FirstDisplayedScrollingRowIndex = row.Index;

                if ((InspectionItem_dgv.Rows[row.Index].Cells["colInsSpecification"].Value != null &&
                                InspectionItem_dgv.Rows[row.Index].Cells["colInsSpecification"].Value.ToString() == Properties.Resources.mmci00024) || is_Copied == true)
                {
                    InspectionSpecification_btn_Click(sender, e);
                }

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

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colInspectionItemName"].Value.ToString());
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                InspectionItemVo inVo = new InspectionItemVo
                {
                    //InspectionItemCode = selectedRow.Cells["colInspectionItemCode"].Value.ToString(),
                    InspectionItemId = Convert.ToInt32(selectedRow.Cells["ColInspectionItemId"].Value),
                    InspectionProcessId = Convert.ToInt32(selectedRow.Cells["colInspectionProcessId"].Value),
                    DeleteFlag = true
                };

                string message = string.Format(Properties.Resources.mmci00038, "Inspection Item", selectedRow.Cells["colInspectionItemName"].Value.ToString());
                StartProgress(message);

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                InspectionFormatVo passformatVo = FormFormatVo(inVo.InspectionItemId);
                if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                inVoList.add(passformatVo);
                inVoList.add(null);
                inVoList.add(inVo);
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
                if (outVo.InspectionProcessId > 0) InspectionProcessId = outVo.InspectionProcessId;
                //LoadInspectionProcessCombo();
                //InspectionProcess_cmb.SelectedValue = InspectionProcessId;
                GridBind();

                messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                

                //try
                //{
                //    InspectionItemVo checkVo = CheckRelation(inVo);

                //    if (checkVo != null && (checkVo.InspectionItemId > 0 || checkVo.AffectedCount>0) )
                //    {
                //        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, "[INSPECTION SPECIFICATION, INSPECTION INSTRUCTION, PARENT ITEM ID]");
                //        popUpMessage.Information(messageData, Text);
                //        return;
                //    }

                //    InspectionItemVo outVo = (InspectionItemVo)base.InvokeCbm(new DeleteInspectionItemMasterMntCbm(), inVo, false);

                //    if (outVo.AffectedCount > 0)
                //    {
                //        messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                //        logger.Info(messageData);
                //        popUpMessage.Information(messageData, Text);

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
            newAddForm.InspectionItemCode = InspectionAddVo.InspectionItemCode;
            newAddForm.InspectionItemName = InspectionAddVo.InspectionItemName;
            newAddForm.InspectionItemDataType = InspectionAddVo.InspectionItemDataType;
            newAddForm.InspectionProcessId = InspectionAddVo.InspectionProcessId;
            newAddForm.ShowDialog();
            if (newAddForm.InspectionItemId > 0)
            {
                InspectionFormatProcessBuzzLogic getprocessid = new InspectionFormatProcessBuzzLogic();
                InspectionReturnVo invo = new InspectionReturnVo();
                invo.InspectionItemId = newAddForm.InspectionItemId;
                InspectionReturnVo getInspectionVo = getprocessid.RefreshAllFormGrid(invo);
                if(getInspectionVo != null && getInspectionVo.InspectionProcessId > 0)
                {
                    InspectionProcessId = getInspectionVo.InspectionProcessId;
                    //LoadInspectionProcessCombo();
                    //InspectionProcess_cmb.SelectedValue = InspectionProcessId;
                }
            }

            if (newAddForm.InspectionItemId == -1) { return; }

            GridBind();

            if (InspectionItem_dgv.Rows.Count > 0 && InspectionItem_dgv.Columns.Count > 0 && InspectionItem_dgv.Columns["ColInspectionItemId"] != null)
            {
                int searchItemId;
                if (newAddForm.InspectionItemId > 0)
                {
                    searchItemId = newAddForm.InspectionItemId;
                }
                else
                {
                    searchItemId = InspectionAddVo.InspectionItemId;
                }

                DataGridViewRow row = InspectionItem_dgv.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["ColInspectionItemId"].Value.ToString().Equals(searchItemId.ToString()));

                if (row == null) { return; }

                InspectionItem_dgv.Rows[row.Index].Selected = true;
                InspectionItem_dgv_CellClick(sender, new DataGridViewCellEventArgs(0, row.Index));
                InspectionItem_dgv.FirstDisplayedScrollingRowIndex = row.Index;

                //(InspectionItem_dgv.Rows[row.Index].Cells["colComments"].Value != null && 
                //InspectionItem_dgv.Rows[row.Index].Cells["colComments"].Value.ToString() == Properties.Resources.mmci00035)

                if ((InspectionItem_dgv.Rows[row.Index].Cells["colTestInstruction"].Value != null && 
                              InspectionItem_dgv.Rows[row.Index].Cells["colTestInstruction"].Value.ToString() == Properties.Resources.mmci00025) || is_Copied == true)                    
                {
                    InspectionTestInstruction_btn_Click(sender, e);
                }              
            }

        }

        private void InspectionTestInstruction_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = InspectionItem_dgv.SelectedCells[0].RowIndex;
            InspectionItemVo InspectionAddVo = (InspectionItemVo)InspectionItem_dgv.Rows[selectedrowindex].DataBoundItem;

            InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();
            inVo.InspectionTestInstructionId = InspectionAddVo.InspectionTestInstructionId;
            inVo.InspectionTestInstructionCode = InspectionAddVo.InspectionTestInstructionCode;
            inVo.InspectionItemId = InspectionAddVo.InspectionItemId;
            inVo.InspectionItemCode = InspectionAddVo.InspectionItemCode;
            inVo.InspectionItemName = InspectionAddVo.InspectionItemName;

            AddInspectionTestInstructionForItemForm newAddForm = new AddInspectionTestInstructionForItemForm(CommonConstants.MODE_ADD, inVo);
            newAddForm.InspectionProcessId = InspectionProcessId;
            newAddForm.ShowDialog();
            if (newAddForm.InspectionItemId > 0)
            {
                InspectionFormatProcessBuzzLogic getprocessid = new InspectionFormatProcessBuzzLogic();
                InspectionReturnVo invo = new InspectionReturnVo();
                invo.InspectionItemId = newAddForm.InspectionItemId;
                InspectionReturnVo getInspectionVo = getprocessid.RefreshAllFormGrid(invo);
                if (getInspectionVo != null && getInspectionVo.InspectionProcessId > 0)
                {
                    InspectionProcessId = getInspectionVo.InspectionProcessId;
                    //LoadInspectionProcessCombo();
                    //InspectionProcess_cmb.SelectedValue = InspectionProcessId;
                }
            }

            GridBind();

            if (InspectionItem_dgv.Rows.Count > 0 && InspectionItem_dgv.Columns.Count > 0 && InspectionItem_dgv.Columns["ColInspectionItemId"] != null)
            {
                int searchItemId;
                if (newAddForm.InspectionItemId > 0)
                {
                    searchItemId = newAddForm.InspectionItemId;
                }
                else
                {
                    searchItemId = InspectionAddVo.InspectionItemId;
                }

                DataGridViewRow row = InspectionItem_dgv.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells["ColInspectionItemId"].Value.ToString().Equals(searchItemId.ToString()));

                if (row == null) { return; }

                InspectionItem_dgv.Rows[row.Index].Selected = true;
                InspectionItem_dgv_CellClick(sender, new DataGridViewCellEventArgs(0, row.Index));
                InspectionItem_dgv.FirstDisplayedScrollingRowIndex = row.Index;
            }

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

        private void ItemCopy_cntxMnu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.ClickedItem.Text) || InspectionItem_dgv.Rows.Count == 0)
            {
                return;
            }

            if (InspectionItem_dgv.SelectedRows.Count > 0)
            {
                ItemCopy_cntxMnu.Items.Clear();

                this.Cursor = Cursors.WaitCursor;

                int selectedrowindex = InspectionItem_dgv.SelectedCells[0].RowIndex;

                InspectionItemVo InspectionCopyVo = (InspectionItemVo)InspectionItem_dgv.Rows[selectedrowindex].DataBoundItem;

                InspectionItemVo inspectionInVo = new InspectionItemVo();
                inspectionInVo.InspectionProcessId = InspectionProcessId;
                inspectionInVo.InspectionProcessCode = InspectionProcessCode;
                inspectionInVo.InspectionProcessName = InspectionProcessName;
                inspectionInVo.InspectionItemIdCopy = InspectionCopyVo.InspectionItemId;
                inspectionInVo.InspectionItemName= InspectionCopyVo.InspectionItemName;

                AddInspectionItemForProcessForm newAddForm = new AddInspectionItemForProcessForm(CommonConstants.MODE_ADD, inspectionInVo);

                newAddForm.ShowDialog();

                if (newAddForm.IntSuccess > 0)
                {
                    messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                is_Copied = newAddForm.is_Copied;

                GridBind();

                if (InspectionItem_dgv.Rows.Count > 0 && InspectionItem_dgv.Columns.Count > 0 && InspectionItem_dgv.Columns["ColInspectionItemId"] != null)
                {
                    int searchItemId;
                    if (newAddForm.IntSuccess > 0)
                    {
                        searchItemId = newAddForm.IntSuccess;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }

                    DataGridViewRow row = InspectionItem_dgv.Rows
                        .Cast<DataGridViewRow>()
                        .FirstOrDefault(r => r.Cells["ColInspectionItemId"].Value.ToString().Equals(searchItemId.ToString()));

                    if (row == null) { this.Cursor = Cursors.Default; return; }

                    InspectionItem_dgv.Rows[row.Index].Selected = true;
                    InspectionItem_dgv_CellClick(sender, new DataGridViewCellEventArgs(0, row.Index));
                    InspectionItem_dgv.FirstDisplayedScrollingRowIndex = row.Index;

                    if ((InspectionItem_dgv.Rows[row.Index].Cells["colInsSpecification"].Value != null &&
                                    InspectionItem_dgv.Rows[row.Index].Cells["colInsSpecification"].Value.ToString() == Properties.Resources.mmci00024) || is_Copied == true)
                    {
                        InspectionSpecification_btn_Click(sender, e);
                    }

                }
                this.Cursor = Cursors.Default;
            }
        }
        
        private void InspectionItem_dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || InspectionItem_dgv.RowCount == 0 || InspectionItem_dgv.SelectedCells.Count == 0)
                return;

            DataGridView.HitTestInfo hti = InspectionItem_dgv.HitTest(e.X, e.Y);
            if (hti.RowIndex < 0 || hti.ColumnIndex < 0)
                return;

            if (InspectionItem_dgv.CurrentRow.Cells["ColInspectionItemId"].Value != null)
            {
                ItemCopy_cntxMnu.Items.Clear();
                ItemCopy_cntxMnu.Items.Add("Copy");
                Point relativeMousePosition = InspectionItem_dgv.PointToClient(Cursor.Position);
                ItemCopy_cntxMnu.Show(InspectionItem_dgv, relativeMousePosition);
            }
        }
    }
}
