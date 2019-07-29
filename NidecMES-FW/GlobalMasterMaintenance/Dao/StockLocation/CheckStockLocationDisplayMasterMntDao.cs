using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckStockLocationDisplayMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            StockLocationVo inVo = (StockLocationVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as DisplayCount from m_stock_location");
            sqlQuery.Append(" where factory_cd = :factcd ");
            sqlQuery.Append(" and display_order = :displayorder");


            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);
                     
                sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
        

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            StockLocationVo outVo = null;

            while (dataReader.Read())
            {
                outVo = new StockLocationVo();
                outVo.AffectedCount = Convert.ToInt32(dataReader["DisplayCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
