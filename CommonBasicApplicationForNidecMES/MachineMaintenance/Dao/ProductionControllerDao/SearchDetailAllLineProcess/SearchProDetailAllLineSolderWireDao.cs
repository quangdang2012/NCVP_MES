using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailAllLineSolderWireDao : AbstractDataAccessObject
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
            sql.Append("times between '00:00:00' and '05:59:00' then dates+1 end datesss,'LA459' model_cd,'All Line' line_cd, sum(pbs_break_copper) pbs_break_copper, ");
            sql.Append("sum(pbs_climb_core) pbs_climb_core, sum(pbs_skip_edge) pbs_skip_edge ,");
            sql.Append("sum(pbs_wire_combine_wrong) pbs_wire_combine_wrong, sum(pbs_loose_wire) pbs_loose_wire, ");
            sql.Append("sum(pbs_rizer_edge_ng) pbs_rizer_edge_ng,  ");
            sql.Append("sum(pbs_core_ng) pbs_core_ng, sum(pbs_com_slip) pbs_com_slip, ");
            sql.Append("sum(pbs_hole) pbs_hole, sum(pbs_2_sleeve) pbs_2_sleeve, ");
            sql.Append("sum(pbs_wire_pb_sticky) pbs_wire_pb_sticky, sum(pbs_com_pb_sticky ) pbs_com_pb_sticky, ");
            sql.Append("sum(pbs_no_lead) pbs_no_lead from ");

            sql.Append("(select i2.dates,i2.times,i2.line_cd, pbs_break_copper, pbs_climb_core, pbs_skip_edge, pbs_wire_combine_wrong, pbs_loose_wire, pbs_rizer_edge_ng, pbs_core_ng, pbs_com_slip, pbs_hole, pbs_2_sleeve, pbs_wire_pb_sticky, pbs_com_pb_sticky, pbs_no_lead from t_productioncontroller_input02 i2 left join (select dates, line_cd, Case when idca3 is null then idca1 else idca3 end id  from(select tblca1.dates, tblca1.line_cd, idca1, idca3  from(select line_cd, o.dates, max(o.input02_id) idca1  from t_productioncontroller_input02 o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.input02_id) idca3  from t_productioncontroller_input02 o  where o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl  order by dates, line_cd) l on l.line_cd = i2.line_cd  where i2.input02_id = l.id order by i2.dates,i2.line_cd ) t group by datesss order by datesss");

            
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

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
