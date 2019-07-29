using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class InventoryReasonMasterForm
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(InventoryReasonMasterForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public InventoryReasonMasterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(InventoryReasonVo conditionInVo)
        {
            InventoryReasonDetails_dgv.DataSource = null;

            try
            {
                InventoryReasonVo outVo = (InventoryReasonVo)base.InvokeCbm(new GetInventoryReasonMasterMntCbm(), conditionInVo, false);

                InventoryReasonDetails_dgv.AutoGenerateColumns = false;

                BindingSource inventoryReasonBindingSource = new BindingSource(outVo.InventoryReasonListVo, null);

                if (inventoryReasonBindingSource.Count > 0)
                {
                    InventoryReasonDetails_dgv.DataSource = inventoryReasonBindingSource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                InventoryReasonDetails_dgv.ClearSelection();

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
        private InventoryReasonVo FormConditionVo()
        {
            InventoryReasonVo inVo = new InventoryReasonVo();


            if (InventoryReasonCode_txt.Text != string.Empty)
            {
                inVo.InventoryReasonCode = InventoryReasonCode_txt.Text;
            }

            if (InventoryReasonName_txt.Text != string.Empty)
            {
                inVo.InventoryReasonName = InventoryReasonName_txt.Text;
            }

            return inVo;
        }

        /// <summary>
        /// selects user record for updation and show Line form
        /// </summary>
        private void BindUpdateInventoryReasonData()
        {
            int selectedrowindex = InventoryReasonDetails_dgv.SelectedCells[0].RowIndex;

            InventoryReasonVo selectedInventoryReason = (InventoryReasonVo)InventoryReasonDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddInventoryReasonMasterForm newAddForm = new AddInventoryReasonMasterForm(CommonConstants.MODE_UPDATE, selectedInventoryReason);

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
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InventoryReasonMasterForm_Load(object sender, EventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = false;
            InventoryReasonCode_txt.Select();

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
            InventoryReasonCode_txt.Text = string.Empty;
            InventoryReasonName_txt.Text = string.Empty;
            InventoryReasonDetails_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
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
            AddInventoryReasonMasterForm newAddForm = new AddInventoryReasonMasterForm(CommonConstants.MODE_ADD, null);

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
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateInventoryReasonData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = InventoryReasonDetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = InventoryReasonDetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colInventoryReasonName"].Value.ToString());
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                InventoryReasonVo inVo = new InventoryReasonVo
                {
                    InventoryReasonId = Convert.ToInt32(selectedRow.Cells["colInventoryReasonId"].Value)
                };

                try
                {
                    InventoryReasonVo outVo = (InventoryReasonVo)base.InvokeCbm(new DeleteInventoryReasonMasterMntCbm(), inVo, false);

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
            Close();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles factory record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InventoryReasonDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InventoryReasonDetails_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles update factory form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InventoryReasonDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InventoryReasonDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateInventoryReasonData();
            }
        }

        #endregion

    }
}
