using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchMainProByDateNCVCDao : AbstractDataAccessObject
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

            sql.Append(@"select tbl.dates,f.dates+f.times endday,f.model_cd,f.line_cd,ca_input_line, ca_input, ba_input, fc_input, output,

            (fc_endplay_small + fc_endplay_big + fc_shaft_scracth + fc_terminal_low +
  fc_case_scracth_dirty + fc_pinion_worm_ng + fc_shaft_lock + fc_ba_deform +
  fc_tape_hole_deform + fc_brush_rust + fc_metal_deform_scracth + fc_washer_tape_hole+ en2_insulation_resistance_ng + en2_cut_coil_wire + en2_no_load_current_hight + en2_ripple + en2_chattering + en2_lock + en2_open + en2_no_load_speed_low + en2_starting_voltage + en2_no_load_speed_high +  en2_rotor_mix + en2_surge_volt_max + en2_wrong_post_of_pole + en2_err + en2_noise + en1_insulation_resistace_ng + en1_cut_coil_wire + en1_lock +
en1_wareform_ma_abnormal + en1_shaft_bent + en1_ripple + en1_short + en1_chattering + en1_no_load_current_high + en1_vibration_ng + en1_open + en1_rotor_mix + ca_app_metal_dirty + ca_app_tape_hole_deform + ca_app_metal_high + ca_app_case_deform_scracth + ca_app_metal_deform_scratch + ca_app_magnet_broken+ ca_mg_metal_deform_scratch + ca_mg_case_deform_scratch+ca_bonding_metal_deform_scratch +
ca_bonding_case_deform_scracth + ba_tc_endplay_big + ba_tc_endplay_small + ba_tc_brush_bent + ba_tc_shaft_mix + ba_rto_ng + ba_rto_mix+ ba_app_metal_deform_scracth + ba_app_ba_deform + ba_app_endplate_deform_scracth + ba_app_error_other + ba_bm_brush_deform_scracth + ba_bm_metal_deform_scracth + ba_bm_ba_deform + ba_bm_endplay_deform_scracth) total_ng,

(fc_endplay_small + fc_endplay_big + fc_shaft_scracth + fc_terminal_low +
  fc_case_scracth_dirty + fc_pinion_worm_ng + fc_shaft_lock + fc_ba_deform +
  fc_tape_hole_deform + fc_brush_rust + fc_metal_deform_scracth + fc_washer_tape_hole) final_app,(en2_insulation_resistance_ng + en2_cut_coil_wire + en2_no_load_current_hight + en2_ripple + en2_chattering + en2_lock + en2_open + en2_no_load_speed_low + en2_starting_voltage + en2_no_load_speed_high +
  en2_rotor_mix + en2_surge_volt_max + en2_wrong_post_of_pole + en2_err + en2_noise) en2, (en1_insulation_resistace_ng + en1_cut_coil_wire + en1_lock +
en1_wareform_ma_abnormal + en1_shaft_bent + en1_ripple + en1_short + en1_chattering + en1_no_load_current_high + en1_vibration_ng + en1_open + en1_rotor_mix) en1, (ca_app_metal_dirty + ca_app_tape_hole_deform + ca_app_metal_high + ca_app_case_deform_scracth + ca_app_metal_deform_scratch + ca_app_magnet_broken) as case_assy,(ca_mg_metal_deform_scratch + ca_mg_case_deform_scratch) as case_mg,(ca_bonding_metal_deform_scratch +
ca_bonding_case_deform_scracth) case_bonding, (ba_tc_endplay_big + ba_tc_endplay_small + ba_tc_brush_bent + ba_tc_shaft_mix) as trust_gap, (ba_rto_ng + ba_rto_mix) as rotor, (ba_app_metal_deform_scracth + ba_app_ba_deform + ba_app_endplate_deform_scracth + ba_app_error_other) as bracket_assy, (ba_bm_brush_deform_scracth + ba_bm_metal_deform_scracth + ba_bm_ba_deform + ba_bm_endplay_deform_scracth) as bracket_metal from t_ncvc_pdc_fc f left join t_ncvc_pdc_en2 e2 on f.fc_id = e2.en2_id
  left join t_ncvc_pdc_en1 e1 on f.fc_id = e1.en1_id 
    left join t_ncvc_pdc_ca ca on f.fc_id = ca.ca_id
    left join t_ncvc_pdc_ba ba on f.fc_id = ba.ba_id                                                                          
    left join (
select t1.dates,case when ca3 is null then ca1 else ca3 end id from
(select dates, line_cd, max(fc_id)ca1 from t_ncvc_pdc_fc  where times > '06:00:00' and times <= '23:59:00' group by dates, line_cd) t1 left join
(select dates - 1 dates, line_cd, max(fc_id) ca3 from t_ncvc_pdc_fc  where times > '00:00:00' and times <= '05:59:00' group by dates, line_cd) t3 on t1.dates = t3.dates where t1.line_cd = :line_cd and  t1.dates between :datesfrom and :datesto) tbl on f.fc_id = tbl.id where f.fc_id = tbl.id and f.line_cd = :line_cd ");

            sqlParameter.AddParameterString("line_cd", inVo.ProLine);
            sqlParameter.AddParameterDateTime("datesfrom", inVo.StartDay);
            sqlParameter.AddParameterDateTime("datesto", inVo.EndDay);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerNCVCVo outVo = new ProductionControllerNCVCVo
                {

                    StartDay = DateTime.Parse(dataReader["dates"].ToString()),
                    EndDay = DateTime.Parse(dataReader["endday"].ToString()),
                    ProModel = dataReader["model_cd"].ToString(),
                    ProLine = dataReader["line_cd"].ToString(),
                    TotalNG = int.Parse(dataReader["total_ng"].ToString()),
                    ProInput = int.Parse(dataReader["ca_input_line"].ToString()),
                    ProInputCase = int.Parse(dataReader["ca_input"].ToString()),
                    ProInputBracket = int.Parse(dataReader["ba_input"].ToString()),
                    ProInputApp = int.Parse(dataReader["fc_input"].ToString()),
                    ProOutput = int.Parse(dataReader["output"].ToString()),

                    Final_App = int.Parse(dataReader["final_app"].ToString()),
                    En2NG = int.Parse(dataReader["en2"].ToString()),
                    En1NG = int.Parse(dataReader["en1"].ToString()),
                    TrustGap = int.Parse(dataReader["trust_gap"].ToString()),
                    Rotor = int.Parse(dataReader["rotor"].ToString()),
                    Braket = int.Parse(dataReader["bracket_assy"].ToString()),
                    Bracket_Metal = int.Parse(dataReader["bracket_metal"].ToString()),
                    Case_Assy = int.Parse(dataReader["case_assy"].ToString()),
                    Case_MG = int.Parse(dataReader["case_mg"].ToString()),
                    MG_Bongding = int.Parse(dataReader["case_bonding"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
