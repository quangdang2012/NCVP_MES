using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchShipmentHistoryDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("select boxid, serno, model, ship_date, status from t_shipment_record where serno = '" + inVo.A90Barcode + "'");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            
            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            //sqlParameter.AddParameter("serno", inVo.A90Barcode);

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