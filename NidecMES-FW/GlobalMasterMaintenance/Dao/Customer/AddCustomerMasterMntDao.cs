using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddCustomerMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CustomerVo inVo = (CustomerVo)arg;

            StringBuilder sqlQuery = new StringBuilder();
           
            sqlQuery.Append("Insert into m_customer");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" customer_cd, ");
            sqlQuery.Append(" customer_name,");
            sqlQuery.Append(" address1, ");
            sqlQuery.Append(" address2, ");
            sqlQuery.Append(" phone_no, ");
            sqlQuery.Append(" email, ");
            sqlQuery.Append(" remarks, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :cucode ,");
            sqlQuery.Append(" :cuname ,");
            sqlQuery.Append(" :add1 ,");
            sqlQuery.Append(" :add2 ,");
            sqlQuery.Append(" :phno ,");
            sqlQuery.Append(" :email ,");
            sqlQuery.Append(" :rem ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("cucode", inVo.CustomerCode);
            sqlParameter.AddParameterString("cuname", inVo.CustomerName);
            sqlParameter.AddParameterString("add1", inVo.Address1);
            sqlParameter.AddParameterString("add2", inVo.Address2);
            sqlParameter.AddParameterString("email", inVo.EmailId);
            sqlParameter.AddParameterString("rem", inVo.Remarks);
            sqlParameter.AddParameterString("phno ", inVo.PhoneNo);
            sqlParameter.AddParameterString("registrationusercode ", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime ", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode ", UserData.GetUserData().FactoryCode);

            CustomerVo outVo = new CustomerVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo; 
        }
    }
}
