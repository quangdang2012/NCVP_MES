using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckInventoryReasonMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InventoryReasonVo inVo = (InventoryReasonVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as InventoryCount from m_inventory_reason ");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.InventoryReasonCode != null)
            {
                sqlQuery.Append(" and UPPER(inventory_reason_cd) = UPPER(:inventoryreasoncd)");
            }
                        
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.InventoryReasonCode != null)
            {
                sqlParameter.AddParameterString("inventoryreasoncd", inVo.InventoryReasonCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InventoryReasonVo outVo = new InventoryReasonVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["InventoryCount"]);
            }

            dataReader.Close();

            return outVo;
        } 
    }
}
