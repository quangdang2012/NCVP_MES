using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountCodeCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.AccountCodeForm
{
    public partial class AddAccountCodeForm : FormCommonNCVP
    {
        public AddAccountCodeForm()
        {
            InitializeComponent();
        }
        public AccountCodeVo vo = null;
        public int IntSuccess = -1;
        private void AddAccountCodeForm_Load(object sender, EventArgs e)
        {
            AccountCode_txt.Select();
            if (vo.AccountCodeId > 0)
            {
                AccountCode_txt.Text = vo.AccountCodeCode;
                AccountName_txt.Text = vo.AccountCodeName;
            }
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (checkdate())
            {
                AccountCodeVo outvo = new AccountCodeVo();
                AccountCodeVo invo = new AccountCodeVo
                {
                    AccountCodeId = vo.AccountCodeId,
                    AccountCodeCode = AccountCode_txt.Text,
                    AccountCodeName = AccountName_txt.Text,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (invo.AccountCodeId > 0)
                    {
                        outvo = (AccountCodeVo)DefaultCbmInvoker.Invoke(new UpdateAccountCodeCbm(), invo);
                    }
                    else
                    {
                        outvo = (AccountCodeVo)DefaultCbmInvoker.Invoke(new AddAccountCodeCbm(), invo);
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
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        private bool checkdate()
        {

            if (AccountCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, AccountCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AccountCode_txt.Focus();
                return false;
            }
            if (AccountName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, AccountName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AccountName_txt.Focus();
                return false;
            }
            AccountCode_txt.Text = AccountCode_txt.Text.Trim();
            AccountName_txt.Text = AccountName_txt.Text.Trim();
            AccountCodeVo outVo = new AccountCodeVo(),
                inVo = new AccountCodeVo { AccountCodeId = vo.AccountCodeId, AccountCodeCode = AccountCode_txt.Text };
            try
            {
                outVo = (AccountCodeVo)DefaultCbmInvoker.Invoke(new CheckAccountCodeCbm(), inVo);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, AccountCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    AccountCode_txt.Focus();
                    return false;
                }
            }
            catch (Com.Nidec.Mes.Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return false;
            }
            return true;

        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
