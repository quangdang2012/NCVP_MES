using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteUserRoleMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            UserRoleVo inVo = (UserRoleVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete from m_mes_user_role");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" user_cd = :usercd ");
            sqlQuery.Append(" and ");
            sqlQuery.Append(" role_cd = :rolecd ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("usercd", inVo.UserCode);
            sqlParameter.AddParameterString("rolecd", inVo.RoleCode);

            UserRoleVo outVo = new UserRoleVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
