using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddCustomerLineMasterMntNewDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CustomerLineVo inVo = (CustomerLineVo)arg;
            CustomerLineVo outVo = new CustomerLineVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_customer_line");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" customer_id, ");
            sqlQuery.Append(" line_id, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :customerid ,");
            sqlQuery.Append(" :lineid ,");
            sqlQuery.Append(" :registrationusercd ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");


            foreach (CustomerLineVo curVo in inVo.customerLineListVo)
            {
                //create command
                DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

                //create parameter
                DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

                sqlParameter.AddParameterInteger("customerid", curVo.CustomerId);
                sqlParameter.AddParameterInteger("lineid", inVo.LineId);
                sqlParameter.AddParameterString("registrationusercd", UserData.GetUserData().UserCode);
                sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
                sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);

                outVo.AffectedCount += sqlCommandAdapter.ExecuteNonQuery(sqlParameter);
            }

            return outVo;
        }
    }
}
