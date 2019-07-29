using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddStockLocationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            StockLocationVo inVo = (StockLocationVo)arg;

            StockLocationVo outVo = new StockLocationVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_stock_location");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" stock_location_code, ");
            sqlQuery.Append(" stock_location_name, ");
            sqlQuery.Append(" display_order, ");
            sqlQuery.Append(" location_type, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :stocklocationcode ,");
            sqlQuery.Append(" :stocklocationname ,");
            sqlQuery.Append(" :Displayorder ,");
            sqlQuery.Append(" :locationtype ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now() ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ) ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("stocklocationcode", inVo.StockLocationCode);
            sqlParameter.AddParameterString("stocklocationname", inVo.StockLocationName);
            sqlParameter.AddParameterInteger("Displayorder", inVo.DisplayOrder);
            sqlParameter.AddParameterInteger("locationtype", inVo.LocationType);
            sqlParameter.AddParameterString("registrationusercode", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);

            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
