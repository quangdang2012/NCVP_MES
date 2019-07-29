using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchProDetailAllLineFinal_AppNCVCDao : AbstractDataAccessObject
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
            sql.Append("times between '00:00:00' and '05:59:00' then dates+1 end datesss, model_cd,'All Line' line_cd, sum(fc_endplay_small) fc_endplay_small, ");
            sql.Append("sum(fc_endplay_big) fc_endplay_big, sum(fc_shaft_scracth) fc_shaft_scracth ,");
            sql.Append("sum(fc_terminal_low) fc_terminal_low, sum(fc_case_scracth_dirty) fc_case_scracth_dirty, ");
            sql.Append("sum(fc_pinion_worm_ng) fc_pinion_worm_ng,  ");
            sql.Append("sum(fc_shaft_lock) fc_shaft_lock, sum(fc_ba_deform) fc_ba_deform, ");
            sql.Append("sum(fc_tape_hole_deform) fc_tape_hole_deform, sum(fc_brush_rust) fc_brush_rust, ");
            sql.Append("sum(fc_metal_deform_scracth) fc_metal_deform_scracth, sum(fc_washer_tape_hole ) fc_washer_tape_hole from ");
            sql.Append("(select i2.dates,i2.times,i2.model_cd,i2.line_cd, fc_endplay_small, fc_endplay_big, fc_shaft_scracth, fc_terminal_low, fc_case_scracth_dirty, fc_pinion_worm_ng,  fc_shaft_lock, fc_ba_deform, fc_tape_hole_deform, fc_brush_rust, fc_metal_deform_scracth, fc_washer_tape_hole  from t_ncvc_pdc_fc i2 left join (select dates, line_cd, Case when idca3 is null then idca1 else idca3 end id  from(select tblca1.dates, tblca1.line_cd, idca1, idca3  from(select line_cd, o.dates, max(o.fc_id) idca1  from t_ncvc_pdc_fc o where o.times > '06:00:00' and o.times <= '23:59:00' and o.dates >= :datefrom and o.dates <= :dateto group by o.dates, line_cd order by dates) tblca1 left join(select line_cd, (o.dates - 1) dates, max(o.fc_id) idca3  from t_ncvc_pdc_fc o  where o.times > '00:00:00' and o.times <= '05:30:00' and o.dates > :datefrom and o.dates - 1 <= :dateto group by line_cd, o.dates order by idca3) tblca3 on tblca1.dates = tblca3.dates and tblca1.line_cd = tblca3.line_cd) tbl  order by dates, line_cd) l on l.line_cd = i2.line_cd  where i2.fc_id = l.id order by i2.dates,i2.line_cd ) t where model_cd= :model_cd group by datesss,model_cd order by datesss");

            
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

                    FC_endplay_small = int.Parse(dataReader["fc_endplay_small"].ToString()),
                    FC_endplay_big = int.Parse(dataReader["fc_endplay_big"].ToString()),
                    FC_shaft_scracth = int.Parse(dataReader["fc_shaft_scracth"].ToString()),
                    FC_terminal_low = int.Parse(dataReader["fc_terminal_low"].ToString()),
                    FC_case_scracth_dirty = int.Parse(dataReader["fc_case_scracth_dirty"].ToString()),
                    FC_pinion_worm_ng = int.Parse(dataReader["fc_pinion_worm_ng"].ToString()),
                    FC_shaft_lock = int.Parse(dataReader["fc_shaft_lock"].ToString()),
                    FC_deform = int.Parse(dataReader["fc_ba_deform"].ToString()),
                    FC_tape_hole_deform = int.Parse(dataReader["fc_tape_hole_deform"].ToString()),
                    FC_brush_rust = int.Parse(dataReader["fc_brush_rust"].ToString()),
                    FC_metal_deform_scracth = int.Parse(dataReader["fc_metal_deform_scracth"].ToString()),
                    FC_washer_tape_hole = int.Parse(dataReader["fc_washer_tape_hole"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
