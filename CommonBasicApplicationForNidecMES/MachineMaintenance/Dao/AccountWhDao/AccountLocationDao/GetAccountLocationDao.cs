using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetAccountLocationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountLocationVo inVo = (AccountLocationVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<AccountLocationVo> voList = new ValueObjectList<AccountLocationVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select account_location_id, account_location_cd, account_location_name, account_location_type, registration_user_cd,registration_date_time,factory_cd from  m_account_location");
            sql.Append(" Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.AccountLocationId > 0)
            {
                sql.Append(" and account_location_id = :account_location_id ");
                sqlParameter.AddParameterInteger("account_location_id", inVo.AccountLocationId);
            }
            if (!string.IsNullOrEmpty(inVo.AccountLocationCode))
            {
                sql.Append(" and account_location_cd = :account_location_cd ");
                sqlParameter.AddParameterString("account_location_cd", inVo.AccountLocationCode);
            }
            if (!string.IsNullOrEmpty(inVo.AccountLocationName))
            {
                sql.Append(" and account_location_name = :account_location_name ");
                sqlParameter.AddParameterString("account_location_name", inVo.AccountLocationName);
            }
           

            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                AccountLocationVo outVo = new AccountLocationVo
                {
                    AccountLocationId = int.Parse(dataReader["account_location_id"].ToString()),
                    AccountLocationCode = dataReader["account_location_cd"].ToString(),                    
                    AccountLocationName =dataReader["account_location_name"].ToString(),
                    AccountLocationType = dataReader["account_location_type"].ToString(),
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
