using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class UpdateWareHouseMainDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            WareHouseMainVo inVo = (WareHouseMainVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update t_warehouse_main set user_location_id =:user_location_id,
                                           qty =:qty,  
unit_id =:unit_id,

account_code_id =:account_code_id,
account_location_id =:account_location_id,
rank_id =:rank_id,
before_location_id =:before_location_id,
after_location_id =:after_location_id,
detail_position_id =:detail_position_id,
comment_data =:comment_data,
depreciation_start = :depreciation_start,
depreciation_end =:depreciation_end,
current_depreciation =:current_depreciation,
monthly_depreciation =:monthly_depreciation,
accum_depreciation_now =:accum_depreciation_now,
net_value =:net_value,
registration_user_cd =:registration_user_cd,
registration_date_time =:registration_date_time,
factory_cd =:factory_cd ");

            sql.Append(" where warehouse_main_id =:warehouse_main_id");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("warehouse_main_id", inVo.WareHouseMainId);
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
            sqlParameter.AddParameter("before_location_id", inVo.BeforeLocationId);
            sqlParameter.AddParameter("after_location_id", inVo.AfterLocationId);
            sqlParameter.AddParameter("detail_position_id", inVo.DetailPositionId);
            sqlParameter.AddParameter("user_location_id", inVo.UserLocationId);
            sqlParameter.AddParameter("registration_user_cd", inVo.RegistrationUserCode);
            sqlParameter.AddParameter("registration_date_time", inVo.RegistrationDateTime);
            sqlParameter.AddParameter("factory_cd", inVo.FactoryCode);


            //execute SQL

            WareHouseMainVo outVo = new WareHouseMainVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }

    }
}