using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetRoleMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            RoleVo inVo = (RoleVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select * from m_mes_role ");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.RoleCode != null)
            {
                sqlQuery.Append(" and role_cd like :rolecd ");
            }

            if (inVo.RoleName != null)
            {
                sqlQuery.Append(" and role_name like :rolename ");
            }
            sqlQuery.Append(" order by role_cd");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.RoleCode != null)
            {
                sqlParameter.AddParameterString("rolecd", inVo.RoleCode + "%");
            }

            if (inVo.RoleName != null)
            {
                sqlParameter.AddParameterString("rolename", inVo.RoleName + "%");
            }

            sqlQuery.Append(" order by role_cd");

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            RoleVo outVo = new RoleVo();

            while (dataReader.Read())
            {

                RoleVo currOutVo = new RoleVo
                {
                    RoleCode = dataReader["role_cd"].ToString(),
                    RoleName = dataReader["role_name"].ToString()
                };
               outVo.RoleListVo.Add(currOutVo);

            }

            dataReader.Close();

            return outVo;
        } 
    }
}
