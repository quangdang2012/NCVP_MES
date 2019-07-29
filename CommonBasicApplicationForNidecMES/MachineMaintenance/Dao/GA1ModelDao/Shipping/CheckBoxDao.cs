using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class CheckBoxDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select serial_short, boxid FROM product_serial_printdate WHERE printdate BETWEEN '" + System.DateTime.Today.AddDays(-7) + "' AND '" + System.DateTime.Today.AddDays(1) + "'");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            DataSet ds = new DataSet();
            ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            GA1ModelVo outVo = new GA1ModelVo
            {
                dt = ds.Tables[0]
            };

            return outVo;
        }
    }
}