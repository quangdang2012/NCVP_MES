using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class DeleteAccountLocationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountLocationVo inVo = (AccountLocationVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  m_account_location Where 1=1 ");
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
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            AccountLocationVo outVo = new AccountLocationVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
