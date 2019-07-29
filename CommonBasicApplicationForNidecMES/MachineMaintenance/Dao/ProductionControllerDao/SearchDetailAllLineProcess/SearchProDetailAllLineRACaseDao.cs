using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailAllLineRACaseDao : AbstractDataAccessObject
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

            sql.Append(@"select Case When times between '06:00:00' and '23:59:00' then dates when ");
            sql.Append("times between '00:00:00' and '05:59:00' then dates+1 end datesss,'LA459' model_cd,'All Line' line_cd, sum(ra_com_pb_sticky) ra_com_pb_sticky, ");
            sql.Append("sum(ra_wire_pb_sticky) ra_wire_pb_sticky, sum(ra_com_slip) ra_com_slip ,");
            sql.Append("sum(ra_renew_ring) ra_renew_ring, sum(ra_break_wire_final_app) ra_break_wire_final_app, ");
            sql.Append("sum(ra_wire_combine_wrong) ra_wire_combine_wrong,  ");
            sql.Append("sum(ra_core_ng) ra_core_ng, sum(ra_segment_hole) ra_segment_hole, ");
            sql.Append("sum(ra_glue_sticky) ra_glue_sticky, sum(ra_loose_wire_final_app) ra_loose_wire_final_app, ");
            sql.Append("sum(ra_lead_not_covered) ra_lead_not_covered,");
            sql.Append("sum(ra_less_lead) ra_less_lead from ");

            sql.Append("(select i2.dates,i2.times,i2.line_cd, ra_com_pb_sticky, ra_wire_pb_sticky, ra_com_slip, ra_renew_ring, ra_break_wire_final_app, ra_wire_combine_wrong, ra_core_ng, ra_segment_hole, ra_glue_sticky, ra_loose_wire_final_app, ra_lead_not_covered, ra_less_lead from t_productioncontroller_output01 i2 left join (select dates, line_cd, Case when idca3 is null then idca1 else idca3 end id  from(select tblca1.dates, tblca1.line_cd, idca1, idca3  from(select line_cd, o.dates, max(o.output01_id) idca1  from t_productioncontroller_output01 o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.output01_id) idca3  from t_productioncontroller_output01 o  where o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl  order by dates, line_cd) l on l.line_cd = i2.line_cd  where i2.output01_id = l.id order by i2.dates,i2.line_cd ) t group by datesss order by datesss");

            
            sqlParameter.AddParameterDateTime("datefrom", DateTime.Parse(inVo.DateFrom));
            sqlParameter.AddParameterDateTime("dateto", DateTime.Parse(inVo.DateTo));
            //sqlParameter.AddParameterString("model_cd", inVo.ProModel);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerVo outVo = new ProductionControllerVo
                {
                    //StartDay = DateTime.Parse(dataReader["dates"].ToString()),
                    TimeHour = DateTime.Parse(dataReader["datesss"].ToString()),
                    ProModel = dataReader["model_cd"].ToString(),
                    ProLine = dataReader["line_cd"].ToString(),

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

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
