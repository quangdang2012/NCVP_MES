using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountLocationCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.AccountLocationForm
{
    public partial class AddAccountLocationForm : FormCommonNCVP
    {
        public AddAccountLocationForm()
        {
            InitializeComponent();
        }
        public AccountLocationVo vo = null;
        public int IntSuccess = -1;
        private void AddAccountLocationForm_Load(object sender, EventArgs e)
        {
            AccountLocationCode_txt.Select();
            if (vo.AccountLocationId > 0)
            {
                AccountLocationCode_txt.Text = vo.AccountLocationCode;
                AccountLocationName_txt.Text = vo.AccountLocationName;
                AccountLocationType_txt.Text = vo.AccountLocationType;
            }
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (checkdate())
            {
                AccountLocationVo outvo = new AccountLocationVo();
                AccountLocationVo invo = new AccountLocationVo
                {
                    AccountLocationId = vo.AccountLocationId,
                    AccountLocationCode = AccountLocationCode_txt.Text,
                    AccountLocationName = AccountLocationName_txt.Text,
                    AccountLocationType = AccountLocationType_txt.Text,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (invo.AccountLocationId > 0)
                    {
                        outvo = (AccountLocationVo)DefaultCbmInvoker.Invoke(new UpdateAccountLocationCbm(), invo);
                    }
                    else
                    {
                        outvo = (AccountLocationVo)DefaultCbmInvoker.Invoke(new AddAccountLocationCbm(), invo);
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

            if (AccountLocationCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, AccountLocationCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AccountLocationCode_txt.Focus();
                return false;
            }
            if (AccountLocationName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, AccountLocationName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AccountLocationName_txt.Focus();
                return false;
            }
            if (AccountLocationType_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, AccountLocationType_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AccountLocationType_txt.Focus();
                return false;
            }
            AccountLocationCode_txt.Text = AccountLocationCode_txt.Text.Trim();
            AccountLocationName_txt.Text = AccountLocationName_txt.Text.Trim();
            AccountLocationVo outVo = new AccountLocationVo(),
                inVo = new AccountLocationVo { AccountLocationId = vo.AccountLocationId, AccountLocationCode = AccountLocationCode_txt.Text };
            try
            {
                outVo = (AccountLocationVo)DefaultCbmInvoker.Invoke(new CheckAccountLocationCbm(), inVo);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, AccountLocationCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    AccountLocationCode_txt.Focus();
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

        private void AccountLocationName_txt_TextChanged(object sender, EventArgs e)
        {
            string textcheck = (AccountLocationCode_txt.Text.Substring(0, 1));
           
            if (textcheck == "P")
            {
                AccountLocationType_txt.Text = "Part";
            }
            else if (textcheck == "M")
            {
                AccountLocationType_txt.Text = "MOTOR";
            }
            else if (textcheck == "G")
            {
                AccountLocationType_txt.Text = "GA";
            }
            else if (textcheck == "C")
            {
                AccountLocationType_txt.Text = "CL";
            }
            else if (textcheck == "T")
            {
                AccountLocationType_txt.Text = "TD";
            }
        }
    }
}
