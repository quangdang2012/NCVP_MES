using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class LocalSupplierCavityForm
    {

        #region Variables

        /// <summary>
        /// datatable for localsupplier data
        /// </summary>
        private DataTable localSupplierDatatable;

        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable itemDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(LocalSupplierCavityForm));

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
        public LocalSupplierCavityForm()
        {
            InitializeComponent();
        }

        #endregion

        #region FormEvents

        /// <summary>
        /// Loads LocalSupplierCavity form
        /// Fill localsupplirer and item combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalSupplierCavityForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();
            InsertItemInformationIntoItemtable();

            ComboBind(LocalSupplier_cmb, localSupplierDatatable, "code", "id");
            ComboBind(Item_cmb, itemDatatable, "code", "id");

            LocalSupplierCavityCode_txt.Select();

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(LocalSupplierCavityVo conditionInVo)
        {
            LocalSupplierCavity_dgv.DataSource = null;

            try
            {
                LocalSupplierCavityVo outVo = (LocalSupplierCavityVo)base.InvokeCbm(new GetLocalSupplierCavityMasterMntCbm(), conditionInVo, false);

                LocalSupplierCavity_dgv.AutoGenerateColumns = false;

                BindingSource localSupplierCavityBindingSource = new BindingSource(outVo.LocalSupplierCavityListVo, null);

                if (localSupplierCavityBindingSource.Count > 0)
                {
                    LocalSupplierCavity_dgv.DataSource = localSupplierCavityBindingSource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                LocalSupplierCavity_dgv.ClearSelection();

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
        private LocalSupplierCavityVo FormConditionVo()
        {
            LocalSupplierCavityVo inVo = new LocalSupplierCavityVo();

            if (LocalSupplierCavityCode_txt.Text != string.Empty)
            {
                inVo.LocalSupplierCavityCode = LocalSupplierCavityCode_txt.Text;
            }

            if (LocalSupplierCavityName_txt.Text != string.Empty)
            {
                inVo.LocalSupplierCavityName = LocalSupplierCavityName_txt.Text;
            }

            if (LocalSupplier_cmb.SelectedIndex > -1)
            {
                inVo.LocalSupplierId = Convert.ToInt32(LocalSupplier_cmb.SelectedValue);
            }

            if (Item_cmb.SelectedIndex > -1)
            {
                inVo.ItemId = Convert.ToInt32(Item_cmb.SelectedValue);
            }

            return inVo;

        }

        /// <summary>
        /// Handles Combobox loading for item
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
            int selectedrowindex = LocalSupplierCavity_dgv.SelectedCells[0].RowIndex;

            LocalSupplierCavityVo selectedMold = (LocalSupplierCavityVo)LocalSupplierCavity_dgv.Rows[selectedrowindex].DataBoundItem;

            AddLocalSupplierCavityForm newAddForm = new AddLocalSupplierCavityForm(CommonConstants.MODE_UPDATE, selectedMold);

            newAddForm.ShowDialog(this);

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
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
            localSupplierDatatable = new DataTable();
            localSupplierDatatable.Columns.Add("id");
            localSupplierDatatable.Columns.Add("code");

            try
            {
                LocalSupplierVo localSupplierVo = (LocalSupplierVo)base.InvokeCbm(new GetLocalSupplierMasterMntCbm(), new LocalSupplierVo(), false);

                foreach (LocalSupplierVo localSupplier in localSupplierVo.LocalSupplierListVo)
                {
                    localSupplierDatatable.Rows.Add(localSupplier.LocalSupplierId, localSupplier.LocalSupplierName);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Insert item information into item table for display in combo box
        /// </summary>
        private void InsertItemInformationIntoItemtable()
        {
            itemDatatable = new DataTable();
            itemDatatable.Columns.Add("id");
            itemDatatable.Columns.Add("code");

            try
            {
                ItemVo itemOutVo = (ItemVo)base.InvokeCbm(new GetItemMasterMntCbm(), new ItemVo(), false);

                foreach (ItemVo item in itemOutVo.ItemListVo)
                {
                    itemDatatable.Rows.Add(item.ItemId, item.ItemCode);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<LocalSupplierCavityVo> outVo)
        {
            LocalSupplierCavity_dgv.AutoGenerateColumns = false;
            BindingSource targetWIPBindingSource = new BindingSource(outVo, null);

            if (targetWIPBindingSource == null || targetWIPBindingSource.Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            LocalSupplierCavity_dgv.DataSource = targetWIPBindingSource;
            LocalSupplierCavity_dgv.ClearSelection();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalSupplierCavity_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LocalSupplierCavity_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
                return;
            }

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// Handles update user form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalSupplierCavity_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LocalSupplierCavity_dgv.SelectedRows.Count > 0)
            {
                BindUpdateUserData();
            }
        }

        /// <summary>
        /// sort DataGridView data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalSupplierCavity_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = LocalSupplierCavity_dgv.Columns[e.ColumnIndex];

            if (LocalSupplierCavity_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)LocalSupplierCavity_dgv.DataSource;

            List<LocalSupplierCavityVo> dataSourceVo = (List<LocalSupplierCavityVo>)currentDatagridSource.DataSource;

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
                LocalSupplierCavity_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            LocalSupplierCavityCode_txt.Text = string.Empty;

            LocalSupplierCavityName_txt.Text = string.Empty;

            LocalSupplier_cmb.SelectedIndex = -1;

            Item_cmb.SelectedIndex = -1;

            LocalSupplierCavity_dgv.DataSource = null;

            LocalSupplierCavityCode_txt.Select();

            Delete_btn.Enabled = Update_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddLocalSupplierCavityForm newAddForm = new AddLocalSupplierCavityForm(CommonConstants.MODE_ADD);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
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
        /// event to open the  updatescreen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateUserData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = LocalSupplierCavity_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = LocalSupplierCavity_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colLocalSupplierCavityCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                LocalSupplierCavityVo inVo = new LocalSupplierCavityVo
                {
                    LocalSupplierCavityId = Convert.ToInt32(selectedRow.Cells["colLocalSupplierCavityId"].Value),
                    RegistrationDateTime = Convert.ToDateTime(DateTime.Now.ToString(UserData.GetUserData().DateTimeFormat)),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                };

                try
                {
                    LocalSupplierCavityVo outVo = (LocalSupplierCavityVo)base.InvokeCbm(new DeleteLocalSupplierCavityMasterMntCbm(), inVo, false);

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
            //else if (dialogResult == DialogResult.Cancel)
            //{
            //    //do something else
            //}
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

    }
}
