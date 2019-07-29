using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailAllLineAppCheckDao : AbstractDataAccessObject
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
            sql.Append("times between '00:00:00' and '05:59:00' then dates+1 end datesss,'LA459' model_cd,'All Line' line_cd, sum(fiapp_stamping_ba) fiapp_stamping_ba, ");
            sql.Append("sum(fiapp_case_set) fiapp_case_set, sum(fiapp_tough_shaft) fiapp_tough_shaft ,");
            sql.Append("sum(fiapp_case_glue_sticky) fiapp_case_glue_sticky, sum(fiapp_up_low_shabby) fiapp_up_low_shabby, ");
            sql.Append("sum(fiapp_hole_shaft) fiapp_hole_shaft,  ");
            sql.Append("sum(fiapp_no_beat_prone_case) fiapp_no_beat_prone_case, sum(fiapp_hole_case) fiapp_hole_case, ");
            sql.Append("sum(fiapp_prone_case) fiapp_prone_case, sum(fiapp_lot_ng) fiapp_lot_ng, ");
            sql.Append("sum(fiapp_ter_deform) fiapp_ter_deform, sum(fiapp_hole_ter ) fiapp_hole_ter, ");
            sql.Append("sum(fiapp_soder_hl) fiapp_soder_hl, sum(fiapp_metal_oven_low) fiapp_metal_oven_low,  ");
            sql.Append("sum(fiapp_fundou_ng) fiapp_fundou_ng, sum(fiapp_ter_glue_sticky) fiapp_ter_glue_sticky, ");
            sql.Append("sum(fiapp_lead_glue_sticky) fiapp_lead_glue_sticky from ");

            sql.Append("(select i2.dates,i2.times,i2.line_cd, fiapp_stamping_ba ,  fiapp_case_set, fiapp_tough_shaft, fiapp_case_glue_sticky, fiapp_up_low_shabby, fiapp_hole_shaft, fiapp_no_beat_prone_case,  fiapp_hole_case, fiapp_prone_case, fiapp_lot_ng, fiapp_ter_deform, fiapp_hole_ter, fiapp_soder_hl, fiapp_metal_oven_low, fiapp_fundou_ng,  fiapp_ter_glue_sticky, fiapp_lead_glue_sticky  from t_productioncontroller_output04 i2 left join (select dates, line_cd, Case when idca3 is null then idca1 else idca3 end id  from(select tblca1.dates, tblca1.line_cd, idca1, idca3  from(select line_cd, o.dates, max(o.output04_id) idca1  from t_productioncontroller_output04 o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.output04_id) idca3  from t_productioncontroller_output04 o  where o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl  order by dates, line_cd) l on l.line_cd = i2.line_cd  where i2.output04_id = l.id order by i2.dates,i2.line_cd ) t group by datesss order by datesss");

            
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

                    App_stamping_ba = int.Parse(dataReader["fiapp_stamping_ba"].ToString()),
                    App_case_set = int.Parse(dataReader["fiapp_case_set"].ToString()),
                    App_tough_shaft = int.Parse(dataReader["fiapp_tough_shaft"].ToString()),
                    App_case_glue_sticky = int.Parse(dataReader["fiapp_case_glue_sticky"].ToString()),
                    App_up_low_shabby = int.Parse(dataReader["fiapp_up_low_shabby"].ToString()),
                    App_hole_shaft = int.Parse(dataReader["fiapp_hole_shaft"].ToString()),
                    App_no_beat_prone_case = int.Parse(dataReader["fiapp_no_beat_prone_case"].ToString()),
                    App_hole_case = int.Parse(dataReader["fiapp_hole_case"].ToString()),
                    App_prone_case = int.Parse(dataReader["fiapp_prone_case"].ToString()),
                    App_lot_ng = int.Parse(dataReader["fiapp_lot_ng"].ToString()),
                    App_ter_deform = int.Parse(dataReader["fiapp_ter_deform"].ToString()),
                    App_hole_ter = int.Parse(dataReader["fiapp_hole_ter"].ToString()),
                    App_soder_hl = int.Parse(dataReader["fiapp_soder_hl"].ToString()),
                    App_metal_oven_low = int.Parse(dataReader["fiapp_metal_oven_low"].ToString()),
                    App_fundou_ng = int.Parse(dataReader["fiapp_fundou_ng"].ToString()),
                    App_ter_glue_sticky = int.Parse(dataReader["fiapp_ter_glue_sticky"].ToString()),
                    App_lead_glue_sticky = int.Parse(dataReader["fiapp_lead_glue_sticky"].ToString()),

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
