using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateStockLocationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            StockLocationVo inVo = (StockLocationVo)arg;

            StockLocationVo outVo = new StockLocationVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_stock_location");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" stock_location_name = :stock_locationname, ");
            sqlQuery.Append(" location_type = :locationtype, ");
            sqlQuery.Append(" display_order = :displayorder ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" stock_location_id = :stock_locationid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("stock_locationid", inVo.StockLocationId);
            sqlParameter.AddParameterString("stock_locationname", inVo.StockLocationName);
            sqlParameter.AddParameterInteger("locationtype", inVo.LocationType);
            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            //execute SQL
            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
