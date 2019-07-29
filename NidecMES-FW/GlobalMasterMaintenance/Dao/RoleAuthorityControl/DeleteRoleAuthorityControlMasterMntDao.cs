using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteRoleAuthorityControlMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            RoleAuthorityControlVo inVo = (RoleAuthorityControlVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete from m_role_authority_control");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" authority_control_cd = :authcd ");
            sqlQuery.Append(" and ");
            sqlQuery.Append(" role_cd = :rolecd ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("authcd", inVo.AuthorityControlCode);
            sqlParameter.AddParameterString("rolecd", inVo.RoleCode);

            RoleAuthorityControlVo outVo = new RoleAuthorityControlVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
