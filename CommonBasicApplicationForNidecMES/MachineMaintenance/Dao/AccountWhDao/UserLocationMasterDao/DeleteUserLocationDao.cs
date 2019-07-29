using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class DeleteUserLocationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            UserLocationVo inVo = (UserLocationVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  m_user_location Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.UserLocationId > 0)
            {
                sql.Append(" and user_location_id = :user_location_id ");
                sqlParameter.AddParameterInteger("user_location_id", inVo.UserLocationId);
            }
            if (!string.IsNullOrEmpty(inVo.UserLocationCode))
            {
                sql.Append(" and user_location_cd = :user_location_cd ");
                sqlParameter.AddParameterString("user_location_cd", inVo.UserLocationCode);
            }
            if (!string.IsNullOrEmpty(inVo.UserLocationName))
            {
                sql.Append(" and user_location_name = :user_location_name ");
                sqlParameter.AddParameterString("user_location_name", inVo.UserLocationName);
            }

           

            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            UserLocationVo outVo = new UserLocationVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
