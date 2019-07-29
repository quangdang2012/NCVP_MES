using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInventoryReasonMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InventoryReasonVo inVo = (InventoryReasonVo)arg;

            InventoryReasonVo outVo = new InventoryReasonVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select * from m_inventory_reason ");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.InventoryReasonCode != null)
            {
                sqlQuery.Append(" and inventory_reason_cd like :inventoryreasoncd ");
            }

            if (inVo.InventoryReasonName != null)
            {
                sqlQuery.Append(" and inventory_reason_name like :inventoryreasonname ");
            }

            sqlQuery.Append(" order by inventory_reason_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.InventoryReasonCode != null)
            {
                sqlParameter.AddParameterString("inventoryreasoncd", inVo.InventoryReasonCode + "%");
            }

            if (inVo.InventoryReasonName != null)
            {
                sqlParameter.AddParameterString("inventoryreasonname", inVo.InventoryReasonName + "%");
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                InventoryReasonVo currOutVo = new InventoryReasonVo
                {
                    InventoryReasonId = Convert.ToInt32(dataReader["inventory_reason_id"]),
                    InventoryReasonCode = dataReader["inventory_reason_cd"].ToString(),
                    InventoryReasonName = dataReader["inventory_reason_name"].ToString(),
                };

                outVo.InventoryReasonListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
