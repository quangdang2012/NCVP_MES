using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddFactoryMasterForm
    {

        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly FactoryVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddFactoryMasterForm));

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
        /// <param name="factoryItem"></param>
        public AddFactoryMasterForm(string pmode, FactoryVo factoryItem = null)
        {
            InitializeComponent();

            mode = pmode;           
            updateData = factoryItem;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }
        }
        public AddFactoryMasterForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (FactoryCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, FactoryCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                FactoryCode_txt.Focus();

                return false;
            }

            if (FactoryName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, FactoryName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                FactoryName_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// For setting selected factory record into respective controls(textbox and combobox) for update operation
        /// passing selected factory data as parameter 
        /// </summary>
        /// <param name="dgvFactory"></param>
        private void LoadFactoryData(FactoryVo dgvFactory)
        {
            if (dgvFactory != null)
            {
                this.FactoryCode_txt.Text = dgvFactory.FactoryCode;
                this.FactoryName_txt.Text = dgvFactory.FactoryName;
            }
        }

        /// <summary>
        /// checks duplicate FactoryCode
        /// </summary>
        /// <param name="factVo"></param>
        /// <returns></returns>
        private FactoryVo DuplicateCheck(FactoryVo factVo)
        {
            FactoryVo outVo = new FactoryVo();

            try
            {
                outVo = (FactoryVo)base.InvokeCbm(new CheckFactoryMasterMntCbm(), factVo, false);
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
        private void AddFactoryMasterForm_Load(object sender, EventArgs e)
        {
            FactoryCode_txt.Select();
            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadFactoryData(updateData);

                FactoryCode_txt.Enabled = false;

                FactoryName_txt.Select();

            }
        }
        #endregion

        #region ButtonClick
        /// <summary>
        /// update data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Ok_btn_Click(object sender, EventArgs e)
        {
            var sch = StringCheckHelper.GetInstance();
          
            FactoryVo inVo = new FactoryVo();

            if (CheckMandatory())
            {
                if (string.IsNullOrEmpty(FactoryCode_txt.Text) || string.IsNullOrEmpty(FactoryName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if(string.IsNullOrEmpty(FactoryCode_txt.Text))
                    {
                        FactoryCode_txt.Focus();
                    }
                    else
                    {
                        FactoryName_txt.Focus();
                    }
                    return;
                }

                inVo.FactoryCode = FactoryCode_txt.Text.Trim();
                inVo.FactoryName = FactoryName_txt.Text.Trim();
                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    FactoryVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, FactoryCode_lbl.Text + " : " + FactoryCode_txt.Text);
                        logger.Info(messageData);                        
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        FactoryVo outVo = (FactoryVo)base.InvokeCbm(new AddFactoryMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        FactoryVo outVo = (FactoryVo)base.InvokeCbm(new UpdateFactoryMasterMntCbm(), inVo, false);
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
        protected virtual void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}
