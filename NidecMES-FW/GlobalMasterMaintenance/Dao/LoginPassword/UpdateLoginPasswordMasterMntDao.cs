using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateLoginPasswordMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            UserVo inVo = (UserVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_login_password");
            sqlQuery.Append(" Set password = :password ");
            sqlQuery.Append(" Where	user_cd = :usercode ");           

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter= sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("password", inVo.PassWord);
            sqlParameter.AddParameterString("usercode", inVo.UserCode);

            UserVo outVo = new UserVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo; 
        }
    }
}
