using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetAccountCodeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountCodeVo inVo = (AccountCodeVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<AccountCodeVo> voList = new ValueObjectList<AccountCodeVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select account_code_id, account_code_cd, account_code_name, registration_user_cd,registration_date_time,factory_cd from  m_account_code");
            sql.Append(" Where 1=1 ");
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
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                AccountCodeVo outVo = new AccountCodeVo
                {
                    AccountCodeId = int.Parse(dataReader["account_code_id"].ToString()),
                    AccountCodeCode = dataReader["account_code_cd"].ToString(),                    
                    AccountCodeName =dataReader["account_code_name"].ToString(),                
                    RegistrationUserCode = dataReader["registration_user_cd"].ToString(),
                    RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    FactoryCode = dataReader["factory_cd"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
