using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckUserRelationDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            UserVo inVo = (UserVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select us.user_cd,Count(ur.role_cd) as RoleCount, Count(uf.factory_cd) as FactoryCount");
            //sqlQuery.Append(" Count(up.process_id) as ProcessCount");
            sqlQuery.Append(" from m_mes_user us");
            sqlQuery.Append(" left outer join m_mes_user_role ur on ur.user_cd = us.user_cd");
            sqlQuery.Append(" left outer join m_user_factory uf on uf.user_cd = us.user_cd");
            //sqlQuery.Append(" left outer join m_user_process up on up.user_cd = us.user_cd");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.UserCode != null)
            {
                sqlQuery.Append(" and UPPER(us.user_cd) = UPPER(:usercode) ");
            }

            sqlQuery.Append("group by us.user_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.UserCode != null)
            {
                sqlParameter.AddParameterString("usercode", inVo.UserCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            UserVo outVo = new UserVo();

            while (dataReader.Read())
            {
                outVo.RoleCount = Convert.ToInt32("0" + dataReader["RoleCount"]);
                outVo.FactoryCount = Convert.ToInt32("0" + dataReader["FactoryCount"]);
                //outVo.ProcessCount = Convert.ToInt32("0" + dataReader["ProcessCount"]);
            }

            dataReader.Close();

            return outVo; 
        }
    }
}
