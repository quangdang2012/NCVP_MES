using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetProcessStockLocationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessStockLocationVo inVo = (ProcessStockLocationVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select ");
            sqlQuery.Append("   psl.process_id, psl.stock_location_id,sl.stock_location_name ");
            sqlQuery.Append(" from m_process_stocklocation psl ");
            sqlQuery.Append(" left join m_process p on p.process_id = psl.process_id ");
            sqlQuery.Append(" left join m_stock_location sl on sl.stock_location_id = psl.stock_location_id ");
            sqlQuery.Append(" where psl.factory_cd = :faccd ");

            if (inVo.ProcessId > 0)
            {
                sqlQuery.Append(" and psl.process_id = :processid ");
            }
 
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("processid", inVo.ProcessId);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<ProcessStockLocationVo> outVo = null;

            while (dataReader.Read())
            {
                ProcessStockLocationVo currOutVo = new ProcessStockLocationVo();

                currOutVo.ProcessId = ConvertDBNull<int>(dataReader,"process_id");
                currOutVo.StockLocationId = ConvertDBNull<int>(dataReader, "stock_location_id");
                currOutVo.StockLocationName = ConvertDBNull<string>(dataReader, "stock_location_name");

                if(outVo==null)
                {
                    outVo = new ValueObjectList<ProcessStockLocationVo>();
                }
                outVo.add(currOutVo);

            }
            dataReader.Close();

            return outVo;
        }
    }
}
