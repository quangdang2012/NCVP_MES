using System;
using System.Windows.Forms;
using System.Text;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{

    public partial class StockLocationForm
    {

        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(StockLocationForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public StockLocationForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(StockLocationVo conditionInVo)
        {
            StockLocationData_dgv.DataSource = null;

            try
            {
                ValueObjectList<StockLocationVo> outVo = (ValueObjectList < StockLocationVo > )base.InvokeCbm(new GetStockLocationMasterMntCbm(), conditionInVo, false);

                if(outVo != null)
                {
                    StockLocationData_dgv.AutoGenerateColumns = false;

                    BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);

                    if (bindingSource1.Count > 0)
                    {
                        StockLocationData_dgv.DataSource = bindingSource1;
                    }                   
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); 
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                StockLocationData_dgv.ClearSelection();

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
        private StockLocationVo FormConditionVo()
        {
            StockLocationVo inVo = new StockLocationVo();

            if (StockLocationCode_txt.Text != string.Empty)
            {
                inVo.StockLocationCode = StockLocationCode_txt.Text;
            }

            if (StockLocationName_txt.Text != string.Empty)
            {
                inVo.StockLocationName = StockLocationName_txt.Text;

            }

            return inVo;

        }

        /// <summary>
        /// selects item record for updation and show item form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = StockLocationData_dgv.SelectedCells[0].RowIndex;

            StockLocationVo selectedData = (StockLocationVo)StockLocationData_dgv.Rows[selectedrowindex].DataBoundItem;

            AddStockLocationForm newAddForm = new AddStockLocationForm();
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
        private void StockLocationForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
                StockLocationCode_txt.Select();
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
            StockLocationCode_txt.Text = string.Empty;

            StockLocationName_txt.Text = string.Empty;

            StockLocationData_dgv.DataSource = null;

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
            AddStockLocationForm newAddForm = new AddStockLocationForm();
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
            int selectedrowindex = StockLocationData_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = StockLocationData_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colStockLocationCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                StockLocationVo inVo = new StockLocationVo
                {
                    StockLocationId = Convert.ToInt32(selectedRow.Cells["colStockLocationId"].Value),
                };

                inVo.StockLocationCode = selectedRow.Cells["colStockLocationCode"].Value.ToString();
                try
                {
                    StockLocationVo outVo = (StockLocationVo)base.InvokeCbm(new DeleteStockLocationMasterMntCbm(), inVo, false);

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
            if (StockLocationData_dgv.SelectedRows.Count > 0)
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
            if (StockLocationData_dgv.SelectedRows.Count > 0)
            {
                BindUpdateUserData();
            }
        }

        #endregion

    }
}
