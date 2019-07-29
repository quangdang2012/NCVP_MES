using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckRoleMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            RoleVo inVo = (RoleVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as RoleCount from m_mes_role ");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.RoleCode != null)
            {
                sqlQuery.Append(" and UPPER(role_cd) = UPPER(:rolecd)");
            }
           
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
                outVo.AffectedCount = Convert.ToInt32(dataReader["RoleCount"]);
            }

            dataReader.Close();

            return outVo;
        } 
    }
}
