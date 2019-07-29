using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.UnitMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.Units
{
    public partial class AddUnitForm : FormCommonNCVP
    {
        public AddUnitForm()
        {
            InitializeComponent();
        }
        public UnitVo vo = null;
        public int IntSuccess = -1;
        private void AddUnitForm_Load(object sender, EventArgs e)
        {
            UnitCode_txt.Select();
            if (vo.UnitId > 0)
            {
                UnitCode_txt.Text = vo.UnitCode;
                UnitName_txt.Text = vo.UnitName;
            }
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (checkdate())
            {
                UnitVo outvo = new UnitVo();
                UnitVo invo = new UnitVo
                {
                    UnitId = vo.UnitId,
                    UnitCode = UnitCode_txt.Text,
                    UnitName = UnitName_txt.Text,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (invo.UnitId > 0)
                    {
                        outvo = (UnitVo)DefaultCbmInvoker.Invoke(new UpdateUnitCbm(), invo);
                    }
                    else
                    {
                        outvo = (UnitVo)DefaultCbmInvoker.Invoke(new AddUnitCbm(), invo);
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

            if (UnitCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, UnitCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                UnitCode_txt.Focus();
                return false;
            }
            if (UnitName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, UnitName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                UnitName_txt.Focus();
                return false;
            }
            UnitCode_txt.Text = UnitCode_txt.Text.Trim();
            UnitName_txt.Text = UnitName_txt.Text.Trim();
            UnitVo outVo = new UnitVo(),
                inVo = new UnitVo { UnitId = vo.UnitId, UnitCode = UnitCode_txt.Text };
            try
            {
                outVo = (UnitVo)DefaultCbmInvoker.Invoke(new CheckUnitCbm(), inVo);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, UnitCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    UnitCode_txt.Focus();
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
