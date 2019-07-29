using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddProcessFlowRuleForm
    {
        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly ProcessFlowRuleVo updateData;

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
        public AddProcessFlowRuleForm(string pmode, ProcessFlowRuleVo dataItem = null)
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
            if (ProcessFlowRuleCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ProcessFlowRuleCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ProcessFlowRuleCode_txt.Focus();

                return false;
            }
            if (Comment_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Comment_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Comment_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvData"></param>
        private void LoadUserData(ProcessFlowRuleVo dgvData)
        {
            if (dgvData != null)
            {
                ProcessFlowRuleCode_txt.Text = dgvData.ProcessFlowRuleCode;

                Comment_txt.Text = dgvData.Comment;
            }
        }

        /// <summary>
        /// checks duplicate Process Code
        /// </summary>
        /// <param name="processVo"></param>
        /// <returns></returns>
        private ProcessFlowRuleVo DuplicateCheck(ProcessFlowRuleVo machineVo)
        {
            ProcessFlowRuleVo outVo = new ProcessFlowRuleVo();

            try
            {
                outVo = (ProcessFlowRuleVo)base.InvokeCbm(new CheckProcessFlowRuleMasterMntCbm(), machineVo, false);
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
        private void AddProcessFlowRuleForm_Load(object sender, EventArgs e)
        {
            ProcessFlowRuleCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                ProcessFlowRuleCode_txt.Enabled = false;

                Comment_txt.Select();

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
        /// inserts/updates ProcessFlowRule on ok click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {

            if (CheckMandatory())
            {
                var sch = StringCheckHelper.GetInstance();

                if (string.IsNullOrEmpty(ProcessFlowRuleCode_txt.Text) || string.IsNullOrEmpty(Comment_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(ProcessFlowRuleCode_txt.Text))
                    {
                        ProcessFlowRuleCode_txt.Focus();
                    }
                    else
                    {
                        Comment_txt.Focus();
                    }

                    return;
                }

                ProcessFlowRuleVo inVo = new ProcessFlowRuleVo
                {
                    ProcessFlowRuleCode = ProcessFlowRuleCode_txt.Text.Trim(),
                    Comment = Comment_txt.Text.Trim(),
                    //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    FactoryCode = UserData.GetUserData().FactoryCode
                };

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    ProcessFlowRuleVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, ProcessFlowRuleCode_lbl.Text + " : " + ProcessFlowRuleCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);

                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        ProcessFlowRuleVo outVo = (ProcessFlowRuleVo)base.InvokeCbm(new AddProcessFlowRuleMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.ProcessFlowRuleId = updateData.ProcessFlowRuleId;

                        ProcessFlowRuleVo outVo = (ProcessFlowRuleVo)base.InvokeCbm(new UpdateProcessFlowRuleMasterMntCbm(), inVo, false);

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
