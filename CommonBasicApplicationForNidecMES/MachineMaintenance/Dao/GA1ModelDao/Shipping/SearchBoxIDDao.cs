using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchBoxIDDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            GA1ModelVo voList = new GA1ModelVo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select boxid, printdate, user_cd as User, shipdate, child_model from t_box_id where 1 = 1");

            if (inVo.Format)
            {
                sql.Append(" and printdate >= '" + inVo.PrintDate.ToString("yyyy/MM/dd") + " 00:00:00' and printdate < '" + inVo.PrintDate.ToString("yyyy/MM/dd") + " 23:59:59'");
                //sqlParameter.AddParameter("printdate", inVo.PrintDate.ToString("yyyy/MM/dd"));
                //sqlParameter.AddParameterDateTime("printdate1", inVo.PrintDate.AddDays(1));
            }
            else
            {
                sql.Append(" and shipdate >= '" + inVo.ShipDate.ToString("yyyy/MM/dd") + " 00:00:00' and shipdate < '" + inVo.ShipDate.ToString("yyyy/MM/dd") + " 23:59:59'");
                //sql.Append(@" and shipdate >= :shipdate and shipdate < :shipdate1");
                //sqlParameter.AddParameterDateTime("shipdate", inVo.ShipDate);
                //sqlParameter.AddParameterDateTime("shipdate1", inVo.ShipDate.AddDays(1));
            }

            sql.Append(@" order by boxid");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DataSet ds = new DataSet();
            ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);
            //execute SQL
            //IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            GA1ModelVo outVo = new GA1ModelVo
            {
                dt = ds.Tables[0]
            };

            return outVo;
        }
    }
}