using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchProductionOUTPUTDao : AbstractDataAccessObject
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
            //string sqlChung = " times,count(*)  from (select a90_barcode, a90_date+a90_time datetimes from t_checkpusha90 where a90_thurst_status = 'OK' and  a90_date+a90_time >= :datefrom and a90_date+a90_time <= :dateto) wl where datetimes >= ";

            string sqlChung = " times,count(*)  from (select a.a90_barcode,a.datetimes,a.a90_thurst_status from (select row_number() over(partition by a90_barcode order by a90_date+a90_time) id, a90_barcode,a90_date+a90_time datetimes,a90_thurst_status from t_checkpusha90 where a90_date+a90_time >= :datefrom and a90_date+a90_time <= :dateto and a90_line = :line and a90_model = :a90_model order by a90_barcode,datetimes) a,(select max(id) id,a90_barcode from (select row_number() over(partition by a90_barcode order by a90_date+a90_time) id, a90_barcode,a90_date+a90_time datetimes,a90_thurst_status from t_checkpusha90 where a90_date+a90_time >= :datefrom and a90_date+a90_time <= :dateto and a90_line = :line and a90_model = :a90_model order by a90_barcode,datetimes) b group by a90_barcode) b where a.id = b.id and a.a90_barcode = b.a90_barcode and a.a90_barcode != '' ";
            sqlParameter.AddParameter("a90_model", inVo.ModelCode);
            sqlParameter.AddParameter("line", inVo.LineCode);
            if (inVo.change) { sqlChung += " and a.a90_thurst_status = 'OK' "; }
            else { sqlChung += " and a.a90_thurst_status = 'NG' "; }
            sqlChung += ") tbl where datetimes >= ";

            sql.Append(@"select '01:00:00' " + sqlChung + " '" + inVo.Date + " 00:00:01' and datetimes <= '" + inVo.Date + " 01:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '02:00:00' " + sqlChung + " '" + inVo.Date + " 01:00:01' and datetimes <= '" + inVo.Date + " 02:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '03:00:00' " + sqlChung + " '" + inVo.Date + " 02:00:01' and datetimes <= '" + inVo.Date + " 03:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '04:00:00' " + sqlChung + " '" + inVo.Date + " 03:00:01' and datetimes <= '" + inVo.Date + " 04:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '05:00:00' " + sqlChung + " '" + inVo.Date + " 04:00:01' and datetimes <= '" + inVo.Date + " 05:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '06:00:00' " + sqlChung + " '" + inVo.Date + " 05:00:01' and datetimes <= '" + inVo.Date + " 06:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '07:00:00' " + sqlChung + " '" + inVo.Date + " 06:00:01' and datetimes <= '" + inVo.Date + " 07:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '08:00:00' " + sqlChung + " '" + inVo.Date + " 07:00:01' and datetimes <= '" + inVo.Date + " 08:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '09:00:00' " + sqlChung + " '" + inVo.Date + " 08:00:01' and datetimes <= '" + inVo.Date + " 09:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '10:00:00' " + sqlChung + " '" + inVo.Date + " 09:00:01' and datetimes <= '" + inVo.Date + " 10:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '11:00:00' " + sqlChung + " '" + inVo.Date + " 10:00:01' and datetimes <= '" + inVo.Date + " 11:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '12:00:00' " + sqlChung + " '" + inVo.Date + " 11:00:01' and datetimes <= '" + inVo.Date + " 12:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '13:00:00' " + sqlChung + " '" + inVo.Date + " 12:00:01' and datetimes <= '" + inVo.Date + " 13:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '14:00:00' " + sqlChung + " '" + inVo.Date + " 13:00:01' and datetimes <= '" + inVo.Date + " 14:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '15:00:00' " + sqlChung + " '" + inVo.Date + " 14:00:01' and datetimes <= '" + inVo.Date + " 15:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '16:00:00' " + sqlChung + " '" + inVo.Date + " 15:00:01' and datetimes <= '" + inVo.Date + " 16:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '17:00:00' " + sqlChung + " '" + inVo.Date + " 16:00:01' and datetimes <= '" + inVo.Date + " 17:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '18:00:00' " + sqlChung + " '" + inVo.Date + " 17:00:01' and datetimes <= '" + inVo.Date + " 18:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '19:00:00' " + sqlChung + " '" + inVo.Date + " 18:00:01' and datetimes <= '" + inVo.Date + " 19:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '20:00:00' " + sqlChung + " '" + inVo.Date + " 19:00:01' and datetimes <= '" + inVo.Date + " 20:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '21:00:00' " + sqlChung + " '" + inVo.Date + " 20:00:01' and datetimes <= '" + inVo.Date + " 21:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '22:00:00' " + sqlChung + " '" + inVo.Date + " 21:00:01' and datetimes <= '" + inVo.Date + " 22:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '23:00:00' " + sqlChung + " '" + inVo.Date + " 22:00:01' and datetimes <= '" + inVo.Date + " 23:00:00'");
            sql.Append(" union ");
            sql.Append(@"select '23:59:59' " + sqlChung + " '" + inVo.Date + " 23:00:01' and datetimes <= '" + inVo.Date + " 23:59:59'");

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