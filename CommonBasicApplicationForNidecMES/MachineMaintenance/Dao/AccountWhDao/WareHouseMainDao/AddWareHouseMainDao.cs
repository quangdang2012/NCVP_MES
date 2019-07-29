using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class AddWareHouseMainDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            WareHouseMainVo inVo = (WareHouseMainVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"insert into t_warehouse_main(asset_id, qty, unit_id, account_code_id, account_location_id, rank_id, comment_data, 
                        depreciation_start, depreciation_end, current_depreciation,   monthly_depreciation, 
                        accum_depreciation_now, net_value, user_location_id,  before_location_id, after_location_id,  detail_position_id, registration_user_cd, registration_date_time, factory_cd, invertory_time_id)");
            sql.Append(@"values(:asset_id, :qty,:unit_id, :account_code_id, :account_location_id, :rank_id, :comment_data, 
                        :depreciation_start, :depreciation_end, :current_depreciation,   :monthly_depreciation, 
                        :accum_depreciation_now, :net_value,  :user_location_id, :before_location_id, :after_location_id,:detail_position_id, :registration_user_cd,:registration_date_time, :factory_cd, :invertory_time_id)");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            
            sqlParameter.AddParameter("asset_id", inVo.AssetId);
            sqlParameter.AddParameter("qty", inVo.QTY);
            sqlParameter.AddParameter("unit_id", inVo.UnitId);
            sqlParameter.AddParameter("account_code_id", inVo.AccountCodeId);
            sqlParameter.AddParameter("account_location_id", inVo.AccountLocationId);
            sqlParameter.AddParameter("rank_id", inVo.RankId);
            sqlParameter.AddParameter("comment_data", inVo.CommnetsData);
            sqlParameter.AddParameter("depreciation_start", inVo.StartDepreciation);
            sqlParameter.AddParameter("depreciation_end", inVo.EndDepreciation);
            sqlParameter.AddParameter("current_depreciation", inVo.CurrentDepreciation);
            sqlParameter.AddParameter("monthly_depreciation", inVo.MonthlyDepreciation);
            sqlParameter.AddParameter("accum_depreciation_now", inVo.AccumDepreciation);
            sqlParameter.AddParameter("net_value", inVo.NetValue);
          //  sqlParameter.AddParameter("location_id", inVo.LocationId);
            sqlParameter.AddParameter("before_location_id", inVo.BeforeLocationId);
            sqlParameter.AddParameter("after_location_id", inVo.AfterLocationId);
            sqlParameter.AddParameter("user_location_id", inVo.UserLocationId);
            sqlParameter.AddParameter("detail_position_id", inVo.DetailPositionId);
            sqlParameter.AddParameter("registration_user_cd", inVo.RegistrationUserCode);
            sqlParameter.AddParameter("registration_date_time", inVo.RegistrationDateTime);
            sqlParameter.AddParameter("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameter("invertory_time_id", inVo.InvertoryId);
            //execute SQL

            WareHouseMainVo outVo = new WareHouseMainVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
