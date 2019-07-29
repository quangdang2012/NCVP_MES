using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.InvertoryTimeCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.InventoryForm
{
    public partial class AddInvertoryTimeForm : FormCommonNCVP
    {
        public AddInvertoryTimeForm()
        {
            InitializeComponent();
        }
        public InvertoryVo vo = null;
        public int IntSuccess = -1;
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (checkdate())
            {
                InvertoryVo outvo = new InvertoryVo();
                InvertoryVo invo = new InvertoryVo
                {
                    InvertoryTimeId = vo.InvertoryTimeId,
                    InvertoryTimeCode = InvertoryTimeCode_txt.Text,
                    InvertoryTimeName = InvertoryTimeName_txt.Text,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (invo.InvertoryTimeId > 0)
                    {
                        outvo = (InvertoryVo)DefaultCbmInvoker.Invoke(new UpdateInvertoryTimeCbm(), invo);
                    }
                    else
                    {
                        outvo = (InvertoryVo)DefaultCbmInvoker.Invoke(new AddInvertoryTimeCbm(), invo);
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
                messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InvertoryTimeCode_lbl.Text + " : " + InvertoryTimeCode_txt.Text);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }
        }
        private bool checkdate()
        {

            if (InvertoryTimeCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, InvertoryTimeCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                InvertoryTimeCode_txt.Focus();
                return false;
            }
            if (InvertoryTimeName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, InvertoryTimeName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                InvertoryTimeName_txt.Focus();
                return false;
            }
            InvertoryTimeCode_txt.Text = InvertoryTimeCode_txt.Text.Trim();
            InvertoryTimeName_txt.Text = InvertoryTimeName_txt.Text.Trim();
            InvertoryVo outVo = new InvertoryVo(),
                inVo = new InvertoryVo { InvertoryTimeId = vo.InvertoryTimeId, InvertoryTimeCode = InvertoryTimeCode_txt.Text };
            try
            {
                outVo = (InvertoryVo)DefaultCbmInvoker.Invoke(new CheckInvertoryTimeCbm(), inVo);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, InvertoryTimeCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    InvertoryTimeCode_txt.Focus();
                    return false ;
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
            InvertoryTimeCode_txt.Select();
            if (vo.InvertoryTimeId > 0)
            {
                InvertoryTimeCode_txt.Text = vo.InvertoryTimeCode;
                InvertoryTimeName_txt.Text = vo.InvertoryTimeName;
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
