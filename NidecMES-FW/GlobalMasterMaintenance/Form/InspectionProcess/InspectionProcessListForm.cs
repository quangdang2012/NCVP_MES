using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class InspectionProcessListForm
    {

        #region property

        /// <summary>
        /// set or get InspectionProcessId
        /// </summary>
        public int InspectionProcessId { get; set; }

        /// <summary>
        /// set or get InspectionProcessCode
        /// </summary>
        public string InspectionProcessCode { get; set; }

        /// <summary>
        /// set or get InspectionProcessName
        /// </summary>
        public string InspectionProcessName { get; set; }

        #endregion

        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(InspectionProcessListForm));

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
        public InspectionProcessListForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Loads inspectionProcess details to ComboBox
        /// </summary>
        private void LoadCombo()
        {

            //ValueObjectList<SapItemGlobalVo> sapItemVo = null;

            //StartProgress(Properties.Resources.mmci00009);
            //try
            //{
            //    sapItemVo = (ValueObjectList<SapItemGlobalVo>)base.InvokeCbm(new GetSapItemMasterMntCbm(), new SapItemGlobalVo(), false);
            //    if (sapItemVo == null || sapItemVo.GetList() == null || sapItemVo.GetList().Count == 0)
            //    {
            //        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
            //        logger.Info(messageData);
            //        popUpMessage.Information(messageData, Text);
            //        return;
            //    }
            //    //sapItemVo.GetList().ForEach(t => t.SapItemName = t.SapItemCode + "-" + t.SapItemName);

            //    ItemId_cmb.DisplayMember = "SapItemName";
            //    ItemId_cmb.ValueMember = "SapItemCode";
            //    ItemId_cmb.DataSource = sapItemVo.GetList();
            //    ItemId_cmb.SelectedIndex = -1;                
            //}
            //catch (Framework.ApplicationException exception)
            //{
            //    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
            //    logger.Error(exception.GetMessageData());
            //}
            //finally
            //{
            //    CompleteProgress();
            //}

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
        protected InspectionProcessVo FormConditionVo()
        {
            InspectionProcessVo inVo = new InspectionProcessVo();

            //if (ItemId_cmb.SelectedIndex > -1)
            //{
            //    inVo.ItemCode = ItemId_cmb.SelectedValue.ToString();
            //}
            if (ItemCode_txt.Text != string.Empty) // && sapItemGlobalVo != null
            {
                inVo.ItemCode = ItemCode_txt.Text; // sapItemGlobalVo.SapItemCode;
            }
            if (LineId_cmb.SelectedIndex > -1)
            {
                inVo.LineCode = LineId_cmb.SelectedValue.ToString();
            }

            return inVo;
        }

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        protected void GridBind(InspectionProcessVo conditionInVo)
        {
            if (conditionInVo == null)
            {
                return;
            }

            Ok_btn.Enabled = false;


            InspectionProcessDetails_dgv.DataSource = null;

            ValueObjectList<InspectionProcessVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionProcessVo>)base.InvokeCbm(new GetInspectionProcessForCopyMasterMntCbm(), conditionInVo, false);

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

            InspectionFormatName_txt.Text = outVo.GetList()[0].InspectionFormatName;

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

            InspectionProcessDetails_dgv.ClearSelection();

        }

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
            InspectionProcessDetails_dgv.ClearSelection();
        }

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            //if (ItemId_cmb.Text == string.Empty || ItemId_cmb.SelectedIndex < 0)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemId_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    ItemId_cmb.Focus();

            //    return false;
            //}

            if (ItemCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemId_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ItemCode_txt.Focus();

                return false;
            }

            if (LineId_cmb.Text == string.Empty || LineId_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LineId_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                LineId_cmb.Focus();

                return false;
            }
            return true;
        }

        #endregion

            #region FormEvents
            /// <summary>
            /// form load
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void InspectionProcessListForm_Load(object sender, EventArgs e)
        {
            Ok_btn.Enabled = false;           
            LoadCombo();
            ItemCode_txt.Select();
            // GridBind(new InspectionProcessVo());
            this.Activate();
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (InspectionProcessDetails_dgv.Rows.Count > 0 && InspectionProcessDetails_dgv.SelectedRows.Count > 0)
            {
                InspectionProcessVo inspectionprocessInVo = (InspectionProcessVo)InspectionProcessDetails_dgv.Rows[InspectionProcessDetails_dgv.CurrentRow.Index].DataBoundItem;
                InspectionProcessId = inspectionprocessInVo.InspectionProcessId;
                InspectionProcessName = inspectionprocessInVo.InspectionProcessName;
                InspectionProcessCode = inspectionprocessInVo.InspectionProcessCode;
            }
            this.Close();
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
        /// Handles inspectionProcess record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionProcessDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionProcessDetails_dgv.SelectedRows.Count > 0)
            {
                Ok_btn.Enabled = true;
            }
            else
            {
                Ok_btn.Enabled = false;
            }
        }


        /// <summary>
        /// sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionProcessDetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Ok_btn.Enabled = false;

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

        /// <summary>
        /// Search Inspection Procecss
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Search_btn_Click(object sender, EventArgs e)
        {
            if (CheckMandatory())
            {
                GridBind(FormConditionVo());
            }
        }
        /// <summary>
        /// Clear data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            InspectionProcessDetails_dgv.DataSource = null;
            LineId_cmb.SelectedIndex = -1;
            //ItemId_cmb.SelectedIndex = -1;
            ItemCode_txt.Text = string.Empty;
            sapItemSearchVo = null;
            InspectionFormatName_txt.Text = string.Empty;
        }


        #endregion
        
    }
}
