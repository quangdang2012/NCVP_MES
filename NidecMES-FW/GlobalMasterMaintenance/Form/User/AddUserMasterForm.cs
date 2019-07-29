using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddUserMasterForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// check for Country list is loaded or not
        /// </summary>
        private bool iscmbCountryLoading;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly UserVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// delares data table country and language
        /// </summary>
        private DataTable cntryLangDatatable;

        /// <summary>
        /// declares factory data table
        /// </summary>
        private DataTable factoryDatatable;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddUserMasterForm));

        #endregion

        #region Constructor

        /// <summary>
        /// Loads control lables from resource file
        /// For setting Insert/Update mode and binds user data while update
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userVo"></param>
        public AddUserMasterForm(string pmode, UserVo userVo = null)
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
            if (UserCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, UserCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                UserCode_txt.Focus();

                return false;
            }
            if (UserName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, UserName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                UserName_txt.Focus();

                return false;
            }
            if (Country_cmb.Text == string.Empty || Country_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Country_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Country_cmb.Focus();

                return false;
            }           
            if (FactoryCode_cmb.Text == string.Empty || FactoryCode_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, FactoryCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                FactoryCode_cmb.Focus();

                return false;
            }
            return true;
        }

        /// <summary>
        /// For binding Country , Language and factory controls
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind(ComboBox pCombo, DataTable pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="userInVo"></param>
        private void LoadUserData(UserVo userInVo)
        {
            if (userInVo != null)
            {
                UserCode_txt.Text = userInVo.UserCode;
                UserName_txt.Text = userInVo.UserName;
                Country_cmb.SelectedValue = userInVo.LocaleId;               
                FactoryCode_cmb.SelectedValue = userInVo.RegistrationFactoryCode;

                if (userInVo.MultiLoginFlag.Equals("1"))
                {
                    MultiLogin_chk.Checked = true;
                }
            }
        }

        /// <summary>
        /// loads factory and country data table
        /// </summary>
        private void FormDatatableFromVo()
        {
            factoryDatatable = new DataTable();
            factoryDatatable.Columns.Add("code");
            factoryDatatable.Columns.Add("Name");

            try
            {
                FactoryVo factoryOutVo = (FactoryVo)base.InvokeCbm(new GetFactoryMasterMntCbm(), new FactoryVo(), false);

                foreach (FactoryVo fac in factoryOutVo.FactoryListVo)
                {
                    factoryDatatable.Rows.Add(fac.FactoryCode, fac.FactoryName);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            cntryLangDatatable = new DataTable();
            cntryLangDatatable.Columns.Add("LocaleId");
            cntryLangDatatable.Columns.Add("countrycode");
            

            try
            {
                CountryLanguageVo countryLangOutVo = (CountryLanguageVo)base.InvokeCbm(new GetCountryLanguageMasterMntCbm(), new CountryLanguageVo(), false);

                foreach (CountryLanguageVo cntry in countryLangOutVo.CountryLangListVo)
                {
                    cntryLangDatatable.Rows.Add(cntry.LocaleId, cntry.Language + "-" + cntry.Country);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// checks duplicate User Code
        /// </summary>
        /// <param name="userVo"></param>
        /// <returns></returns>
        private UserVo DuplicateCheck(UserVo userVo)
        {
            UserVo outVo = new UserVo();

            try
            {
                outVo = (UserVo)base.InvokeCbm(new CheckUserMasterMntCbm(), userVo, false);
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
        /// Handles Load event for user data Insert/Update operations 
        /// Loading user data for update user data and binding controls with selected user record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserMasterForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            iscmbCountryLoading = true;

            ComboBind(Country_cmb, cntryLangDatatable,"countrycode", "LocaleId");

            iscmbCountryLoading = false;           

            ComboBind(FactoryCode_cmb, factoryDatatable, "code", "code");

            UserCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);
                UserCode_txt.Enabled = false;
                UserName_txt.Select();

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
            var sch = StringCheckHelper.GetInstance();
            if (CheckMandatory())
            {
                if (string.IsNullOrEmpty(UserCode_txt.Text) || string.IsNullOrEmpty(UserName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(UserCode_txt.Text))
                    {
                        UserCode_txt.Focus();
                    }
                    else
                    {
                        UserName_txt.Focus();
                    }
                    return;
                }

                string multilogin = string.Empty;
                //string language = string.Empty;
                int country =0;

                if (MultiLogin_chk.Checked) { multilogin = "1"; }               
                if (Country_cmb.SelectedIndex > -1)
                {
                    country = Convert.ToInt32(Country_cmb.SelectedValue.ToString());
                }

                UserVo inVo = new UserVo
                {
                    UserCode = UserCode_txt.Text.Trim(),
                    UserName = UserName_txt.Text.Trim(),
                   // Language = language,
                    MultiLoginFlag = multilogin,
                    IpAddress = UserData.GetUserData().IpAddress,
                    //RegistrationDateTime = DateTime.Now.ToString(),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    LocaleId = country,
                    RegistrationFactoryCode = FactoryCode_cmb.SelectedValue.ToString()
                };
                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    UserVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, UserCode_lbl.Text + " : " + UserCode_txt.Text);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);

                        return;
                    }
                }


                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        UserVo outVo = (UserVo)base.InvokeCbm(new AddUserMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        UserVo outVo = (UserVo)base.InvokeCbm(new UpdateUserMasterMntCbm(), inVo, false);
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

        #region ControlEvents
        /// <summary>
        /// For loading language when changing Country combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Country_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iscmbCountryLoading) { return; }

            if (Country_cmb.SelectedIndex > -1)
            {
                string selectedCountry = Country_cmb.SelectedValue.ToString();

                DataRow[] selectLanguage = cntryLangDatatable.Select("countrycode = '" + selectedCountry + "'");

                //if (selectLanguage.Length > 0)
                //{
                //    ComboBind(Language_cmb, selectLanguage.CopyToDataTable(), "langcode", "langcode");

                //    Language_cmb.Enabled = true;
                //}
            }
        }

        /// <summary>
        /// If no country is selected setting language combobox as empty and disabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      
        #endregion

    }
}
