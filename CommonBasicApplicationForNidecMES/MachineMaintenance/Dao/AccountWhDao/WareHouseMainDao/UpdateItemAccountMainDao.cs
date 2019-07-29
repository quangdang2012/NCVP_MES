using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class UpdateItemAccountMainDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountMainVo inVo = (AccountMainVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update t_account_main set rank_id =:rank_id,
location_id =:location_id,
user_location_id =:user_location_id,
registration_user_cd =:registration_user_cd,
registration_date_time= :registration_date_time");

            sql.Append(" where asset_id =:asset_id");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            //sqlParameter.AddParameter("asset_id", inVo.AcountMainId);
            sqlParameter.AddParameter("asset_id", inVo.AssetId);
            sqlParameter.AddParameter("rank_id", inVo.RankId);
            sqlParameter.AddParameter("location_id", inVo.LocationId);
            sqlParameter.AddParameter("user_location_id", inVo.UserLocationId);
            sqlParameter.AddParameter("registration_user_cd", inVo.RegistrationUserCode);
            sqlParameter.AddParameter("registration_date_time", inVo.RegistrationDateTime);

            //execute SQL

            AccountMainVo outVo = new AccountMainVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }

    }
}