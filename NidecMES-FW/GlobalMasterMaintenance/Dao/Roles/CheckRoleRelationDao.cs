using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckRoleRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            RoleVo inVo = (RoleVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select ro.role_cd, Count(ur.user_cd) as UserCount, Count(rac.authority_control_cd) AuthCount");
            sqlQuery.Append(" from m_mes_role ro");
            sqlQuery.Append(" left outer join m_mes_user_role ur on ur.role_cd = ro.role_cd");
            sqlQuery.Append(" left outer join m_role_authority_control rac on rac.role_cd = ro.role_cd");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.RoleCode != null)
            {
                sqlQuery.Append(" and UPPER(ro.role_cd) = UPPER(:rolecd)");
            }

            sqlQuery.Append(" group by ro.role_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.RoleCode != null)
            {
                sqlParameter.AddParameterString("rolecd", inVo.RoleCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            RoleVo outVo = new RoleVo();

            while (dataReader.Read())
            {
                outVo.UserCount = Convert.ToInt32("0" + dataReader["UserCount"]);
                outVo.AuthorityCount = Convert.ToInt32("0" + dataReader["AuthCount"]);
            }

            dataReader.Close();

            return outVo;
        } 
    }
}
