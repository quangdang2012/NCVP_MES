using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchBoxIDProDao : AbstractDataAccessObject
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
            sql.Append("select a.boxid as BoxID, a.printdate as PrintDate, a.user_cd as User, a.shipdate as ShipDate from t_box_id a left join t_product_serial b on b.boxid = a.boxid where 1 = 1");

            sql.Append(" and b.serialno >= :serialno");
            sqlParameter.AddParameterString("serialno", inVo.A90Barcode);

            sql.Append(@" order by a.boxid");

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