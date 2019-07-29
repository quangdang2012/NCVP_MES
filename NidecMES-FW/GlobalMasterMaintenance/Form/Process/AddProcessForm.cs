using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddProcessForm
    {
        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly ProcessVo updateData;

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
        public AddProcessForm(string pmode, ProcessVo dataItem = null)
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
            if (ProcessCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ProcessCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ProcessCode_txt.Focus();

                return false;
            }
            if (ProcessName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ProcessName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ProcessName_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvData"></param>
        private void LoadUserData(ProcessVo dgvData)
        {
            if (dgvData != null)
            {
                ProcessCode_txt.Text = dgvData.ProcessCode;

                ProcessName_txt.Text = dgvData.ProcessName;

                //NextProcessCode_txt.Text = dgvData.NextPocessCode;
            }
        }

        /// <summary>
        /// checks duplicate Process Code
        /// </summary>
        /// <param name="processVo"></param>
        /// <returns></returns>
        private ProcessVo DuplicateCheck(ProcessVo processVo)
        {
            ProcessVo outVo = new ProcessVo();

            try
            {
                outVo = (ProcessVo)base.InvokeCbm(new CheckProcessMasterMntCbm(), processVo, false);
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
        private void AddProcessForm_Load(object sender, EventArgs e)
        {
            ProcessCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                ProcessCode_txt.Enabled = false;

                ProcessName_txt.Select();

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
                string nextPocessCode = string.Empty;

                var sch = StringCheckHelper.GetInstance();  
                if (!sch.IsASCII(ProcessCode_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    ProcessCode_txt.Focus();
                    return;
                }

                //else if (!sch.IsASCII(ProcessName_txt.Text))
                //{
                //    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                //    logger.Info(messageData);
                //    popUpMessage.ConfirmationOkCancel(messageData, Text);
                //    ProcessName_txt.Focus();
                //    return;
                //}

                //if (NextProcessCode_txt.Text != null)
                //{
                //    nextPocessCode = NextProcessCode_txt.Text;
                //}

                ProcessVo inVo = new ProcessVo
                {
                    ProcessCode = ProcessCode_txt.Text.Trim(),
                    ProcessName = ProcessName_txt.Text.Trim(),
                    //NextPocessCode = nextPocessCode,
                    //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    FactoryCode = UserData.GetUserData().FactoryCode
                };

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    ProcessVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, ProcessCode_lbl.Text + " : " + ProcessCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);

                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        ProcessVo outVo = (ProcessVo)base.InvokeCbm(new AddProcessMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.ProcessId = updateData.ProcessId;

                        ProcessVo outVo = (ProcessVo)base.InvokeCbm(new UpdateProcessMasterMntCbm(), inVo, false);

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
