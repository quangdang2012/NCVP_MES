using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchMainProByHourDao : AbstractDataAccessObject
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

            string sqlApp = "(fiapp_stamping_ba + fiapp_case_set + fiapp_tough_shaft + fiapp_case_glue_sticky + fiapp_up_low_shabby + fiapp_hole_shaft + fiapp_no_beat_prone_case + fiapp_hole_case + fiapp_prone_case + fiapp_lot_ng + fiapp_ter_deform + fiapp_hole_ter + fiapp_soder_hl + fiapp_metal_oven_low + fiapp_fundou_ng +  fiapp_ter_glue_sticky + fiapp_lead_glue_sticky )";

            string sqlEn2 = "(en2_lock + en2_cut + en2_chattering + en2_insulation + en2_open + en2_short + en2_duty + en2_no + en2_var + en2_reverse_spinning +  en2_starting_volt + en2_io)";

            string sqlFundou = "(fd_ng_beat_point + fd_fundou_deform)";

            string sqlEn1 = "(en1_lock + en1_cut + en1_chattering + en1_insulation + en1_open + en1_bad_wave + en1_duty + en1_short + en1_beat_case_ng + en1_beat_fundou_ng )";

            string sqlIS = "(insc_no_ink_case_mc1 + insc_ba_deform_mc1 + insc_break_case_mc1 + insc_drop_mc1 + insc_break_wire_mc1 + insc_break_ring_mc1)";

            string sqlRA = "(ra_com_pb_sticky + ra_wire_pb_sticky + ra_com_slip + ra_renew_ring + ra_break_wire_final_app + ra_wire_combine_wrong + ra_core_ng + ra_segment_hole +  ra_glue_sticky + ra_loose_wire_final_app + ra_lead_not_covered + ra_less_lead )";

            string sqlSW = "(pbs_break_copper + pbs_climb_core + pbs_skip_edge + pbs_wire_combine_wrong + pbs_loose_wire +  pbs_rizer_edge_ng + pbs_core_ng + pbs_com_slip +  pbs_hole + pbs_2_sleeve + pbs_wire_pb_sticky + pbs_com_pb_sticky + pbs_no_lead)";

            string sqlRing = "(rigs_wire_pb_sticky + rigs_com_pb_sticky + rigs_ring_prone + rigs_cracked_ring)";

            string sqlWE = "(we_com_slip + we_long_shaft + we_short_shaft)";

            string sqlWi = "(wi_break_copper_mc + wi_ruffle_copper_mc + wi_edge_ng_mc + wi_no_sleeve_mc)";

            string sqlCore = "(co_beat_core_ng + co_com_wrap + co_core_ng + co_com_glue_sticky)";
            
            sql.Append(@"select tblout.datestimes, tblout.model_cd, tblout.line_cd, ( holder + app + en2 + fundou + en1 + insert_case + ra + solder_wire + solder_ring + ");
            sql.Append("wingding + welding + core) as sum_ng,input_data, output_data, holder, app, en2, fundou, en1, insert_case, ra, solder_wire, solder_ring, wingding, welding, core ");
            sql.Append("from ");
            sql.Append("(select ROW_NUMBER() OVER(ORDER BY o4.dates,o4.times ASC) rowo, (o4.dates + o4.times) datestimes, o4.model_cd,o4.line_cd, o4.process_cd,  ");
            sql.Append("output_data, hol_gap_holder as holder, " + sqlApp + " as app, " + sqlEn2 + " as en2, " + sqlFundou + " as fundou, " + sqlEn1 + " as en1, ");
            sql.Append(sqlIS + " as insert_case, " + sqlRA + " as ra ");
            sql.Append("from t_productioncontroller_output04 o4, t_productioncontroller_output03 o3, t_productioncontroller_output02 o2, t_productioncontroller_output01 o1 ");

            sql.Append("where o4.line_cd = :line_cd and o3.line_cd = :line_cd and o2.line_cd = :line_cd and o1.line_cd = :line_cd ");
            sql.Append(" and o4.output04_id = o3.output03_id and o4.output04_id = o2.output02_id and o4.output04_id = o1.output01_id ");
            sql.Append("and o4.dates = :dates ");
            sql.Append("and (o4.times in(select min(times) from t_productioncontroller_output04 where times between '06:00:00' and '06:55:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd ) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '06:00:00' and '07:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '07:00:00' and '08:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '08:00:00' and '09:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '09:00:00' and '10:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '10:00:00' and '11:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '11:00:00' and '12:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '12:00:00' and '13:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '13:00:00' and '14:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '14:00:00' and '15:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '15:00:00' and '16:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '16:00:00' and '17:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '17:00:00' and '18:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '18:00:00' and '19:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '19:00:00' and '20:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '20:00:00' and '21:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '21:00:00' and '22:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '22:00:00' and '23:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");

            sql.Append("or o4.dates-1 =:dates ");
            sql.Append("and o4.line_cd = :line_cd and o3.line_cd = :line_cd and o2.line_cd = :line_cd and o1.line_cd = :line_cd ");
            sql.Append("and o4.output04_id = o3.output03_id and o4.output04_id = o2.output02_id and o4.output04_id = o1.output01_id ");
            sql.Append("and (o4.times in(select min(times) from t_productioncontroller_output04 where times between '00:00:00' and '00:55:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '00:00:00' and '01:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '01:00:00' and '02:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '02:00:00' and '03:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '03:00:00' and '04:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '04:00:00' and '05:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output04 where times between '05:00:00' and '05:35:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd))) tblout ");

            sql.Append("left join ");
            //

            sql.Append(@"(select ROW_NUMBER() OVER(ORDER BY i1.dates,i1.times ASC) rowi,(i1.dates + i1.times) datestimes, i1.model_cd,i1.line_cd, i1.process_cd, input_data,  ");
            sql.Append(sqlSW + " as solder_wire, " + sqlRing + " as solder_ring, " + sqlWi + " as wingding, "+sqlWE +" as welding, "+ sqlCore + " as core ");
            sql.Append("from t_productioncontroller_input02 i2, t_productioncontroller_input01 i1 ");

            sql.Append("where i2.line_cd = :line_cd and i1.line_cd = :line_cd and i1.input01_id = i2.input02_id ");
            sql.Append("and i1.dates = :dates ");
            sql.Append("and (i1.times in(select min(times) from t_productioncontroller_input01 where times between '06:00:00' and '06:55:00' and input_data < 100 and dates = :dates and line_cd = :line_cd and model_cd = :model_cd ) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '06:00:00' and '07:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '07:00:00' and '08:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '08:00:00' and '09:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '09:00:00' and '10:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '10:00:00' and '11:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '11:00:00' and '12:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '12:00:00' and '13:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '13:00:00' and '14:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '14:00:00' and '15:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '15:00:00' and '16:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '16:00:00' and '17:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '17:00:00' and '18:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '18:00:00' and '19:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '19:00:00' and '20:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '20:00:00' and '21:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '21:00:00' and '22:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '22:00:00' and '23:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");

            sql.Append("or i1.dates-1 =:dates ");
            sql.Append("and i1.line_cd = :line_cd and i2.line_cd = :line_cd and i1.input01_id = i2.input02_id ");
            sql.Append("and (i1.times in(select min(times) from t_productioncontroller_input01 where times between '00:00:00' and '00:55:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '00:00:00' and '01:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '01:00:00' and '02:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '02:00:00' and '03:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '03:00:00' and '04:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '04:00:00' and '05:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i1.times in(select max(times) from t_productioncontroller_input01 where times between '05:00:00' and '05:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd))) tblin on tblout.rowo = tblin.rowi ");
            sql.Append("where tblout.rowo = tblin.rowi");
            sqlParameter.AddParameterString("line_cd", inVo.ProLine);
            sqlParameter.AddParameterDateTime("dates", DateTime.Parse(inVo.Date));
            sqlParameter.AddParameterString("model_cd", inVo.ProModel);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerVo outVo = new ProductionControllerVo
                {
                TimeHour = DateTime.Parse(dataReader["datestimes"].ToString()),
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
                    InsertCaseNG = int.Parse(dataReader["insert_case"].ToString()),
                    RANG = int.Parse(dataReader["ra"].ToString()),

                    SolderWireNG = int.Parse(dataReader["solder_wire"].ToString()),
                    SolderRingNG = int.Parse(dataReader["solder_ring"].ToString()),
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
