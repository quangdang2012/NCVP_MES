using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteUserMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            UserVo inVo = (UserVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete from m_mes_user");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" user_cd = :usercode ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("usercode", inVo.UserCode);

            UserVo outVo = new UserVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo; 
        }
    }
}
