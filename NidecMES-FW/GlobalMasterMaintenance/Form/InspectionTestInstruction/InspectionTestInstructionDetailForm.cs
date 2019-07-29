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
    public partial class InspectionTestInstructionDetailForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private string mode = string.Empty;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// for loading equipment details
        /// </summary>
        private DataTable inspectionTestInstructionDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(InspectionTestInstructionDetailForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        ///  get message data
        /// </summary>
        private const string InspectionTestInstruction = "InspectionTestInstruction";

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        /// <summary>
        /// 
        /// </summary>
        private InspectionTestInstructionVo updateData;

        public int InspectionTestInstructionId;
        #endregion

        #region Constructor 

        /// <summary>
        /// constructor
        /// </summary>
        public InspectionTestInstructionDetailForm(InspectionTestInstructionVo userdata)
        {
            updateData = userdata;
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods 

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind()
        {

            Update_btn.Enabled = false;

            Delete_btn.Enabled = false;

            InspectionTestInstructionVo conditionInVo = new InspectionTestInstructionVo();
            conditionInVo.InspectionTestInstructionId = updateData.InspectionTestInstructionId;

            InspectionTestInstructionDetail_dgv.DataSource = null;

            ValueObjectList<InspectionTestInstructionVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionTestInstructionVo>)base.InvokeCbm(new GetInspectionTestInstructionDetailMasterMntCbm(), conditionInVo, false);

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
            InspectionTestInstructionDetail_dgv.AutoGenerateColumns = false;

            BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionTestInstructionDetail_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            InspectionTestInstructionDetail_dgv.ClearSelection();

        }

        /// <summary>
        /// GetInspTestCode
        /// </summary>
        private void GetInspTestCode()
        {
            
            InspectionTestInstructionVo conditionInVo = new InspectionTestInstructionVo();
            conditionInVo.InspectionTestInstructionId = updateData.InspectionTestInstructionId;

            InspectionTestInstructionDetail_dgv.DataSource = null;

            ValueObjectList<InspectionTestInstructionVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionTestInstructionVo>)base.InvokeCbm(new GetInspectionTestInstructionMasterCbm(), conditionInVo, false);

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
            updateData.InspectionTestInstructionCode = outVo.GetList()[0].InspectionTestInstructionCode;
        }

        /// <summary>
        /// passing update data to update form
        /// </summary>
        private void BindUpdateInspectionTestInstructionDetailData()
        {
            int selectedrowindex = InspectionTestInstructionDetail_dgv.SelectedCells[0].RowIndex;

            InspectionTestInstructionVo inspTestInstructionVo = (InspectionTestInstructionVo)InspectionTestInstructionDetail_dgv.Rows[selectedrowindex].DataBoundItem;

            AddInspectionTestInstructionDetailForm newAddForm = new AddInspectionTestInstructionDetailForm(CommonConstants.MODE_UPDATE, inspTestInstructionVo);
            newAddForm.InspectionTestInstructionText = updateData.InspectionTestInstructionText;

            newAddForm.ShowDialog(this);

            if (newAddForm.InspectionTestInstructionId > 0)
            {
                updateData.InspectionTestInstructionId = newAddForm.InspectionTestInstructionId;
                InspectionTestInstructionId = newAddForm.InspectionTestInstructionId;
                GetInspTestCode();
            }
            GridBind();

            InspectionTestInstructionDetail_dgv.Rows[selectedrowindex].Selected = true;
            InspectionTestInstructionDetail_dgv_CellClick(this, new DataGridViewCellEventArgs(0, selectedrowindex));
            InspectionTestInstructionDetail_dgv.FirstDisplayedScrollingRowIndex = selectedrowindex;
            
            //if (newAddForm.IntSuccess > 0)
            //{
            //    messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
            //    logger.Info(messageData);
            //    popUpMessage.Information(messageData, Text);

            //    GridBind();
            //}
            //else if (newAddForm.IntSuccess == 0)
            //{
            //    messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
            //    logger.Info(messageData);
            //    popUpMessage.Information(messageData, Text);
            //    GridBind();
            //}
        }

        /// <summary>
        /// Loads data table for inspectionformat 
        /// </summary>
        private void FormDatatableFromVo()
        {
            inspectionTestInstructionDatatable = new DataTable();
            inspectionTestInstructionDatatable.Columns.Add("Id");
            inspectionTestInstructionDatatable.Columns.Add("Name");

            ValueObjectList<InspectionTestInstructionVo> inspectionTestInstructionOutVo = null;

            try
            {

                inspectionTestInstructionOutVo = (ValueObjectList<InspectionTestInstructionVo>)base.InvokeCbm(new GetInspectionTestInstructionMasterCbm(), new InspectionTestInstructionVo(), false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (inspectionTestInstructionOutVo == null || inspectionTestInstructionOutVo.GetList() == null || inspectionTestInstructionOutVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            foreach (InspectionTestInstructionVo fac in inspectionTestInstructionOutVo.GetList())
            {
                inspectionTestInstructionDatatable.Rows.Add(fac.InspectionTestInstructionId, fac.InspectionTestInstructionText);
            }

        }

        /// <summary>
        /// To get the Format Id based on item id
        /// </summary>
        /// <param name="inspectionItemId"></param>
        /// <returns></returns>
        private InspectionFormatVo FormFormatVo(int testinstructionid)
        {
            InspectionFormatProcessBuzzLogic getFormatdetails = new InspectionFormatProcessBuzzLogic();
            CopyInspectionFormatVo inVo = new CopyInspectionFormatVo();
            inVo.InspectionTestInstructionId = testinstructionid;
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

            AddInspectionTestInstructionDetailForm newAddForm = new AddInspectionTestInstructionDetailForm(CommonConstants.MODE_ADD, null);
            newAddForm.InspectionTestInstructionId = updateData.InspectionTestInstructionId;
            newAddForm.InspectionTestInstructionCode = updateData.InspectionTestInstructionCode;
            newAddForm.InspectionTestInstructionText = updateData.InspectionTestInstructionText;

            newAddForm.ShowDialog();
            if (newAddForm.IntSuccess > 0)
            {
                GridBind();

                if(InspectionTestInstructionDetail_dgv.Rows.Count> 0)
                {
                    InspectionTestInstructionDetail_dgv.Rows[InspectionTestInstructionDetail_dgv.Rows.Count - 1].Selected = true;
                    InspectionTestInstructionDetail_dgv_CellClick(sender, new DataGridViewCellEventArgs(0, InspectionTestInstructionDetail_dgv.Rows.Count - 1));
                    InspectionTestInstructionDetail_dgv.FirstDisplayedScrollingRowIndex = InspectionTestInstructionDetail_dgv.Rows.Count - 1;
                }

                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

            }
        }

        /// <summary>
        /// clear the condition control values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            InspectionTestInstructionDetail_dgv.DataSource = null;

            Update_btn.Enabled = Delete_btn.Enabled = false;

            Add_btn.Select();
        }


        /// <summary>
        /// fetch record from db by condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Search_btn_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(InspectionTestInstructionId_cmb.Text) && !(InspectionTestInstructionId_cmb.SelectedIndex > -1))
        //    {
        //        messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, InspectionTestInstructionId_lbl.Text);
        //        popUpMessage.Warning(messageData, Text);
        //        InspectionTestInstructionId_cmb.Focus();
        //        return;
        //    }

        //    GridBind(FormConditionVo());
        //}

        /// <summary>
        /// open the update form with selected record bind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateInspectionTestInstructionDetailData();
        }

        /// <summary>
        /// delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = InspectionTestInstructionDetail_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = InspectionTestInstructionDetail_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colInspectionTestInstructionDetailText"].Value.ToString());
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {

                InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();

                inVo.InspectionTestInstructionDetailId = Convert.ToInt32(selectedRow.Cells["colInspectionTestInstructionDetailId"].Value.ToString());
                inVo.InspectionTestInstructionId = Convert.ToInt32(selectedRow.Cells["colInspectionTestInstructionId"].Value.ToString());
                inVo.DeleteFlag = true;

                string message = string.Format(Properties.Resources.mmci00038, "Inspection Test Instruction Detail", selectedRow.Cells["colInspectionTestInstructionDetailText"].Value.ToString());
                StartProgress(message);

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                InspectionFormatVo passformatVo = FormFormatVo(updateData.InspectionTestInstructionId);
                if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                inVoList.add(passformatVo);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(null);
                inVoList.add(inVo);
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
                if (outVo == null) return;

                InspectionTestInstructionId = outVo.InspectionTestInstructionId;
                updateData.InspectionTestInstructionId = outVo.InspectionTestInstructionId;
                
                GetInspTestCode();
                GridBind();

                this.messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                logger.Info(this.messageData);
                popUpMessage.Information(this.messageData, Text);
                

                //inVo.InspectionTestInstructionDetailCode = selectedRow.Cells["colInspectionTestInstructionDetailCode"].Value.ToString();
                //try
                //{

                //    InspectionTestInstructionVo outVo = (InspectionTestInstructionVo)base.InvokeCbm(new DeleteInspectionTestInstructionDetailMasterMntCbm(), inVo, false);

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
        private void InspectionTestInstructionDetail_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionTestInstructionDetail_dgv.SelectedRows.Count > 0)
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
        private void InspectionTestInstructionDetail_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionTestInstructionDetail_dgv.SelectedRows.Count > 0)
            {
                BindUpdateInspectionTestInstructionDetailData();
            }
        }

        #endregion

        #region FormEvents 
        /// <summary>
        /// load  the form with  combobox bind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionTestInstructionDetailForm_Load(object sender, EventArgs e)
        {
            if (updateData == null)
            {
                return;
            }
            InspectionTestInstructionCode_txt.Text = updateData.InspectionTestInstructionCode;
            InspectionTestInstructionDetail_txt.Text = updateData.InspectionTestInstructionText;

            Update_btn.Enabled = Delete_btn.Enabled = false;

            InspectionTestInstructionCode_txt.ReadOnly = InspectionTestInstructionDetail_txt.ReadOnly = true;

            GridBind();
        }

        #endregion
        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<InspectionTestInstructionVo> outVo)
        {
            InspectionTestInstructionDetail_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionTestInstructionDetail_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            InspectionTestInstructionDetail_dgv.ClearSelection();
        }
        private void InspectionTestInstructionDetail_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = InspectionTestInstructionDetail_dgv.Columns[e.ColumnIndex];

            if (InspectionTestInstructionDetail_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)InspectionTestInstructionDetail_dgv.DataSource;

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
                InspectionTestInstructionDetail_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

    }
}
