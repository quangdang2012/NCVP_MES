using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddEquipmentForm
    {

        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly EquipmentVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddEquipmentForm));

        #endregion

        #region Constructor
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="dataItem"></param>
        public AddEquipmentForm(string pmode, EquipmentVo dataItem = null)
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
            if (EquipmentCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, EquipmentCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                EquipmentCode_txt.Focus();

                return false;
            }
            if (EquipmentName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, EquipmentName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                EquipmentName_txt.Focus();

                return false;
            }
            if (InstrationDate_dtp.Text == " ")
            {
               messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InstrationDate_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InstrationDate_dtp.Focus();

                return false;
            }
            if (AssetNo_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, AssetNo_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                AssetNo_txt.Focus();

                return false;
            }
            //if (Manufacturer_txt.Text == string.Empty)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, "manufacturer");
            //    popUpMessage.Warning(messageData, Text);

            //    Manufacturer_txt.Focus();

            //    return false;
            //}
            //if (ModelCode_txt.Text == string.Empty)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, "model code");
            //    popUpMessage.Warning(messageData, Text);

            //    ModelCode_txt.Focus();

            //    return false;
            //}
            //if (ModelName_txt.Text == string.Empty)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, "model name");
            //    popUpMessage.Warning(messageData, Text);

            //    ModelName_txt.Focus();

            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvData"></param>
        private void LoadUserData(EquipmentVo dgvData)
        {
            if (dgvData != null)
            {
                EquipmentCode_txt.Text = dgvData.EquipmentCode;

                EquipmentName_txt.Text = dgvData.EquipmentName;

                InstrationDate_dtp.Value = dgvData.InstrationDate;

                AssetNo_txt.Text = dgvData.AssetNo;

                Manufacturer_txt.Text = dgvData.Manufacturer;

                ModelCode_txt.Text = dgvData.ModelCode;

                ModelName_txt.Text = dgvData.ModelName;
            }
        }

        /// <summary>
        /// checks duplicate Equipment Code
        /// </summary>
        /// <param name="eqpVo"></param>
        /// <returns></returns>
        private EquipmentVo DuplicateCheck(EquipmentVo eqpVo)
        {
            EquipmentVo outVo = new EquipmentVo();

            try
            {
                outVo = (EquipmentVo)base.InvokeCbm(new CheckEquipmentMasterMntCbm(), eqpVo, false);
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
        private void AddEquipmentForm_Load(object sender, EventArgs e)
        {
            EquipmentCode_txt.Select();

            this.InstrationDate_dtp.Format = DateTimePickerFormat.Custom;

            this.InstrationDate_dtp.CustomFormat = UserData.GetUserData().DateTimeFormat.ShortDatePattern;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                EquipmentCode_txt.Enabled = false;

                EquipmentName_txt.Select();

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
            string manufacturer = string.Empty;
            string modelCode = string.Empty;
            string modelName = string.Empty;
            var sch = StringCheckHelper.GetInstance();

            if (Manufacturer_txt.Text != null)
            {
                manufacturer = Manufacturer_txt.Text.Trim();
            }
            if (ModelCode_txt.Text != null)
            {
                modelCode = ModelCode_txt.Text.Trim();
            }
            if (ModelName_txt.Text != null)
            {
                modelName = ModelName_txt.Text.Trim();
            }

            EquipmentVo inVo = new EquipmentVo();

            if (CheckMandatory())
            {
                if (string.IsNullOrEmpty(EquipmentCode_txt.Text) || string.IsNullOrEmpty(EquipmentName_txt.Text) || string.IsNullOrEmpty(AssetNo_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(EquipmentCode_txt.Text))
                    {
                        EquipmentCode_txt.Focus();
                    }
                    else if (string.IsNullOrEmpty(EquipmentName_txt.Text))
                    {
                        EquipmentName_txt.Focus();
                    }
                    else if (string.IsNullOrEmpty(AssetNo_txt.Text))
                    {
                        AssetNo_txt.Focus();
                    }
                    return;
                }
                inVo.EquipmentCode = EquipmentCode_txt.Text.Trim();

                inVo.EquipmentName = EquipmentName_txt.Text.Trim();

                inVo.InstrationDate = InstrationDate_dtp.Value;

                inVo.AssetNo = AssetNo_txt.Text.Trim();

                inVo.Manufacturer = manufacturer;

                inVo.ModelCode = modelCode;

                inVo.ModelName = modelName;

                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;

                inVo.FactoryCode = UserData.GetUserData().FactoryCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    EquipmentVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, EquipmentCode_lbl.Text + " : " + EquipmentCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);

                        return;
                    }
                }

                if (mode.Equals(CommonConstants.MODE_UPDATE))
                {
                    inVo.EquipmentId = updateData.EquipmentId;
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        EquipmentVo outVo = (EquipmentVo)base.InvokeCbm(new AddEquipmentMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.EquipmentId = updateData.EquipmentId;

                        EquipmentVo outVo = (EquipmentVo)base.InvokeCbm(new UpdateEquipmentMasterMntCbm(), inVo, false);

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

        #region ControlEvents
        /// <summary>
        /// sets date local format to date control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstrationDate_dtp_ValueChanged(object sender, EventArgs e)
        {
            InstrationDate_dtp.CustomFormat = UserData.GetUserData().DateTimeFormat.ShortDatePattern;
        }
        #endregion
    }
}
