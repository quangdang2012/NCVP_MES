using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.WorkingStatusCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class AddPlanWorkingStatusForm : FormCommonNCVP
    {
        public AddPlanWorkingStatusForm()
        {
            InitializeComponent();
        }
   public PlanWorkingStatusVo addplanworking = new PlanWorkingStatusVo();
        private void AddPlanWorkingStatusForm_Load(object sender, EventArgs e)
        {
            rate_txt.ReadOnly = true;
            LocationVo Locationvo = (LocationVo)DefaultCbmInvoker.Invoke(new GetLocationMasterMntCbm(), new LocationVo());
            section_cbm.DataSource = Locationvo.LocationListVo;
            section_cbm.DisplayMember = "LocationCode";

        }
        private void plan_machine_txt_TextChanged(object sender, EventArgs e)
        {
            if (plan_machine_txt.Text != "")
            {
                try
                {
                    rate_txt.Text = ((Convert.ToDouble(plan_machine_txt.Text)) / (Convert.ToDouble(total_machine_txt.Text)) * 100).ToString();
                    if (rate_txt.Text.Length > 4)
                    {
                        rate_txt.Text = rate_txt.Text.Substring(0, 3);
                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
            }
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            if (checkdata())
            {
                PlanWorkingStatusVo outVo = new PlanWorkingStatusVo();
                PlanWorkingStatusVo inVo = new PlanWorkingStatusVo()
                {

                    PlanId = addplanworking.PlanId,
                    PlanSection = ((LocationVo)this.section_cbm.SelectedItem).LocationCode,
                    DateTimeAdd = datetime_add_dtp.Value,
                    TotalNo = Int16.Parse(total_machine_txt.Text),
                    PlanNo = Int16.Parse(plan_machine_txt.Text),
                    Rate = Double.Parse(rate_txt.Text),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationDateTime = DateTime.Now
                };
                try
                {
                    
                        outVo = (PlanWorkingStatusVo)DefaultCbmInvoker.Invoke(new AddPlanWorkingStatusCbm(), inVo);
               
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, section_cbm.Text + " : " + section_cbm.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }
            }
        }
        bool checkdata()
        {
            if (section_cbm.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, section_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                section_cbm.Focus();
                return false;
            }
            if (total_machine_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, total_machine_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                total_machine_txt.Focus();
                return false;
            }
            if (plan_machine_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, plan_machine_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                plan_machine_txt.Focus();
                return false;
            }
            if (rate_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, rate_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                rate_txt.Focus();
                return false;
            }
            if (datetime_add_dtp.Value > DateTime.Now)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, datetime_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                datetime_add_dtp.Focus();
                return false;
            }
            return true;
        }
        private void section_cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(section_cbm.Text == "TD")
            {
                total_machine_txt.Text = "32";
            }
            else if (section_cbm.Text == "CUTTING")
            {
                total_machine_txt.Text = "67";
            }
            else if (section_cbm.Text == "MOLD")
            {
                total_machine_txt.Text = "50";
            }
            else if (section_cbm.Text == "ST")
            {
                total_machine_txt.Text = "18";
            }
            else if (section_cbm.Text == "SP")
            {
                total_machine_txt.Text = "39";
            }
            else
            {
                total_machine_txt.Text = "";
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
