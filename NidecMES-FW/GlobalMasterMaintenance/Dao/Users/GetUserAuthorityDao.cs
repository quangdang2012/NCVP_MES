using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetUserAuthorityDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            UserRoleVo inVo = (UserRoleVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select mu.user_cd, mu.user_name, rac.authority_control_cd");
            sqlQuery.Append(" from m_mes_user_role mur ");
            sqlQuery.Append(" inner join m_mes_user mu on mur.user_cd = mu.user_cd ");
            sqlQuery.Append(" inner join m_mes_role mr on mur.role_cd = mr.role_cd ");
            sqlQuery.Append(" inner join m_role_authority_control rac on rac.role_cd = mr.role_cd");
            sqlQuery.Append(" inner join m_authority_control ac on rac.authority_control_cd = ac.authority_control_cd ");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.RoleCode != null)
            {
                sqlQuery.Append(" and mur.role_cd = :rolecd ");
            }

            if (inVo.UserCode != null)
            {
                sqlQuery.Append(" and mur.user_cd = :usercd ");
            }
            sqlQuery.Append(" order by mu.user_cd");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.RoleCode != null)
            {
                sqlParameter.AddParameterString("rolecd", inVo.RoleCode);
            }

            if (inVo.UserCode != null)
            {
                sqlParameter.AddParameterString("usercd", inVo.UserCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            UserRoleVo outVo = new UserRoleVo();

            while (dataReader.Read())
            {
                UserRoleVo currOutVo = new UserRoleVo
                {
                    AuthorityControlCode = dataReader["authority_control_cd"].ToString(),
                    UserCode = dataReader["user_cd"].ToString(),
                    UserName = dataReader["user_name"].ToString()
                };

                outVo.UserRoleListVo.Add(currOutVo);

            }

            dataReader.Close();

            return outVo;
        } 
    }
}
