using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddCavityForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly CavityVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;


        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable moldDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddCavityForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for the  form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>

        public AddCavityForm()
        {
            InitializeComponent();

        }

        public AddCavityForm (string pmode, CavityVo userItem = null)
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

        #region PrivateMethods

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (CavityCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, CavityCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                CavityCode_txt.Focus();

                return false;
            }

            if (CavityName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, CavityName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                CavityName_txt.Focus();

                return false;
            }
            if (Mold_cmb.Text == string.Empty || Mold_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Mold_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Mold_cmb.Focus();

                return false;
            }

            return true;
        }


        /// <summary>
        /// For binding item
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
        /// <param name="dgvMoldType"></param>
        private void LoadUserData(CavityVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {
                this.CavityCode_txt.Text = dgvMoldType.CavityCode;

                this.CavityName_txt.Text = dgvMoldType.CavityName;

                this.Mold_cmb.SelectedValue = dgvMoldType.MoldId.ToString();
            }
        }

        /// <summary>
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            moldDatatable = new DataTable();
            moldDatatable.Columns.Add("id");
            moldDatatable.Columns.Add("code");

            try
            {
                MoldVo moldOutVo = (MoldVo)base.InvokeCbm(new GetMoldMasterMntCbm(), new MoldVo (), false);

                foreach (MoldVo mold in moldOutVo.MoldListVo)
                {
                    moldDatatable.Rows.Add(mold.MoldId, mold.MoldCode);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// checks duplicate mold Code
        /// </summary>
        /// <returns></returns>
        private CavityVo DuplicateCheck(CavityVo cavityVo)
        {
            CavityVo outVo = new CavityVo();

            try
            {
                outVo = (CavityVo)base.InvokeCbm(new CheckCavityMasterMntCbm(), cavityVo, false);
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
        /// Handles Load event for mold data Insert/Update operations 
        /// Loading mold data for update mold data and binding controls with selected mold record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddCavityForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                FormDatatableFromVo();

                ComboBind(Mold_cmb, moldDatatable, "code", "id");

                CavityCode_txt.Select();

                if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    LoadUserData(updateData);

                    CavityCode_txt.Enabled = false;

                    CavityName_txt.Select();

                }

            }
        }
        #endregion

        #region ButtonClick

        /// <summary>
        /// update the  record to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Ok_btn_Click(object sender, EventArgs e)
        {
            CavityVo inVo = new CavityVo();

            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (string.IsNullOrEmpty(CavityCode_txt.Text) || string.IsNullOrEmpty(CavityName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(CavityCode_txt.Text))
                    {
                        CavityCode_txt.Focus();
                    }
                    else
                    {
                        CavityName_txt.Focus();
                    }

                    return;
                }

                if (CavityCode_txt.Text.Trim().Length < 4)
                {
                    MessageData messageData = new MessageData("mmci00008", Properties.Resources.mmci00008, CavityCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    CavityCode_txt.Focus();
                    return;
                }

                inVo.CavityCode = CavityCode_txt.Text.Trim();

                inVo.CavityName = CavityName_txt.Text.Trim();

                inVo.MoldId = Convert.ToInt32(Mold_cmb.SelectedValue);

                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;

                inVo.FactoryCode = UserData.GetUserData().FactoryCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    CavityVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, CavityCode_lbl.Text + " : " + CavityCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);

                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        CavityVo outVo = (CavityVo)base.InvokeCbm(new AddCavityMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.CavityId = updateData.CavityId;

                        CavityVo outVo = (CavityVo)base.InvokeCbm(new UpdateCavityMasterMntCbm(), inVo, false);

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
        /// close the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
