using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class DeleteAccountCodeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountCodeVo inVo = (AccountCodeVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  m_account_code Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.AccountCodeId > 0)
            {
                sql.Append(" and account_code_id = :account_code_id ");
                sqlParameter.AddParameterInteger("account_code_id", inVo.AccountCodeId);
            }
            if (!string.IsNullOrEmpty(inVo.AccountCodeCode))
            {
                sql.Append(" and account_code_cd = :account_code_cd ");
                sqlParameter.AddParameterString("account_code_cd", inVo.AccountCodeCode);
            }
            if (!string.IsNullOrEmpty(inVo.AccountCodeName))
            {
                sql.Append(" and account_code_name = :account_code_name ");
                sqlParameter.AddParameterString("account_code_name", inVo.AccountCodeName);
            }

           

            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            AccountCodeVo outVo = new AccountCodeVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
