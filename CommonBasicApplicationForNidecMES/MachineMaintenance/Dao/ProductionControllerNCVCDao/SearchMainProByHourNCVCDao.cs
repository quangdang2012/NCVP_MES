using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchMainProByHourNCVCDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProductionControllerNCVCVo inVo = (ProductionControllerNCVCVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProductionControllerNCVCVo> voList = new ValueObjectList<ProductionControllerNCVCVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            
            sql.Append(@"select tblin.datestimes, tblin.model_cd, tblin.line_cd, ( final_app + en2 + en1 + case_assy + case_bonding + case_mg + trust_gap + rotor + bracket_assy + bracket_metal) as sum_ng,ca_input_line,ca_input, ba_input, fc_input,output, final_app, en2, en1, case_assy, case_bonding, case_mg, trust_gap, rotor, bracket_assy, bracket_metal from 
(select(fc.dates + fc.times) datestimes, fc.model_cd, fc.line_cd, ca_input_line,ca_input, ba_input, fc_input, output, (fc_endplay_small + fc_endplay_big + fc_shaft_scracth + fc_terminal_low + fc_case_scracth_dirty + fc_pinion_worm_ng + fc_shaft_lock + fc_ba_deform + fc_tape_hole_deform + fc_brush_rust + fc_metal_deform_scracth + fc_washer_tape_hole) final_app, (en2_insulation_resistance_ng + en2_cut_coil_wire + en2_no_load_current_hight + en2_ripple + en2_chattering + en2_lock + en2_open + en2_no_load_speed_low + en2_starting_voltage + en2_no_load_speed_high + en2_rotor_mix + en2_surge_volt_max + en2_wrong_post_of_pole + en2_err + en2_noise) en2, (en1_insulation_resistace_ng + en1_cut_coil_wire + en1_lock + en1_wareform_ma_abnormal + en1_shaft_bent + en1_ripple + en1_short + en1_chattering + en1_no_load_current_high + en1_vibration_ng + en1_open + en1_rotor_mix) en1, (ca_app_metal_dirty + ca_app_tape_hole_deform + ca_app_metal_high + ca_app_case_deform_scracth + ca_app_metal_deform_scratch + ca_app_magnet_broken) as case_assy, (ca_mg_metal_deform_scratch + ca_mg_case_deform_scratch) as case_mg, (ca_bonding_metal_deform_scratch + ca_bonding_case_deform_scracth) case_bonding, (ba_tc_endplay_big + ba_tc_endplay_small + ba_tc_brush_bent + ba_tc_shaft_mix) as trust_gap, (ba_rto_ng + ba_rto_mix) as rotor, (ba_app_metal_deform_scracth + ba_app_ba_deform + ba_app_endplate_deform_scracth + ba_app_error_other) as bracket_assy, (ba_bm_brush_deform_scracth + ba_bm_metal_deform_scracth + ba_bm_ba_deform + ba_bm_endplay_deform_scracth) as bracket_metal
from t_ncvc_pdc_fc fc left join t_ncvc_pdc_en2 e2 on fc.fc_id = e2.en2_id and fc.line_cd = e2.line_cd and fc.dates = e2.dates
left join t_ncvc_pdc_en1 e1 on fc.fc_id = e1.en1_id and fc.line_cd = e1.line_cd
left join t_ncvc_pdc_ca ca on fc.fc_id = ca.ca_id and fc.line_cd = ca.line_cd
left join t_ncvc_pdc_ba ba on fc.fc_id = ba.ba_id and fc.line_cd = ba.line_cd
where fc.line_cd = :line_cd and fc.dates = :dates and(fc.times in(select min(times) from t_ncvc_pdc_fc where times between '06:00:00' and '06:55:00'  and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '06:00:00' and '07:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '07:00:00' and '08:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '08:00:00' and '09:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '09:00:00' and '10:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '10:00:00' and '11:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '11:00:00' and '12:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '12:00:00' and '13:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '13:00:00' and '14:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '14:00:00' and '15:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '15:00:00' and '16:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '16:00:00' and '17:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '17:00:00' and '18:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '18:00:00' and '19:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '19:00:00' and '20:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '20:00:00' and '21:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '21:00:00' and '22:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '22:00:00' and '23:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd)) or fc.dates - 1 = :dates and fc.line_cd = :line_cd and fc.line_cd = :line_cd and(fc.times in(select min(times) from t_ncvc_pdc_fc where times between '00:00:00' and '00:55:00' and dates - 1 = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '00:00:00' and '01:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '01:00:00' and '02:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '02:00:00' and '03:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '03:00:00' and '04:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '04:00:00' and '05:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) or fc.times in(select max(times) from t_ncvc_pdc_fc where times between '05:00:00' and '05:56:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd))) tblin");
            
            sqlParameter.AddParameterString("line_cd", inVo.ProLine);
            sqlParameter.AddParameterDateTime("dates", DateTime.Parse(inVo.Date));
            sqlParameter.AddParameterString("model_cd", inVo.ProModel);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerNCVCVo outVo = new ProductionControllerNCVCVo
                {
                    TimeHour = DateTime.Parse(dataReader["datestimes"].ToString()),
                    ProModel = dataReader["model_cd"].ToString(),
                    ProLine = dataReader["line_cd"].ToString(),
                    TotalNG = int.Parse(dataReader["sum_ng"].ToString()),
                    ProInput = int.Parse(dataReader["ca_input_line"].ToString()),
                    ProInputCase = int.Parse(dataReader["ca_input"].ToString()),
                    ProInputBracket = int.Parse(dataReader["ba_input"].ToString()),
                    ProInputApp = int.Parse(dataReader["fc_input"].ToString()),
                    ProOutput = int.Parse(dataReader["output"].ToString()),

                    Final_App = int.Parse(dataReader["final_app"].ToString()),
                    En2NG = int.Parse(dataReader["en2"].ToString()),
                    Case_Assy = int.Parse(dataReader["case_assy"].ToString()),
                    En1NG = int.Parse(dataReader["en1"].ToString()),
                    MG_Bongding = int.Parse(dataReader["case_bonding"].ToString()),
                    Case_MG = int.Parse(dataReader["case_mg"].ToString()),

                    TrustGap = int.Parse(dataReader["trust_gap"].ToString()),
                    Rotor = int.Parse(dataReader["rotor"].ToString()),
                    Braket = int.Parse(dataReader["bracket_assy"].ToString()),
                    Bracket_Metal = int.Parse(dataReader["bracket_metal"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
