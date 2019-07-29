using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckStockLocationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            StockLocationVo inVo = (StockLocationVo)arg;         

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as StockLocationCount from m_stock_location ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.StockLocationCode != null)
            {
                sqlQuery.Append(" and UPPER(stock_location_code) = UPPER(:stock_locationcd)");
            }
           
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.StockLocationCode != null)
            {
                sqlParameter.AddParameterString("stock_locationcd", inVo.StockLocationCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            StockLocationVo outVo = new StockLocationVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["StockLocationCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
