using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateAccountCodeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountCodeVo inVo = (AccountCodeVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update m_account_code set account_code_cd=:account_code_cd,account_code_name=:account_code_name");
            sql.Append(" where account_code_id =:account_code_id");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("account_code_id", inVo.AccountCodeId);
            sqlParameter.AddParameterString("account_code_cd", inVo.AccountCodeCode);
            sqlParameter.AddParameterString("account_code_name", inVo.AccountCodeName);
            sqlParameter.AddParameterDateTime("registration_date_time", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            AccountCodeVo outVo = new AccountCodeVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
