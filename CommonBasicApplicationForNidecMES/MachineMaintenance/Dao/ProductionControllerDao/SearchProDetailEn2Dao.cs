using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailEn2Dao : AbstractDataAccessObject
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

            sql.Append(@"select (o4.dates+o4.times) datetimes, o4.model_cd,o4.line_cd, o4.process_cd, ");
            sql.Append("en2_lock, en2_cut, en2_chattering, en2_insulation, en2_open, en2_short, en2_duty,  ");
            sql.Append("en2_no, en2_var, en2_reverse_spinning, en2_starting_volt, en2_io ");
            sql.Append("from t_productioncontroller_output03 o4 ");
            sql.Append("where o4.line_cd = :line_cd ");
            sql.Append("and o4.dates = :dates ");
            sql.Append("and (o4.times in(select min(times) from t_productioncontroller_output03 where times between '06:00:00' and '06:55:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd ) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '06:00:00' and '07:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '07:00:00' and '08:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '08:00:00' and '09:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '09:00:00' and '10:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '10:00:00' and '11:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '11:00:00' and '12:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '12:00:00' and '13:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '13:00:00' and '14:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '14:00:00' and '15:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '15:00:00' and '16:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '16:00:00' and '17:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '17:00:00' and '18:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '18:00:00' and '19:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '19:00:00' and '20:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '20:00:00' and '21:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '21:00:00' and '22:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '22:00:00' and '23:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");

            sql.Append("or o4.dates-1 =:dates and o4.line_cd = :line_cd ");
            sql.Append("and (o4.times in(select min(times) from t_productioncontroller_output03 where times between '00:00:00' and '00:55:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '00:00:00' and '01:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '01:00:00' and '02:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '02:00:00' and '03:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '03:00:00' and '04:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '04:00:00' and '05:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or o4.times in(select max(times) from t_productioncontroller_output03 where times between '05:00:00' and '05:35:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");


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

                    //StartDay = DateTime.Parse(dataReader["dates"].ToString()),
                    TimeHour = DateTime.Parse(dataReader["datetimes"].ToString()),
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
