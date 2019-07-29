using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailEn1NCVCDao : AbstractDataAccessObject
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

            sql.Append(@"select (e1.dates+e1.times) datetimes, e1.model_cd,e1.line_cd, e1.process_cd, ");
            sql.Append("en1_insulation_resistace_ng, en1_cut_coil_wire, en1_lock, en1_wareform_ma_abnormal, en1_shaft_bent, en1_ripple, en1_short, en1_chattering, en1_no_load_current_high, en1_vibration_ng, en1_open, en1_rotor_mix ");
            sql.Append("from t_ncvc_pdc_en1 e1 ");
            sql.Append("where e1.line_cd = :line_cd ");
            sql.Append("and e1.dates = :dates ");
            sql.Append("and (e1.times in(select min(times) from t_ncvc_pdc_en1 where times between '06:00:00' and '06:55:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd ) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '06:00:00' and '07:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '07:00:00' and '08:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '08:00:00' and '09:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '09:00:00' and '10:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '10:00:00' and '11:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '11:00:00' and '12:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '12:00:00' and '13:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '13:00:00' and '14:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '14:00:00' and '15:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '15:00:00' and '16:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '16:00:00' and '17:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '17:00:00' and '18:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '18:00:00' and '19:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '19:00:00' and '20:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '20:00:00' and '21:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '21:00:00' and '22:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '22:00:00' and '23:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");

            sql.Append("or e1.dates-1 =:dates and e1.line_cd = :line_cd ");
            sql.Append("and (e1.times in(select min(times) from t_ncvc_pdc_en1 where times between '00:00:00' and '00:55:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '00:00:00' and '01:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '01:00:00' and '02:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '02:00:00' and '03:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '03:00:00' and '04:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '04:00:00' and '05:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or e1.times in(select max(times) from t_ncvc_pdc_en1 where times between '05:00:00' and '05:35:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");


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
                    TimeHour = DateTime.Parse(dataReader["datetimes"].ToString()),
                    ProModel = dataReader["model_cd"].ToString(),
                    ProLine = dataReader["line_cd"].ToString(),

                    En1_insulation_resistace_ng = int.Parse(dataReader["en1_insulation_resistace_ng"].ToString()),
                    En1_cut_coil_wire = int.Parse(dataReader["en1_cut_coil_wire"].ToString()),
                    En1_lock = int.Parse(dataReader["en1_lock"].ToString()),
                    En1_wareform_ma_abnormal = int.Parse(dataReader["en1_wareform_ma_abnormal"].ToString()),
                    En1_shaft_bent = int.Parse(dataReader["en1_shaft_bent"].ToString()),
                    En1_ripple = int.Parse(dataReader["en1_ripple"].ToString()),
                    En1_short = int.Parse(dataReader["en1_short"].ToString()),
                    En1_chattering = int.Parse(dataReader["en1_chattering"].ToString()),
                    En1_no_load_current_high = int.Parse(dataReader["en1_no_load_current_high"].ToString()),
                    En1_vibration_ng = int.Parse(dataReader["en1_vibration_ng"].ToString()),
                    En1_open = int.Parse(dataReader["en1_open"].ToString()),
                    En1_rotor_mix = int.Parse(dataReader["en1_rotor_mix"].ToString()),

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
