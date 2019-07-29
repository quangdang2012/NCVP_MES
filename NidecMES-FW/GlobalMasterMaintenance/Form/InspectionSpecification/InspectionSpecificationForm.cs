using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Text.RegularExpressions;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class InspectionSpecificationForm
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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(InspectionSpecificationForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        ///  get message data
        /// </summary>
        private const string InspectionItem = "InspectionItem";

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        #endregion

        #region Constructor 

        /// <summary>
        /// constructor
        /// </summary>
        public InspectionSpecificationForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods 

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(InspectionSpecificationVo conditionInVo)
        {
            if (conditionInVo == null)
            {
                return;
            }

            InspectionSpecificationDetails_dgv.DataSource = null;

            ValueObjectList<InspectionSpecificationVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionSpecificationVo>)base.InvokeCbm(new GetInspectionSpecificationMasterMntCbm(), conditionInVo, false);

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
            InspectionSpecificationDetails_dgv.AutoGenerateColumns = false;

            BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionSpecificationDetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            InspectionSpecificationDetails_dgv.ClearSelection();

            Update_btn.Enabled = false;

            Delete_btn.Enabled = false;

            Copy_btn.Enabled = false;
        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private InspectionSpecificationVo FormConditionVo()
        {
            InspectionSpecificationVo inVo = new InspectionSpecificationVo();

            if (InspectionSpecificationCode_txt.Text != string.Empty)
            {
                inVo.InspectionSpecificationCode = InspectionSpecificationCode_txt.Text;
            }

            if (InspectionSpecificationText_txt.Text != string.Empty)
            {
                inVo.InspectionSpecificationText = InspectionSpecificationText_txt.Text;
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
        private void BindUpdateInspectionSpecificationData()
        {
            int selectedrowindex = InspectionSpecificationDetails_dgv.SelectedCells[0].RowIndex;

            InspectionSpecificationVo inspProcessVo = (InspectionSpecificationVo)InspectionSpecificationDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddInspectionSpecificationForm newAddForm = new AddInspectionSpecificationForm(CommonConstants.MODE_UPDATE, inspProcessVo);

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
            AddInspectionSpecificationForm newAddForm = new AddInspectionSpecificationForm(CommonConstants.MODE_ADD, null);

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
            InspectionSpecificationCode_txt.Text = string.Empty;

            InspectionSpecificationText_txt.Text = string.Empty;

            InspectionItemId_cmb.SelectedIndex = -1;

            InspectionSpecificationDetails_dgv.DataSource = null;

            InspectionSpecificationCode_txt.Select();

            Update_btn.Enabled = Delete_btn.Enabled = Copy_btn.Enabled = false;
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
            BindUpdateInspectionSpecificationData();
        }

        /// <summary>
        /// delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = InspectionSpecificationDetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = InspectionSpecificationDetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colInspectionSpecificationCode"].Value.ToString());
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {

                InspectionSpecificationVo inVo = new InspectionSpecificationVo();

                inVo.InspectionSpecificationId = Convert.ToInt32(selectedRow.Cells["colInspectionSpecificationId"].Value.ToString());
                inVo.InspectionSpecificationCode = selectedRow.Cells["colInspectionSpecificationCode"].Value.ToString();
                try
                {

                    InspectionSpecificationVo outVo = (InspectionSpecificationVo)base.InvokeCbm(new DeleteInspectionSpecificationMasterMntCbm(), inVo, false);

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
        /// copy from grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Copy_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = InspectionSpecificationDetails_dgv.SelectedCells[0].RowIndex;

            InspectionSpecificationVo inspProcessVo = (InspectionSpecificationVo)InspectionSpecificationDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddInspectionSpecificationForm newAddForm = new AddInspectionSpecificationForm(CommonConstants.MODE_SELECT, inspProcessVo);

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

        #endregion

        #region ControlEvents

        /// <summary>
        /// update, delete button enable  based on the record selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionSpecificationDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionSpecificationDetails_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = Copy_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = Copy_btn.Enabled = false;
            }
        }

        /// <summary>
        /// open update form on double click on the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionSpecificationDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InspectionSpecificationDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateInspectionSpecificationData();
            }
        }

        #endregion

        #region FormEvents 
        /// <summary>
        /// load  the form with  combobox bind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionSpecificationForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(InspectionItemId_cmb, inspectionitemDatatable, "Name", "Id");

            InspectionSpecificationCode_txt.Select();

            Update_btn.Enabled = Delete_btn.Enabled = Copy_btn.Enabled = false;
        }

        #endregion

        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<InspectionSpecificationVo> outVo)
        {
            InspectionSpecificationDetails_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                InspectionSpecificationDetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            InspectionSpecificationDetails_dgv.ClearSelection();
        }


        private void InspectionSpecificationDetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           DataGridViewColumn column = InspectionSpecificationDetails_dgv.Columns[e.ColumnIndex];

            if (InspectionSpecificationDetails_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)InspectionSpecificationDetails_dgv.DataSource;

            List<InspectionSpecificationVo> dataSourceVo = (List<InspectionSpecificationVo>)currentDatagridSource.DataSource;

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
                InspectionSpecificationDetails_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }
    }
}
