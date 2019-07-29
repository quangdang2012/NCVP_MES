using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteCustomerLineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CustomerLineVo inVo = (CustomerLineVo)arg;      

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_customer_line");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" line_id = :lineid ");
            sqlQuery.Append(" and factory_cd = :factorycode ");
            if (inVo.CustomerId > 0)
            {
                sqlQuery.Append(" and customer_id = :customerid");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);
            if (inVo.CustomerId > 0)
            {
                sqlParameter.AddParameterInteger("customerid", inVo.CustomerId);
            }

            CustomerLineVo outVo = new CustomerLineVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
