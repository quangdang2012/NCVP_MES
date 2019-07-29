using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddAccountLocationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountLocationVo inVo = (AccountLocationVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into m_account_location(account_location_cd, account_location_name, account_location_type, registration_user_cd, registration_date_time, factory_cd) ");
            sql.Append("values(:account_location_cd,:account_location_name,:account_location_type,  :registration_user_cd,now(),:factory_cd)");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("account_location_cd", inVo.AccountLocationCode);
            sqlParameter.AddParameterString("account_location_name", inVo.AccountLocationName);
            sqlParameter.AddParameterString("account_location_type", inVo.AccountLocationType);
           // sqlParameter.AddParameterDateTime("registration_user_cd", inVo.RegistrationDateTime);
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
