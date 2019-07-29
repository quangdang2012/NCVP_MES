using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetLocalSupplierCavityMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LocalSupplierCavityVo inVo = (LocalSupplierCavityVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" SELECT ");
            sqlQuery.Append("  lsc.cavity_id, ");
            sqlQuery.Append("  lsc.cavity_cd, ");
            sqlQuery.Append("  lsc.cavity_name, ");
            sqlQuery.Append("  lsc.item_id, ");
            sqlQuery.Append("  ls.local_supplier_id, ");
            sqlQuery.Append("  ls.local_supplier_cd, ");
            sqlQuery.Append("  ls.local_supplier_name, ");
            sqlQuery.Append("  l.item_cd ");
            sqlQuery.Append(" FROM ");
            sqlQuery.Append("  m_local_supplier_cavity lsc ");
            sqlQuery.Append("  INNER JOIN m_local_supplier ls ON ls.local_supplier_id = lsc.local_supplier_id ");
            sqlQuery.Append("  LEFT  JOIN m_local_item l ON l.item_id = lsc.item_id ");
            sqlQuery.Append(" WHERE 1 = 1 ");

            if (inVo.LocalSupplierCavityCode != null)
            {
                sqlQuery.Append(" AND lsc.cavity_cd like :cavitycd ");
            }

            if (inVo.LocalSupplierCavityName != null)
            {
                sqlQuery.Append(" AND lsc.cavity_name like :cavityname ");
            }

            if (inVo.LocalSupplierId != 0)
            {
                sqlQuery.Append(" AND ls.local_supplier_id = :localsupplierid ");
            }

            if (inVo.ItemId != 0)
            {
                sqlQuery.Append(" AND lsc.item_id = :itemid ");
            }

            sqlQuery.Append(" ORDER BY lsc.cavity_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.LocalSupplierCavityCode != null)
            {
                sqlParameter.AddParameterString("cavitycd", inVo.LocalSupplierCavityCode + "%");
            }

            if (inVo.LocalSupplierCavityName != null)
            {
                sqlParameter.AddParameterString("cavityname", inVo.LocalSupplierCavityName + "%");
            }
            if (inVo.LocalSupplierId != 0)
            {
                sqlParameter.AddParameterInteger("localsupplierid", inVo.LocalSupplierId);
            }
            if (inVo.ItemId != 0)
            {
                sqlParameter.AddParameterInteger("itemid", inVo.ItemId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            LocalSupplierCavityVo outVo = new LocalSupplierCavityVo();

            while (dataReader.Read())
            {
                LocalSupplierCavityVo currOutVo = new LocalSupplierCavityVo
                {
                    LocalSupplierCavityId = Convert.ToInt32(dataReader["cavity_id"]),
                    LocalSupplierCavityCode = dataReader["cavity_cd"].ToString(),
                    LocalSupplierCavityName = dataReader["cavity_name"].ToString(),
                    LocalSupplierId = Convert.ToInt32(dataReader["local_supplier_id"]),
                    LocalSupplierName = dataReader["local_supplier_name"].ToString(),
                    ItemId = Convert.ToInt32(dataReader["item_id"]),
                    ItemCode = dataReader["item_cd"].ToString()
                };
                outVo.LocalSupplierCavityListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        } 
    }
}
