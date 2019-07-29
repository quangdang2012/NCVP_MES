using System.Text;
using System.Data;

namespace Com.Nidec.Mes.Framework.Login
{
    public class ChangePasswordDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            ChangePasswordVo inVo = (ChangePasswordVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_login_password");
            sqlQuery.Append(" Set password = :password ");
            sqlQuery.Append(" Where	user_cd = :usercode ");           

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter= sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("password", inVo.Password);
            sqlParameter.AddParameterString("usercode", inVo.UserCode);

            ChangePasswordVo outVo = new ChangePasswordVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo; 
        }
    }
}
