using System;
using System.Windows.Forms;
using System.Text;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class GlobalItemForm
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
        public GlobalItemForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(GlobalItemVo conditionInVo)
        {
            GlobalItemData_dgv.DataSource = null;

            try
            {
                GlobalItemVo outVo = (GlobalItemVo)base.InvokeCbm(new GetGlobalItemMasterMntCbm(), conditionInVo, false);

                GlobalItemData_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.GlobalItemListVo, null);

                if (bindingSource1.Count > 0)
                {
                    GlobalItemData_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                GlobalItemData_dgv.ClearSelection();

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
        private GlobalItemVo FormConditionVo()
        {
            GlobalItemVo inVo = new GlobalItemVo();

            if (GlobalItemCode_txt.Text != string.Empty)
            {
                inVo.GlobalItemCode = GlobalItemCode_txt.Text;
            }

            if (GlobalItemName_txt.Text != string.Empty)
            {
                inVo.GlobalItemName = GlobalItemName_txt.Text;

            }

            return inVo;

        }

        /// <summary>
        /// selects item record for updation and show item form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = GlobalItemData_dgv.SelectedCells[0].RowIndex;

            GlobalItemVo selectedData = (GlobalItemVo)GlobalItemData_dgv.Rows[selectedrowindex].DataBoundItem;

            AddGlobalItemForm newAddForm = new AddGlobalItemForm();
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
                GlobalItemCode_txt.Select();
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
            GlobalItemCode_txt.Text = string.Empty;

            GlobalItemName_txt.Text = string.Empty;

            GlobalItemData_dgv.DataSource = null;

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
            AddGlobalItemForm newAddForm = new AddGlobalItemForm();
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
            int selectedrowindex = GlobalItemData_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = GlobalItemData_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colItemCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                GlobalItemVo inVo = new GlobalItemVo
                {
                    GlobalItemId = Convert.ToInt32(selectedRow.Cells["colItemId"].Value),
                };

                inVo.GlobalItemCode = selectedRow.Cells["colItemCode"].Value.ToString();
                try
                {
                    GlobalItemVo outVo = (GlobalItemVo)base.InvokeCbm(new DeleteGlobalItemMasterMntCbm(), inVo, false);

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
            if (GlobalItemData_dgv.SelectedRows.Count > 0)
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
            if (e.RowIndex > -1 && GlobalItemData_dgv.SelectedRows.Count > 0)
            {
                BindUpdateUserData();
            }
        }

        #endregion

    }
}
