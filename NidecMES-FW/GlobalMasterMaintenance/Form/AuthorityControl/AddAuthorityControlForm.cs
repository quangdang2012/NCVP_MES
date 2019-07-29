using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.Framework;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddAuthorityControlForm
    {
        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly AuthorityControlVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// parent control table
        /// </summary>
        private DataTable parentControlDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AuthorityControlForm));

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
        /// <param name="authorityItem"></param>
        public AddAuthorityControlForm(string pmode, AuthorityControlVo authorityItem = null)
        {
            InitializeComponent();

            mode = pmode;
            updateData = authorityItem;


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
            if (AuthorityControlCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, AuthorityControlCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                AuthorityControlCode_txt.Focus();

                return false;
            }

            if (AuthorityControlName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, AuthorityControlName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                AuthorityControlName_txt.Focus();

                return false;
            }

            //if (AssemblyName_txt.Text == string.Empty)
            //{
            //    MessageData messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, "Assembly Name");
            //    _popUpMessage.ConfirmationOkCancel(messageData, Text);

            //    AssemblyName_txt.Focus();

            //    return false;
            //}

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
        /// <param name="autInVo"></param>
        private void LoadAuthorityData(AuthorityControlVo autInVo)
        {
            if (autInVo != null)
            {
                this.AuthorityControlCode_txt.Text = autInVo.AuthorityControlCode;

                this.AuthorityControlName_txt.Text = autInVo.AuthorityControlName;

                this.ParentControl_cmb.SelectedValue = autInVo.ParentControlCode;

                //this.AssemblyName_txt.Text = dgvAuthority.Cells["colAssemblyName"].Value.ToString();

                //this.FormName_txt.Text = dgvAuthority.Cells["colFormName"].Value.ToString();

            }
        }



        /// <summary>
        /// form datatable from vo
        /// </summary>
        private void FormDatatableFromVo()
        {
            parentControlDatatable = new DataTable();
            parentControlDatatable.Columns.Add("Code");
            parentControlDatatable.Columns.Add("Name");

            try
            {
                AuthorityControlVo authOutVo = (AuthorityControlVo)base.InvokeCbm(new GetAuthorityControlMasterMntCbm(), new AuthorityControlVo(), false);

                foreach (AuthorityControlVo auth in authOutVo.AuthorityControlListVo)
                {
                    parentControlDatatable.Rows.Add(auth.AuthorityControlCode, auth.AuthorityControlCode);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }


        }

        /// <summary>
        /// checks duplicate auth Code
        /// </summary>
        /// <param name="authVo"></param>
        /// <returns></returns>
        private AuthorityControlVo DuplicateCheck(AuthorityControlVo authVo)
        {
            AuthorityControlVo outVo = new AuthorityControlVo();

            try
            {
                outVo = (AuthorityControlVo)base.InvokeCbm(new CheckAuthorityControlMasterMntCbm(), authVo, false);
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
        /// load data from db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAuthorityControlForm_Load(object sender, EventArgs e)
        {
            try
            {
                FormDatatableFromVo();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }


            ComboBind(ParentControl_cmb, parentControlDatatable, "Name", "Code");

            AuthorityControlCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadAuthorityData(updateData);

                AuthorityControlCode_txt.Enabled = false;

                AuthorityControlName_txt.Select();

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
            var sch = StringCheckHelper.GetInstance();

            AuthorityControlVo inVo = new AuthorityControlVo();

            if (CheckMandatory())
            {
                if (!sch.IsSmallAlphabetOrNumeric(AuthorityControlCode_txt.Text))
                {
                    messageData = new MessageData("mmce00006", Properties.Resources.mmce00006, AuthorityControlCode_lbl.Text);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    AuthorityControlCode_txt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(AuthorityControlName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    AuthorityControlName_txt.Focus();
                    return;
                }
                inVo.AuthorityControlCode = AuthorityControlCode_txt.Text.Trim();

                inVo.AuthorityControlName = AuthorityControlName_txt.Text.Trim();

                if (ParentControl_cmb.SelectedIndex > -1)
                {
                    inVo.ParentControlCode = ParentControl_cmb.SelectedValue.ToString();
                }
                //inVo.AssemblyName = AssemblyName_txt.Text;

                //inVo.FormName = FormName_txt.Text;

                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;

                //inVo.FactoryCode = UserData.GetUserData().FactoryCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    AuthorityControlVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, AuthorityControlCode_lbl.Text + " : " + AuthorityControlCode_txt.Text);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);

                        return;
                    }
                }

                try
                {

                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        AuthorityControlVo outVo = (AuthorityControlVo)base.InvokeCbm(new AddAuthorityControlMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        AuthorityControlVo outVo = (AuthorityControlVo)base.InvokeCbm(new UpdateAuthorityControlMasterMntCbm(), inVo, false);
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
            Close();
        }

        #endregion
    }
}
