using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class ProductionControllerNCVCVo : ValueObject
    {
        public int ProId { get; set; }
        public string ProLine { get; set; }
        public string ProModel { get; set; }
        public string ProProcess { get; set; }
        public int ProInput { get; set; }
        public int ProOutput { get; set; }
        public int ProInputCase { get; set; }
        public int ProInputBracket { get; set; }
        public int ProInputApp { get; set; }

        //
        public DateTime TimeHour { get; set; }
        public string Date { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public DateTime Dates { get; set; }

        //main datagripview 

        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public int TotalNG { get; set; }
        public int Final_App { get; set; }
        public int En2NG { get; set; }
        public int En1NG { get; set; }
        public int TrustGap { get; set; }
        public int Rotor { get; set; }

        public int Braket { get; set; }
        public int Bracket_Metal { get; set; }
        public int Case_Assy { get; set; }
        public int Case_MG { get; set; }
        public int MG_Bongding { get; set; }
        //end main datagripview 

        //Final apperance
        public int FC_endplay_small { get; set; }
        public int FC_endplay_big { get; set; }
        public int FC_shaft_scracth { get; set; }
        public int FC_terminal_low { get; set; }
        public int FC_case_scracth_dirty { get; set; }
        public int FC_pinion_worm_ng { get; set; }
        public int FC_shaft_lock { get; set; }
        public int FC_deform { get; set; }
        public int FC_tape_hole_deform { get; set; }
        public int FC_brush_rust { get; set; }
        public int FC_metal_deform_scracth { get; set; }
        public int FC_washer_tape_hole { get; set; }
        public int FC_input { get; set; }
        //end Final apperance

        //en2
        public int En2_insulation_resistance_ng { get; set; }
        public int En2_cut_coil_wire { get; set; }
        public int En2_no_load_current_hight { get; set; }
        public int En2_ripple { get; set; }
        public int En2_chattering { get; set; }
        public int En2_lock { get; set; }
        public int En2_open { get; set; }
        public int En2_no_load_speed_low { get; set; }
        public int En2_starting_voltage { get; set; }
        public int En2_no_load_speed_high { get; set; }
        public int En2_rotor_mix { get; set; }
        public int En2_surge_volt_max { get; set; }
        public int En2_wrong_post_of_pole { get; set; }
        public int En2_err { get; set; }
        public int En2_noise { get; set; }
        //end en2

        //En1
        public int En1_insulation_resistace_ng { get; set; }
        public int En1_cut_coil_wire { get; set; }
        public int En1_lock { get; set; }
        public int En1_wareform_ma_abnormal { get; set; }
        public int En1_shaft_bent { get; set; }
        public int En1_ripple { get; set; }
        public int En1_short { get; set; }
        public int En1_chattering { get; set; }
        public int En1_no_load_current_high { get; set; }
        public int En1_vibration_ng { get; set; }
        public int En1_open { get; set; }
        public int En1_rotor_mix { get; set; }
        //end en1

        //case assy
        public int CA_input { get; set; }
        public int CA_app_metal_dirty { get; set; }
        public int CA_app_tape_hole_deform { get; set; }
        public int CA_app_metal_high { get; set; }
        public int CA_app_case_deform_scracth { get; set; }
        public int CA_app_metal_deform_scratch { get; set; }
        public int CA_app_magnet_broken { get; set; }
        //end case assy

        //case mg
        public int CA_mg_metal_deform_scratch { get; set; }
        public int CA_mg_case_deform_scratch { get; set; }
        //end case mg

        //mg bonding
        public int CA_bonding_metal_deform_scratch { get; set; }
        public int CA_bonding_case_deform_scracth { get; set; }
        //end mg bonding


        public int BA_input { get; set; }
        //trust gap
        public int BA_tc_endplay_big { get; set; }
        public int BA_tc_endplay_small { get; set; }
        public int BA_tc_brush_bent { get; set; }
        public int BA_tc_shaft_mix { get; set; }
        //end trust gap

        //rotor
        public int BA_rto_ng { get; set; }
        public int BA_rto_mix { get; set; }
        //end rotor

        //braket assy
        public int BA_app_metal_deform_scracth { get; set; }
        public int BA_app_deform { get; set; }
        public int BA_app_endplate_deform_scracth { get; set; }
        public int BA_app_error_other { get; set; }
        //end bracket assy

        //bracket metal
        public int BA_bm_brush_deform_scracth { get; set; }
        public int BA_bm_metal_deform_scracth { get; set; }
        public int BA_bm_deform { get; set; }
        public int BA_bm_endplay_deform_scracth { get; set; }
        //end bracket metal

        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }
        public List<ProductionControllerNCVCVo> productioncontrollervo = new List<ProductionControllerNCVCVo>();
    }
}