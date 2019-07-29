using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckAccountCodeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountCodeVo inVo = (AccountCodeVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as AccountCount ");
            sql.Append(" from  m_account_code");
            sql.Append(" Where 1=1 ");
    
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (!string.IsNullOrEmpty(inVo.AccountCodeCode))
            {
                sql.Append(" and UPPER(account_code_cd) = UPPER(:account_code_cd) ");
                sqlParameter.AddParameterString("account_code_cd", inVo.AccountCodeCode);
            }
            if (inVo.AccountCodeId > 0)
            {
                sql.Append(" and account_code_id != :account_code_id "); ///?????
                sqlParameter.AddParameterInteger("account_code_id", inVo.AccountCodeId);
            }
          

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            AccountCodeVo outVo = new AccountCodeVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["AccountCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
