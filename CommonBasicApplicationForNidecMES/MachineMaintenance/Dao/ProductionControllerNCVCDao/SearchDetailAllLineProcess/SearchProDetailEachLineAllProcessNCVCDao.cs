using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailEachLineAllProcessNCVCDao : AbstractDataAccessObject
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
            

            sql.Append("select Case When fc.times between '06:00:00' and '23:59:00' then fc.dates when fc.times between '00:00:00' and '05:59:00' then fc.dates-1 end datesss,fc.line_cd l, fc.model_cd model, *from t_ncvc_pdc_fc fc left join t_ncvc_pdc_en2 e2 on fc.fc_id = e2.en2_id left                                   join t_ncvc_pdc_en1 e1 on fc.fc_id = e1.en1_id left join t_ncvc_pdc_ca ca on fc.fc_id = ca.ca_id left join t_ncvc_pdc_ba ba on fc.fc_id = ba.ba_id left                                   join (select dates date1, line_cd line1, Case when idca3 is null then idca1 else             idca3 end id  from    (select tblca1.dates, tblca1.line_cd, idca1, idca3  from (select line_cd, o.dates, max(o.fc_id) idca1  from t_ncvc_pdc_fc o where o.times > '06:00:00'             and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto             group by o.dates, line_cd order by dates) tblca1    left join(select line_cd, (o.dates - 1) dates, max(o.fc_id) idca3 from t_ncvc_pdc_fc o             where o.times > '00:00:00' and o.times <= '05:55:00'             and o.dates > :datefrom and o.dates - 1 <= :dateto             group by line_cd, o.dates order by idca3) tblca3             on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl             order by dates, line_cd) l on l.line1 = fc.line_cd where fc.fc_id = l.id and l.line1 = e2.line_cd and l.line1 = e1.line_cd             and l.line1 = ca.line_cd and fc.line_cd = :line_cd order by fc.dates, fc.line_cd");

            sqlParameter.AddParameterDateTime("datefrom", DateTime.Parse(inVo.DateFrom));
            sqlParameter.AddParameterDateTime("dateto", DateTime.Parse(inVo.DateTo));
            sqlParameter.AddParameterString("line_cd", inVo.ProLine);
            //sqlParameter.AddParameterString("model_cd", inVo.ProModel);

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
                    ProLine = dataReader["l"].ToString(),

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

                    BA_tc_endplay_big = int.Parse(dataReader["ba_tc_endplay_big"].ToString()),
                    BA_tc_endplay_small = int.Parse(dataReader["ba_tc_endplay_small"].ToString()),
                    BA_tc_brush_bent = int.Parse(dataReader["ba_tc_brush_bent"].ToString()),
                    BA_tc_shaft_mix = int.Parse(dataReader["ba_tc_shaft_mix"].ToString()),

                    BA_rto_ng = int.Parse(dataReader["ba_rto_ng"].ToString()),
                    BA_rto_mix = int.Parse(dataReader["ba_rto_mix"].ToString()),

                    BA_app_metal_deform_scracth = int.Parse(dataReader["ba_app_metal_deform_scracth"].ToString()),
                    BA_app_deform = int.Parse(dataReader["ba_app_ba_deform"].ToString()),
                    BA_app_endplate_deform_scracth = int.Parse(dataReader["ba_app_endplate_deform_scracth"].ToString()),
                    BA_app_error_other = int.Parse(dataReader["ba_app_error_other"].ToString()),

                    BA_bm_brush_deform_scracth = int.Parse(dataReader["ba_bm_brush_deform_scracth"].ToString()),
                    BA_bm_metal_deform_scracth = int.Parse(dataReader["ba_bm_metal_deform_scracth"].ToString()),
                    BA_bm_deform = int.Parse(dataReader["ba_bm_ba_deform"].ToString()),
                    BA_bm_endplay_deform_scracth = int.Parse(dataReader["ba_bm_endplay_deform_scracth"].ToString()),

                    CA_app_metal_dirty = int.Parse(dataReader["ca_app_metal_dirty"].ToString()),
                    CA_app_tape_hole_deform = int.Parse(dataReader["ca_app_tape_hole_deform"].ToString()),
                    CA_app_metal_high = int.Parse(dataReader["ca_app_metal_high"].ToString()),
                    CA_app_case_deform_scracth = int.Parse(dataReader["ca_app_case_deform_scracth"].ToString()),
                    CA_app_metal_deform_scratch = int.Parse(dataReader["ca_app_metal_deform_scratch"].ToString()),
                    CA_app_magnet_broken = int.Parse(dataReader["ca_app_magnet_broken"].ToString()),

                    CA_mg_metal_deform_scratch = int.Parse(dataReader["ca_mg_metal_deform_scratch"].ToString()),
                    CA_mg_case_deform_scratch = int.Parse(dataReader["ca_mg_case_deform_scratch"].ToString()),

                    CA_bonding_metal_deform_scratch = int.Parse(dataReader["ca_bonding_metal_deform_scratch"].ToString()),
                    CA_bonding_case_deform_scracth = int.Parse(dataReader["ca_bonding_case_deform_scracth"].ToString()),

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
