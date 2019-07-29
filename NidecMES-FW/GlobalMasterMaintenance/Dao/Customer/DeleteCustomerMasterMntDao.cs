using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteCustomerMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CustomerVo inVo = (CustomerVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete from m_customer");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" customer_id = :cuid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("cuid", inVo.CustomerId);

            CustomerVo outVo = new CustomerVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo; 
        }
    }
}
