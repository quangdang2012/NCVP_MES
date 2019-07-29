using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class DeleteBoxIDDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;

            //Delete BoxID
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from t_box_id where boxid = :boxid");

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("boxid", inVo.BoxID);

            sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            //Delete Production
            StringBuilder sqlDelPro = new StringBuilder();
            sqlDelPro.Append("delete from t_product_serial where boxid = :boxid");

            DbCommandAdaptor sqlCommandAdapterDelPro = base.GetDbCommandAdaptor(trxContext, sqlDelPro.ToString());

            DbParameterList sqlParameterDelPro = sqlCommandAdapterDelPro.CreateParameterList();
            sqlParameterDelPro.AddParameter("boxid", inVo.BoxID);

            sqlCommandAdapterDelPro.ExecuteNonQuery(sqlParameterDelPro);

            GA1ModelVo outVo = new GA1ModelVo
            {
                AffectedCount = 1
            };

            return outVo;
        }
    }
}