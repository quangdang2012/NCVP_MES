using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteInventoryReasonMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InventoryReasonVo inVo = (InventoryReasonVo)arg;        

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_inventory_reason");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" inventory_reason_id = :inventoryreasonid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inventoryreasonid", inVo.InventoryReasonId);

            InventoryReasonVo outVo = new InventoryReasonVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
