using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailBracketMetalNCVCDao : AbstractDataAccessObject
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

            sql.Append(@"select (ba.dates+ba.times) datetimes, ba.model_cd,ba.line_cd, ba.process_cd, ");
            sql.Append("ba_bm_brush_deform_scracth, ba_bm_metal_deform_scracth, ba_bm_ba_deform, ba_bm_endplay_deform_scracth ");
            sql.Append("from t_ncvc_pdc_ba ba ");
            sql.Append("where ba.line_cd = :line_cd ");
            sql.Append("and ba.dates = :dates ");
            sql.Append("and (ba.times in(select min(times) from t_ncvc_pdc_ba where times between '06:00:00' and '06:55:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd ) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '06:00:00' and '07:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '07:00:00' and '08:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '08:00:00' and '09:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '09:00:00' and '10:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '10:00:00' and '11:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '11:00:00' and '12:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '12:00:00' and '13:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '13:00:00' and '14:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '14:00:00' and '15:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '15:00:00' and '16:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '16:00:00' and '17:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '17:00:00' and '18:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '18:00:00' and '19:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '19:00:00' and '20:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '20:00:00' and '21:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '21:00:00' and '22:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '22:00:00' and '23:05:00' and dates = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");

            sql.Append("or ba.dates-1 =:dates and ba.line_cd = :line_cd ");
            sql.Append("and (ba.times in(select min(times) from t_ncvc_pdc_ba where times between '00:00:00' and '00:55:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '00:00:00' and '01:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '01:00:00' and '02:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '02:00:00' and '03:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '03:00:00' and '04:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '04:00:00' and '05:05:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd) ");
            sql.Append("or ba.times in(select max(times) from t_ncvc_pdc_ba where times between '05:00:00' and '05:35:00' and dates-1 = :dates and line_cd = :line_cd and model_cd = :model_cd)) ");


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

                    BA_bm_brush_deform_scracth = int.Parse(dataReader["ba_bm_brush_deform_scracth"].ToString()),
                    BA_bm_metal_deform_scracth = int.Parse(dataReader["ba_bm_metal_deform_scracth"].ToString()),
                    BA_bm_deform = int.Parse(dataReader["ba_bm_ba_deform"].ToString()),
                    BA_bm_endplay_deform_scracth = int.Parse(dataReader["ba_bm_endplay_deform_scracth"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
