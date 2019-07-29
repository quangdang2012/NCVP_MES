using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckAuthorityControlRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AuthorityControlVo inVo = (AuthorityControlVo)arg;

            AuthorityControlVo outVo = new AuthorityControlVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("select count(rac.role_cd) as RoleCount from m_authority_control ac");
            sqlQuery.Append(" inner join m_role_authority_control rac on rac.authority_control_cd = ac.authority_control_cd");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.AuthorityControlCode != null)
            {
                sqlQuery.Append(" and UPPER(ac.authority_control_cd) = UPPER(:authcontcd) ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.AuthorityControlCode != null)
            {
                sqlParameter.AddParameterString("authcontcd", inVo.AuthorityControlCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            outVo.AffectedCount = 0;

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32("0" + dataReader["RoleCount"].ToString());
            }

            dataReader.Close();

            return outVo;
        }
 
    }
}
