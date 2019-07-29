using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckAccountLocationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountLocationVo inVo = (AccountLocationVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as AccountLocationCount ");
            sql.Append(" from  m_account_location");
            sql.Append(" Where 1=1 ");
    
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (!string.IsNullOrEmpty(inVo.AccountLocationCode))
            {
                sql.Append(" and UPPER(account_location_cd) = UPPER(:account_location_cd) ");
                sqlParameter.AddParameterString("account_location_cd", inVo.AccountLocationCode);
            }
            if (inVo.AccountLocationId > 0)
            {
                sql.Append(" and account_location_id != :account_location_id "); ///?????
                sqlParameter.AddParameterInteger("account_location_id", inVo.AccountLocationId);
            }
          

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            AccountLocationVo outVo = new AccountLocationVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["AccountLocationCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
