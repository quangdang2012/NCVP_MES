using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class EmployeeMasterForm
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(EmployeeMasterForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public EmployeeMasterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(EmployeeVo conditionInVo)
        {
            EmployeeDetails_dgv.DataSource = null;

            try
            {
                EmployeeVo outVo = (EmployeeVo)base.InvokeCbm(new GetEmployeeMasterMntCbm(), conditionInVo, false);

                EmployeeDetails_dgv.AutoGenerateColumns = false;

                BindingSource lineBindingSource = new BindingSource(outVo.EmployeeListVo, null);

                if (lineBindingSource.Count > 0)
                {
                    EmployeeDetails_dgv.DataSource = lineBindingSource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                EmployeeDetails_dgv.ClearSelection();

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
        private EmployeeVo FormConditionVo()
        {
            EmployeeVo inVo = new EmployeeVo();


            if (EmployeeCode_txt.Text != string.Empty)
            {
                inVo.EmployeeCode = EmployeeCode_txt.Text;
            }

            if (EmployeeName_txt.Text != string.Empty)
            {
                inVo.EmployeeName = EmployeeName_txt.Text;
            }

            return inVo;
        }

        /// <summary>
        /// selects user record for updation and show Employee form
        /// </summary>
        private void BindUpdateEmployeeData()
        {
            int selectedrowindex = EmployeeDetails_dgv.SelectedCells[0].RowIndex;

            EmployeeVo selectedEmployee = (EmployeeVo)EmployeeDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddEmployeeMasterForm newAddForm = new AddEmployeeMasterForm(CommonConstants.MODE_UPDATE, selectedEmployee);

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
        private void EmployeeMasterForm_Load(object sender, EventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = false;
            EmployeeCode_txt.Select();
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
            EmployeeCode_txt.Text = string.Empty;
            EmployeeName_txt.Text = string.Empty;
            EmployeeDetails_dgv.DataSource = null;
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
            AddEmployeeMasterForm newAddForm = new AddEmployeeMasterForm(CommonConstants.MODE_ADD, null);

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
            BindUpdateEmployeeData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = EmployeeDetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = EmployeeDetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colEmployeeName"].Value.ToString());
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                EmployeeVo inVo = new EmployeeVo
                {
                    EmployeeCode = selectedRow.Cells["colEmployeeCode"].Value.ToString()
                };

                try
                {
                    EmployeeVo outVo = (EmployeeVo)base.InvokeCbm(new DeleteEmployeeMasterMntCbm(), inVo, false);

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
        private void LineDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EmployeeDetails_dgv.SelectedRows.Count > 0)
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
        private void LineDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EmployeeDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateEmployeeData();
            }
        }

        #endregion

    }
}
