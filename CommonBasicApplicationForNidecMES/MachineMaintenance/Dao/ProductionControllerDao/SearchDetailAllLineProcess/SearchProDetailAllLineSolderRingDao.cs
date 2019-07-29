using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailAllLineSolderRingDao : AbstractDataAccessObject
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
            sql.Append("times between '00:00:00' and '05:59:00' then dates+1 end datesss,'LA459' model_cd,'All Line' line_cd, sum(rigs_wire_pb_sticky) rigs_wire_pb_sticky, ");
            sql.Append("sum(rigs_com_pb_sticky) rigs_com_pb_sticky, sum(rigs_ring_prone) rigs_ring_prone ,");
            sql.Append("sum(rigs_cracked_ring) rigs_cracked_ring from ");

            sql.Append("(select i2.dates,i2.times,i2.line_cd, rigs_wire_pb_sticky, rigs_com_pb_sticky, rigs_ring_prone, rigs_cracked_ring from t_productioncontroller_input01 i2 left join (select dates, line_cd, Case when idca3 is null then idca1 else idca3 end id  from(select tblca1.dates, tblca1.line_cd, idca1, idca3  from(select line_cd, o.dates, max(o.input01_id) idca1  from t_productioncontroller_input01 o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.input01_id) idca3  from t_productioncontroller_input01 o  where o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl  order by dates, line_cd) l on l.line_cd = i2.line_cd  where i2.input01_id = l.id order by i2.dates,i2.line_cd ) t group by datesss order by datesss");

            
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

                    Rigs_wire_pb_sticky = int.Parse(dataReader["rigs_wire_pb_sticky"].ToString()),
                    Rigs_com_pb_sticky = int.Parse(dataReader["rigs_com_pb_sticky"].ToString()),
                    Rigs_ring_prone = int.Parse(dataReader["rigs_ring_prone"].ToString()),
                    Rigs_cracked_ring = int.Parse(dataReader["rigs_cracked_ring"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
