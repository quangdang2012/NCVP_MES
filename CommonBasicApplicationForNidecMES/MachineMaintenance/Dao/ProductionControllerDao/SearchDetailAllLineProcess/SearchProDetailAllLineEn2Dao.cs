using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailAllLineEn2Dao : AbstractDataAccessObject
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
            sql.Append("times between '00:00:00' and '05:59:00' then dates+1 end datesss,'LA459' model_cd,'All Line' line_cd, sum(en2_lock) en2_lock, ");
            sql.Append("sum(en2_cut) en2_cut, sum(en2_chattering) en2_chattering ,");
            sql.Append("sum(en2_insulation) en2_insulation, sum(en2_open) en2_open, ");
            sql.Append("sum(en2_short) en2_short, ");
            sql.Append("sum(en2_duty) en2_duty, sum(en2_no) en2_no, ");
            sql.Append("sum(en2_var) en2_var, sum(en2_reverse_spinning) en2_reverse_spinning, ");
            sql.Append("sum(en2_starting_volt) en2_starting_volt, sum(en2_io ) en2_io from ");

            sql.Append("(select i2.dates,i2.times,i2.line_cd, en2_lock, en2_cut, en2_chattering , en2_insulation , en2_open , en2_short , en2_duty , en2_no , en2_var , en2_reverse_spinning , en2_starting_volt ,  en2_io from t_productioncontroller_output03 i2 left join (select dates, line_cd, Case when idca3 is null then idca1 else idca3 end id  from(select tblca1.dates, tblca1.line_cd, idca1, idca3  from(select line_cd, o.dates, max(o.output03_id) idca1  from t_productioncontroller_output03 o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.output03_id) idca3  from t_productioncontroller_output03 o  where o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl  order by dates, line_cd) l on l.line_cd = i2.line_cd  where i2.output03_id = l.id order by i2.dates,i2.line_cd ) t group by datesss order by datesss");

            
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

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
