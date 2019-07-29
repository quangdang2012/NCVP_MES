using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.DetailPositionCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.DetailPositionForm
{
    public partial class AddDetailPositionForm : FormCommonNCVP
    {
        public AddDetailPositionForm()
        {
            InitializeComponent();
        }
        public DetailPositionVo vo = null;
        public int IntSuccess = -1;
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (checkdate())
            {
                DetailPositionVo outvo = new DetailPositionVo();
                DetailPositionVo invo = new DetailPositionVo
                {
                    LocationId =  ((LocationVo)this.location_cmb.SelectedItem).LocationId,
                    DetailPositionId = vo.DetailPositionId,
                    DetailPositionCode = DetailPositionCode_txt.Text,
                    DetailPositionName = DetailPositionName_txt.Text,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (invo.DetailPositionId > 0)
                    {
                        outvo = (DetailPositionVo)DefaultCbmInvoker.Invoke(new UpdateDetailPositionCbm(), invo);
                    }
                    else
                    {
                        outvo = (DetailPositionVo)DefaultCbmInvoker.Invoke(new AddDetailPositionCbm(), invo);
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

            if (DetailPositionCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, DetailPositionCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                DetailPositionCode_txt.Focus();
                return false;
            }
            if (DetailPositionCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, DetailPositionCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                DetailPositionCode_txt.Focus();
                return false;
            }
            if (location_cmb.Text.Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, location_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                location_cmb.Focus();
                return false;
            }
            DetailPositionCode_txt.Text = DetailPositionCode_txt.Text.Trim();
            DetailPositionName_txt.Text = DetailPositionName_txt.Text.Trim();
            DetailPositionVo outVo = new DetailPositionVo(),
                inVo = new DetailPositionVo { DetailPositionId = vo.DetailPositionId, DetailPositionCode = DetailPositionCode_txt.Text };
            try
            {
                outVo = (DetailPositionVo)DefaultCbmInvoker.Invoke(new CheckDetailPositionCbm(), inVo);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, DetailPositionCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    DetailPositionCode_txt.Focus();
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

        private void AddDetailPositionForm_Load(object sender, EventArgs e)
        {
            LocationVo Locationvo = (LocationVo)DefaultCbmInvoker.Invoke(new GetLocationMasterMntCbm(), new LocationVo());
            location_cmb.DataSource = Locationvo.LocationListVo;
            location_cmb.DisplayMember = "LocationCode";
            location_cmb.Text = "";



            DetailPositionCode_txt.Select();
            if (vo.DetailPositionId > 0)
            {

                DetailPositionCode_txt.Text = vo.DetailPositionCode;
                DetailPositionName_txt.Text = vo.DetailPositionName;
                location_cmb.Text = vo.LocationCd;
            }
        }
    }
}
