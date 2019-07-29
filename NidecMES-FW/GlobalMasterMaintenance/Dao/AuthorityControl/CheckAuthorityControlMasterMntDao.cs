using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckAuthorityControlMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AuthorityControlVo inVo = (AuthorityControlVo)arg;

            AuthorityControlVo outVo = new AuthorityControlVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as AuthCount from m_authority_control ");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.AuthorityControlCode != null)
            {
                sqlQuery.Append(" and UPPER(authority_control_cd) = UPPER(:authcontcd) ");
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
                outVo.AffectedCount = Convert.ToInt32(dataReader["AuthCount"].ToString());
            }

            dataReader.Close();

            return outVo;
        }
 
    }
}
