using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddInventoryReasonMasterForm
    {

        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly InventoryReasonVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInventoryReasonMasterForm));

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
        /// <param name="LineItem"></param>
        public AddInventoryReasonMasterForm(string pmode, InventoryReasonVo InventoryReasonItem = null)
        {
            InitializeComponent();

            mode = pmode;
            updateData = InventoryReasonItem;

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
            if (InventoryReasonCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InventoryReasonCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InventoryReasonCode_txt.Focus();

                return false;
            }

            if (InventoryReasonName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InventoryReasonName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InventoryReasonName_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// For setting selected Line record into respective controls(textbox and combobox) for update operation
        /// passing selected Line data as parameter 
        /// </summary>
        /// <param name="dgvLine"></param>
        private void LoadInventoryReasonData(InventoryReasonVo dgvInventoryReason)
        {
            if (dgvInventoryReason != null)
            {
                this.InventoryReasonCode_txt.Text = dgvInventoryReason.InventoryReasonCode;
                this.InventoryReasonName_txt.Text = dgvInventoryReason.InventoryReasonName;
            }
        }

        /// <summary>
        /// checks duplicate FactoryCode
        /// </summary>
        /// <param name="lineVo"></param>
        /// <returns></returns>
        private InventoryReasonVo DuplicateCheck(InventoryReasonVo inventoryReasonVo)
        {
            InventoryReasonVo outVo = new InventoryReasonVo();

            try
            {
                outVo = (InventoryReasonVo)base.InvokeCbm(new CheckInventoryReasonMasterMntCbm(), inventoryReasonVo, false);
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
        private void AddInventoryReasonMasterForm_Load(object sender, EventArgs e)
        {
            InventoryReasonCode_txt.Select();
            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadInventoryReasonData(updateData);

                InventoryReasonCode_txt.Enabled = false;

                InventoryReasonName_txt.Select();

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
            

            InventoryReasonVo inVo = new InventoryReasonVo();

            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (string.IsNullOrEmpty(InventoryReasonCode_txt.Text) || string.IsNullOrEmpty(InventoryReasonName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(InventoryReasonCode_txt.Text))
                    {
                        InventoryReasonCode_txt.Focus();
                    }
                    else
                    {
                        InventoryReasonName_txt.Focus();
                    }

                    return;
                }

                inVo.InventoryReasonCode = InventoryReasonCode_txt.Text.Trim();
                inVo.InventoryReasonName = InventoryReasonName_txt.Text.Trim();
                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;
                inVo.FactoryCode = UserData.GetUserData().FactoryCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    InventoryReasonVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InventoryReasonCode_lbl.Text + " : " + InventoryReasonCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);

                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        InventoryReasonVo outVo = (InventoryReasonVo)base.InvokeCbm(new AddInventoryReasonMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        inVo.InventoryReasonId = updateData.InventoryReasonId;
                        InventoryReasonVo outVo = (InventoryReasonVo)base.InvokeCbm(new UpdateInventoryReasonMasterMntCbm(), inVo, false);
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
