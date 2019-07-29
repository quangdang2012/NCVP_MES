using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailEn2NCVCDao : AbstractDataAccessObject
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

            sql.Append(@"select (e2.dates+e2.times) datetimes, e2.model_cd,e2.line_cd, e2.process_cd, ");
            sql.Append("en2_insulation_resistance_ng, en2_cut_coil_wire, en2_no_load_current_hight, en2_ripple, en2_chattering,  en2_lock, en2_open, en2_no_load_speed_low, en2_starting_voltage, en2_no_load_speed_high, en2_rotor_mix, en2_surge_volt_max, en2_wrong_post_of_pole, en2_err, en2_noise ");
            sql.Append("from t_ncvc_pdc_en2 e2 ");
            sql.Append("where e2.line_cd = :line_cd ");
            sql.Append("and e2.dates = :dates ");
            sql.Append("and (e2.times in(select min(times) from t_ncvc_pdc_en2 where times between '06:00:00' and '06:55:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd ) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '06:00:00' and '07:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '07:00:00' and '08:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '08:00:00' and '09:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '09:00:00' and '10:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '10:00:00' and '11:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '11:00:00' and '12:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '12:00:00' and '13:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '13:00:00' and '14:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '14:00:00' and '15:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '15:00:00' and '16:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '16:00:00' and '17:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '17:00:00' and '18:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '18:00:00' and '19:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '19:00:00' and '20:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '20:00:00' and '21:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '21:00:00' and '22:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '22:00:00' and '23:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");

            sql.Append("or e2.dates-1 =:dates and e2.line_cd = :line_cd ");
            sql.Append("and (e2.times in(select min(times) from t_ncvc_pdc_en2 where times between '00:00:00' and '00:55:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '00:00:00' and '01:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '01:00:00' and '02:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '02:00:00' and '03:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '03:00:00' and '04:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '04:00:00' and '05:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e2.times in(select max(times) from t_ncvc_pdc_en2 where times between '05:00:00' and '05:35:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");


            sqlParameter.AddParameterString("line_cd", inVo.ProLine);
            sqlParameter.AddParameterDateTime("dates", DateTime.Parse(inVo.Date));
            sqlParameter.AddParameterString("model_cd", inVo.ProModel);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerNCVCVo outVo = new ProductionControllerNCVCVo
                {

                    //StartDay = DateTime.Parse(dataReader["dates"].ToString()),
                    TimeHour = DateTime.Parse(dataReader["datetimes"].ToString()),
                    ProModel = dataReader["model_cd"].ToString(),
                    ProLine = dataReader["line_cd"].ToString(),

                    En2_insulation_resistance_ng = int.Parse(dataReader["en2_insulation_resistance_ng"].ToString()),
                    En2_cut_coil_wire = int.Parse(dataReader["en2_cut_coil_wire"].ToString()),
                    En2_no_load_current_hight = int.Parse(dataReader["en2_no_load_current_hight"].ToString()),
                    En2_ripple = int.Parse(dataReader["en2_ripple"].ToString()),
                    En2_chattering = int.Parse(dataReader["en2_chattering"].ToString()),
                    En2_lock = int.Parse(dataReader["en2_lock"].ToString()),
                    En2_open = int.Parse(dataReader["en2_open"].ToString()),
                    En2_no_load_speed_low = int.Parse(dataReader["en2_no_load_speed_low"].ToString()),
                    En2_starting_voltage = int.Parse(dataReader["en2_starting_voltage"].ToString()),
                    En2_no_load_speed_high = int.Parse(dataReader["en2_no_load_speed_high"].ToString()),
                    En2_rotor_mix = int.Parse(dataReader["en2_rotor_mix"].ToString()),
                    En2_surge_volt_max = int.Parse(dataReader["en2_surge_volt_max"].ToString()),
                    En2_wrong_post_of_pole = int.Parse(dataReader["en2_wrong_post_of_pole"].ToString()),
                    En2_err = int.Parse(dataReader["en2_err"].ToString()),
                    En2_noise = int.Parse(dataReader["en2_noise"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
