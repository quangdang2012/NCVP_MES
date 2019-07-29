using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddCountryLanguageForm 
    {
        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly CountryLanguageVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddCountryLanguageForm));

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
        /// <param name="userItem"></param>
        public AddCountryLanguageForm(string pmode, CountryLanguageVo userItem = null)
        {
            InitializeComponent();

            mode = pmode;           
            updateData = userItem;
            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (Country_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Country_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                Country_txt.Focus();

                return false;
            }
            if (Language_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Language_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                Language_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks country field and language field
        /// </summary>
        /// <returns></returns>
        private bool CheckCountryAndLanguage()
        {
            List<string> regions = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.IsNeutralCulture && c.LCID != 0x7f)
                .Select(c => new RegionInfo(c.LCID).TwoLetterISORegionName)
                .Distinct().ToList();

            List<string> languages = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.IsNeutralCulture && c.LCID != 0x7f) // LCID 0x7f ="InvariantCulture" having no associated RegionInfo
                .Select(c => c.TwoLetterISOLanguageName)
                .Distinct().ToList();

            bool regionOK = regions.Contains(Country_txt.Text);
            bool languageOK = languages.Contains(Language_txt.Text);

            if (!regionOK)
            {
                messageData = new MessageData("mmce00004", Properties.Resources.mmce00004);
                popUpMessage.Warning(messageData, Text);
                Country_txt.Focus();
                return regionOK;
            }

            if (!languageOK)
            {
                messageData = new MessageData("mmce00005", Properties.Resources.mmce00005);
                popUpMessage.Warning(messageData, Text);
                Language_txt.Focus();
                return languageOK;
            }

            return regionOK && languageOK;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvUser"></param>
        private void LoadUserData(CountryLanguageVo dgvUser)
        {
            if (dgvUser != null)
            {
                this.Country_txt.Text = dgvUser.Country;

                this.Language_txt.Text = dgvUser.Language;
            }
        }

        /// <summary>
        /// checks duplicate Country
        /// </summary>
        /// <param name="cntryVo"></param>
        /// <returns></returns>
        private CountryLanguageVo DuplicateCheck(CountryLanguageVo cntryVo)
        {
            CountryLanguageVo outVo = new CountryLanguageVo();

            try
            {
                outVo = (CountryLanguageVo)base.InvokeCbm(new CheckCountryLanguageMasterMntCbm(), cntryVo, false);
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
        /// load the form with combobox bind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCountryLanguageForm_Load(object sender, EventArgs e)
        {
            Country_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);
                var resourceMngr = new ResourceManager(this.GetType());
                // this.Text = resourceMngr.GetString("UpdateForm");
                this.Text = UpdateText_lbl.Text;
            }
        }

        #endregion

        #region ButtonClick
        /// <summary>
        /// update the record to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {        

            if (CheckMandatory())
            {
                bool inputOK = CheckCountryAndLanguage();

                if (!inputOK) return;

                CountryLanguageVo inVo = new CountryLanguageVo();

                inVo.Country = Country_txt.Text;

                inVo.Language = Language_txt.Text;

                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    CountryLanguageVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, Country_lbl.Text + " : " + Country_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        
                        return;
                    }
                }

                try
                {

                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        CountryLanguageVo outVo = (CountryLanguageVo)base.InvokeCbm(new AddCountryLanguageMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        CountryLanguageVo outVo = (CountryLanguageVo)base.InvokeCbm(new UpdateCountryLanguageMasterMntCbm(), inVo, false);
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
        /// close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
