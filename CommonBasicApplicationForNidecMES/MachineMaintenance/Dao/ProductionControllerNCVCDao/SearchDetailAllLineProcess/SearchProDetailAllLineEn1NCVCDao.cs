using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailAllLineEn1NCVCDao : AbstractDataAccessObject
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
            sql.Append("times between '00:00:00' and '05:59:00' then dates+1 end datesss, model_cd,'All Line' line_cd, sum(en1_insulation_resistace_ng) en1_insulation_resistace_ng, ");
            sql.Append("sum(en1_cut_coil_wire) en1_cut_coil_wire, sum(en1_lock) en1_lock ,");
            sql.Append("sum(en1_wareform_ma_abnormal) en1_wareform_ma_abnormal, sum(en1_shaft_bent) en1_shaft_bent, ");
            sql.Append("sum(en1_ripple) en1_ripple, sum(en1_short) en1_short,  ");
            sql.Append("sum(en1_chattering) en1_chattering, sum(en1_no_load_current_high) en1_no_load_current_high, ");
            sql.Append("sum(en1_vibration_ng) en1_vibration_ng, sum(en1_open) en1_open, sum(en1_rotor_mix) en1_rotor_mix from ");

            sql.Append("(select i2.dates,i2.times,i2.model_cd,i2.line_cd, en1_insulation_resistace_ng, en1_cut_coil_wire, en1_lock,en1_wareform_ma_abnormal, en1_shaft_bent,  en1_ripple,  en1_short, en1_chattering, en1_no_load_current_high, en1_vibration_ng, en1_open,  en1_rotor_mix from t_ncvc_pdc_en1 i2 left join (select dates, line_cd, Case when idca3 is null then idca1 else idca3 end id  from(select tblca1.dates, tblca1.line_cd, idca1, idca3  from(select line_cd, o.dates, max(o.en1_id) idca1  from t_ncvc_pdc_en1 o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.en1_id) idca3  from t_ncvc_pdc_en1 o  where o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl  order by dates, line_cd) l on l.line_cd = i2.line_cd  where i2.en1_id = l.id order by i2.dates,i2.line_cd ) t where model_cd = :model_cd group by datesss,model_cd order by datesss");

            
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
                    //StartDay = DateTime.Parse(dataReader["dates"].ToString()),
                    TimeHour = DateTime.Parse(dataReader["datesss"].ToString()),
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
                    En1_vibration_ng = int.Parse(dataReader["en1_vibration_ng"].ToString()),
                    En1_open = int.Parse(dataReader["en1_open"].ToString()),
                    En1_rotor_mix = int.Parse(dataReader["en1_rotor_mix"].ToString()),
                    En1_no_load_current_high = int.Parse(dataReader["en1_no_load_current_high"].ToString()),

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
