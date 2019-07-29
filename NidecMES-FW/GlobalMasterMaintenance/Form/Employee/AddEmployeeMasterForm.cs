using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddEmployeeMasterForm
    {

        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly EmployeeVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddEmployeeMasterForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;
        #endregion

        #region Constructor
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="EmployeeItem"></param>
        public AddEmployeeMasterForm(string pmode, EmployeeVo EmployeeItem = null)
        {
            InitializeComponent();

            mode = pmode;
           
            updateData = EmployeeItem;
            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }
        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (EmployeeCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, EmployeeCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                EmployeeCode_txt.Focus();

                return false;
            }

            if (EmployeeName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, EmployeeName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                EmployeeName_txt.Focus();

                return false;
            }
            if (Department_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Department_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Department_txt.Focus();

                return false;
            }
            return true;
        }

        /// <summary>
        /// For setting selected Line record into respective controls(textbox and combobox) for update operation
        /// passing selected Line data as parameter 
        /// </summary>
        /// <param name="dgvEmployee"></param>
        private void LoadEmployeeData(EmployeeVo dgvLine)
        {
            if (dgvLine != null)
            {
                this.EmployeeCode_txt.Text = dgvLine.EmployeeCode;
                this.EmployeeName_txt.Text = dgvLine.EmployeeName;
            }
        }

        /// <summary>
        /// checks duplicate FactoryCode
        /// </summary>
        /// <param name="EmployeeVo"></param>
        /// <returns></returns>
        private EmployeeVo DuplicateCheck(EmployeeVo EmployeeVo)
        {
            EmployeeVo outVo = new EmployeeVo();

            try
            {
                outVo = (EmployeeVo)base.InvokeCbm(new CheckEmployeeMasterMntCbm(), EmployeeVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        #endregion

        #region FormEvent
        /// <summary>
        /// load screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEmployeeMasterForm_Load(object sender, EventArgs e)
        {
            EmployeeCode_txt.Select();
            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadEmployeeData(updateData);

                EmployeeCode_txt.Enabled = false;

                EmployeeName_txt.Select();

            }
        }
        #endregion

        #region ButtonClick
        /// <summary>
        /// update data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {

            EmployeeVo inVo = new EmployeeVo();

            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(EmployeeCode_txt.Text) || !sch.IsASCII(EmployeeName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (!sch.IsASCII(EmployeeCode_txt.Text))
                    {
                        EmployeeCode_txt.Focus();
                    }
                    else
                    {
                        EmployeeName_txt.Focus();
                    }

                    return;
                }

                inVo.EmployeeCode = EmployeeCode_txt.Text.Trim();
                inVo.EmployeeName = EmployeeName_txt.Text.Trim();
                inVo.Department = Department_txt.Text.Trim();
                if(IsActive_chk.Checked)
                { inVo.IsActive = 1; }
                else
                { inVo.IsActive = 0; }
                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;
                inVo.FactoryCode = UserData.GetUserData().FactoryCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    EmployeeVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, EmployeeCode_lbl.Text + " : " + EmployeeCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);

                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        EmployeeVo outVo = (EmployeeVo)base.InvokeCbm(new AddEmployeeMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        inVo.EmployeeCode = updateData.EmployeeCode;
                        EmployeeVo outVo = (EmployeeVo)base.InvokeCbm(new UpdateEmployeeMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                  
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }

                if ((IntSuccess > 0) || (IntSuccess == 0))
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Window close when Exit button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}
