using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddSapUserMasterForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;
               
        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly SapUserVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddSapUserMasterForm));

        /// <summary>
        /// Encrypt Decrypt variable initialize
        /// </summary>
        private EncryptDecrypt encryptDecrypt = new EncryptDecrypt();

        #endregion

        #region Constructor

        /// <summary>
        /// Loads control lables from resource file
        /// For setting Insert/Update mode and binds user data while update
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userVo"></param>
        public AddSapUserMasterForm(string pmode, SapUserVo userVo = null)
        {
            InitializeComponent();

            mode = pmode;
         
            updateData = userVo;
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
            if (UserName_cmb.Text == string.Empty || UserName_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, UserName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                UserName_cmb.Focus();

                return false;
            }

            if (SapUserName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002,SapUser_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                SapUserName_txt.Focus();

                return false;
            }
            
            if (UserPassword_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Password_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                UserPassword_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// For binding combo box
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind<T>(ComboBox pCombo, List<T> pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        /// <summary>
        /// Loads Process Work
        /// </summary>
        private void LoadMesUser()
        {
            UserVo outVo = new UserVo();

            try
            {
                outVo = (UserVo)base.InvokeCbm(new GetUserMasterMntCbm(), new UserVo(), false);
                outVo.UserListVo.ForEach(u => u.UserName = u.UserCode + " " + u.UserName);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            ComboBind(UserName_cmb, outVo.UserListVo.OrderBy(u => u.UserName).ToList(), "UserName", "UserCode");
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="userInVo"></param>
        private void LoadUserData(SapUserVo sapInVo)
        {
            if (sapInVo != null)
            {
                UserName_cmb.SelectedValue = sapInVo.MesUserCode;
                SapUserName_txt.Text = sapInVo.SapUser;               
                UserPassword_txt.Text = sapInVo.SapPassWord;

            }
        }
       
        #endregion

        #region FormEvents

        /// <summary>
        /// Handles Load event for user data Insert/Update operations 
        /// Loading user data for update user data and binding controls with selected user record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSapUserMasterForm_Load(object sender, EventArgs e)
        {
            LoadMesUser();
                        
            UserName_cmb.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                UserName_cmb.Enabled = false;
                SapUserName_txt.Select();
            }

        }
        #endregion

        #region ButtonClick
        /// <summary>
        /// close the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// update data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            SapUserVo inVo = new SapUserVo();

            var sch = StringCheckHelper.GetInstance();
            if (CheckMandatory())
            {
                if (!sch.IsASCII(SapUserName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    SapUserName_txt.Focus();
                    return;
                }

                else if (!sch.IsASCII(UserPassword_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    UserPassword_txt.Focus();
                    return;
                }
          
                if (UserName_cmb.SelectedIndex > -1)
                {
                    inVo.MesUserCode = UserName_cmb.SelectedValue.ToString();
                }

                    inVo.SapPassWord = UserPassword_txt.Text.Trim();
                    inVo.SapUser = SapUserName_txt.Text.Trim();      
                
                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        SapUserVo outVo = (SapUserVo)base.InvokeCbm(new AddSapUserMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        inVo.SapUserId = updateData.SapUserId;
                        SapUserVo outVo = (SapUserVo)base.InvokeCbm(new UpdateSapUserMasterMntCbm(), inVo, false);
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
