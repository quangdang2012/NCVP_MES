using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddLocalSupplierForm
    {
        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly LocalSupplierVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddProcessForm));

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
        public AddLocalSupplierForm(string pmode, LocalSupplierVo dataItem = null)
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
            if (LocalSupplierCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LocalSupplierCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                LocalSupplierCode_txt.Focus();

                return false;
            }
            if (LocalSupplierName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LocalSupplierName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                LocalSupplierName_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvData"></param>
        private void LoadUserData(LocalSupplierVo dgvData)
        {
            if (dgvData != null)
            {
                LocalSupplierCode_txt.Text = dgvData.LocalSupplierCode;

                LocalSupplierName_txt.Text = dgvData.LocalSupplierName;
            }
        }

        /// <summary>
        /// checks duplicate Process Code
        /// </summary>
        /// <param name="processVo"></param>
        /// <returns></returns>
        private LocalSupplierVo DuplicateCheck(LocalSupplierVo localSupplierVo)
        {
            LocalSupplierVo outVo = new LocalSupplierVo();

            try
            {
                outVo = (LocalSupplierVo)base.InvokeCbm(new CheckLocalSupplierMasterMntCbm(), localSupplierVo, false);
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
        /// load the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLocalSupplierForm_Load(object sender, EventArgs e)
        {
            LocalSupplierCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                LocalSupplierCode_txt.Enabled = false;

                LocalSupplierName_txt.Select();

            }
        }
        #endregion

        #region ButtonClick

        /// <summary>
        /// closes form on exit click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// inserts/updates process on ok click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (string.IsNullOrEmpty(LocalSupplierCode_txt.Text) || string.IsNullOrEmpty(LocalSupplierName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(LocalSupplierCode_txt.Text))
                    {
                        LocalSupplierCode_txt.Focus();
                    }
                    else
                    {
                        LocalSupplierName_txt.Focus();
                    }

                    return;
                }

                LocalSupplierVo inVo = new LocalSupplierVo
                {
                    LocalSupplierCode = LocalSupplierCode_txt.Text.Trim(),
                    LocalSupplierName = LocalSupplierName_txt.Text.Trim(),
                    //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    FactoryCode = UserData.GetUserData().FactoryCode
                };

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    LocalSupplierVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, LocalSupplierCode_lbl.Text + " : " + LocalSupplierCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);

                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        LocalSupplierVo outVo = (LocalSupplierVo)base.InvokeCbm(new AddLocalSupplierMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.LocalSupplierId = updateData.LocalSupplierId;

                        LocalSupplierVo outVo = (LocalSupplierVo)base.InvokeCbm(new UpdateLocalSupplierMasterMntCbm(), inVo, false);

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
