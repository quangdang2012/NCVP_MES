using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailAllLineAllProcessNCVCDao : AbstractDataAccessObject
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

            //sql.Append("select tbloutput.datesss dates,'All Line' line_cd,* from ");
            sql.Append("select datesss,model, 'All Line' line, ");

            sql.Append("sum(fc_endplay_small) fc_endplay_small , sum(fc_endplay_big) fc_endplay_big, ");
            sql.Append("sum(fc_shaft_scracth) fc_shaft_scracth, sum(fc_terminal_low) fc_terminal_low, ");
            sql.Append("sum(fc_case_scracth_dirty) fc_case_scracth_dirty ,  sum(fc_pinion_worm_ng) fc_pinion_worm_ng,  ");
            sql.Append("sum(fc_shaft_lock) fc_shaft_lock, sum(fc_ba_deform) fc_ba_deform, ");
            sql.Append("sum(fc_tape_hole_deform) fc_tape_hole_deform, sum(fc_brush_rust) fc_brush_rust, ");
            sql.Append("sum(fc_metal_deform_scracth) fc_metal_deform_scracth, sum(fc_washer_tape_hole ) fc_washer_tape_hole, ");
            
            sql.Append("sum(en2_insulation_resistance_ng) en2_insulation_resistance_ng, ");
            sql.Append("sum(en2_cut_coil_wire) en2_cut_coil_wire ,");
            sql.Append("sum(en2_no_load_current_hight) en2_no_load_current_hight, ");
            sql.Append("sum(en2_ripple) en2_ripple, ");
            sql.Append("sum(en2_chattering) en2_chattering, ");
            sql.Append("sum(en2_lock) en2_lock, ");
            sql.Append("sum(en2_open) en2_open, ");
            sql.Append("sum(en2_no_load_speed_low) en2_no_load_speed_low, ");
            sql.Append("sum(en2_starting_voltage) en2_starting_voltage, ");
            sql.Append("sum(en2_no_load_speed_high) en2_no_load_speed_high, ");
            sql.Append("sum(en2_rotor_mix) en2_rotor_mix, ");
            sql.Append("sum(en2_surge_volt_max) en2_surge_volt_max, ");
            sql.Append("sum(en2_wrong_post_of_pole) en2_wrong_post_of_pole, ");
            sql.Append("sum(en2_err) en2_err, ");
            sql.Append("sum(en2_noise) en2_noise, ");

            sql.Append("sum(en1_insulation_resistace_ng) en1_insulation_resistace_ng, ");
            sql.Append("sum(en1_cut_coil_wire) en1_cut_coil_wire, ");
            sql.Append("sum(en1_lock) en1_lock, ");
            sql.Append("sum(en1_wareform_ma_abnormal) en1_wareform_ma_abnormal,");
            sql.Append("sum(en1_shaft_bent) en1_shaft_bent, ");
            sql.Append("sum(en1_ripple) en1_ripple, ");
            sql.Append("sum(en1_short) en1_short, ");
            sql.Append("sum(en1_chattering) en1_chattering, ");
            sql.Append("sum(en1_no_load_current_high) en1_no_load_current_high, ");
            sql.Append("sum(en1_vibration_ng) en1_vibration_ng,");
            sql.Append("sum(en1_open) en1_open, ");
            sql.Append("sum(en1_rotor_mix) en1_rotor_mix, ");

            sql.Append("sum(ba_tc_endplay_big) ba_tc_endplay_big, sum(ba_tc_endplay_small) ba_tc_endplay_small, ");
            sql.Append("sum(ba_tc_brush_bent) ba_tc_brush_bent ,");
            sql.Append("sum(ba_tc_shaft_mix) ba_tc_shaft_mix , ");

            sql.Append("sum(ba_rto_ng) ba_rto_ng, ");
            sql.Append("sum(ba_rto_mix) ba_rto_mix,");

            sql.Append("sum(ba_app_metal_deform_scracth) ba_app_metal_deform_scracth, ");
            sql.Append("sum(ba_app_ba_deform) ba_app_ba_deform, ");
            sql.Append("sum(ba_app_endplate_deform_scracth) ba_app_endplate_deform_scracth, ");
            sql.Append("sum(ba_app_error_other) ba_app_error_other, ");

            sql.Append("sum(ba_bm_brush_deform_scracth) ba_bm_brush_deform_scracth, ");
            sql.Append("sum(ba_bm_metal_deform_scracth) ba_bm_metal_deform_scracth, ");
            sql.Append("sum(ba_bm_ba_deform) ba_bm_ba_deform,");
            sql.Append("sum(ba_bm_endplay_deform_scracth) ba_bm_endplay_deform_scracth, ");
            ///
            sql.Append("sum(ca_app_metal_dirty) ca_app_metal_dirty, ");
            sql.Append("sum(ca_app_tape_hole_deform) ca_app_tape_hole_deform,");
            sql.Append("sum(ca_app_metal_high) ca_app_metal_high, ");
            sql.Append("sum(ca_app_case_deform_scracth) ca_app_case_deform_scracth, ");
            sql.Append("sum(ca_app_metal_deform_scratch) ca_app_metal_deform_scratch, ");
            sql.Append("sum(ca_app_magnet_broken) ca_app_magnet_broken, ");

            sql.Append("sum(ca_mg_metal_deform_scratch) ca_mg_metal_deform_scratch, ");
            sql.Append("sum(ca_mg_case_deform_scratch) ca_mg_case_deform_scratch, ");

            sql.Append("sum(ca_bonding_metal_deform_scratch) ca_bonding_metal_deform_scratch,");
            sql.Append("sum(ca_bonding_case_deform_scracth) ca_bonding_case_deform_scracth ");

            sql.Append("from ");

            sql.Append("(select Case When fc.times between '06:00:00' and '23:59:00' then fc.dates when fc.times between '00:00:00' and '05:59:00' then fc.dates-1 end datesss, fc.line_cd l, fc.model_cd model, * from t_ncvc_pdc_fc fc left join t_ncvc_pdc_en2 e2 on fc.fc_id = e2.en2_id left join t_ncvc_pdc_en1 e1 on fc.fc_id = e1.en1_id left join t_ncvc_pdc_ca ca on fc.fc_id = ca.ca_id left join t_ncvc_pdc_ba ba on fc.fc_id = ba.ba_id left                                   join (select dates date1, line_cd line1, Case when idca3 is null then idca1 else             idca3 end id  from (select tblca1.dates, tblca1.line_cd, idca1, idca3  from (select line_cd, o.dates, max(o.fc_id) idca1  from t_ncvc_pdc_fc o where o.times > '06:00:00'             and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto             group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.fc_id) idca3 from t_ncvc_pdc_fc o             where o.times > '00:00:00' and o.times <= '05:55:00'             and o.dates > :datefrom and o.dates - 1 <= :dateto             group by line_cd, o.dates order by idca3) tblca3             on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl             order by dates, line_cd) l on l.line1 = fc.line_cd where fc.fc_id = l.id and l.line1 = e2.line_cd and l.line1 = e1.line_cd             and l.line1 = ca.line_cd order by fc.dates, fc.line_cd ) tbl where model = :model_cd group by datesss,model");

            

            sqlParameter.AddParameterDateTime("datefrom", DateTime.Parse(inVo.DateFrom));
            sqlParameter.AddParameterDateTime("dateto", DateTime.Parse(inVo.DateTo));
            sqlParameter.AddParameterString("model_cd", inVo.ProModel);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerNCVCVo outVo = new ProductionControllerNCVCVo
                {
                    //StartDay = DateTime.Parse(dataReader["dates"].ToString()),
                    TimeHour = DateTime.Parse(dataReader["datesss"].ToString()),
                    ProModel = dataReader["model"].ToString(),
                    ProLine = dataReader["line"].ToString(),

                    FC_endplay_small = int.Parse(dataReader["fc_endplay_small"].ToString()),
                    FC_endplay_big = int.Parse(dataReader["fc_endplay_big"].ToString()),
                    FC_shaft_scracth = int.Parse(dataReader["fc_shaft_scracth"].ToString()),
                    FC_terminal_low = int.Parse(dataReader["fc_terminal_low"].ToString()),
                    FC_case_scracth_dirty = int.Parse(dataReader["fc_case_scracth_dirty"].ToString()),
                    FC_pinion_worm_ng = int.Parse(dataReader["fc_pinion_worm_ng"].ToString()),
                    FC_shaft_lock = int.Parse(dataReader["fc_shaft_lock"].ToString()),
                    FC_deform = int.Parse(dataReader["fc_ba_deform"].ToString()),
                    FC_tape_hole_deform = int.Parse(dataReader["fc_tape_hole_deform"].ToString()),
                    FC_brush_rust = int.Parse(dataReader["fc_brush_rust"].ToString()),
                    FC_metal_deform_scracth = int.Parse(dataReader["fc_metal_deform_scracth"].ToString()),
                    FC_washer_tape_hole = int.Parse(dataReader["fc_washer_tape_hole"].ToString()),

                    En2_insulation_resistance_ng = int.Parse(dataReader["en2_insulation_resistance_ng"].ToString()),
                    En2_cut_coil_wire = int.Parse(dataReader["en2_cut_coil_wire"].ToString()),
                    En2_no_load_current_hight = int.Parse(dataReader["en2_no_load_current_hight"].ToString()),
                    En2_ripple = int.Parse(dataReader["en2_ripple"].ToString()),
                    En2_chattering = int.Parse(dataReader["en2_chattering"].ToString()),
                    En2_lock = int.Parse(dataReader["en2_lock"].ToString()),
                    En2_open = int.Parse(dataReader["en2_open"].ToString()),
                    En2_no_load_speed_low = int.Parse(dataReader["en2_no_load_speed_low"].ToString()),
                    En2_starting_voltage = int.Parse(dataReader["en2_starting_voltage"].ToString()),
                    En2_no_load_speed_high = int.Parse(dataReader["en2_no_load_speed_high"].ToString()),
                    En2_rotor_mix = int.Parse(dataReader["en2_rotor_mix"].ToString()),
                    En2_surge_volt_max = int.Parse(dataReader["en2_surge_volt_max"].ToString()),
                    En2_wrong_post_of_pole = int.Parse(dataReader["en2_wrong_post_of_pole"].ToString()),
                    En2_err = int.Parse(dataReader["en2_err"].ToString()),
                    En2_noise = int.Parse(dataReader["en2_noise"].ToString()),

                    En1_insulation_resistace_ng = int.Parse(dataReader["en1_insulation_resistace_ng"].ToString()),
                    En1_cut_coil_wire = int.Parse(dataReader["en1_cut_coil_wire"].ToString()),
                    En1_lock = int.Parse(dataReader["en1_lock"].ToString()),
                    En1_wareform_ma_abnormal = int.Parse(dataReader["en1_wareform_ma_abnormal"].ToString()),
                    En1_shaft_bent = int.Parse(dataReader["en1_shaft_bent"].ToString()),
                    En1_ripple = int.Parse(dataReader["en1_ripple"].ToString()),
                    En1_short = int.Parse(dataReader["en1_short"].ToString()),
                    En1_chattering = int.Parse(dataReader["en1_chattering"].ToString()),
                    En1_no_load_current_high = int.Parse(dataReader["en1_no_load_current_high"].ToString()),
                    En1_vibration_ng = int.Parse(dataReader["en1_vibration_ng"].ToString()),
                    En1_open = int.Parse(dataReader["en1_open"].ToString()),
                    En1_rotor_mix = int.Parse(dataReader["en1_rotor_mix"].ToString()),

                    //BA_tc_endplay_big = int.Parse(dataReader["ba_tc_endplay_big"].ToString()),
                    //BA_tc_endplay_small = int.Parse(dataReader["ba_tc_endplay_small"].ToString()),
                    //BA_tc_brush_bent = int.Parse(dataReader["ba_tc_brush_bent"].ToString()),
                    //BA_tc_shaft_mix = int.Parse(dataReader["ba_tc_shaft_mix"].ToString()),

                    //BA_rto_ng = int.Parse(dataReader["ba_rto_ng"].ToString()),
                    //BA_rto_mix = int.Parse(dataReader["ba_rto_mix"].ToString()),

                    //BA_app_metal_deform_scracth = int.Parse(dataReader["ba_app_metal_deform_scracth"].ToString()),
                    //BA_app_deform = int.Parse(dataReader["ba_app_ba_deform"].ToString()),
                    //BA_app_endplate_deform_scracth = int.Parse(dataReader["ba_app_endplate_deform_scracth"].ToString()),
                    //BA_app_error_other = int.Parse(dataReader["ba_app_error_other"].ToString()),

                    //BA_bm_brush_deform_scracth = int.Parse(dataReader["ba_bm_brush_deform_scracth"].ToString()),
                    //BA_bm_metal_deform_scracth = int.Parse(dataReader["ba_bm_metal_deform_scracth"].ToString()),
                    //BA_bm_deform = int.Parse(dataReader["ba_bm_ba_deform"].ToString()),
                    //BA_bm_endplay_deform_scracth = int.Parse(dataReader["ba_bm_endplay_deform_scracth"].ToString()),

                    //CA_app_metal_dirty = int.Parse(dataReader["ca_app_metal_dirty"].ToString()),
                    //CA_app_tape_hole_deform = int.Parse(dataReader["ca_app_tape_hole_deform"].ToString()),
                    //CA_app_metal_high = int.Parse(dataReader["ca_app_metal_high"].ToString()),
                    //CA_app_case_deform_scracth = int.Parse(dataReader["ca_app_case_deform_scracth"].ToString()),
                    //CA_app_metal_deform_scratch = int.Parse(dataReader["ca_app_metal_deform_scratch"].ToString()),
                    //CA_app_magnet_broken = int.Parse(dataReader["ca_app_magnet_broken"].ToString()),

                    //CA_mg_metal_deform_scratch = int.Parse(dataReader["ca_mg_metal_deform_scratch"].ToString()),
                    //CA_mg_case_deform_scratch = int.Parse(dataReader["ca_mg_case_deform_scratch"].ToString()),

                    //CA_bonding_metal_deform_scratch = int.Parse(dataReader["ca_bonding_metal_deform_scratch"].ToString()),
                    //CA_bonding_case_deform_scracth = int.Parse(dataReader["ca_bonding_case_deform_scracth"].ToString()),

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
