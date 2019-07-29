using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddDefectiveCategoryForm
    {

        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly DefectiveCategoryVo updateData;

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
        /// <param name="DefectiveCategoryItem"></param>
        public AddDefectiveCategoryForm(string pmode, DefectiveCategoryVo DefectiveCategoryItem = null)
        {
            InitializeComponent();

            mode = pmode;
           
            updateData = DefectiveCategoryItem;
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
            if (DefectiveCategoryCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, DefectiveCategoryCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                DefectiveCategoryCode_txt.Focus();

                return false;
            }

            if (DefectiveCategoryName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, DefectiveCategoryName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                DefectiveCategoryName_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// For setting selected DefectiveCategory record into respective controls(textbox and combobox) for update operation
        /// passing selected DefectiveCategory data as parameter 
        /// </summary>
        /// <param name="dgvDefectiveCategory"></param>
        private void LoadDefectiveCategoryData(DefectiveCategoryVo dgvDefectiveCategory)
        {
            if (dgvDefectiveCategory != null)
            {
                this.DefectiveCategoryCode_txt.Text = dgvDefectiveCategory.DefectiveCategoryCode;
                this.DefectiveCategoryName_txt.Text = dgvDefectiveCategory.DefectiveCategoryName;
            }
        }

        /// <summary>
        /// checks duplicate FactoryCode
        /// </summary>
        /// <param name="defectiveCategoryVo"></param>
        /// <returns></returns>
        private DefectiveCategoryVo DuplicateCheck(DefectiveCategoryVo defectiveCategoryVo)
        {
            DefectiveCategoryVo outVo = new DefectiveCategoryVo();

            try
            {
                outVo = (DefectiveCategoryVo)base.InvokeCbm(new CheckDefectiveCategoryMasterMntCbm(), defectiveCategoryVo, false);
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
        private void AddDefectiveCategoryForm_Load(object sender, EventArgs e)
        {
            DefectiveCategoryCode_txt.Select();
            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadDefectiveCategoryData(updateData);

                DefectiveCategoryCode_txt.Enabled = false;

                DefectiveCategoryName_txt.Select();

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

            DefectiveCategoryVo inVo = new DefectiveCategoryVo();

            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (string.IsNullOrEmpty(DefectiveCategoryCode_txt.Text) || string.IsNullOrEmpty(DefectiveCategoryName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(DefectiveCategoryCode_txt.Text))
                    {
                        DefectiveCategoryCode_txt.Focus();
                    }
                    else
                    {
                        DefectiveCategoryName_txt.Focus();
                    }

                    return;
                }

                inVo.DefectiveCategoryCode = DefectiveCategoryCode_txt.Text.Trim();
                inVo.DefectiveCategoryName = DefectiveCategoryName_txt.Text.Trim();
                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;
                inVo.FactoryCode = UserData.GetUserData().FactoryCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    DefectiveCategoryVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, DefectiveCategoryCode_lbl.Text + " : " + DefectiveCategoryCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);

                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        DefectiveCategoryVo outVo = (DefectiveCategoryVo)base.InvokeCbm(new AddDefectiveCategoryMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        inVo.DefectiveCategoryId = updateData.DefectiveCategoryId;
                        DefectiveCategoryVo outVo = (DefectiveCategoryVo)base.InvokeCbm(new UpdateDefectiveCategoryMasterMntCbm(), inVo, false);
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
