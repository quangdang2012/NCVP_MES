using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetDisplayOrderNextValForStockLocDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select  max(display_order)+1 display_order ");
            sqlQuery.Append(" from m_stock_location sl ");
            sqlQuery.Append(" where sl.factory_cd = :factcd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            StockLocationVo outVo = null;

            while (dataReader.Read())
            {
                outVo = new StockLocationVo();
                outVo.DisplayOrder = ConvertDBNull<int>(dataReader, "display_order");
            }
            dataReader.Close();

            return outVo;
        }
    }
}
