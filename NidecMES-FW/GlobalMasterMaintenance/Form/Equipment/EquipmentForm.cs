using System;
using System.Text;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{

    public enum EquipmentRelationTables
    {
        CastingMachineFurnace = 0,
        CastingMachine = 1
    };
    public partial class EquipmentForm
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(EquipmentForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public EquipmentForm()
        {
            InitializeComponent();

        }
        #endregion

        #region PrivateMethods
        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(EquipmentVo conditionInVo)
        {
            EquipmentData_dgv.DataSource = null;

            try
            {
                EquipmentVo outVo = (EquipmentVo)base.InvokeCbm(new GetEquipmentMasterMntCbm(), conditionInVo, false);

                EquipmentData_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.EquipmentListVo, null);

                if (bindingSource1 != null && bindingSource1.Count > 0)
                {
                    EquipmentData_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"equipment"
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                EquipmentData_dgv.ClearSelection();

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
        private EquipmentVo FormConditionVo()
        {
            EquipmentVo inVo = new EquipmentVo();

            if (EquipmentCode_txt.Text != string.Empty)
            {
                inVo.EquipmentCode =EquipmentCode_txt.Text;
            }

            if (EquipmentName_txt .Text != string.Empty)
            {
                inVo.EquipmentName = EquipmentName_txt.Text;

            }

            if (InstrationDate_dtp.Text != " ")
            {
                inVo.InstrationDate= Convert.ToDateTime(InstrationDate_dtp.Text);
            }

            if (AssertNo_txt.Text != string.Empty)
            {
                inVo.AssetNo= AssertNo_txt.Text;
            }

            if (Manufacturer_txt.Text != string.Empty)
            {
                inVo.Manufacturer=Manufacturer_txt.Text;
            }

            if (ModelCode_txt.Text != string.Empty)
            {
                inVo.ModelCode= ModelCode_txt.Text;
            }

            if (ModelName_txt.Text != string.Empty)
            {
                inVo.ModelName= ModelName_txt.Text;
            }
            return inVo;

        }

        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = EquipmentData_dgv.SelectedCells[0].RowIndex;

            EquipmentVo selectedData = (EquipmentVo)EquipmentData_dgv.Rows[selectedrowindex].DataBoundItem;

            AddEquipmentForm newAddForm = new AddEquipmentForm(CommonConstants.MODE_UPDATE, selectedData);

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
        private EquipmentVo CheckEquipmentRelation(EquipmentVo inVo)
        {
            EquipmentVo outVo = new EquipmentVo();

            try
            {
                outVo = (EquipmentVo)base.InvokeCbm(new CheckEquipmentRelationCbm(), inVo, false);
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
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = false;

            InstrationDate_dtp.Value = DateTimePicker.MinimumDateTime;
            EquipmentCode_txt.Select();

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
            EquipmentCode_txt.Text = string.Empty;

            EquipmentName_txt.Text = string.Empty;          

            InstrationDate_dtp.Value = DateTimePicker.MinimumDateTime;

            AssertNo_txt.Text = string.Empty;

            Manufacturer_txt.Text = string.Empty;

            ModelCode_txt.Text = string.Empty;

            ModelName_txt.Text = string.Empty;

            EquipmentData_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;

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
            AddEquipmentForm newAddForm = new AddEquipmentForm(CommonConstants.MODE_ADD, null);

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
            int selectedrowindex = EquipmentData_dgv.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = EquipmentData_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colEquipmentCode"].Value.ToString());

            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);          

            if (dialogResult == DialogResult.OK)
            {
                EquipmentVo inVo = new EquipmentVo();

                inVo.EquipmentId = Convert.ToInt32(selectedRow.Cells["colEquipmentId"].Value);

                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss");

                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;                

                inVo.EquipmentCode = selectedRow.Cells["colEquipmentCode"].Value.ToString();

                try
                {
                  
                    EquipmentVo outVo = CheckEquipmentRelation(inVo);

                    if (outVo != null)
                    {
                        StringBuilder message = new StringBuilder();

                        if (outVo.CastingMachineFurnaceId > 0)
                        {
                            message.Append(EquipmentRelationTables.CastingMachineFurnace);
                        }
                        if (outVo.CastingMachineId > 0)
                        {
                            if (message.Length > 0)
                            {
                                message.Append(" And ");
                            }

                            message.Append(EquipmentRelationTables.CastingMachine);
                        }
                        if (message.Length > 0)
                        {
                            messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, message.ToString());
                            popUpMessage.Information(messageData, Text);
                            return;
                        }
                    }
                  
                    outVo = (EquipmentVo)base.InvokeCbm(new DeleteEquipmentMasterMntCbm(), inVo, false);
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
        /// dateteime control valuechange event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstrationDate_dtp_ValueChanged(object sender, EventArgs e)
        {

            if (InstrationDate_dtp.Value == DateTimePicker.MinimumDateTime)
            {
                InstrationDate_dtp.Value = DateTime.Now;
                InstrationDate_dtp.Format = DateTimePickerFormat.Custom;
                InstrationDate_dtp.CustomFormat = " ";
            }
            else
            { InstrationDate_dtp.CustomFormat = UserData.GetUserData().DateTimeFormat.ShortDatePattern; }
            
        }

        /// <summary>
        /// Handles equipment record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquipmentData_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EquipmentData_dgv.SelectedRows.Count > 0)
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
        private void EquipmentData_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EquipmentData_dgv.SelectedRows.Count > 0)
            {
                BindUpdateUserData();
            }
        }

        #endregion

    }
}
