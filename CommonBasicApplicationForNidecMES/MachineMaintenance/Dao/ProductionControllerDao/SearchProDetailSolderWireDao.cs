using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailSolderWireDao : AbstractDataAccessObject
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

            sql.Append(@"select (i2.dates+i2.times) datetimes, i2.model_cd,i2.line_cd, i2.process_cd, ");
            sql.Append("pbs_break_copper, pbs_climb_core, pbs_skip_edge, pbs_wire_combine_wrong, pbs_loose_wire,  pbs_rizer_edge_ng, ");
            sql.Append("pbs_core_ng, pbs_com_slip,  pbs_hole, pbs_2_sleeve, pbs_wire_pb_sticky, pbs_com_pb_sticky, pbs_no_lead ");
            sql.Append("from t_productioncontroller_input02 i2 ");
            sql.Append("where i2.line_cd = :line_cd ");
            sql.Append("and i2.dates = :dates ");
            sql.Append("and (i2.times in(select min(times) from t_productioncontroller_input02 where times between '06:00:00' and '06:55:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd ) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '06:00:00' and '07:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '07:00:00' and '08:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '08:00:00' and '09:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '09:00:00' and '10:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '10:00:00' and '11:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '11:00:00' and '12:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '12:00:00' and '13:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '13:00:00' and '14:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '14:00:00' and '15:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '15:00:00' and '16:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '16:00:00' and '17:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '17:00:00' and '18:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '18:00:00' and '19:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '19:00:00' and '20:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '20:00:00' and '21:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '21:00:00' and '22:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '22:00:00' and '23:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");

            sql.Append("or i2.dates-1 =:dates and i2.line_cd = :line_cd ");
            sql.Append("and (i2.times in(select min(times) from t_productioncontroller_input02 where times between '00:00:00' and '00:55:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '00:00:00' and '01:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '01:00:00' and '02:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '02:00:00' and '03:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '03:00:00' and '04:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '04:00:00' and '05:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or i2.times in(select max(times) from t_productioncontroller_input02 where times between '05:00:00' and '05:35:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");


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
