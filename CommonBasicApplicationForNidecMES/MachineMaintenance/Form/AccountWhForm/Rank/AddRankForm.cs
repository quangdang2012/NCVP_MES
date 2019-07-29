using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.RankMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.Rank
{
    public partial class AddRankForm : FormCommonNCVP
    {
        public AddRankForm()
        {
            InitializeComponent();
        }
        public RankVo vo = null;
        public int IntSuccess = -1;
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (checkdate())
            {
                RankVo outvo = new RankVo();
                RankVo invo = new RankVo
                {
                    RankId = vo.RankId,
                    RankCode = RankCode_txt.Text,
                    RankName = RankName_txt.Text,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (invo.RankId > 0)
                    {
                        outvo = (RankVo)DefaultCbmInvoker.Invoke(new UpdateRankCbm(), invo);
                    }
                    else
                    {
                        outvo = (RankVo)DefaultCbmInvoker.Invoke(new AddRankCbm(), invo);
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

            if (RankCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, RankCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                RankCode_txt.Focus();
                return false;
            }
            if (RankName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, RankName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                RankName_txt.Focus();
                return false;
            }
            RankCode_txt.Text = RankCode_txt.Text.Trim();
            RankName_txt.Text = RankName_txt.Text.Trim();
            RankVo outVo = new RankVo(),
                inVo = new RankVo { RankId = vo.RankId, RankCode = RankCode_txt.Text };
            try
            {
                outVo = (RankVo)DefaultCbmInvoker.Invoke(new CheckRankCbm(), inVo);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, RankCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    RankCode_txt.Focus();
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
        private void AddRankForm_Load(object sender, EventArgs e)
        {
            RankCode_txt.Select();
            if (vo.RankId > 0)
            {
                RankCode_txt.Text = vo.RankCode;
                RankName_txt.Text = vo.RankName;
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
