using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchMainProChartAllLineDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProductionControllerVo inVo = (ProductionControllerVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProductionControllerVo> voList = new ValueObjectList<ProductionControllerVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();


            sql.Append("select tblout.datetimes,'All Line' model_cd, tblout.line_cd,input_data,output_data,(holder + app + en2 + fundou + en1 + isca + ra + core + welding + wingding + ring + solder_wire) as sum_ng, ");
            sql.Append("holder, app, en2, fundou, en1, isca, ra, core, welding, wingding, ring, solder_wire ");
            sql.Append("from ");
                sql.Append("(select min, t.dates + min datetimes, h, t.line_cd, output_data, hol_gap_holder holder, ");
                sql.Append("(fiapp_stamping_ba + fiapp_case_set + fiapp_tough_shaft + fiapp_case_glue_sticky + fiapp_up_low_shabby + fiapp_hole_shaft + fiapp_no_beat_prone_case + fiapp_hole_case + fiapp_prone_case + ");
                sql.Append("fiapp_lot_ng + fiapp_ter_deform + fiapp_hole_ter + fiapp_soder_hl + fiapp_metal_oven_low + fiapp_fundou_ng + fiapp_ter_glue_sticky + fiapp_lead_glue_sticky) app, ");
                sql.Append("( en2_lock + en2_cut + en2_chattering + en2_insulation + en2_open + en2_short + en2_duty + en2_no + en2_var + en2_reverse_spinning + en2_starting_volt + en2_io) en2, ");
                sql.Append("(fd_ng_beat_point + fd_fundou_deform) fundou, (en1_lock + en1_cut + en1_chattering + en1_insulation + en1_open + en1_bad_wave + en1_duty + en1_short + en1_beat_case_ng + en1_beat_fundou_ng) en1, ");
                sql.Append("(insc_no_ink_case_mc1 + insc_ba_deform_mc1 + insc_break_case_mc1 +  insc_drop_mc1 + insc_break_wire_mc1 + insc_break_ring_mc1) isca, ");
                sql.Append("(ra_com_pb_sticky + ra_wire_pb_sticky + ra_com_slip + ra_renew_ring + ra_break_wire_final_app + ra_wire_combine_wrong + ra_core_ng + ra_segment_hole + ");
                sql.Append("ra_glue_sticky + ra_loose_wire_final_app + ra_lead_not_covered + ra_less_lead) ra ");
                sql.Append("from t_productioncontroller_output04 o4, t_productioncontroller_output03 o3, t_productioncontroller_output02 o2, t_productioncontroller_output01 o1, ");
                sql.Append("(select dates,'06:00' h, min(times),line_cd from t_productioncontroller_output04 where dates = :dates and times between '06:00:00' and '06:55:00' group by line_cd, dates union ");
                sql.Append("select dates,'07:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '06:00:00' and '07:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'08:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '07:00:00' and '08:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'09:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '08:00:00' and '09:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'10:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '09:00:00' and '10:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'11:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '10:00:00' and '11:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'12:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '11:00:00' and '12:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'13:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '12:00:00' and '13:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'14:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '13:00:00' and '14:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'15:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '14:00:00' and '15:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'16:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '15:00:00' and '16:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'17:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '16:00:00' and '17:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'18:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '17:00:00' and '18:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'19:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '18:00:00' and '19:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'20:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '19:00:00' and '20:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'21:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '20:00:00' and '21:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'22:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '21:00:00' and '22:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'23:00' h,max(times),line_cd from t_productioncontroller_output04 where dates = :dates  and times between '22:00:00' and '23:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'00:00' h,min(times),line_cd from t_productioncontroller_output04 where dates - 1 = :dates  and times between '00:00:00' and '01:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'01:00' h,max(times),line_cd from t_productioncontroller_output04 where dates - 1 = :dates  and times between '00:00:00' and '01:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'02:00' h,max(times),line_cd from t_productioncontroller_output04 where dates - 1 = :dates  and times between '01:00:00' and '02:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'03:00' h,max(times),line_cd from t_productioncontroller_output04 where dates - 1 = :dates  and times between '02:00:00' and '03:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'04:00' h,max(times),line_cd from t_productioncontroller_output04 where dates - 1 = :dates  and times between '03:00:00' and '04:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'05:00' h,max(times),line_cd from t_productioncontroller_output04 where dates - 1 = :dates  and times between '04:00:00' and '05:05:00' group by line_cd, dates union ");
                sql.Append("select dates,'05:55' h,max(times),line_cd from t_productioncontroller_output04 where dates - 1 = :dates  and times between '05:00:00' and '05:32:00' group by line_cd, dates) t ");
                sql.Append("where o4.output04_id = o3.output03_id and o4.output04_id = o2.output02_id and o4.output04_id = o1.output01_id and o4.line_cd = t.line_cd and o4.times = t.min and o4.dates = :dates ");
                sql.Append("and o3.line_cd = t.line_cd and o3.times = t.min and o2.line_cd = t.line_cd and o2.times = t.min and o1.line_cd = t.line_cd and o1.times = t.min order by line_cd,o1.times) tblout ");
            sql.Append("left join ");
                sql.Append("(select min,t.dates+min datetimes,h,t.line_cd, input_data, (co_beat_core_ng + co_com_wrap + co_core_ng + co_com_glue_sticky) as core, (we_com_slip + we_long_shaft + we_short_shaft) as welding, ");
                sql.Append("(wi_break_copper_mc + wi_ruffle_copper_mc + wi_edge_ng_mc + wi_no_sleeve_mc) as wingding, (rigs_wire_pb_sticky + rigs_com_pb_sticky + rigs_ring_prone + rigs_cracked_ring) as ring, ");
                sql.Append("(pbs_break_copper + pbs_climb_core + pbs_skip_edge + pbs_wire_combine_wrong + pbs_loose_wire + pbs_rizer_edge_ng + pbs_core_ng + pbs_com_slip + pbs_hole + pbs_2_sleeve ");
                sql.Append("+ pbs_wire_pb_sticky + pbs_com_pb_sticky + pbs_no_lead) as solder_wire ");
                sql.Append("from t_productioncontroller_input01 i1, t_productioncontroller_input02 i2, ");
                sql.Append("(select dates,'06:00' h, min(times),line_cd from t_productioncontroller_input01 where dates = :dates and times between '06:00:00' and '06:55:00'  group by line_cd, dates union ");
                sql.Append("select dates,'07:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '06:00:00' and '07:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '08:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '07:00:00' and '08:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '09:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '08:00:00' and '09:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '10:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '09:00:00' and '10:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '11:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '10:00:00' and '11:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '12:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '11:00:00' and '12:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '13:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '12:00:00' and '13:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '14:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '13:00:00' and '14:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '15:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '14:00:00' and '15:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '16:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '15:00:00' and '16:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '17:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '16:00:00' and '17:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '18:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '17:00:00' and '18:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '19:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '18:00:00' and '19:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '20:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '19:00:00' and '20:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '21:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '20:00:00' and '21:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '22:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '21:00:00' and '22:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '23:00' h,max(times),line_cd from t_productioncontroller_input01 where dates = :dates  and times between '22:00:00' and '23:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '00:00' h,min(times),line_cd from t_productioncontroller_input01 where dates - 1 = :dates  and times between '00:00:00' and '01:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '01:00' h,max(times),line_cd from t_productioncontroller_input01 where dates - 1 = :dates  and times between '00:00:00' and '01:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '02:00' h,max(times),line_cd from t_productioncontroller_input01 where dates - 1 = :dates  and times between '01:00:00' and '02:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '03:00' h,max(times),line_cd from t_productioncontroller_input01 where dates - 1 = :dates  and times between '02:00:00' and '03:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '04:00' h,max(times),line_cd from t_productioncontroller_input01 where dates - 1 = :dates  and times between '03:00:00' and '04:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '05:00' h,max(times),line_cd from t_productioncontroller_input01 where dates - 1 = :dates  and times between '04:00:00' and '05:05:00' group by line_cd, dates union ");
                sql.Append("select dates, '05:55' h,max(times),line_cd from t_productioncontroller_input01 where dates - 1 = :dates  and times between '05:00:00' and '05:32:00' group by line_cd, dates) t ");
                sql.Append("where i1.input01_id = i2.input02_id and i1.line_cd = t.line_cd and i1.times = t.min and i1.dates = :dates and i2.line_cd = t.line_cd and i2.times = t.min order by line_cd,i1.times) ");
             sql.Append("tblin on tblout.line_cd = tblin.line_cd and tblout.h = tblin.h where tblout.h = tblin.h and tblout.line_cd != 'L08'");

            sqlParameter.AddParameterDateTime("dates", inVo.StartDay);
            //sqlParameter.AddParameterDateTime("datesto", inVo.EndDay);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);


            //sql.Append("select tblout.datetimes, tblout.line_cd,input_data,output_data,(holder + app + en2 + fundou + en1 + isca + ra + core + welding + wingding + ring + solder_wire) as sum_ng, ");
            //sql.Append("holder, app, en2, fundou, en1, isca, ra, core, welding, wingding, ring, solder_wire ");
            while (dataReader.Read())
            {
                ProductionControllerVo outVo = new ProductionControllerVo
                {

                    //StartDay = DateTime.Parse(dataReader["datetimes"].ToString()),
                    TimeHour = DateTime.Parse(dataReader["datetimes"].ToString()),
                    ProModel = dataReader["model_cd"].ToString(),
                    ProLine = dataReader["line_cd"].ToString(),
                    TotalNG = int.Parse(dataReader["sum_ng"].ToString()),
                    ProInput = int.Parse(dataReader["input_data"].ToString()),
                    ProOutput = int.Parse(dataReader["output_data"].ToString()),

                    HolderNG = int.Parse(dataReader["holder"].ToString()),
                    AppCheckNG = int.Parse(dataReader["app"].ToString()),
                    En2NG = int.Parse(dataReader["en2"].ToString()),
                    FundouNG = int.Parse(dataReader["fundou"].ToString()),
                    En1NG = int.Parse(dataReader["en1"].ToString()),
                    InsertCaseNG = int.Parse(dataReader["isca"].ToString()),
                    RANG = int.Parse(dataReader["ra"].ToString()),

                    SolderWireNG = int.Parse(dataReader["solder_wire"].ToString()),
                    SolderRingNG = int.Parse(dataReader["ring"].ToString()),
                    WindingNG = int.Parse(dataReader["wingding"].ToString()),
                    WeldingNG = int.Parse(dataReader["welding"].ToString()),
                    CoreNG = int.Parse(dataReader["core"].ToString()),

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
