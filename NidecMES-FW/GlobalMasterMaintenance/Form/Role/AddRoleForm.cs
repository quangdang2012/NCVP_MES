using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;
namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddRoleForm
    {
        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly RoleVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddRoleForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor
        /// <summary>
        /// constructor for the form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="dataItem"></param>
        public AddRoleForm(string pmode, RoleVo dataItem = null)
        {
            InitializeComponent();

            mode = pmode;
           
            updateData = dataItem;
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
            if (RoleCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, RoleCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                RoleCode_txt.Focus();

                return false;
            }
            if (RoleName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, RoleName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                RoleName_txt.Focus();

                return false;
            }
            return true;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvData"></param>
        private void LoadUserData(RoleVo dgvData)
        {
            if (dgvData != null)
            {
                RoleCode_txt.Text = dgvData.RoleCode;
                RoleName_txt.Text = dgvData.RoleName;
            }
        }

        /// <summary>
        /// checks duplicate Role Code
        /// </summary>
        /// <param name="roleVo"></param>
        /// <returns></returns>
        private RoleVo DuplicateCheck(RoleVo roleVo)
        {
            RoleVo outVo = new RoleVo();

            try
            {
                outVo = (RoleVo)base.InvokeCbm(new CheckRoleMasterMntCbm(), roleVo, false);
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
        /// form load event , loads role data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRoleForm_Load(object sender, EventArgs e)
        {
            RoleCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                RoleCode_txt.Enabled = false;
                RoleName_txt.Select();

            }
        }
        #endregion

        #region ButtonClick

        /// <summary>
        /// form close on exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// update data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            var sch = StringCheckHelper.GetInstance();

            if (CheckMandatory())
            {
                if (!sch.IsASCII(RoleCode_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    RoleCode_txt.Focus();

                    return;
                }
                RoleVo inVo = new RoleVo
                {
                    RoleCode = RoleCode_txt.Text.Trim(),
                    RoleName = RoleName_txt.Text.Trim(),
                    //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    FactoryCode = UserData.GetUserData().FactoryCode
                };

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    RoleVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, RoleCode_lbl.Text + " : " + RoleCode_txt.Text);
                        popUpMessage.Information(messageData, Text);
                        return;
                    }
                }

                try
                {

                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        RoleVo outVo = (RoleVo)base.InvokeCbm(new AddRoleMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        RoleVo outVo = (RoleVo)base.InvokeCbm(new UpdateRoleMasterMntCbm(), inVo, false);
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
        #endregion
    }
}
