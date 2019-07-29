using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateAccountLocationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountLocationVo inVo = (AccountLocationVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update m_account_location set account_location_cd=:account_location_cd,account_location_name=:account_location_name, account_location_type =:account_location_type");
            sql.Append(" where account_location_id =:account_location_id");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("account_location_id", inVo.AccountLocationId);
            sqlParameter.AddParameterString("account_location_cd", inVo.AccountLocationCode);
            sqlParameter.AddParameterString("account_location_name", inVo.AccountLocationName);
            sqlParameter.AddParameterString("account_location_type", inVo.AccountLocationType);
            sqlParameter.AddParameterDateTime("registration_date_time", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            AccountLocationVo outVo = new AccountLocationVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
