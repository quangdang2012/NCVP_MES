using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateInventoryReasonMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InventoryReasonVo inVo = (InventoryReasonVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_inventory_reason");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" inventory_reason_name = :inventoryreasonname ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" inventory_reason_id = :inventoryreasonid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inventoryreasonid", inVo.InventoryReasonId);
            sqlParameter.AddParameterString("inventoryreasonname", inVo.InventoryReasonName);

            InventoryReasonVo outVo = new InventoryReasonVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
