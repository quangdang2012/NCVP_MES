using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetRoleAuthorityControlMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            RoleAuthorityControlVo inVo = (RoleAuthorityControlVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select rac.role_cd,rac.authority_control_cd ");
            sqlQuery.Append("from m_role_authority_control rac ");
            sqlQuery.Append(" inner join m_mes_role ro  on rac.role_cd = ro.role_cd ");
            sqlQuery.Append(" inner join m_authority_control ac  on rac.authority_control_cd = ac.authority_control_cd ");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.RoleCode != null)
            {
                sqlQuery.Append(" and rac.role_cd = :rolecd ");
            }

            if (inVo.AuthorityControlCode != null)
            {
                sqlQuery.Append(" and rac.authority_control_cd = :authcd ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.RoleCode != null)
            {
                sqlParameter.AddParameterString("rolecd", inVo.RoleCode);
            }

            if (inVo.AuthorityControlCode != null)
            {
                sqlParameter.AddParameterString("authcd", inVo.AuthorityControlCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            RoleAuthorityControlVo outVo = new RoleAuthorityControlVo();

            while (dataReader.Read())
            {
                RoleAuthorityControlVo currOutVo = new RoleAuthorityControlVo
                {
                    RoleCode = dataReader["role_cd"].ToString(),
                    AuthorityControlCode = dataReader["authority_control_cd"].ToString()
                };
                outVo.RoleAuthorityControlListVo.Add(currOutVo);

            }

            dataReader.Close();

            return outVo;
        }
    }
}
