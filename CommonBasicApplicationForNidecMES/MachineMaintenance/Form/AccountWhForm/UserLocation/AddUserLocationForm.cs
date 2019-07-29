using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.UserLocationMasterCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.UserLocation
{
    public partial class AddUserLocationForm : FormCommonNCVP
    {
        public AddUserLocationForm()
        {
            InitializeComponent();
        }
        public UserLocationVo vo = null;
        public int IntSuccess = -1;
        private void AddUserLocationForm_Load(object sender, EventArgs e)
        {
            UserLocationCode_txt.Select();
            if (vo.UserLocationId > 0)
            {
                UserLocationCode_txt.Text = vo.UserLocationCode;
                UserLocationName_txt.Text = vo.UserLocationName;
            }
            LocationVo Locationvo = (LocationVo)DefaultCbmInvoker.Invoke(new GetLocationMasterMntCbm(), new LocationVo());
            locationcode_cmb.DataSource = Locationvo.LocationListVo;
            locationcode_cmb.DisplayMember = "LocationCode";
            locationcode_cmb.Text = "";
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (checkdate())
            {
                UserLocationVo outvo = new UserLocationVo();
                UserLocationVo invo = new UserLocationVo
                {
                    UserLocationId = vo.UserLocationId,
                    UserLocationCode = UserLocationCode_txt.Text,
                    UserLocationName = UserLocationName_txt.Text,
                    DeptCode = locationcode_cmb.Text,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (invo.UserLocationId > 0)
                    {
                        outvo = (UserLocationVo)DefaultCbmInvoker.Invoke(new UpdateUserLocationCbm(), invo);
                    }
                    else
                    {
                        outvo = (UserLocationVo)DefaultCbmInvoker.Invoke(new AddUserLocationCbm(), invo);
                    }
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, UserLocationCode_lbl.Text + " : " + UserLocationCode_txt.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
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

            if (UserLocationCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, UserLocationCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                UserLocationCode_txt.Focus();
                return false;
            }
            if (UserLocationName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, UserLocationName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                UserLocationName_txt.Focus();
                return false;
            }
            UserLocationCode_txt.Text = UserLocationCode_txt.Text.Trim();
            UserLocationName_txt.Text = UserLocationName_txt.Text.Trim();
            UserLocationVo outVo = new UserLocationVo(),
                inVo = new UserLocationVo { UserLocationId = vo.UserLocationId, UserLocationCode = UserLocationCode_txt.Text };
            try
            {
                outVo = (UserLocationVo)DefaultCbmInvoker.Invoke(new CheckUserLocationCbm(), inVo);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, UserLocationCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    UserLocationCode_txt.Focus();
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
