using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailAllLineEn2NCVCDao : AbstractDataAccessObject
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
            sql.Append("times between '00:00:00' and '05:59:00' then dates+1 end datesss, model_cd,'All Line' line_cd, sum(en2_insulation_resistance_ng) en2_insulation_resistance_ng, ");
            sql.Append("sum(en2_cut_coil_wire) en2_cut_coil_wire, sum(en2_no_load_current_hight) en2_no_load_current_hight ,");

            sql.Append("sum(en2_ripple) en2_ripple, sum(en2_chattering) en2_chattering, ");

            sql.Append("sum(en2_lock) en2_lock, ");
            sql.Append("sum(en2_open) en2_open, sum(en2_no_load_speed_low) en2_no_load_speed_low, ");
            sql.Append("sum(en2_starting_voltage) en2_starting_voltage, sum(en2_no_load_speed_high) en2_no_load_speed_high, ");
            sql.Append("sum(en2_rotor_mix) en2_rotor_mix, sum(en2_surge_volt_max ) en2_surge_volt_max, ");
            sql.Append("sum(en2_wrong_post_of_pole) en2_wrong_post_of_pole, sum(en2_err ) en2_err, sum(en2_noise) en2_noise from ");

            sql.Append("(select i2.dates,i2.times,i2.model_cd,i2.line_cd, en2_insulation_resistance_ng, en2_cut_coil_wire, en2_no_load_current_hight, en2_ripple, en2_chattering, en2_lock, en2_open, en2_no_load_speed_low, en2_starting_voltage,  en2_no_load_speed_high, en2_rotor_mix, en2_surge_volt_max, en2_wrong_post_of_pole, en2_err, en2_noise from t_ncvc_pdc_en2 i2 left join (select dates, line_cd, Case when idca3 is null then idca1 else idca3 end id  from(select tblca1.dates, tblca1.line_cd, idca1, idca3  from(select line_cd, o.dates, max(o.en2_id) idca1  from t_ncvc_pdc_en2 o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.en2_id) idca3  from t_ncvc_pdc_en2 o  where o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl  order by dates, line_cd) l on l.line_cd = i2.line_cd  where i2.en2_id = l.id order by i2.dates,i2.line_cd ) t where model_cd = :model_cd group by datesss,model_cd order by datesss");

            
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
