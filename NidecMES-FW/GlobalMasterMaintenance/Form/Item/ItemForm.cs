using System;
using System.Windows.Forms;
using System.Text;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{

    public enum ItemRelationTables
    {
        ItemProcessWorkId = 0,
        MoldTypeId = 1
    };
    public partial class ItemForm
    {

        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ItemForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public ItemForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(ItemVo conditionInVo)
        {
            ItemData_dgv.DataSource = null;

            try
            {
                ItemVo outVo = (ItemVo)base.InvokeCbm(new GetItemMasterMntCbm(), conditionInVo, false);

                ItemData_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.ItemListVo, null);

                if (bindingSource1.Count > 0)
                {
                    ItemData_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"item"
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                ItemData_dgv.ClearSelection();

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
        private ItemVo FormConditionVo()
        {
            ItemVo inVo = new ItemVo();

            if (ItemCode_txt.Text != string.Empty)
            {
                inVo.ItemCode = ItemCode_txt.Text;
            }

            if (ItemName_txt.Text != string.Empty)
            {
                inVo.ItemName = ItemName_txt.Text;

            }

            return inVo;

        }

        /// <summary>
        /// selects item record for updation and show item form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = ItemData_dgv.SelectedCells[0].RowIndex;

            ItemVo selectedData = (ItemVo)ItemData_dgv.Rows[selectedrowindex].DataBoundItem;

            AddItemForm newAddForm = new AddItemForm();
            newAddForm.CreateForm(CommonConstants.MODE_UPDATE, selectedData);

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
        /// To idenctify the relation ship with tables
        /// </summary>
        private ItemVo CheckItemRelation(ItemVo inVo)
        {
            ItemVo outVo = new ItemVo();

            try
            {
                outVo = (ItemVo)base.InvokeCbm(new CheckItemRelationCbm(), inVo, false);
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
        /// form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
                ItemCode_txt.Select();
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
            ItemCode_txt.Text = string.Empty;

            ItemName_txt.Text = string.Empty;

            ItemData_dgv.DataSource = null;

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
            AddItemForm newAddForm = new AddItemForm();
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
            int selectedrowindex = ItemData_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = ItemData_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colItemCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                ItemVo inVo = new ItemVo
                {
                    ItemId = Convert.ToInt32(selectedRow.Cells["colItemId"].Value),
                };

                inVo.ItemCode = selectedRow.Cells["colItemCode"].Value.ToString();
                try
                {
                    ItemVo outCountVo = CheckItemRelation(inVo);

                    if (outCountVo != null)
                    {
                        StringBuilder message = new StringBuilder();

                        if (outCountVo.ItemProcessWorkId > 0)
                        {
                            message.Append(ItemRelationTables.ItemProcessWorkId);
                        }
                        if (outCountVo.MoldTypeId > 0)
                        {
                            if (message.Length > 0)
                            {
                                message.Append(" And ");
                            }

                            message.Append(ItemRelationTables.MoldTypeId);
                        }
                        if (message.Length > 0)
                        {
                            messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, message.ToString());
                            popUpMessage.Information(messageData, Text);
                            return;
                        }
                    }

                    ItemVo outVo = (ItemVo)base.InvokeCbm(new DeleteItemMasterMntCbm(), inVo, false);

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
        protected virtual void ItemData_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ItemData_dgv.SelectedRows.Count > 0)
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
        protected virtual void ItemData_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ItemData_dgv.SelectedRows.Count > 0)
            {
                BindUpdateUserData();
            }
        }

        #endregion

    }
}
