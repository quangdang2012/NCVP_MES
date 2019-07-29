using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchMainProByDateAllLineNCVCDao : AbstractDataAccessObject
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
            
            sql.Append(@"select model_cd,'All Line' line_cd, Case When times between '06:00:00' and '23:59:00' then dates when times between '00:00:00' and '05:59:00' then dates-1 end datesss, sum(ca_input_line) as ca_input_line,sum(ba_input) ba_input, sum(ca_input) as ca_input, sum(fc_input) as fc_input,sum(output) output,sum(final_app+en2+en1+case_assy+case_mg+case_bonding+trust_gap+rotor+bracket_assy+bracket_metal) as total_ng,sum(final_app) final_app, sum(en2) en2, sum(en1) en1,sum(case_assy) case_assy,sum(case_mg) case_mg, sum(case_bonding) case_bonding,sum(trust_gap) trust_gap,sum(rotor) rotor,sum(bracket_assy) bracket_assy,sum(bracket_metal) bracket_metal from 
        
            (Select fc.dates ,fc.times ,fc.fc_id ,fc.model_cd ,fc.line_cd,ca_input_line,ca_input,ba_input,fc_input, output, (fc_endplay_small + fc_endplay_big + fc_shaft_scracth + fc_terminal_low + fc_case_scracth_dirty + fc_pinion_worm_ng + fc_shaft_lock + fc_ba_deform + fc_tape_hole_deform + fc_brush_rust + fc_metal_deform_scracth + fc_washer_tape_hole) final_app,(en2_insulation_resistance_ng + en2_cut_coil_wire + en2_no_load_current_hight + en2_ripple + en2_chattering + en2_lock + en2_open + en2_no_load_speed_low + en2_starting_voltage + en2_no_load_speed_high + en2_rotor_mix + en2_surge_volt_max + en2_wrong_post_of_pole + en2_err + en2_noise) en2, (en1_insulation_resistace_ng + en1_cut_coil_wire + en1_lock + en1_wareform_ma_abnormal + en1_shaft_bent + en1_ripple + en1_short + en1_chattering + en1_no_load_current_high + en1_vibration_ng + en1_open + en1_rotor_mix) en1, (ca_app_metal_dirty + ca_app_tape_hole_deform + ca_app_metal_high + ca_app_case_deform_scracth + ca_app_metal_deform_scratch + ca_app_magnet_broken) as case_assy,(ca_mg_metal_deform_scratch + ca_mg_case_deform_scratch) as case_mg,(ca_bonding_metal_deform_scratch + ca_bonding_case_deform_scracth) case_bonding, (ba_tc_endplay_big + ba_tc_endplay_small + ba_tc_brush_bent + ba_tc_shaft_mix) as trust_gap, (ba_rto_ng + ba_rto_mix) as rotor, (ba_app_metal_deform_scracth + ba_app_ba_deform + ba_app_endplate_deform_scracth + ba_app_error_other) as bracket_assy, (ba_bm_brush_deform_scracth + ba_bm_metal_deform_scracth + ba_bm_ba_deform + ba_bm_endplay_deform_scracth) as bracket_metal 
            from t_ncvc_pdc_fc fc left join t_ncvc_pdc_en2 e2 on fc.line_cd = e2.line_cd and fc.fc_id = e2.en2_id left join t_ncvc_pdc_en1 e1 on fc.line_cd = e1.line_cd and fc.fc_id = e1.en1_id left join t_ncvc_pdc_ca ca on fc.line_cd = ca.line_cd and fc.fc_id = ca.ca_id left join 
            t_ncvc_pdc_ba ba on fc.line_cd = ba.line_cd and fc.fc_id = ba.ba_id left join 
            (select dates ,line_cd, Case when idca3 is null then idca1 else idca3 end id from (select tblca1.dates,tblca1.line_cd, idca1, idca3 from (select line_cd,o.dates , max(o.fc_id) idca1 from t_ncvc_pdc_fc o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :datesto group by o.dates, line_cd order by dates) tblca1 left join (select line_cd,(o.dates-1) dates , max(o.fc_id) idca3 from t_ncvc_pdc_fc o where o.times > '00:00:00' and o.times <= '05:55:00' and o.dates > :datefrom and o.dates - 1 <= :datesto group by line_cd,o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl order by dates,line_cd) l on l.line_cd = fc.line_cd where l.id = fc.fc_id order by fc.dates,fc.line_cd ) tbl where model_cd = :model_cd group by datesss,model_cd order by datesss");

            sqlParameter.AddParameterDateTime("datefrom", inVo.StartDay);
            sqlParameter.AddParameterDateTime("datesto", inVo.EndDay);

            sqlParameter.AddParameterString("line_cd", inVo.ProLine);
            sqlParameter.AddParameterString("model_cd", inVo.ProModel);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            //IDataAdapter d = sqlCommandAdapter.ExecuteScalar(sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerNCVCVo outVo = new ProductionControllerNCVCVo
                {

                    StartDay = DateTime.Parse(dataReader["datesss"].ToString()),
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
                    Case_Assy = int.Parse(dataReader["case_assy"].ToString()),
                    En1NG = int.Parse(dataReader["en1"].ToString()),
                    Case_MG = int.Parse(dataReader["case_mg"].ToString()),
                    MG_Bongding = int.Parse(dataReader["case_bonding"].ToString()),

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
