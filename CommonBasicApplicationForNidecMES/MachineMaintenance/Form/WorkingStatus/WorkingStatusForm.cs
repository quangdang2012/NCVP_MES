using Com.Nidec.Mes.Framework;
using System;
using System.Windows.Forms;

using System.Drawing;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.WorkingStatusCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class WorkingStatusForm : FormCommonNCVP
    {
        public WorkingStatusForm()
        {
            InitializeComponent();
        }

        private void MainView_btn_Click(object sender, EventArgs e)
        {
            MainSection_gpb.Visible = true;
            TDSection_gpb.Visible = false;
            STSection_gpb.Visible = false;
            MoldSection_gpb.Visible = false;
            MACSection_gpb.Visible = false;
            PressSection_gpb.Visible = false;
        }
        private void MoldSection_btn_Click(object sender, EventArgs e)
        {
            MainSection_gpb.Visible = false;
            TDSection_gpb.Visible = false;
            STSection_gpb.Visible = false;
            MoldSection_gpb.Visible = true;
            MACSection_gpb.Visible = false;
            PressSection_gpb.Visible = false;
        }
        private void PressSection_btn_Click(object sender, EventArgs e)
        {
            MainSection_gpb.Visible = false;
            TDSection_gpb.Visible = false;
            STSection_gpb.Visible = false;
            MoldSection_gpb.Visible = false;
            MACSection_gpb.Visible = false;
            PressSection_gpb.Visible = true;
            press_mc_mc20_btn.Visible = false;
            press_mc_mc21_btn.Visible = false;
            press_mc_mc26_btn.Visible = false;
            press_mc_mc30_btn.Visible = false;
            press_mc_mc33_btn.Visible = false;
            press_mc_mc34_btn.Visible = false;
            press_mc_mc35_btn.Visible = false;
            press_mc_mc36_btn.Visible = false;


        }
        private void MacSection_btn_Click(object sender, EventArgs e)
        {
            MainSection_gpb.Visible = false;
            TDSection_gpb.Visible = false;
            STSection_gpb.Visible = false;
            MoldSection_gpb.Visible = false;
            MACSection_gpb.Visible = true;
            PressSection_gpb.Visible = false;
        }
        private void STSection_btn_Click(object sender, EventArgs e)
        {
            MainSection_gpb.Visible = false;
            TDSection_gpb.Visible = false;
            STSection_gpb.Visible = true;
            MoldSection_gpb.Visible = false;
            MACSection_gpb.Visible = false;
            PressSection_gpb.Visible = false;

        }
        private void TDSection_btn_Click(object sender, EventArgs e)
        {
            MainSection_gpb.Visible = false;
            TDSection_gpb.Visible = true;
            STSection_gpb.Visible = false;
            MoldSection_gpb.Visible = false;
            MACSection_gpb.Visible = false;
            PressSection_gpb.Visible = false;

        }
        private void EditMachineDGV(ref DataGridViewCommon dgv)
        {
            dgv.DefaultCellStyle.Font = new Font("Arial", 9);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Regular);
            dgv.ReadOnly = true;
        }
        private void WorkingStatusForm_Load(object sender, EventArgs e)
        {
           
            EditMachineDGV(ref td_machine_dgv);
            EditMachineDGV(ref st_machine_dgv);
            EditMachineDGV(ref mac_machine_dgv);
            EditMachineDGV(ref mold_machine_dgv);
            EditMachineDGV(ref sp_machine_dgv);

            MainView_btn_Click(sender, e);
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string time = DateTime.Now.ToString("HH:mm:ss");
            year_lbl.Text = year;
            month_lbl.Text = month;
            day_lbl.Text = day;
            time_lbl.Text = time;
            auto_load_btn.Text = "Auto";
            plan_dgv.Visible = false;
            st_machine_dgv.Visible = true;
            td_machine_dgv.Visible = true;
            mac_machine_dgv.Visible = true;
        }

        private void timer_load_Tick(object sender, EventArgs e)
        {
            
            time_lbl.Text = DateTime.Now.ToString("HH:mm:ss");
            st_time_lbl.Text = DateTime.Now.ToString("HH:mm:ss");
            td_time_lbl.Text = DateTime.Now.ToString("HH:mm:ss");
            mold_time_lbl.Text = DateTime.Now.ToString("HH:mm:ss");
            mac_time_lbl.Text = DateTime.Now.ToString("HH:mm:ss");
            press_time_lbl.Text = DateTime.Now.ToString("HH:mm:ss");
            day_lbl.Text = DateTime.Now.ToString("dd");
            st_day_lbl.Text = DateTime.Now.ToString("dd");
            td_day_lbl.Text = DateTime.Now.ToString("dd");
            mold_day_lbl.Text = DateTime.Now.ToString("dd");
            mac_day_lbl.Text = DateTime.Now.ToString("dd");
            press_day_lbl.Text = DateTime.Now.ToString("dd");

            year_lbl.Text = DateTime.Now.ToString("yyyy");
            st_year_lbl.Text = DateTime.Now.ToString("yyyy");
            td_year_lbl.Text = DateTime.Now.ToString("yyyy");
            mold_year_lbl.Text = DateTime.Now.ToString("yyyy");
            mac_year_lbl.Text = DateTime.Now.ToString("yyyy");
            press_year_lbl.Text = DateTime.Now.ToString("yyyy");

            month_lbl.Text = DateTime.Now.ToString("MM");
            st_month_lbl.Text = DateTime.Now.ToString("MM");
            td_month_lbl.Text = DateTime.Now.ToString("MM");
            mold_month_lbl.Text = DateTime.Now.ToString("MM");
            mac_month_lbl.Text = DateTime.Now.ToString("MM");
            press_month_lbl.Text = DateTime.Now.ToString("MM");

            manual_btn_Click(sender, e);
        }
        private void auto_load_btn_Click(object sender, EventArgs e)
        {
            if (timer_load_txt.Text != "")
            {
                if (auto_load_btn.Text == "Stop")
                {
                    auto_load_btn.Text = "Auto";
                    timer_load.Enabled = false;
                    timer_load_txt.ReadOnly = false;
                }
                else
                {
                    auto_load_btn.Text = "Stop";
                    timer_load.Interval = int.Parse(timer_load_txt.Text) * 1000;
                    timer_load.Enabled = true;
                    timer_load_txt.ReadOnly = true;
                }
            }
            else
            {
                messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, auto_load_btn.Text + " : " + auto_load_btn.Text);
                logger.Info(messageData);
                popUpMessage.ApplicationError(messageData, Text);
            }
        }
        public void callplan()
        {
            plan_dgv.AutoGenerateColumns = false;
            PlanWorkingStatusVo callplan = new PlanWorkingStatusVo();
            ValueObjectList<PlanWorkingStatusVo> listvo = (ValueObjectList<PlanWorkingStatusVo>)DefaultCbmInvoker.Invoke(new CallPlanCbm(), callplan);
            plan_dgv.DataSource = listvo.GetList();
            int i = 0;
            for (i = 0; i < plan_dgv.Rows.Count; i++)
            {
                if (plan_dgv[0, i].Value.ToString() == "CUTTING")
                {
                    mac_plan_no_lbl.Text = plan_dgv[2, i].Value.ToString();
                    mac_total_machine_lbl.Text = plan_dgv[1, i].Value.ToString();
                    mac_plan_div_lbl.Text = plan_dgv[3, i].Value.ToString();
                }
                if (plan_dgv[0, i].Value.ToString() == "MOLD")
                {
                    mold_plan_no_lbl.Text = plan_dgv[2, i].Value.ToString();
                    mold_total_machine_lbl.Text = plan_dgv[1, i].Value.ToString();
                    mold_plan_div_lbl.Text = plan_dgv[3, i].Value.ToString();
                }
                if (plan_dgv[0, i].Value.ToString() == "ST")
                {
                    st_plan_no_lbl.Text = plan_dgv[2, i].Value.ToString();
                    st_total_machine_lbl.Text = plan_dgv[1, i].Value.ToString();
                    st_plan_div_lbl.Text = plan_dgv[3, i].Value.ToString();
                }
                if (plan_dgv[0, i].Value.ToString() == "TD")
                {
                    td_plan_no_lbl.Text = plan_dgv[2, i].Value.ToString();
                    td_total_machine_lbl.Text = plan_dgv[1, i].Value.ToString();
                    td_plan_div_lbl.Text = plan_dgv[3, i].Value.ToString();
                }
                if (plan_dgv[0, i].Value.ToString() == "SP")
                {
                    press_plan_no_lbl.Text = plan_dgv[2, i].Value.ToString();
                    press_total_machine_lbl.Text = plan_dgv[1, i].Value.ToString();
                    press_plan_div_lbl.Text = plan_dgv[3, i].Value.ToString();
                }
            }
            {//compare plan 
                main_mac_plan_no_lbl.Text = mac_plan_no_lbl.Text;
                main_mac_plan_div_lbl.Text = mac_plan_div_lbl.Text;
                main_mold_plan_no_lbl.Text = mold_plan_no_lbl.Text;
                main_mold_plan_div_lbl.Text = mold_plan_div_lbl.Text;
                main_st_plan_no_lbl.Text = st_plan_div_lbl.Text;
                main_st_plan_div_lbl.Text = st_plan_div_lbl.Text;
                main_td_plan_no_lbl.Text = td_plan_no_lbl.Text;
                main_td_plan_div_lbl.Text = td_plan_div_lbl.Text;
                main_press_plan_no_lbl.Text = press_plan_no_lbl.Text;
                main_press_plan_div_lbl.Text = press_plan_div_lbl.Text;

            }
        }
        private void callactuallbl()
        {
            //percent div actual
            mac_actual_div_lbl.Text = ((double.Parse(mac_actual_no_lbl.Text)) / (double.Parse(mac_total_machine_lbl.Text)) * 100).ToString();
            mold_actual_div_lbl.Text = ((double.Parse(mold_actual_no_lbl.Text)) / (double.Parse(mold_total_machine_lbl.Text)) * 100).ToString();
            st_actual_div_lbl.Text = ((double.Parse(st_actual_no_lbl.Text)) / (double.Parse(st_total_machine_lbl.Text)) * 100).ToString();
            td_actual_div_lbl.Text = ((double.Parse(td_actual_no_lbl.Text)) / (double.Parse(td_total_machine_lbl.Text)) * 100).ToString();
            press_actual_div_lbl.Text = ((double.Parse(press_actual_no_lbl.Text)) / (double.Parse(press_total_machine_lbl.Text)) * 100).ToString();

            //compare actual
            main_mac_actual_no_lbl.Text = mac_actual_no_lbl.Text;
            main_mac_actual_div_lbl.Text = mac_actual_div_lbl.Text;
            main_mold_actual_no_lbl.Text = mold_actual_no_lbl.Text;
            main_mold_actual_div_lbl.Text = mold_actual_div_lbl.Text;
            main_st_actual_no_lbl.Text = st_actual_no_lbl.Text;
            main_st_actual_div_lbl.Text = st_actual_div_lbl.Text;
            main_td_actual_no_lbl.Text = td_actual_no_lbl.Text;
            main_td_actual_div_lbl.Text = td_actual_div_lbl.Text;
            main_press_actual_no_lbl.Text = press_actual_no_lbl.Text;
            main_press_actual_div_lbl.Text = press_actual_div_lbl.Text;

        }
        public void changecolor(ref DataGridViewCommon dgv, Button btn, int i)
        {
            btn.BackColor = Color.Silver;
            if (dgv[1, i].Value.ToString() == "0")
            {
                btn.BackColor = Color.LimeGreen;
            }
            else if (dgv[1, i].Value.ToString() == "1")
            {
                btn.BackColor = Color.Yellow;
            }
            else if (dgv[1, i].Value.ToString() == "3")
            {
                btn.BackColor = Color.Red;
            }
            else if (dgv[1, i].Value.ToString() == "4")
            {
                btn.BackColor = Color.Silver;
            }
        }
        public void callmachineST()
        {
            st_machine_dgv.AutoGenerateColumns = false;
            SeachMachineWorkingStatusVo callSTmachine = new SeachMachineWorkingStatusVo();
            ValueObjectList<SeachMachineWorkingStatusVo> listvo = (ValueObjectList<SeachMachineWorkingStatusVo>)DefaultCbmInvoker.Invoke(new SearchSTWorkingStatusCbm(), callSTmachine);
            st_machine_dgv.DataSource = listvo.GetList();
            for (int i = 0; i < st_machine_dgv.Rows.Count; i++)
            {
                if (st_machine_dgv[0, i].Value.ToString() == "ANODIZING")
                { changecolor(ref st_machine_dgv, st_mc_anodizing_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "PLATING")
                { changecolor(ref st_machine_dgv, st_mc_plating_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "ORGANIC_COATING")
                { changecolor(ref st_machine_dgv, st_mc_organic_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "RTR_PLATING")
                { changecolor(ref st_machine_dgv, st_mc_rtr_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "PAINTING")
                { changecolor(ref st_machine_dgv, st_mc_painting_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "PRINT01")
                { changecolor(ref st_machine_dgv, st_mc_print01_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "PRINT02")
                { changecolor(ref st_machine_dgv, st_mc_print02_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "PRINT03")
                { changecolor(ref st_machine_dgv, st_mc_print03_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "PRINT04")
                { changecolor(ref st_machine_dgv, st_mc_print04_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "PRINT05")
                { changecolor(ref st_machine_dgv, st_mc_print05_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "PRINT06")
                { changecolor(ref st_machine_dgv, st_mc_print06_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "LASER01")
                { changecolor(ref st_machine_dgv, st_mc_laser01_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "LASER02")
                { changecolor(ref st_machine_dgv, st_mc_laser02_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "LASER03")
                { changecolor(ref st_machine_dgv, st_mc_laser03_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "LASER04")
                { changecolor(ref st_machine_dgv, st_mc_laser04_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "LASER05")
                { changecolor(ref st_machine_dgv, st_mc_laser05_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "LASER06")
                { changecolor(ref st_machine_dgv, st_mc_laser06_btn, i); }
                if (st_machine_dgv[0, i].Value.ToString() == "LASER07")
                { changecolor(ref st_machine_dgv, st_mc_laser07_btn, i); }
            }
        }
        public void callmachineTD()
        {
            td_machine_dgv.AutoGenerateColumns = false;
            SeachMachineWorkingStatusVo callTDmachine = new SeachMachineWorkingStatusVo();
            ValueObjectList<SeachMachineWorkingStatusVo> listvo = (ValueObjectList<SeachMachineWorkingStatusVo>)DefaultCbmInvoker.Invoke(new SearchTDWorkingStatusCbm(), callTDmachine);
            td_machine_dgv.DataSource = listvo.GetList();
            for (int i = 0; i < td_machine_dgv.Rows.Count; i++)
            {
                if (td_machine_dgv[0, i].Value.ToString() == "W01")
                { changecolor(ref td_machine_dgv, td_mc_w04_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "W02")
                { changecolor(ref td_machine_dgv, td_mc_w02_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "W03")
                { changecolor(ref td_machine_dgv, td_mc_w03_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "W04")
                { changecolor(ref td_machine_dgv, td_mc_w01_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "W05")
                { changecolor(ref td_machine_dgv, td_mc_w05_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "W06")
                { changecolor(ref td_machine_dgv, td_mc_w06_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "W07")
                { changecolor(ref td_machine_dgv, td_mc_w07_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "W08")
                { changecolor(ref td_machine_dgv, td_mc_w08_btn, i); }

                if (td_machine_dgv[0, i].Value.ToString() == "E01")
                { changecolor(ref td_machine_dgv, td_mc_e01_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "E02")
                { changecolor(ref td_machine_dgv, td_mc_e02_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "E03")
                { changecolor(ref td_machine_dgv, td_mc_e03_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "E04")
                { changecolor(ref td_machine_dgv, td_mc_e04_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "E05")
                { changecolor(ref td_machine_dgv, td_mc_e05_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "E06")
                { changecolor(ref td_machine_dgv, td_mc_e06_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "E07")
                { changecolor(ref td_machine_dgv, td_mc_e07_btn, i); }

                if (td_machine_dgv[0, i].Value.ToString() == "M01")
                { changecolor(ref td_machine_dgv, td_mc_m01_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "M02")
                { changecolor(ref td_machine_dgv, td_mc_m02_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "M03")
                { changecolor(ref td_machine_dgv, td_mc_m03_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "M04")
                { changecolor(ref td_machine_dgv, td_mc_m04_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "M05")
                { changecolor(ref td_machine_dgv, td_mc_m05_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "M06")
                { changecolor(ref td_machine_dgv, td_mc_m06_btn, i); }

                if (td_machine_dgv[0, i].Value.ToString() == "G01")
                { changecolor(ref td_machine_dgv, td_mc_g01_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "G02")
                { changecolor(ref td_machine_dgv, td_mc_g02_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "G03")
                { changecolor(ref td_machine_dgv, td_mc_g03_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "G04")
                { changecolor(ref td_machine_dgv, td_mc_g04_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "G05")
                { changecolor(ref td_machine_dgv, td_mc_g05_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "G06")
                { changecolor(ref td_machine_dgv, td_mc_g06_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "G07")
                { changecolor(ref td_machine_dgv, td_mc_g07_btn, i); }

                if (td_machine_dgv[0, i].Value.ToString() == "P01")
                { changecolor(ref td_machine_dgv, td_mc_p01_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "P02")
                { changecolor(ref td_machine_dgv, td_mc_p02_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "P03")
                { changecolor(ref td_machine_dgv, td_mc_p03_btn, i); }
                if (td_machine_dgv[0, i].Value.ToString() == "P04")
                { changecolor(ref td_machine_dgv, td_mc_p04_btn, i); }
            }
        }
        public void callmachineMAC()
        {
            mac_machine_dgv.AutoGenerateColumns = false;
            SeachMachineWorkingStatusVo callMACmachine = new SeachMachineWorkingStatusVo();
            ValueObjectList<SeachMachineWorkingStatusVo> listvo = (ValueObjectList<SeachMachineWorkingStatusVo>)DefaultCbmInvoker.Invoke(new SearchMACWorkingStatusCbm(), callMACmachine);
            mac_machine_dgv.DataSource = listvo.GetList();
            for (int i = 0; i < mac_machine_dgv.Rows.Count; i++)
            {
                if (mac_machine_dgv[0, i].Value.ToString() == "NC01")
                { changecolor(ref mac_machine_dgv, mac_mc_nc01_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC02")
                { changecolor(ref mac_machine_dgv, mac_mc_nc02_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC03")
                { changecolor(ref mac_machine_dgv, mac_mc_nc03_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC04")
                { changecolor(ref mac_machine_dgv, mac_mc_nc04_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC05")
                { changecolor(ref mac_machine_dgv, mac_mc_nc05_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC06")
                { changecolor(ref mac_machine_dgv, mac_mc_nc06_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC07")
                { changecolor(ref mac_machine_dgv, mac_mc_nc07_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC08")
                { changecolor(ref mac_machine_dgv, mac_mc_nc08_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC09")
                { changecolor(ref mac_machine_dgv, mac_mc_nc09_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC10")
                { changecolor(ref mac_machine_dgv, mac_mc_nc10_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC11")
                { changecolor(ref mac_machine_dgv, mac_mc_nc11_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC12")
                { changecolor(ref mac_machine_dgv, mac_mc_nc12_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC13")
                { changecolor(ref mac_machine_dgv, mac_mc_nc13_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC14")
                { changecolor(ref mac_machine_dgv, mac_mc_nc14_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC15")
                { changecolor(ref mac_machine_dgv, mac_mc_nc15_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC16")
                { changecolor(ref mac_machine_dgv, mac_mc_nc16_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC17")
                { changecolor(ref mac_machine_dgv, mac_mc_nc17_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC18")
                { changecolor(ref mac_machine_dgv, mac_mc_nc18_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC19")
                { changecolor(ref mac_machine_dgv, mac_mc_nc19_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC20")
                { changecolor(ref mac_machine_dgv, mac_mc_nc20_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC21")
                { changecolor(ref mac_machine_dgv, mac_mc_nc21_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC22")
                { changecolor(ref mac_machine_dgv, mac_mc_nc22_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC23")
                { changecolor(ref mac_machine_dgv, mac_mc_nc23_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC24")
                { changecolor(ref mac_machine_dgv, mac_mc_nc24_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC25")
                { changecolor(ref mac_machine_dgv, mac_mc_nc25_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC26")
                { changecolor(ref mac_machine_dgv, mac_mc_nc26_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC27")
                { changecolor(ref mac_machine_dgv, mac_mc_nc27_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC28")
                { changecolor(ref mac_machine_dgv, mac_mc_nc28_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC29")
                { changecolor(ref mac_machine_dgv, mac_mc_nc29_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC30")
                { changecolor(ref mac_machine_dgv, mac_mc_nc30_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC31")
                { changecolor(ref mac_machine_dgv, mac_mc_nc31_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC32")
                { changecolor(ref mac_machine_dgv, mac_mc_nc32_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC33")
                { changecolor(ref mac_machine_dgv, mac_mc_nc33_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC34")
                { changecolor(ref mac_machine_dgv, mac_mc_nc34_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC35")
                { changecolor(ref mac_machine_dgv, mac_mc_nc35_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC36")
                { changecolor(ref mac_machine_dgv, mac_mc_nc36_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC37")
                { changecolor(ref mac_machine_dgv, mac_mc_nc37_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC38")
                { changecolor(ref mac_machine_dgv, mac_mc_nc38_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC39")
                { changecolor(ref mac_machine_dgv, mac_mc_nc39_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC40")
                { changecolor(ref mac_machine_dgv, mac_mc_nc40_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC41")
                { changecolor(ref mac_machine_dgv, mac_mc_nc41_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC42")
                { changecolor(ref mac_machine_dgv, mac_mc_nc42_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC43")
                { changecolor(ref mac_machine_dgv, mac_mc_nc43_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC44")
                { changecolor(ref mac_machine_dgv, mac_mc_nc44_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC45")
                { changecolor(ref mac_machine_dgv, mac_mc_nc45_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC46")
                { changecolor(ref mac_machine_dgv, mac_mc_nc46_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC47")
                { changecolor(ref mac_machine_dgv, mac_mc_nc47_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC48")
                { changecolor(ref mac_machine_dgv, mac_mc_nc48_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC49")
                { changecolor(ref mac_machine_dgv, mac_mc_nc49_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC50")
                { changecolor(ref mac_machine_dgv, mac_mc_nc50_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "NC51")
                { changecolor(ref mac_machine_dgv, mac_mc_nc51_btn, i); }

                if (mac_machine_dgv[0, i].Value.ToString() == "MC01")
                { changecolor(ref mac_machine_dgv, mac_mc_mc01_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC02")
                { changecolor(ref mac_machine_dgv, mac_mc_mc02_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC03")
                { changecolor(ref mac_machine_dgv, mac_mc_mc03_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC04")
                { changecolor(ref mac_machine_dgv, mac_mc_mc04_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC05")
                { changecolor(ref mac_machine_dgv, mac_mc_mc05_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC06")
                { changecolor(ref mac_machine_dgv, mac_mc_mc06_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC07")
                { changecolor(ref mac_machine_dgv, mac_mc_mc07_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC08")
                { changecolor(ref mac_machine_dgv, mac_mc_mc08_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC12")
                { changecolor(ref mac_machine_dgv, mac_mc_mc12_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC13")
                { changecolor(ref mac_machine_dgv, mac_mc_mc13_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC14")
                { changecolor(ref mac_machine_dgv, mac_mc_mc14_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC15")
                { changecolor(ref mac_machine_dgv, mac_mc_mc15_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC16")
                { changecolor(ref mac_machine_dgv, mac_mc_mc16_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC17")
                { changecolor(ref mac_machine_dgv, mac_mc_mc17_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "MC18")
                { changecolor(ref mac_machine_dgv, mac_mc_mc18_btn, i); }
                if (mac_machine_dgv[0, i].Value.ToString() == "R/L01")
                { changecolor(ref mac_machine_dgv, mac_mc_rl01_btn, i); }
            }
        }
        public void callmachineSP()
        {
            sp_machine_dgv.AutoGenerateColumns = false;
            SeachMachineWorkingStatusVo callSPmachine = new SeachMachineWorkingStatusVo();
            ValueObjectList<SeachMachineWorkingStatusVo> listvo = (ValueObjectList<SeachMachineWorkingStatusVo>)DefaultCbmInvoker.Invoke(new SearchSPWorkingStatusCbm(), callSPmachine);
            sp_machine_dgv.DataSource = listvo.GetList();
            for (int i = 0; i < sp_machine_dgv.Rows.Count; i++)
            {
                if (sp_machine_dgv[0, i].Value.ToString() == "MC01")
                { changecolor(ref sp_machine_dgv, press_mc_mc01_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC02")
                { changecolor(ref sp_machine_dgv, press_mc_mc02_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC03")
                { changecolor(ref sp_machine_dgv, press_mc_mc03_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC04")
                { changecolor(ref sp_machine_dgv, press_mc_mc04_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC05")
                { changecolor(ref sp_machine_dgv, press_mc_mc05_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC06")
                { changecolor(ref sp_machine_dgv, press_mc_mc06_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC07")
                { changecolor(ref sp_machine_dgv, press_mc_mc07_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC08")
                { changecolor(ref sp_machine_dgv, press_mc_mc08_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC09")
                { changecolor(ref sp_machine_dgv, press_mc_mc09_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC10")
                { changecolor(ref sp_machine_dgv, press_mc_mc10_btn, i); }

                if (sp_machine_dgv[0, i].Value.ToString() == "MC11")
                { changecolor(ref sp_machine_dgv, press_mc_mc11_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC12")
                { changecolor(ref sp_machine_dgv, press_mc_mc12_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC13")
                { changecolor(ref sp_machine_dgv, press_mc_mc13_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC14")
                { changecolor(ref sp_machine_dgv, press_mc_mc14_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC15")
                { changecolor(ref sp_machine_dgv, press_mc_mc15_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC16")
                { changecolor(ref sp_machine_dgv, press_mc_mc16_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC17")
                { changecolor(ref sp_machine_dgv, press_mc_mc17_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC18")
                { changecolor(ref sp_machine_dgv, press_mc_mc18_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC19")
                { changecolor(ref sp_machine_dgv, press_mc_mc19_btn, i); }
                //if (sp_machine_dgv[0, i].Value.ToString() == "MC20")
                //{ changecolor(ref sp_machine_dgv, press_mc_mc20_btn, i); }

                //if (sp_machine_dgv[0, i].Value.ToString() == "MC21")
                //{ changecolor(ref sp_machine_dgv, press_mc_mc21_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC22")
                { changecolor(ref sp_machine_dgv, press_mc_mc22_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC23")
                { changecolor(ref sp_machine_dgv, press_mc_mc23_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC24")
                { changecolor(ref sp_machine_dgv, press_mc_mc24_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC25")
                { changecolor(ref sp_machine_dgv, press_mc_mc25_btn, i); }
                //if (sp_machine_dgv[0, i].Value.ToString() == "MC26")
                //{ changecolor(ref sp_machine_dgv, press_mc_mc26_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC27")
                { changecolor(ref sp_machine_dgv, press_mc_mc27_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC28")
                { changecolor(ref sp_machine_dgv, press_mc_mc28_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "MC29")
                { changecolor(ref sp_machine_dgv, press_mc_mc29_btn, i); }
                //if (sp_machine_dgv[0, i].Value.ToString() == "MC30")
                //{ changecolor(ref sp_machine_dgv, press_mc_mc30_btn, i); }

                if (sp_machine_dgv[0, i].Value.ToString() == "MC31")
                { changecolor(ref sp_machine_dgv, press_mc_mc31_btn, i); }
                //if (sp_machine_dgv[0, i].Value.ToString() == "mc32")
                //{ changecolor(ref sp_machine_dgv, press_mc_mc32_btn, i); }
                //if (sp_machine_dgv[0, i].Value.ToString() == "MC33")
                //{ changecolor(ref sp_machine_dgv, press_mc_mc33_btn, i); }
                //if (sp_machine_dgv[0, i].Value.ToString() == "MC34")
                //{ changecolor(ref sp_machine_dgv, press_mc_mc34_btn, i); }
                //if (sp_machine_dgv[0, i].Value.ToString() == "MC35")
                //{ changecolor(ref sp_machine_dgv, press_mc_mc35_btn, i); }
                //if (sp_machine_dgv[0, i].Value.ToString() == "MC36")
                //{ changecolor(ref sp_machine_dgv, press_mc_mc36_btn, i); }

                if (sp_machine_dgv[0, i].Value.ToString() == "TR01")
                { changecolor(ref sp_machine_dgv, press_mc_tr01_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "TR02")
                { changecolor(ref sp_machine_dgv, press_mc_tr02_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "TR03")
                { changecolor(ref sp_machine_dgv, press_mc_tr03_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "TR04")
                { changecolor(ref sp_machine_dgv, press_mc_tr04_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "TR05")
                { changecolor(ref sp_machine_dgv, press_mc_tr05_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "TR06")
                { changecolor(ref sp_machine_dgv, press_mc_tr06_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "TR07")
                { changecolor(ref sp_machine_dgv, press_mc_tr07_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "TR08")
                { changecolor(ref sp_machine_dgv, press_mc_tr08_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "TR09")
                { changecolor(ref sp_machine_dgv, press_mc_tr09_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "TR10")
                { changecolor(ref sp_machine_dgv, press_mc_tr10_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "TR11")
                { changecolor(ref sp_machine_dgv, press_mc_tr11_btn, i); }
                if (sp_machine_dgv[0, i].Value.ToString() == "TR12")
                { changecolor(ref sp_machine_dgv, press_mc_tr12_btn, i); }
            }
        }
        public void callmachineMOLD()
        {
            mold_machine_dgv.AutoGenerateColumns = false;
            SeachMachineWorkingStatusVo callMOLDmachine = new SeachMachineWorkingStatusVo();
            ValueObjectList<SeachMachineWorkingStatusVo> listvo = (ValueObjectList<SeachMachineWorkingStatusVo>)DefaultCbmInvoker.Invoke(new SearchMOLDWorkingStatusCbm(), callMOLDmachine);
            mold_machine_dgv.DataSource = listvo.GetList();
            for (int i = 0; i < mold_machine_dgv.Rows.Count; i++)
            {
                if (mold_machine_dgv[0, i].Value.ToString() == "MC01")
                { changecolor(ref mold_machine_dgv, mold_mc_mc01_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC02")
                { changecolor(ref mold_machine_dgv, mold_mc_mc02_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC03")
                { changecolor(ref mold_machine_dgv, mold_mc_mc03_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC04")
                { changecolor(ref mold_machine_dgv, mold_mc_mc04_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC05")
                { changecolor(ref mold_machine_dgv, mold_mc_mc05_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC06")
                { changecolor(ref mold_machine_dgv, mold_mc_mc06_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC07")
                { changecolor(ref mold_machine_dgv, mold_mc_mc07_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC08")
                { changecolor(ref mold_machine_dgv, mold_mc_mc08_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC09")
                { changecolor(ref mold_machine_dgv, mold_mc_mc09_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC10")
                { changecolor(ref mold_machine_dgv, mold_mc_mc10_btn, i); }

                if (mold_machine_dgv[0, i].Value.ToString() == "MC11")
                { changecolor(ref mold_machine_dgv, mold_mc_mc11_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC12")
                { changecolor(ref mold_machine_dgv, mold_mc_mc12_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC13")
                { changecolor(ref mold_machine_dgv, mold_mc_mc13_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC14")
                { changecolor(ref mold_machine_dgv, mold_mc_mc14_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC15")
                { changecolor(ref mold_machine_dgv, mold_mc_mc15_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC16")
                { changecolor(ref mold_machine_dgv, mold_mc_mc16_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC17")
                { changecolor(ref mold_machine_dgv, mold_mc_mc17_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC18")
                { changecolor(ref mold_machine_dgv, mold_mc_mc18_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC19")
                { changecolor(ref mold_machine_dgv, mold_mc_mc19_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC20")
                { changecolor(ref mold_machine_dgv, mold_mc_mc20_btn, i); }

                if (mold_machine_dgv[0, i].Value.ToString() == "MC21")
                { changecolor(ref mold_machine_dgv, mold_mc_mc21_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC22")
                { changecolor(ref mold_machine_dgv, mold_mc_mc22_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC23")
                { changecolor(ref mold_machine_dgv, mold_mc_mc23_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC24")
                { changecolor(ref mold_machine_dgv, mold_mc_mc24_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC25")
                { changecolor(ref mold_machine_dgv, mold_mc_mc25_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC26")
                { changecolor(ref mold_machine_dgv, mold_mc_mc26_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC27")
                { changecolor(ref mold_machine_dgv, mold_mc_mc27_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC28")
                { changecolor(ref mold_machine_dgv, mold_mc_mc28_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC29")
                { changecolor(ref mold_machine_dgv, mold_mc_mc29_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC30")
                { changecolor(ref mold_machine_dgv, mold_mc_mc30_btn, i); }

                if (mold_machine_dgv[0, i].Value.ToString() == "MC31")
                { changecolor(ref mold_machine_dgv, mold_mc_mc31_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC32")
                { changecolor(ref mold_machine_dgv, mold_mc_mc32_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC33")
                { changecolor(ref mold_machine_dgv, mold_mc_mc33_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC34")
                { changecolor(ref mold_machine_dgv, mold_mc_mc34_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC35")
                { changecolor(ref mold_machine_dgv, mold_mc_mc35_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC36")
                { changecolor(ref mold_machine_dgv, mold_mc_mc36_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC37")
                { changecolor(ref mold_machine_dgv, mold_mc_mc37_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC38")
                { changecolor(ref mold_machine_dgv, mold_mc_mc38_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC39")
                { changecolor(ref mold_machine_dgv, mold_mc_mc39_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC40")
                { changecolor(ref mold_machine_dgv, mold_mc_mc40_btn, i); }

                if (mold_machine_dgv[0, i].Value.ToString() == "MC41")
                { changecolor(ref mold_machine_dgv, mold_mc_mc41_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC42")
                { changecolor(ref mold_machine_dgv, mold_mc_mc42_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC43")
                { changecolor(ref mold_machine_dgv, mold_mc_mc43_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC44")
                { changecolor(ref mold_machine_dgv, mold_mc_mc44_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC45")
                { changecolor(ref mold_machine_dgv, mold_mc_mc45_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC46")
                { changecolor(ref mold_machine_dgv, mold_mc_mc46_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC47")
                { changecolor(ref mold_machine_dgv, mold_mc_mc47_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC48")
                { changecolor(ref mold_machine_dgv, mold_mc_mc48_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC49")
                { changecolor(ref mold_machine_dgv, mold_mc_mc49_btn, i); }
                if (mold_machine_dgv[0, i].Value.ToString() == "MC50")
                { changecolor(ref mold_machine_dgv, mold_mc_mc50_btn, i); }
            }
        }
        public int count = 0;
        public int count_red = 0;
        public int count_yellow = 0;
        public int count_silver = 0;
        private void callactual(ref DataGridViewCommon dgv)
        {
            count = 0;
            count_red = 0;
            count_yellow = 0;
            count_silver = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv[1, i].Value.ToString() == "0")
                {
                    count = count + 1;
                }
                if (dgv[1, i].Value.ToString() == "1")
                {
                    count_yellow = count_yellow + 1;
                }
                if (dgv[1, i].Value.ToString() == "3")
                {
                    count_red = count_red + 1;
                }
                if (dgv[1, i].Value.ToString() == "4")
                {
                    count_silver = count_silver + 1;
                }
            }

        }
        public void callchartmain()
        {
            Ch_main.Series[0].Points.Clear();
            Ch_main.Series[1].Points.Clear();
            Ch_main.Series[2].Points.Clear();

            Ch_main.Series[2].Points.AddXY("Mold Section", int.Parse(mold_total_machine_lbl.Text));
            Ch_main.Series[1].Points.AddXY("Mold Section", int.Parse(mold_plan_no_lbl.Text));
            Ch_main.Series[0].Points.AddXY("Mold Section", int.Parse(mold_actual_no_lbl.Text));

            Ch_main.Series[2].Points.AddXY("SP Section", int.Parse(press_total_machine_lbl.Text));
            Ch_main.Series[1].Points.AddXY("SP Section", int.Parse(press_plan_no_lbl.Text));
            Ch_main.Series[0].Points.AddXY("SP Section", int.Parse(press_actual_no_lbl.Text));

            Ch_main.Series[2].Points.AddXY("Cutting Section", int.Parse(mac_total_machine_lbl.Text));
            Ch_main.Series[1].Points.AddXY("Cutting Section", int.Parse(mac_plan_no_lbl.Text));
            Ch_main.Series[0].Points.AddXY("Cutting Section", int.Parse(mac_actual_no_lbl.Text));

            Ch_main.Series[2].Points.AddXY("ST Section", int.Parse(st_total_machine_lbl.Text));
            Ch_main.Series[1].Points.AddXY("ST Section", int.Parse(st_plan_no_lbl.Text));
            Ch_main.Series[0].Points.AddXY("ST Section", int.Parse(st_actual_no_lbl.Text));

            Ch_main.Series[2].Points.AddXY("TD Section", int.Parse(td_total_machine_lbl.Text));
            Ch_main.Series[1].Points.AddXY("TD Section", int.Parse(td_plan_no_lbl.Text));
            Ch_main.Series[0].Points.AddXY("TD Section", int.Parse(td_actual_no_lbl.Text));
        }
        private void manual_btn_Click(object sender, EventArgs e)
        {
            callplan();

          //  if (STSection_gpb.Visible == true)
            {
                callmachineST();
                callactual(ref st_machine_dgv);
                st_actual_no_lbl.Text = count.ToString();
                main_st_green_lbl.Text = count.ToString();
                main_st_yellow_lbl.Text = count_yellow.ToString();
                main_st_red_lbl.Text = count_red.ToString();
                main_st_silver_lbl.Text = count_silver.ToString();

            }
          //  else if (TDSection_gpb.Visible == true)
            {
                callmachineTD();
                callactual(ref td_machine_dgv);
                td_actual_no_lbl.Text = count.ToString();
                main_td_green_lbl.Text = count.ToString();
                main_td_yellow_lbl.Text = count_yellow.ToString();
                main_td_red_lbl.Text = count_red.ToString();
                main_td_silver_lbl.Text = count_silver.ToString();

            }
          //  else if (MACSection_gpb.Visible == true)
            {
                callmachineMAC();
                callactual(ref mac_machine_dgv);
                mac_actual_no_lbl.Text = count.ToString();
                main_mac_green_lbl.Text = count.ToString();
                main_mac_yellow_lbl.Text = count_yellow.ToString();
                main_mac_red_lbl.Text = count_red.ToString();
                main_mac_silver_lbl.Text = count_silver.ToString();
            }
         //   else if (PressSection_gpb.Visible == true)
            {
                callmachineSP();
                callactual(ref sp_machine_dgv);
                press_actual_no_lbl.Text = count.ToString();
                main_press_green_lbl.Text = count.ToString();
                main_press_yellow_lbl.Text = count_yellow.ToString();
                main_press_red_lbl.Text = count_red.ToString();
                main_press_silver_lbl.Text = count_silver.ToString();
            }
         //   else if (MoldSection_gpb.Visible == true)
            {
                callmachineMOLD();
                callactual(ref mold_machine_dgv);
                mold_actual_no_lbl.Text = count.ToString();
                main_mold_green_lbl.Text = count.ToString();
                main_mold_yellow_lbl.Text = count_yellow.ToString();
                main_mold_red_lbl.Text = count_red.ToString();
                main_mold_silver_lbl.Text = count_silver.ToString();
            }
         //   else if (MainSection_gpb.Visible == true)
            {
                callchartmain();

            }
            callactuallbl();
        }

      
    }
}
