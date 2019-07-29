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
    public partial class InspectionSelectionDatetypeValueForItemForm
    {

        #region property
        /// <summary>
        /// set or get InspectionItemId
        /// </summary>
        public int InspectionItemId { get; set; }

        /// <summary>
        /// set or get InspectionItemId
        /// </summary>
        public int InspectionProcessId { get; set; }

        /// <summary>
        /// set or get InspectionItemCode
        /// </summary>
        public string InspectionItemCode { get; set; }

        /// <summary>
        /// set or get InspectionItemDataType
        /// </summary>
        public int InspectionItemDataType { get; set; }

        /// <summary>
        /// set or get InspectionItemCode
        /// </summary>
        public string InspectionItemName { get; set; }

        #endregion

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
        public bool IsNewSelectionValue { get; internal set; }

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
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        /// <summary>
        /// 
        /// </summary>
        private InspectionItemVo inspectionItemdata;

        /// <summary>
        /// 
        /// </summary>
        public InspectionItemSelectionDatatypeValueVo UpdateInspectionItemSelectionDatatypeValueVo { get; set; }

        #endregion

        #region Constructor 

        /// <summary>
        /// constructor
        /// </summary>
        public InspectionSelectionDatetypeValueForItemForm(InspectionItemVo itemid)
        {
            inspectionItemdata = itemid;
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

            InspectionSelectionValue_dgv.DataSource = null;


            InspectionItemSelectionDatatypeValueVo conditionInVo = new InspectionItemSelectionDatatypeValueVo();
            if (inspectionItemdata == null || inspectionItemdata.InspectionItemId == 0)
            {
                conditionInVo.InspectionItemId = 0;
            }
            else
            {
                conditionInVo.InspectionItemId = inspectionItemdata.InspectionItemId;
            }


            ValueObjectList<InspectionItemSelectionDatatypeValueVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionItemSelectionDatatypeValueVo>)base.InvokeCbm(new GetInspectionItemSelectionDatatypeValueCbm(), conditionInVo, false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
            {

                return;
            }
            InspectionSelectionValue_dgv.AutoGenerateColumns = false;

            BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionSelectionValue_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            InspectionSelectionValue_dgv.ClearSelection();

        }


        /// <summary>
        /// passing update data to update form
        /// </summary>
        private void BindUpdateInspectionTestInstructionDetailData()
        {
            int selectedrowindex = InspectionSelectionValue_dgv.SelectedCells[0].RowIndex;

            InspectionItemSelectionDatatypeValueVo inspTestInstructionVo = (InspectionItemSelectionDatatypeValueVo)InspectionSelectionValue_dgv.Rows[selectedrowindex].DataBoundItem;

            AddInspectionSelectionDatetypeValueForItemForm newAddForm = new AddInspectionSelectionDatetypeValueForItemForm(CommonConstants.MODE_UPDATE, inspTestInstructionVo);

            newAddForm.ShowDialog(this);
            UpdateInspectionItemSelectionDatatypeValueVo = new InspectionItemSelectionDatatypeValueVo();
            UpdateInspectionItemSelectionDatatypeValueVo = newAddForm.UpdateInspectionItemSelectionDatatypeValueVo;

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                if (newAddForm.InspectionItemId > 0)
                {
                    inspectionItemdata.InspectionItemId = newAddForm.InspectionItemId;
                    InspectionItemId = newAddForm.InspectionItemId;
                    InspectionProcessId = newAddForm.InspectionProcessId;
                }
            }
            else if (newAddForm.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);                
            }
            GridBind();

            InspectionSelectionValue_dgv.Rows[selectedrowindex].Selected = true;
            InspectionTestInstructionDetail_dgv_CellClick(this, new DataGridViewCellEventArgs(0, selectedrowindex));
            InspectionSelectionValue_dgv.FirstDisplayedScrollingRowIndex = selectedrowindex;
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

        #region ButtonClick 

        /// <summary>
        /// insert  the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            InspectionItemSelectionDatatypeValueVo inVo = new InspectionItemSelectionDatatypeValueVo();
            inVo.InspectionItemId = inspectionItemdata.InspectionItemId;
            inVo.InspectionItemName = inspectionItemdata.InspectionItemName;
            inVo.InspectionItemCode = inspectionItemdata.InspectionItemCode;

            AddInspectionSelectionDatetypeValueForItemForm newAddForm = new AddInspectionSelectionDatetypeValueForItemForm(CommonConstants.MODE_ADD, inVo);
            newAddForm.InspectionItemCode = InspectionItemCode;
            //if (inspectionItemdata != null)
            //{
            //    newAddForm.InspectionItemId = inspectionItemdata.InspectionItemId;
            //    newAddForm.InspectionItemName = inspectionItemdata.InspectionItemName;
            //    newAddForm.InspectionItemCode = inspectionItemdata.InspectionItemCode;
            //}            

            newAddForm.ShowDialog();
            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);                
                GridBind();
            }
        }

        /// <summary>
        /// clear the condition control values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            InspectionSelectionValue_dgv.DataSource = null;

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
            int selectedrowindex = InspectionSelectionValue_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = InspectionSelectionValue_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colInspectionItemSelectionValueText"].Value.ToString());
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {

                InspectionItemSelectionDatatypeValueVo inVo = new InspectionItemSelectionDatatypeValueVo();

                inVo.InspectionItemSelectionDatatypeValueId = Convert.ToInt32(selectedRow.Cells["colInspectionItemSelectionDatatypeValueId"].Value.ToString());
                inVo.DeleteFlag = true;
                if(inspectionItemdata != null)
                {
                    inVo.InspectionItemId = inspectionItemdata.InspectionItemId;
                }
                else
                {
                    inVo.InspectionItemId = InspectionItemId;
                }

                //UpdateInspectionItemSelectionDatatypeValueVo = inVo;
                //this.Close();


                try
                {

                    UpdateResultVo deleteVo = null;

                    if (inspectionItemdata == null)
                    {
                        deleteVo = (UpdateResultVo)base.InvokeCbm(new DeleteInspectionItemSelectionDatatypeValueCbm(), inVo, false);
                        if (deleteVo == null) { return; }
                        IntSuccess = deleteVo.AffectedCount;

                        if (deleteVo.AffectedCount > 0)
                        {
                            this.messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                            logger.Info(this.messageData);
                            popUpMessage.Information(this.messageData, Text);
                        }
                        else if (deleteVo.AffectedCount == 0)
                        {
                            messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);
                        }

                        GridBind();
                    }
                    else
                    {
                        string message = string.Format(Properties.Resources.mmci00038, "Inspection Item Selection Datatype Value", selectedRow.Cells["colInspectionItemSelectionValueText"].Value.ToString());
                        StartProgress(message);

                        ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                        InspectionFormatVo passformatVo = FormFormatVo(inspectionItemdata.InspectionItemId);
                        if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                        inVoList.add(passformatVo);
                        inVoList.add(null);
                        inVoList.add(null);
                        inVoList.add(inVo);
                        inVoList.add(null);
                        inVoList.add(null);
                        inVoList.add(null);

                        InspectionReturnVo outVo = null;

                        try
                        {
                            outVo = (InspectionReturnVo)base.InvokeCbm(new UpdateAllInspectionFunctionMasterMntCbm(), inVoList, false);
                        }
                        catch (Framework.ApplicationException exception)
                        {
                            popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                            logger.Error(exception.GetMessageData());
                            return;
                        }
                        finally
                        {
                            CompleteProgress();
                        }
                        if (outVo != null && outVo.AffectedCount > 0)
                        {
                            IntSuccess = outVo.AffectedCount;
                            InspectionItemId = outVo.InspectionItemId;
                            inspectionItemdata.InspectionItemId = outVo.InspectionItemId;

                            InspectionFormatProcessBuzzLogic getprocessid = new InspectionFormatProcessBuzzLogic();
                            InspectionReturnVo invo = new InspectionReturnVo();
                            invo.InspectionItemId = outVo.InspectionItemId;
                            InspectionReturnVo getInspectionVo = getprocessid.RefreshAllFormGrid(invo);
                            if (getInspectionVo != null && getInspectionVo.InspectionProcessId > 0)
                            {
                                InspectionProcessId = getInspectionVo.InspectionProcessId;
                            }

                            this.messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                            logger.Info(this.messageData);
                            popUpMessage.Information(this.messageData, Text);

                            GridBind();
                        }
                        else
                        {
                            messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);
                        }
                    }

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }

                //string message = string.Format(Properties.Resources.mmci00038, "Inspection Selection DataType Value", selectedRow.Cells["colInspectionItemSelectionValueText"].Value.ToString());
                //StartProgress(message);

                //ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
                //InspectionFormatVo passformatVo = FormFormatVo(inspectionItemdata.InspectionItemId);
                //if (passformatVo == null || passformatVo.InspectionFormatId == 0) return;

                //inVoList.add(passformatVo);
                //inVoList.add(null);
                //inVoList.add(null);
                //inVoList.add(inVo);
                //inVoList.add(null);
                //inVoList.add(null);
                //inVoList.add(null);

                //UpdateResultVo outVo = (UpdateResultVo)base.InvokeCbm(new UpdateAllInspectionFunctionMasterMntCbm(), inVoList, false);

                //CompleteProgress();
                //if (outVo == null) { return; }

                //try
                //{
                //    UpdateResultVo outVo = (UpdateResultVo)base.InvokeCbm(new DeleteInspectionItemSelectionDatatypeValueCbm(), inVo, false);

                //    if (outVo.AffectedCount > 0)
                //    {
                //        this.messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                //        logger.Info(this.messageData);
                //        popUpMessage.Information(this.messageData, Text);                        
                //    }
                //    else if (outVo.AffectedCount == 0)
                //    {
                //        messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                //        logger.Info(messageData);
                //        popUpMessage.Information(messageData, Text);
                //    }
                //    GridBind();
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
            if (InspectionSelectionValue_dgv.RowCount > 0) { IsNewSelectionValue = true; }
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (InspectionSelectionValue_dgv.RowCount > 0) { IsNewSelectionValue = true; }
            this.Close();
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
            if (InspectionSelectionValue_dgv.SelectedRows.Count > 0)
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
            if (InspectionSelectionValue_dgv.SelectedRows.Count > 0)
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
        private void InspectionSelectionDatetypeValueForItemForm_Load(object sender, EventArgs e)
        {

            Update_btn.Enabled = Delete_btn.Enabled = false;

            if (!string.IsNullOrEmpty(InspectionItemName))
            {
                InspectionItem_cmb.Text = InspectionItemName;
            }
            GridBind();
        }

        #endregion
        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<InspectionItemSelectionDatatypeValueVo> outVo)
        {
            InspectionSelectionValue_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionSelectionValue_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            InspectionSelectionValue_dgv.ClearSelection();
        }
        private void InspectionTestInstructionDetail_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = InspectionSelectionValue_dgv.Columns[e.ColumnIndex];

            if (InspectionSelectionValue_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)InspectionSelectionValue_dgv.DataSource;

            List<InspectionItemSelectionDatatypeValueVo> dataSourceVo = (List<InspectionItemSelectionDatatypeValueVo>)currentDatagridSource.DataSource;

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
                InspectionSelectionValue_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        
    }
}
