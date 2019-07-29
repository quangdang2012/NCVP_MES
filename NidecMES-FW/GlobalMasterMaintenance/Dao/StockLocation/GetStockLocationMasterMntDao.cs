using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetStockLocationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            StockLocationVo inVo = (StockLocationVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" Select li.stock_location_id, li.stock_location_code, li.stock_location_name, ");
            sqlQuery.Append(" CASE ");
            sqlQuery.Append(" WHEN location_type = 0 THEN 'Process' ");
            sqlQuery.Append(" WHEN location_type = 1 THEN 'Warehouse' ");          
            sqlQuery.Append(" END as locationtype, ");
            sqlQuery.Append(" display_order ");
            sqlQuery.Append(" from m_stock_location li ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.StockLocationCode != null)
            {
                sqlQuery.Append(" and stock_location_code like :stocklocationcd ");
            }

            if (inVo.StockLocationName != null)
            {
                sqlQuery.Append(" and stock_location_name like :stocklocationname ");
            }

            sqlQuery.Append(" order by stock_location_code ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.StockLocationCode != null)
            {
                sqlParameter.AddParameterString("stocklocationcd", inVo.StockLocationCode + "%");
            }

            if (inVo.StockLocationName != null)
            {
                sqlParameter.AddParameterString("stocklocationname", inVo.StockLocationName + "%");
            }         

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<StockLocationVo> outVo = null;

            while (dataReader.Read())
            {
                if (outVo == null)
                {
                    outVo = new ValueObjectList<StockLocationVo>();
                }
                StockLocationVo currOutVo = new StockLocationVo
                {
                    StockLocationId = ConvertDBNull<int>(dataReader,"stock_location_id"),
                    StockLocationCode = ConvertDBNull<string>( dataReader, "stock_location_code"),
                    StockLocationName = ConvertDBNull<string>(dataReader, "stock_location_name"),
                    LocationTypeDisplay = ConvertDBNull<string>(dataReader, "locationtype"),
                    DisplayOrder = ConvertDBNull<int>(dataReader, "display_order")
                };

                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
