using System;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class LocalSupplierForm
    {

        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ProcessForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        ///  get message data
        /// </summary>
        private const string ProcessSupplier = "ProcessWorkSupplier";
        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public LocalSupplierForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(LocalSupplierVo conditionInVo)
        {
            LocalSupplier_dgv.DataSource = null;

            try
            {
                LocalSupplierVo outVo = (LocalSupplierVo)base.InvokeCbm(new GetLocalSupplierMasterMntCbm(), conditionInVo, false);

                LocalSupplier_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.LocalSupplierListVo, null);

                if (bindingSource1.Count > 0)
                {
                    LocalSupplier_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //process
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                LocalSupplier_dgv.ClearSelection();

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
        private LocalSupplierVo FormConditionVo()
        {
            LocalSupplierVo inVo = new LocalSupplierVo();

            if (LocalSupplierCode_txt.Text != string.Empty)
            {
                inVo.LocalSupplierCode = LocalSupplierCode_txt.Text;
            }

            if (LocalSupplierName_txt.Text != string.Empty)
            {
                inVo.LocalSupplierName = LocalSupplierName_txt.Text;

            }

            return inVo;

        }


        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = LocalSupplier_dgv.SelectedCells[0].RowIndex;

            LocalSupplierVo selectedData = (LocalSupplierVo)LocalSupplier_dgv.Rows[selectedrowindex].DataBoundItem;

            AddLocalSupplierForm newAddForm = new AddLocalSupplierForm(CommonConstants.MODE_UPDATE, selectedData);

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
        private LocalSupplierVo CheckSupplierRelationCbm(LocalSupplierVo inVo)
        {
            LocalSupplierVo outVo = new LocalSupplierVo();

            try
            {
                outVo = (LocalSupplierVo)base.InvokeCbm(new CheckLocalSupplierRelationCbm(), inVo, false);
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
        private void LocalSupplierForm_Load(object sender, EventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = false;
            LocalSupplierCode_txt.Select();
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
           LocalSupplierCode_txt.Text = string.Empty;

            LocalSupplierName_txt.Text = string.Empty;

            LocalSupplier_dgv.DataSource = null;

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
            AddLocalSupplierForm newAddForm = new AddLocalSupplierForm(CommonConstants.MODE_ADD, null);

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
            BindUpdateUserData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = LocalSupplier_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = LocalSupplier_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colLocalSupplierCode"].Value.ToString());
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                LocalSupplierVo inVo = new LocalSupplierVo
                {
                    LocalSupplierId = Convert.ToInt32(selectedRow.Cells["colLocalSupplierId"].Value),
                };

                try
                {
                    inVo.LocalSupplierCode = selectedRow.Cells["colLocalSupplierCode"].Value.ToString();
                    LocalSupplierVo tableCount = tableCount = CheckSupplierRelationCbm(inVo);
                    if (tableCount.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, ProcessSupplier.ToString());
                        popUpMessage.Information(messageData, Text);
                        return;
                    }

                    LocalSupplierVo outVo = (LocalSupplierVo)base.InvokeCbm(new DeleteLocalSupplierMasterMntCbm(), inVo, false);

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
        private void LocalSupplier_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LocalSupplier_dgv.SelectedRows.Count > 0)
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
        private void LocalSupplier_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LocalSupplier_dgv.SelectedRows.Count > 0)
            {
                BindUpdateUserData();
            }
        }

        #endregion

    }
}
