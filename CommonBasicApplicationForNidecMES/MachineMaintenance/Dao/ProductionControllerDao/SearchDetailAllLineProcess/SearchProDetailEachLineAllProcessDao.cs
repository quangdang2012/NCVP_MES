using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailEachLineAllProcessDao : AbstractDataAccessObject
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

            sql.Append("select tbloutput.datesss dates,'LA459' model_cd,* from ");
            sql.Append("(select Case When t.timeso4 between '06:00:00' and '23:59:00' then t.dateo4 when ");
            sql.Append("t.timeso4 between '00:00:00' and '05:59:00' then t.dateo4-1 end datesss, line_cdo4, ");
            sql.Append("sum(fiapp_stamping_ba) fiapp_stamping_ba , sum(fiapp_case_set) fiapp_case_set, ");
            sql.Append("sum(fiapp_tough_shaft) fiapp_tough_shaft, sum(fiapp_case_glue_sticky) fiapp_case_glue_sticky, ");
            sql.Append("sum(fiapp_up_low_shabby) fiapp_up_low_shabby ,  sum(fiapp_hole_shaft) fiapp_hole_shaft,  ");
            sql.Append("sum(fiapp_no_beat_prone_case) fiapp_no_beat_prone_case, sum(fiapp_hole_case) fiapp_hole_case, ");
            sql.Append("sum(fiapp_prone_case) fiapp_prone_case, sum(fiapp_lot_ng) fiapp_lot_ng, ");
            sql.Append("sum(fiapp_ter_deform) fiapp_ter_deform, sum(fiapp_hole_ter ) fiapp_hole_ter, ");
            sql.Append("sum(fiapp_soder_hl) fiapp_soder_hl, ");
            sql.Append("sum(fiapp_metal_oven_low) fiapp_metal_oven_low, ");
            sql.Append("sum(fiapp_fundou_ng) fiapp_fundou_ng, ");
            sql.Append("sum(fiapp_ter_glue_sticky) fiapp_ter_glue_sticky, ");
            sql.Append("sum(fiapp_lead_glue_sticky) fiapp_lead_glue_sticky, ");

            sql.Append("sum(hol_gap_holder) hol_gap_holder, ");

            sql.Append("sum(en2_lock) en2_lock , sum(en2_cut) en2_cut , ");
            sql.Append("sum(en2_chattering) en2_chattering ,");
            sql.Append("sum(en2_insulation) en2_insulation,  sum(en2_open) en2_open, ");
            sql.Append("sum(en2_short) en2_short, sum(en2_duty) en2_duty, ");
            sql.Append("sum(en2_no) en2_no, sum(en2_var) en2_var, ");
            sql.Append("sum(en2_reverse_spinning) en2_reverse_spinning, sum(en2_io) en2_io, ");
            sql.Append("sum(en2_starting_volt) en2_starting_volt, ");

            sql.Append("sum(fd_ng_beat_point) fd_ng_beat_point , sum(fd_fundou_deform) fd_fundou_deform , ");
            sql.Append("sum(en1_lock) en1_lock, sum(en1_cut) en1_cut, sum(en1_chattering) en1_chattering, ");
            sql.Append("sum(en1_insulation) en1_insulation, sum(en1_open) en1_open, ");
            sql.Append("sum(en1_bad_wave) en1_bad_wave, sum(en1_duty) en1_duty, ");
            sql.Append("sum(en1_short) en1_short, sum(en1_beat_case_ng ) en1_beat_case_ng, ");
            sql.Append("sum(en1_beat_fundou_ng) en1_beat_fundou_ng, ");

            sql.Append("sum(insc_no_ink_case_mc1) insc_no_ink_case_mc1, sum(insc_ba_deform_mc1) insc_ba_deform_mc1, ");
            sql.Append("sum(insc_break_case_mc1) insc_break_case_mc1 ,");
            sql.Append("sum(insc_drop_mc1) insc_drop_mc1 ,  sum(insc_break_wire_mc1) insc_break_wire_mc1, ");
            sql.Append("sum(insc_break_ring_mc1) insc_break_ring_mc1, ");

            sql.Append("sum(ra_com_pb_sticky) ra_com_pb_sticky,");
            sql.Append("sum(ra_wire_pb_sticky) ra_wire_pb_sticky, sum(ra_com_slip) ra_com_slip, ");
            sql.Append("sum(ra_renew_ring) ra_renew_ring, sum(ra_break_wire_final_app ) ra_break_wire_final_app, ");
            sql.Append("sum(ra_wire_combine_wrong) ra_wire_combine_wrong, ");
            sql.Append("sum(ra_core_ng) ra_core_ng, ");
            sql.Append("sum(ra_segment_hole) ra_segment_hole, sum(ra_glue_sticky) ra_glue_sticky, ");
            sql.Append("sum(ra_loose_wire_final_app) ra_loose_wire_final_app, sum(ra_lead_not_covered ) ra_lead_not_covered,");
            sql.Append("sum(ra_less_lead) ra_less_lead ");
            sql.Append("from ");
            sql.Append("(select o4.dates dateo4,o4.times timeso4,o4.line_cd line_cdo4,* from t_productioncontroller_output04 o4 left join ");
            sql.Append("t_productioncontroller_output03 o3 on o4.output04_id = o3.output03_id ");
            sql.Append("left join t_productioncontroller_output02 o2 on o4.output04_id = o2.output02_id ");
            sql.Append("left join t_productioncontroller_output01 o1 on o4.output04_id = o1.output01_id ");
            sql.Append("left join ");
            sql.Append("(select dates date1, line_cd line1, Case when idca3 is null then idca1 else ");
            sql.Append("idca3 end id  from (select tblca1.dates,tblca1.line_cd, idca1, idca3  from ");
            sql.Append("(select line_cd,o.dates , max(o.output01_id) idca1  from ");
            sql.Append("t_productioncontroller_output01 o where line_cd = :line_cd and o.times > '06:00:00' ");
            sql.Append("and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto ");
            sql.Append("group by o.dates, line_cd order by dates) tblca1 ");
            sql.Append("left join ");
            sql.Append("(select line_cd,(o.dates-1) dates , max(o.input01_id) idca3 from t_productioncontroller_input01 o ");
            sql.Append("where line_cd = :line_cd and o.times > '00:00:00' and o.times <= '05:30:00' ");
            sql.Append("and o.dates > :datefrom and o.dates - 1 <= :dateto ");
            sql.Append("group by line_cd,o.dates order by idca3) tblca3 ");
            sql.Append("on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl ");
            sql.Append("order by dates,line_cd) l on l.line1 = o4.line_cd ");
            sql.Append("where o4.output04_id = l.id and l.line1 = o3.line_cd and l.line1 = o2.line_cd ");
            sql.Append("and l.line1 = o1.line_cd order by o4.dates, o4.line_cd) ");
            sql.Append("t group by datesss,line_cdo4 order by datesss ) tbloutput ");

            sql.Append("left join ");

            sql.Append("(select Case When t.timeso4 between '06:00:00' and '23:59:00' then t.dateo4 when ");
            sql.Append("t.timeso4 between '00:00:00' and '05:59:00' then t.dateo4-1 end datesss, ");
            sql.Append("sum(pbs_break_copper) pbs_break_copper, sum(pbs_climb_core) pbs_climb_core, ");
            sql.Append("sum(pbs_skip_edge) pbs_skip_edge, ");
            sql.Append("sum(pbs_wire_combine_wrong) pbs_wire_combine_wrong, sum(pbs_loose_wire) pbs_loose_wire,  ");
            sql.Append("sum(pbs_rizer_edge_ng) pbs_rizer_edge_ng, sum(pbs_core_ng) pbs_core_ng, ");
            sql.Append("sum(pbs_com_slip) pbs_com_slip, sum(pbs_hole) pbs_hole, ");
            sql.Append("sum(pbs_2_sleeve) pbs_2_sleeve, sum(pbs_wire_pb_sticky ) pbs_wire_pb_sticky, ");
            sql.Append("sum(pbs_com_pb_sticky) pbs_com_pb_sticky, sum(pbs_no_lead) pbs_no_lead, ");
            sql.Append("sum(rigs_cracked_ring) rigs_cracked_ring, sum(rigs_ring_prone) rigs_ring_prone, ");
            sql.Append("sum(rigs_com_pb_sticky) rigs_com_pb_sticky, sum(rigs_wire_pb_sticky) rigs_wire_pb_sticky, ");
            sql.Append("sum(wi_no_sleeve_mc) wi_no_sleeve_mc, ");
            sql.Append("sum(wi_edge_ng_mc) wi_edge_ng_mc, sum(wi_ruffle_copper_mc) wi_ruffle_copper_mc, ");
            sql.Append("sum(wi_break_copper_mc) wi_break_copper_mc, ");
            sql.Append("sum(we_short_shaft) we_short_shaft, sum(we_long_shaft) we_long_shaft, sum(we_com_slip) we_com_slip, ");
            sql.Append("sum(co_com_glue_sticky) co_com_glue_sticky, sum(co_core_ng) co_core_ng, ");
            sql.Append("sum(co_com_wrap) co_com_wrap, sum(co_beat_core_ng) co_beat_core_ng ");
            sql.Append("from ");
            sql.Append("(select i1.dates dateo4,i1.times timeso4,* from t_productioncontroller_input01 i1 ");
            sql.Append("left join t_productioncontroller_input02 i2 on i2.input02_id = i1.input01_id ");
            sql.Append("left join ");
            sql.Append("(select dates date1, line_cd line1, Case when idca3 is null then idca1 else idca3 end id ");
            sql.Append("from (select tblca1.dates,tblca1.line_cd, idca1, idca3  from ");
            sql.Append("(select line_cd,o.dates , max(o.input01_id) idca1  from t_productioncontroller_input01 o ");
            sql.Append("where line_cd = :line_cd and o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom ");
            sql.Append("and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 ");
            sql.Append("left join (select line_cd,(o.dates-1) dates , max(o.input01_id) idca3 ");
            sql.Append("from t_productioncontroller_input01 o ");
            sql.Append("where line_cd = :line_cd and o.times > '00:00:00' and o.times <= '05:30:00' ");
            sql.Append("and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd,o.dates order by idca3) tblca3 ");
            sql.Append("on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl order by dates,line_cd) ");
            sql.Append("l on l.line1 = i1.line_cd where l.id = i1.input01_id and l.line1 = i2.line_cd and l.line1 = i1.line_cd order by i1.dates,i1.line_cd ) t group by datesss order by datesss) ");
            sql.Append("tblinput on tbloutput.datesss = tblinput.datesss ");

            sqlParameter.AddParameterDateTime("datefrom", DateTime.Parse(inVo.DateFrom));
            sqlParameter.AddParameterDateTime("dateto", DateTime.Parse(inVo.DateTo));
            sqlParameter.AddParameterString("line_cd", inVo.ProLine);
            //sqlParameter.AddParameterString("model_cd", inVo.ProModel);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerVo outVo = new ProductionControllerVo
                {
                    //StartDay = DateTime.Parse(dataReader["dates"].ToString()),
                    TimeHour = DateTime.Parse(dataReader["dates"].ToString()),
                    ProModel = dataReader["model_cd"].ToString(),
                    ProLine = dataReader["line_cdo4"].ToString(),

                    HolGapHolder = int.Parse(dataReader["hol_gap_holder"].ToString()),

                    App_stamping_ba = int.Parse(dataReader["fiapp_stamping_ba"].ToString()),
                    App_case_set = int.Parse(dataReader["fiapp_case_set"].ToString()),
                    App_tough_shaft = int.Parse(dataReader["fiapp_tough_shaft"].ToString()),
                    App_case_glue_sticky = int.Parse(dataReader["fiapp_case_glue_sticky"].ToString()),
                    App_up_low_shabby = int.Parse(dataReader["fiapp_up_low_shabby"].ToString()),
                    App_hole_shaft = int.Parse(dataReader["fiapp_hole_shaft"].ToString()),
                    App_no_beat_prone_case = int.Parse(dataReader["fiapp_no_beat_prone_case"].ToString()),
                    App_hole_case = int.Parse(dataReader["fiapp_hole_case"].ToString()),
                    App_prone_case = int.Parse(dataReader["fiapp_prone_case"].ToString()),
                    App_lot_ng = int.Parse(dataReader["fiapp_lot_ng"].ToString()),
                    App_ter_deform = int.Parse(dataReader["fiapp_ter_deform"].ToString()),
                    App_hole_ter = int.Parse(dataReader["fiapp_hole_ter"].ToString()),
                    App_soder_hl = int.Parse(dataReader["fiapp_soder_hl"].ToString()),
                    App_metal_oven_low = int.Parse(dataReader["fiapp_metal_oven_low"].ToString()),
                    App_fundou_ng = int.Parse(dataReader["fiapp_fundou_ng"].ToString()),
                    App_ter_glue_sticky = int.Parse(dataReader["fiapp_ter_glue_sticky"].ToString()),
                    App_lead_glue_sticky = int.Parse(dataReader["fiapp_lead_glue_sticky"].ToString()),

                    Co_beat_core_ng = int.Parse(dataReader["co_beat_core_ng"].ToString()),
                    Co_com_wrap = int.Parse(dataReader["co_com_wrap"].ToString()),
                    Co_core_ng = int.Parse(dataReader["co_core_ng"].ToString()),
                    Co_com_glue_sticky = int.Parse(dataReader["co_com_glue_sticky"].ToString()),

                    En1_lock = int.Parse(dataReader["en1_lock"].ToString()),
                    En1_cut = int.Parse(dataReader["en1_cut"].ToString()),
                    En1_chattering = int.Parse(dataReader["en1_chattering"].ToString()),
                    En1_insulation = int.Parse(dataReader["en1_insulation"].ToString()),
                    En1_open = int.Parse(dataReader["en1_open"].ToString()),
                    En1_bad_wave = int.Parse(dataReader["en1_bad_wave"].ToString()),
                    En1_duty = int.Parse(dataReader["en1_duty"].ToString()),
                    En1_short = int.Parse(dataReader["en1_short"].ToString()),
                    En1_beat_case_ng = int.Parse(dataReader["en1_beat_case_ng"].ToString()),
                    En1_beat_fundou_ng = int.Parse(dataReader["en1_beat_fundou_ng"].ToString()),

                    En2_lock = int.Parse(dataReader["en2_lock"].ToString()),
                    En2_cut = int.Parse(dataReader["en2_cut"].ToString()),
                    En2_chattering = int.Parse(dataReader["en2_chattering"].ToString()),
                    En2_insulation = int.Parse(dataReader["en2_insulation"].ToString()),
                    En2_open = int.Parse(dataReader["en2_open"].ToString()),
                    En2_short = int.Parse(dataReader["en2_short"].ToString()),
                    En2_duty = int.Parse(dataReader["en2_duty"].ToString()),
                    En2_no = int.Parse(dataReader["en2_no"].ToString()),
                    En2_var = int.Parse(dataReader["en2_var"].ToString()),
                    En2_reverse_spinning = int.Parse(dataReader["en2_reverse_spinning"].ToString()),
                    En2_starting_volt = int.Parse(dataReader["en2_starting_volt"].ToString()),
                    En2_io = int.Parse(dataReader["en2_io"].ToString()),

                    Fd_ng_beat_point = int.Parse(dataReader["fd_ng_beat_point"].ToString()),
                    Fd_fundou_deform = int.Parse(dataReader["fd_fundou_deform"].ToString()),

                    Insc_no_ink_case_mc1 = int.Parse(dataReader["insc_no_ink_case_mc1"].ToString()),
                    Insc_ba_deform_mc1 = int.Parse(dataReader["insc_ba_deform_mc1"].ToString()),
                    Insc_break_case_mc1 = int.Parse(dataReader["insc_break_case_mc1"].ToString()),
                    Insc_drop_mc1 = int.Parse(dataReader["insc_drop_mc1"].ToString()),
                    Insc_break_wire_mc1 = int.Parse(dataReader["insc_break_wire_mc1"].ToString()),
                    Insc_break_ring_mc1 = int.Parse(dataReader["insc_break_ring_mc1"].ToString()),


                    RA_com_pb_sticky = int.Parse(dataReader["ra_com_pb_sticky"].ToString()),
                    RA_wire_pb_sticky = int.Parse(dataReader["ra_wire_pb_sticky"].ToString()),
                    RA_com_slip = int.Parse(dataReader["ra_com_slip"].ToString()),
                    RA_renew_ring = int.Parse(dataReader["ra_renew_ring"].ToString()),
                    RA_break_wire_final_app = int.Parse(dataReader["ra_break_wire_final_app"].ToString()),
                    RA_wire_combine_wrong = int.Parse(dataReader["ra_wire_combine_wrong"].ToString()),
                    RA_core_ng = int.Parse(dataReader["ra_core_ng"].ToString()),
                    RA_segment_hole = int.Parse(dataReader["ra_segment_hole"].ToString()),
                    RA_glue_sticky = int.Parse(dataReader["ra_glue_sticky"].ToString()),
                    RA_loose_wire_final_app = int.Parse(dataReader["ra_loose_wire_final_app"].ToString()),
                    RA_lead_not_covered = int.Parse(dataReader["ra_lead_not_covered"].ToString()),
                    RA_less_lead = int.Parse(dataReader["ra_less_lead"].ToString()),

                    Rigs_wire_pb_sticky = int.Parse(dataReader["rigs_wire_pb_sticky"].ToString()),
                    Rigs_com_pb_sticky = int.Parse(dataReader["rigs_com_pb_sticky"].ToString()),
                    Rigs_ring_prone = int.Parse(dataReader["rigs_ring_prone"].ToString()),
                    Rigs_cracked_ring = int.Parse(dataReader["rigs_cracked_ring"].ToString()),

                    Pbs_break_copper = int.Parse(dataReader["pbs_break_copper"].ToString()),
                    Pbs_climb_core = int.Parse(dataReader["pbs_climb_core"].ToString()),
                    Pbs_skip_edge = int.Parse(dataReader["pbs_skip_edge"].ToString()),
                    Pbs_wire_combine_wrong = int.Parse(dataReader["pbs_wire_combine_wrong"].ToString()),
                    Pbs_loose_wire = int.Parse(dataReader["pbs_loose_wire"].ToString()),
                    Pbs_rizer_edge_ng = int.Parse(dataReader["pbs_rizer_edge_ng"].ToString()),
                    Pbs_core_ng = int.Parse(dataReader["pbs_core_ng"].ToString()),
                    Pbs_com_slip = int.Parse(dataReader["pbs_com_slip"].ToString()),
                    Pbs_hole = int.Parse(dataReader["pbs_hole"].ToString()),
                    Pbs_2_sleeve = int.Parse(dataReader["pbs_2_sleeve"].ToString()),
                    Pbs_wire_pb_sticky = int.Parse(dataReader["pbs_wire_pb_sticky"].ToString()),
                    Pbs_com_pb_sticky = int.Parse(dataReader["pbs_com_pb_sticky"].ToString()),
                    Pbs_no_lead = int.Parse(dataReader["pbs_no_lead"].ToString()),

                    We_com_slip = int.Parse(dataReader["we_com_slip"].ToString()),
                    We_long_shaft = int.Parse(dataReader["we_long_shaft"].ToString()),
                    We_short_shaft = int.Parse(dataReader["we_short_shaft"].ToString()),

                    Wi_break_copper_mc = int.Parse(dataReader["wi_break_copper_mc"].ToString()),
                    Wi_ruffle_copper_mc = int.Parse(dataReader["wi_ruffle_copper_mc"].ToString()),
                    Wi_edge_ng_mc = int.Parse(dataReader["wi_edge_ng_mc"].ToString()),
                    Wi_no_sleeve_mc = int.Parse(dataReader["wi_no_sleeve_mc"].ToString()),

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
