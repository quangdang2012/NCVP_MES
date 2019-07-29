using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class ProductionControllerVo : ValueObject
    {
        public int ProId { get; set; }
        public string ProLine { get; set; }
        public string ProModel { get; set; }
        public string ProProcess { get; set; }
        public int ProInput { get; set; }
        public int ProOutput { get; set; }

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
        public int HolderNG { get; set; }
        public int AppCheckNG { get; set; }
        public int En2NG { get; set; }
        public int FundouNG { get; set; }
        public int En1NG { get; set; }
        public int InsertCaseNG { get; set; }
        public int RANG { get; set; }


        public int SolderRingNG { get; set; }
        public int SolderWireNG { get; set; }
        public int WindingNG { get; set; }
        public int WeldingNG { get; set; }
        public int CoreNG { get; set; }
        //end main datagripview 

        //holder
        public int HolGapHolder { get; set; }
        //end holder

        //appcheck
        public int App_stamping_ba { get; set; }
        public int App_case_set { get; set; }
        public int App_tough_shaft { get; set; }
        public int App_case_glue_sticky { get; set; }
        public int App_up_low_shabby { get; set; }
        public int App_hole_shaft { get; set; }
        public int App_no_beat_prone_case { get; set; }
        public int App_hole_case { get; set; }
        public int App_prone_case { get; set; }
        public int App_lot_ng { get; set; }
        public int App_ter_deform { get; set; }
        public int App_hole_ter { get; set; }
        public int App_soder_hl { get; set; }
        public int App_metal_oven_low { get; set; }
        public int App_fundou_ng { get; set; }
        public int App_ter_glue_sticky { get; set; }
        public int App_lead_glue_sticky { get; set; }
        //end appcheck

        //en2
        public int En2_lock { get; set; }
        public int En2_cut { get; set; }
        public int En2_chattering { get; set; }
        public int En2_insulation { get; set; }
        public int En2_open { get; set; }
        public int En2_short { get; set; }
        public int En2_duty { get; set; }
        public int En2_no { get; set; }
        public int En2_var { get; set; }
        public int En2_reverse_spinning { get; set; }
        public int En2_starting_volt { get; set; }
        public int En2_io { get; set; }
        //end en2

        //fundou
        public int Fd_ng_beat_point { get; set; }
        public int Fd_fundou_deform { get; set; }
        //end fundou

        //En1
        public int En1_lock { get; set; }
        public int En1_cut { get; set; }
        public int En1_chattering { get; set; }
        public int En1_insulation { get; set; }
        public int En1_open { get; set; }
        public int En1_bad_wave { get; set; }
        public int En1_duty { get; set; }
        public int En1_short { get; set; }
        public int En1_beat_case_ng { get; set; }
        public int En1_beat_fundou_ng { get; set; }
        //end en1

        //IS
        public int Insc_no_ink_case_mc1 { get; set; }
        public int Insc_ba_deform_mc1 { get; set; }
        public int Insc_break_case_mc1 { get; set; }
        public int Insc_drop_mc1 { get; set; }
        public int Insc_break_wire_mc1 { get; set; }
        public int Insc_break_ring_mc1 { get; set; }
        //end IS

        //RA
        public int RA_com_pb_sticky { get; set; }
        public int RA_wire_pb_sticky { get; set; }
        public int RA_com_slip { get; set; }
        public int RA_renew_ring { get; set; }
        public int RA_break_wire_final_app { get; set; }
        public int RA_wire_combine_wrong { get; set; }
        public int RA_core_ng { get; set; }
        public int RA_segment_hole { get; set; }
        public int RA_glue_sticky { get; set; }
        public int RA_loose_wire_final_app { get; set; }
        public int RA_lead_not_covered { get; set; }
        public int RA_less_lead { get; set; }
        //end RA

        //solder wire
        public int Pbs_break_copper { get; set; }
        public int Pbs_climb_core { get; set; }
        public int Pbs_skip_edge { get; set; }
        public int Pbs_wire_combine_wrong { get; set; }
        public int Pbs_loose_wire { get; set; }
        public int Pbs_rizer_edge_ng { get; set; }
        public int Pbs_core_ng { get; set; }
        public int Pbs_com_slip { get; set; }
        public int Pbs_hole { get; set; }
        public int Pbs_2_sleeve { get; set; }
        public int Pbs_wire_pb_sticky { get; set; }
        public int Pbs_com_pb_sticky { get; set; }
        public int Pbs_no_lead { get; set; }
        //end solder wire

        //solder ring
        public int Rigs_wire_pb_sticky { get; set; }
        public int Rigs_com_pb_sticky { get; set; }
        public int Rigs_ring_prone { get; set; }
        public int Rigs_cracked_ring { get; set; }
        //end solder ring

        //wingding
        public int Wi_break_copper_mc { get; set; }
        public int Wi_ruffle_copper_mc { get; set; }
        public int Wi_edge_ng_mc { get; set; }
        public int Wi_no_sleeve_mc { get; set; }
        //end wingding

        //welding
        public int We_com_slip { get; set; }
        public int We_long_shaft { get; set; }
        public int We_short_shaft { get; set; }
        //end welding

        //core
        public int Co_beat_core_ng { get; set; }
        public int Co_com_wrap { get; set; }
        public int Co_core_ng { get; set; }
        public int Co_com_glue_sticky { get; set; }
        //end core


        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }
        public List<ProductionControllerVo> productioncontrollervo = new List<ProductionControllerVo>();
    }
}