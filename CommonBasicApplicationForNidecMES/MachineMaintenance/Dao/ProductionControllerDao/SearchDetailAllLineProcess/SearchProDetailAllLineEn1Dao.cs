using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailAllLineEn1Dao : AbstractDataAccessObject
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
            sql.Append("times between '00:00:00' and '05:59:00' then dates+1 end datesss,'LA459' model_cd,'All Line' line_cd, sum(en1_lock) en1_lock, ");
            sql.Append("sum(en1_cut) en1_cut, sum(en1_chattering) en1_chattering ,");
            sql.Append("sum(en1_insulation) en1_insulation, sum(en1_open) en1_open, ");
            sql.Append("sum(en1_bad_wave) en1_bad_wave,  ");
            sql.Append("sum(en1_duty) en1_duty, sum(en1_short) en1_short, ");
            sql.Append("sum(en1_beat_case_ng) en1_beat_case_ng, sum(en1_beat_fundou_ng) en1_beat_fundou_ng from ");

            sql.Append("(select i2.dates,i2.times,i2.line_cd, en1_lock, en1_cut, en1_chattering, en1_insulation, en1_open, en1_bad_wave, en1_duty, en1_short, en1_beat_case_ng, en1_beat_fundou_ng from t_productioncontroller_output02 i2 left join (select dates, line_cd, Case when idca3 is null then idca1 else idca3 end id  from(select tblca1.dates, tblca1.line_cd, idca1, idca3  from(select line_cd, o.dates, max(o.output02_id) idca1  from t_productioncontroller_output02 o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.output02_id) idca3  from t_productioncontroller_output02 o  where o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl  order by dates, line_cd) l on l.line_cd = i2.line_cd  where i2.output02_id = l.id order by i2.dates,i2.line_cd ) t group by datesss order by datesss");

            
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

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
