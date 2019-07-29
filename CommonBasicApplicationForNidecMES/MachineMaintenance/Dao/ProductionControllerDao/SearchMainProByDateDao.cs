using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchMainProByDateDao : AbstractDataAccessObject
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

            /*sql.Append(@"select (o4.dates -1) as starday,(o4.dates + o4.times) as endday,o4.model_cd,o4.line_cd, o4.process_cd,  ");
            sql.Append("input_data, output_data, (hol_gap_holder + " + sqlApp + "+" + sqlEn2 + "+" + sqlFundou + "+" + sqlEn1 + "+" + sqlIS + "+" + sqlRA + "+" + sqlSW + "+" + sqlRing + "+" + sqlWE + "+" + sqlWi + "+" + sqlCore + ") as sum_ng,");
            sql.Append("hol_gap_holder as holder, " + sqlApp + " as app, " + sqlEn2 + " as en2, " + sqlFundou + " as fundou, " + sqlEn1 + " as en1, ");
            sql.Append(sqlIS + " as insert_case, " + sqlRA + " as ra, " + sqlSW + " as solder_wire, " + sqlRing + " as solder_ring, " + sqlWi + " as wingding,");
            sql.Append(sqlWE + " as welding," + sqlCore + " as core ");
            sql.Append("from t_productioncontroller_output04 o4, t_productioncontroller_output03 o3, t_productioncontroller_output02 o2, t_productioncontroller_output01 o1, ");
            sql.Append("t_productioncontroller_input02 i2, t_productioncontroller_input01 i1, ");
                sql.Append("(select o.dates , max(o.output04_id) id from t_productioncontroller_output04 o where o.times > '00:00:00' and o.times <= '05:50:00' ");
                sql.Append("and o.dates-1 >= :datesfrom and o.dates-1 <= :datesto and o.line_cd = :line_cd group by o.dates order by id ) tbltam ");
            sql.Append("where o4.line_cd = :line_cd and o3.line_cd = :line_cd and o2.line_cd = :line_cd and o1.line_cd = :line_cd and i2.line_cd = :line_cd and i1.line_cd = :line_cd ");
            sql.Append(" and tbltam.id = o4.output04_id and tbltam.id = o3.output03_id and tbltam.id = o2.output02_id and tbltam.id = o1.output01_id and ");
            sql.Append("tbltam.id = i1.input01_id and tbltam.id = i2.input02_id ");  */
            //tbl output
            sql.Append("select Case When tblout.times between '06:00:00' and '23:59:00' then tblout.dates when tblout.times between '00:00:00' and '05:59:00' then tblout.dates-1 end starday, ");
            sql.Append("(tblout.dates + tblout.times) endday, tblout.model_cd, tblout.line_cd,input_data, output_data, ");
            sql.Append("(holder+ app+ en2+ fundou+ en1+ insert_case+ra+ solder_wire+ solder_ring+ wingding+ welding+ core) sum_ng, ");
            sql.Append("holder, app, en2, fundou, en1, insert_case,ra, solder_wire, solder_ring, wingding, welding, core ");
            sql.Append("from ");
                sql.Append("(select ROW_NUMBER() OVER(ORDER BY o4.dates,o4.times ASC) rowo,o4.dates, o4.times, o4.model_cd, o4.line_cd, output_data, hol_gap_holder as holder, ");
                sql.Append(sqlApp + " as app, " + sqlEn2 + " as en2, " + sqlFundou + " as fundou, " + sqlEn1 + " as en1, " + sqlIS + " as insert_case, " + sqlRA + " as ra ");
                sql.Append("from t_productioncontroller_output04 o4 left join t_productioncontroller_output03 o3 on o4.line_cd = o3.line_cd and o4.output04_id = o3.output03_id ");
                sql.Append("left join t_productioncontroller_output02 o2 on o4.line_cd = o2.line_cd and o4.output04_id = o2.output02_id ");
                sql.Append("left join t_productioncontroller_output01 o1 on o4.line_cd = o1.line_cd and o4.output04_id = o1.output01_id ");
                    sql.Append("left join (select dates,line_cd, ");
                    sql.Append("Case when idca3 is null then idca1 else idca3 end id ");
                    sql.Append("from ");
                    sql.Append("(select tblca1.dates,tblca1.line_cd, idca1, idca3 ");
                    sql.Append("from ");
                        sql.Append("(select line_cd,o.dates , max(o.output04_id) idca1 ");
                        sql.Append("from t_productioncontroller_output04 o where line_cd in(:line_cd) and o.times > '06:00:00' and o.times <= '23:59:00' ");
                        sql.Append("and o.dates >= :datesfrom and o.dates <= :datesto group by o.dates, line_cd order by dates) tblca1 ");
                    sql.Append("left join ");
                        sql.Append("(select line_cd,(o.dates-1) dates , max(o.output04_id) idca3 ");
                        sql.Append("from t_productioncontroller_output04 o where line_cd in(:line_cd) and o.times > '00:00:00' and o.times <= '05:30:00' ");
                        sql.Append("and o.dates > :datesfrom and o.dates - 1 <= :datesto group by line_cd,o.dates order by idca3) tblca3 ");
                    sql.Append("on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) ");
                //sql.Append("on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) ");
            sql.Append("tbl order by dates,line_cd) l on l.line_cd = o4.line_cd where l.id = o4.output04_id order by o4.dates, o4.line_cd) tblout ");
            //end tbl output
            //tbl input
            sql.Append("left join ");
                sql.Append("(select ROW_NUMBER() OVER(ORDER BY i1.dates,i1.times ASC) rowi, i1.dates,i1.times,i1.model_cd,i1.line_cd, input_data,");
                sql.Append(sqlSW + " as solder_wire, " + sqlRing + " as solder_ring, " + sqlWi + " as wingding, " + sqlWE + " as welding, " + sqlCore + " as core ");
                sql.Append("from t_productioncontroller_input01 i1 left join t_productioncontroller_input02 i2 on i1.line_cd = i2.line_cd and i1.input01_id = i2.input02_id ");
                sql.Append("left join ");
                    sql.Append("(select dates,line_cd, ");
                    sql.Append("Case when idca3 is null then idca1 else idca3 end id ");
                    sql.Append("from ");
                        sql.Append("(select tblca1.dates,tblca1.line_cd, idca1, idca3 ");
                        sql.Append("from ");
                            sql.Append("(select line_cd,o.dates , max(o.input01_id) idca1 from t_productioncontroller_input01 o ");
                            sql.Append("where line_cd in(:line_cd) and o.times > '06:00:00' and o.times <= '23:59:00' ");
                            sql.Append("and o.dates >= :datesfrom and o.dates <= :datesto group by o.dates, line_cd order by dates) tblca1 ");
                        sql.Append("left join ");
                            sql.Append("(select line_cd,(o.dates-1) dates , max(o.input01_id) idca3 from t_productioncontroller_input01 o ");
                            sql.Append("where line_cd in(:line_cd) and o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datesfrom and o.dates - 1 <= :datesto ");
                            sql.Append("group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) ");
                        sql.Append("tbl order by dates,line_cd) l on l.line_cd = i1.line_cd ");
                   sql.Append("where i1.input01_id = l.id order by i1.dates,i1.line_cd ) tblin on tblout.rowo = tblin.rowi");

            sqlParameter.AddParameterString("line_cd", inVo.ProLine);
            sqlParameter.AddParameterDateTime("datesfrom", inVo.StartDay);
            sqlParameter.AddParameterDateTime("datesto", inVo.EndDay);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerVo outVo = new ProductionControllerVo
                {

                    StartDay = DateTime.Parse(dataReader["starday"].ToString()),
                    EndDay = DateTime.Parse(dataReader["endday"].ToString()),
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
