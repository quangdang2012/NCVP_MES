using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckUserLocationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            UserLocationVo inVo = (UserLocationVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as UserLocationCount ");
            sql.Append(" from  m_user_location");
            sql.Append(" Where 1=1 ");
    
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (!string.IsNullOrEmpty(inVo.UserLocationCode))
            {
                sql.Append(" and UPPER(user_location_cd) = UPPER(:user_location_cd) ");
                sqlParameter.AddParameterString("user_location_cd", inVo.UserLocationCode);
            }
            if (inVo.UserLocationId > 0)
            {
                sql.Append(" and user_location_id != :user_location_id "); ///?????
                sqlParameter.AddParameterInteger("user_location_id", inVo.UserLocationId);
            }
          

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            UserLocationVo outVo = new UserLocationVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["UserLocationCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
