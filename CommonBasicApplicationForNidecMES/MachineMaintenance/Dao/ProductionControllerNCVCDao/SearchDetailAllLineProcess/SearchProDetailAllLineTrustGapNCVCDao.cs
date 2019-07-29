using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailAllLineTrustGapNCVCDao : AbstractDataAccessObject
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

            sql.Append(@"select Case When times between '06:00:00' and '23:59:00' then dates when ");
            sql.Append("times between '00:00:00' and '05:59:00' then dates+1 end datesss, model_cd,'All Line' line_cd, sum(ba_tc_endplay_big) ba_tc_endplay_big, ");
            sql.Append("sum(ba_tc_endplay_small) ba_tc_endplay_small, sum(ba_tc_brush_bent) ba_tc_brush_bent ,");
            sql.Append("sum(ba_tc_shaft_mix) ba_tc_shaft_mix from ");

            sql.Append("(select i2.dates,i2.times,i2.model_cd,i2.line_cd, ba_tc_endplay_big, ba_tc_endplay_small, ba_tc_brush_bent, ba_tc_shaft_mix from t_ncvc_pdc_ba i2 left join (select dates, line_cd, Case when idca3 is null then idca1 else idca3 end id  from(select tblca1.dates, tblca1.line_cd, idca1, idca3  from(select line_cd, o.dates, max(o.ba_id) idca1  from t_ncvc_pdc_ba o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.ba_id) idca3  from t_ncvc_pdc_ba o  where o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl  order by dates, line_cd) l on l.line_cd = i2.line_cd  where i2.ba_id = l.id order by i2.dates,i2.line_cd ) t where model_cd = :model_cd group by datesss,model_cd order by datesss");

            
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
                    TimeHour = DateTime.Parse(dataReader["datesss"].ToString()),
                    ProModel = dataReader["model_cd"].ToString(),
                    ProLine = dataReader["line_cd"].ToString(),

                    BA_tc_endplay_big = int.Parse(dataReader["ba_tc_endplay_big"].ToString()),
                    BA_tc_endplay_small = int.Parse(dataReader["ba_tc_endplay_small"].ToString()),
                    BA_tc_brush_bent = int.Parse(dataReader["ba_tc_brush_bent"].ToString()),
                    BA_tc_shaft_mix = int.Parse(dataReader["ba_tc_shaft_mix"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
