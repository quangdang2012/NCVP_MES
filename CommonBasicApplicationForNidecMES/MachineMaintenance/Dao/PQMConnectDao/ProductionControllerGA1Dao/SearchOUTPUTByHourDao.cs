using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchOUTPUTByHourDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProductionControllerGA1Vo inVo = (ProductionControllerGA1Vo)vo;
            StringBuilder sql = new StringBuilder();
            ProductionControllerGA1Vo voList = new ProductionControllerGA1Vo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            //string sqlChung = " times,count(*)  from (select a90_barcode, a90_date+a90_time regist_date from t_checkpusha90 where a90_thurst_status = 'OK' and  a90_date+a90_time >= :datefrom and a90_date+a90_time <= :dateto) wl where regist_date >= ";

            string sqlChung = " times, count(distinct barcode) from (select * from t_serno where regist_date >= :datefrom and regist_date <=:dateto) t where 1=1 ";
            if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sqlChung += " and model = :model";
                sqlParameter.AddParameter("model", inVo.ModelCode);
            }
            if (!string.IsNullOrEmpty(inVo.LineCode))
            {
                sqlChung += " and line = :line";
                sqlParameter.AddParameter("line", inVo.LineCode);
            }
            sqlChung += " and regist_date >=";

            sql.Append(@"select '01:00:00' " + sqlChung + " '" + inVo.Date + " 00:00:01' and regist_date <= '" + inVo.Date + " 01:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '02:00:00' " + sqlChung + " '" + inVo.Date + " 01:00:01' and regist_date <= '" + inVo.Date + " 02:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '03:00:00' " + sqlChung + " '" + inVo.Date + " 02:00:01' and regist_date <= '" + inVo.Date + " 03:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '04:00:00' " + sqlChung + " '" + inVo.Date + " 03:00:01' and regist_date <= '" + inVo.Date + " 04:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '05:00:00' " + sqlChung + " '" + inVo.Date + " 04:00:01' and regist_date <= '" + inVo.Date + " 05:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '06:00:00' " + sqlChung + " '" + inVo.Date + " 05:00:01' and regist_date <= '" + inVo.Date + " 06:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '07:00:00' " + sqlChung + " '" + inVo.Date + " 06:00:01' and regist_date <= '" + inVo.Date + " 07:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '08:00:00' " + sqlChung + " '" + inVo.Date + " 07:00:01' and regist_date <= '" + inVo.Date + " 08:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '09:00:00' " + sqlChung + " '" + inVo.Date + " 08:00:01' and regist_date <= '" + inVo.Date + " 09:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '10:00:00' " + sqlChung + " '" + inVo.Date + " 09:00:01' and regist_date <= '" + inVo.Date + " 10:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '11:00:00' " + sqlChung + " '" + inVo.Date + " 10:00:01' and regist_date <= '" + inVo.Date + " 11:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '12:00:00' " + sqlChung + " '" + inVo.Date + " 11:00:01' and regist_date <= '" + inVo.Date + " 12:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '13:00:00' " + sqlChung + " '" + inVo.Date + " 12:00:01' and regist_date <= '" + inVo.Date + " 13:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '14:00:00' " + sqlChung + " '" + inVo.Date + " 13:00:01' and regist_date <= '" + inVo.Date + " 14:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '15:00:00' " + sqlChung + " '" + inVo.Date + " 14:00:01' and regist_date <= '" + inVo.Date + " 15:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '16:00:00' " + sqlChung + " '" + inVo.Date + " 15:00:01' and regist_date <= '" + inVo.Date + " 16:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '17:00:00' " + sqlChung + " '" + inVo.Date + " 16:00:01' and regist_date <= '" + inVo.Date + " 17:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '18:00:00' " + sqlChung + " '" + inVo.Date + " 17:00:01' and regist_date <= '" + inVo.Date + " 18:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '19:00:00' " + sqlChung + " '" + inVo.Date + " 18:00:01' and regist_date <= '" + inVo.Date + " 19:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '20:00:00' " + sqlChung + " '" + inVo.Date + " 19:00:01' and regist_date <= '" + inVo.Date + " 20:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '21:00:00' " + sqlChung + " '" + inVo.Date + " 20:00:01' and regist_date <= '" + inVo.Date + " 21:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '22:00:00' " + sqlChung + " '" + inVo.Date + " 21:00:01' and regist_date <= '" + inVo.Date + " 22:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '23:00:00' " + sqlChung + " '" + inVo.Date + " 22:00:01' and regist_date <= '" + inVo.Date + " 23:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '23:59:59' " + sqlChung + " '" + inVo.Date + " 23:00:01' and regist_date <= '" + inVo.Date + " 23:59:59'");

            sql.Append(" order by times ");

            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);

            //if (!string.IsNullOrEmpty(inVo.LineCode))
            //{
            //    sql.Append(@" and a90_line  =:line");
            //    sqlParameter.AddParameterString("line", inVo.LineCode);
            //}
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DataSet ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            //execute SQL

            ProductionControllerGA1Vo outVo1 = new ProductionControllerGA1Vo
            {
                dt = ds.Tables[0],
            };

            return outVo1;

        }
    }
}