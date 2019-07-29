using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddCustomerMasterForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly CustomerVo updateData;

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
        /// <param name="CustomerVo"></param>
        public AddCustomerMasterForm(string pmode, CustomerVo CustomerVo = null)
        {
            InitializeComponent();

            mode = pmode;

            updateData = CustomerVo;
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
            if (CustomerCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, CustomerCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                CustomerCode_txt.Focus();

                return false;
            }
            if (CustomerName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, CustomerName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                CustomerName_txt.Focus();

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
        /// <param name="cuInVo"></param>
        private void LoadUserData(CustomerVo cuInVo)
        {
            if (cuInVo != null)
            {
                CustomerCode_txt.Text = cuInVo.CustomerCode;
                CustomerName_txt.Text = cuInVo.CustomerName;
                Address1_txt.Text = string.IsNullOrEmpty(cuInVo.Address1) ? "" : cuInVo.Address1;
                Address2_txt.Text = string.IsNullOrEmpty(cuInVo.Address2) ? "" : cuInVo.Address2;
                EmailId_txt.Text = string.IsNullOrEmpty(cuInVo.EmailId) ? "" : cuInVo.EmailId;
                Remarks_txt.Text = string.IsNullOrEmpty(cuInVo.Remarks) ? "" : cuInVo.Remarks;
                PhoneNo_txt.Text = string.IsNullOrEmpty(cuInVo.PhoneNo) ? "" : cuInVo.PhoneNo;

            }
        }

        /// <summary>
        /// loads factory and country data table
        /// </summary>
        private void FormDatatableFromVo()
        {

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
        /// <param name="CustomerVo"></param>
        /// <returns></returns>
        private CustomerVo DuplicateCheck(CustomerVo CustomerVo)
        {
            CustomerVo outVo = new CustomerVo();

            try
            {
                outVo = (CustomerVo)base.InvokeCbm(new CheckCustomerMasterMntCbm(), CustomerVo, false);
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
        private void AddCustomerMasterForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            CustomerCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);
                CustomerCode_txt.Enabled = false;
                CustomerName_txt.Select();

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
                if (!sch.IsASCII(CustomerCode_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    CustomerCode_txt.Focus();
                    return;
                }

                CustomerVo inVo = new CustomerVo
                {
                    CustomerCode = CustomerCode_txt.Text.Trim(),
                    CustomerName = CustomerName_txt.Text.Trim(),
                    Address1 = Address1_txt.Text.Trim(),
                    Address2 = Address2_txt.Text.Trim(),
                    EmailId = EmailId_txt.Text.Trim(),
                    Remarks = Remarks_txt.Text.Trim(),
                    PhoneNo = PhoneNo_txt.Text.Trim(),
                };

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    CustomerVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, CustomerCode_lbl.Text + " : " + CustomerCode_txt.Text);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);

                        return;
                    }
                }


                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        CustomerVo outVo = (CustomerVo)base.InvokeCbm(new AddCustomerMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        inVo.CustomerId = updateData.CustomerId;
                        CustomerVo outVo = (CustomerVo)base.InvokeCbm(new UpdateCustomerMasterMntCbm(), inVo, false);
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

        #endregion

    }
}
