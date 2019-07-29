using Com.Nidec.Mes.Framework;
using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ProductionControllerCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class AddPersonForm : FormCommonNCVP
    {
        public AddPersonForm()
        {
            InitializeComponent();
        }
        public PersonVo vo;
        private void PersonForm_Load(object sender, EventArgs e)
        {
            getLine();
            getModel();
            shift_cmb.Text = "1";

            if(vo.PersonId > 0)
            {
                model_cmb.Text = vo.Model;
                line_cmb.Text = vo.Line;
                datetime_dtp.Value = vo.DateTimes;
                shift_cmb.Text = vo.Shift.ToString();
                lot_txt.Text = vo.LotNumber;
                plan_txt.Text = vo.PlanPro.ToString();
                st_plan_txt.Text = vo.PlanST.ToString();
                st_actual_txt.Text = vo.ActualSt.ToString();
                actual_co_txt.Text = vo.DoCo.ToString();
                actual_ra_txt.Text = vo.DoRa.ToString();
                actual_ca_txt.Text = vo.DoCa.ToString();
                actual_ba_txt.Text = vo.DoBa.ToString();
                actual_ma_txt.Text = vo.DoMa.ToString();
                absent_co_txt.Text = vo.AbsentCo.ToString();
                absent_ra_txt.Text = vo.AbsentRa.ToString();
                absent_ca_txt.Text = vo.AbsentCa.ToString();
                absent_ba_txt.Text = vo.AbsentBa.ToString();
                absent_ma_txt.Text = vo.AbsentMa.ToString();
                overtime_txt.Text = vo.TimeOver.ToString();
                offsettime_txt.Text = vo.TimeOffset.ToString();
                totaltime_txt.Text = vo.TimeTotal.ToString();
                actual_co_txt_Click(sender, e);
            }


        }

        void getModel()
        {
            ValueObjectList<ProductionControllerVo> model = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new GetModelProCbm(), new ProductionControllerVo());
            model_cmb.DisplayMember = "ProModel";
            model_cmb.DataSource = model.GetList();
            //  model_cmb.Text = "";

        }
        void getLine()
        {
            ValueObjectList<ProductionControllerVo> line = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new GetLineProCbm(), new ProductionControllerVo());
            line_cmb.DisplayMember = "ProLine";
            line_cmb.DataSource = line.GetList();
            line_cmb.Text = "";

        }

        public string lot1;
        public string lot2;
        public string lot3;
        void lotnumbers()
        {
            //processing lot[2]
            string month = datetime_dtp.Value.ToString("MM");
            if (month.Substring(0, 1) == "0")
            {
                month = month.Substring(1, 1).ToString();
            }
            lot2 = month;

            //processing lot[3]
            string[] code = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "N", "P", "Q", "R", "S", "T", "U", "X", "Y", "Z" };
            string date = datetime_dtp.Value.ToString("dd");
            if (date.Substring(0, 1) == "0")
            {
                date = date.Substring(1, 1).ToString();
            }
            for (int i = 1; i <= 31; i++)
            {
                if (date == i.ToString())
                {
                    lot3 = code[i - 1];
                }
            }

            //processing lot[1]
            string year = datetime_dtp.Value.ToString("yy");
            for (int i = 0; i < 31; i++)
            {
                if (year == i.ToString())
                {
                    lot1 = code[i];
                }
            }
            lot_txt.Text = lot1 + lot2 + lot3;
        }

        private void shift_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            lotnumbers();
        }

        private void lot_txt_Click(object sender, EventArgs e)
        {
            lotnumbers();
        }
        private void datetime_dtp_ValueChanged(object sender, EventArgs e)
        {
            lotnumbers();
        }
        void totaltime()
        {
            double co = double.Parse(actual_co_txt.Text);
            double ba = double.Parse(actual_ba_txt.Text);
            double ca = double.Parse(actual_ca_txt.Text);
            double ma = double.Parse(actual_ma_txt.Text);
            double ra = double.Parse(actual_ra_txt.Text);
            double overtime = double.Parse(overtime_txt.Text);
            double offsettime = double.Parse(offsettime_txt.Text);

            double tem426 = 426 * (co + ba + ra + ca + ma) + overtime * (co + ba + ra + ca + ma) + offsettime * (co + ba + ra + ca + ma);
            double tem416 = 416 * (co + ba + ra + ca + ma) + overtime * (co + ba + ra + ca + ma) + offsettime * (co + ba + ra + ca + ma);
            if (shift_cmb.Text == "1" || shift_cmb.Text == "2")
            {
                totaltime_txt.Text = Math.Round(tem426, 3).ToString();
            }
            if (shift_cmb.Text == "3")
            {
                totaltime_txt.Text = Math.Round(tem416, 3).ToString();
            }
            outputthucte();
            if (output_cmb.Text != "0")
            {
                st_actual_txt.Text = Math.Round(double.Parse(totaltime_txt.Text) / double.Parse(output_cmb.Text), 3).ToString();
            }
        }
        void outputthucte()
        {
            ProductionControllerVo invo = new ProductionControllerVo
            {
                ProModel = model_cmb.Text,
                ProLine = line_cmb.Text,
                Date = datetime_dtp.Value.ToShortDateString(),

            };

            ValueObjectList<ProductionControllerVo> output = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchPersonOutputCbm(), invo);
            output_cmb.DisplayMember = "ProOutput";
            output_cmb.DataSource = output.GetList();
        }

        void clearcmb()
        {
            actual_co_txt.Text = "0";
            actual_ba_txt.Text = "0";
            actual_ca_txt.Text = "0";
            actual_ma_txt.Text = "0";
            actual_ra_txt.Text = "0";

            absent_co_txt.Text = "0";
            absent_ba_txt.Text = "0";
            absent_ra_txt.Text = "0";
            absent_ma_txt.Text = "0";
            absent_ca_txt.Text = "0";
            overtime_txt.Text = "0";
            totaltime_txt.Text = "0";
            offsettime_txt.Text = "0";
            leader_txt.Text = "";



        }
        private void totaltime_txt_Click(object sender, EventArgs e)
        {
            totaltime();
        }

        private void actual_co_txt_Click(object sender, EventArgs e)
        {
            totaltime();
        }

        private void actual_ra_txt_Click(object sender, EventArgs e)
        {
            totaltime();
        }

        private void actual_ca_txt_Click(object sender, EventArgs e)
        {
            totaltime();
        }

        private void actual_ba_txt_Click(object sender, EventArgs e)
        {
            totaltime();
        }

        private void actual_ma_txt_Click(object sender, EventArgs e)
        {
            totaltime();
        }

        private void overtime_txt_Click(object sender, EventArgs e)
        {
            totaltime();
        }

        private void offsettime_txt_Click(object sender, EventArgs e)
        {
            totaltime();
        }
        bool Checkdata()
        {
            if (lot_txt.Text.Length < 3)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lot_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                lot_txt.Focus();
                return false;
            }
            if (plan_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, plan_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                plan_txt.Focus();
                return false;
            }
            if (st_plan_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, st_plan_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                st_plan_txt.Focus();
                return false;
            }
            if (st_actual_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, st_actual_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                st_actual_txt.Focus();
                return false;
            }
            if (actual_co_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, actual_co_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                actual_co_txt.Focus();
                return false;
            }
            if (absent_co_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, absent_co_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                absent_co_txt.Focus();
                return false;
            }
            if (actual_ra_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, actual_ra_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                actual_ra_txt.Focus();
                return false;
            }
            if (absent_ra_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, absent_ra_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                absent_ra_txt.Focus();
                return false;
            }
            if (actual_ma_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, actual_ma_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                actual_ma_txt.Focus();
                return false;
            }
            if (absent_ma_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, absent_ma_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                absent_ma_txt.Focus();
                return false;
            }
            if (actual_ba_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, actual_ba_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                actual_ba_txt.Focus();
                return false;
            }
            if (absent_ba_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, absent_ba_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                absent_ba_txt.Focus();
                return false;
            }
            if (actual_ca_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, actual_ca_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                actual_ca_txt.Focus();
                return false;
            }
            if (absent_ca_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, absent_ca_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                absent_ca_txt.Focus();
                return false;
            }


            if (shift_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, shift_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                shift_cmb.Focus();
                return false;
            }
            if (line_cmb.Text == "" || line_cmb.Text == "All Line")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, line_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                line_cmb.Focus();
                return false;
            }
            if (model_cmb.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, model_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                model_cmb.Focus();
                return false;
            }
            if (leader_txt.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, leader_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                leader_txt.Focus();
                return false;
            }

            return true;
        }
        
        private void search_btn_Click(object sender, EventArgs e)
        {
            line_cmb.Items.Remove("All Line");
        }
        
        private void edit_btn_Click(object sender, EventArgs e)
        {
            totaltime();
            if (Checkdata())
            {
                PersonVo invo = new PersonVo
                {
                    PersonId = vo.PersonId,
                    Model = model_cmb.Text,
                    Line = line_cmb.Text,
                    DateTimes = datetime_dtp.Value,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    BuildingCode = "2A",
                    LotNumber = lot_txt.Text,
                    LeaderName = leader_txt.Text,
                    Shift = int.Parse(shift_cmb.Text),
                    PlanPro = int.Parse(plan_txt.Text),
                    PlanST = double.Parse(st_plan_txt.Text),
                    ActualSt = double.Parse(st_actual_txt.Text),
                    DoCo = double.Parse(actual_co_txt.Text),
                    DoRa = double.Parse(actual_ra_txt.Text),
                    DoCa = double.Parse(actual_ca_txt.Text),
                    DoBa = double.Parse(actual_ba_txt.Text),
                    DoMa = double.Parse(actual_ma_txt.Text),
                    AbsentCo = double.Parse(absent_co_txt.Text),
                    AbsentRa = double.Parse(absent_ra_txt.Text),
                    AbsentCa = double.Parse(absent_ca_txt.Text),
                    AbsentBa = double.Parse(absent_ba_txt.Text),
                    AbsentMa = double.Parse(absent_ma_txt.Text),
                    TimeOver = double.Parse(overtime_txt.Text),
                    TimeOffset = double.Parse(offsettime_txt.Text),
                    TimeTotal = double.Parse(totaltime_txt.Text),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                };
                try
                {

                    PersonVo updatePerson = (PersonVo)DefaultCbmInvoker.Invoke(new UpdatePersonProCbm(), invo);

                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, leader_lbl.Text + " : " + leader_txt.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    //clearcmb();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
