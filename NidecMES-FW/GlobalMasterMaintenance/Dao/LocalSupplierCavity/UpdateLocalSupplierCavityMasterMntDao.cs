using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateLocalSupplierCavityMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LocalSupplierCavityVo inVo = (LocalSupplierCavityVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" UPDATE ");
            sqlQuery.Append("  m_local_supplier_cavity ");
            sqlQuery.Append(" SET ");
            sqlQuery.Append("  cavity_name = :cavityname, ");
            sqlQuery.Append("  local_supplier_id = :localsupplierid, ");
            sqlQuery.Append("  item_id = :itemid ");
            sqlQuery.Append(" WHERE ");
            sqlQuery.Append("  cavity_id = :cavityid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("cavityid", inVo.LocalSupplierCavityId);
            sqlParameter.AddParameterString("cavityname", inVo.LocalSupplierCavityName);
            sqlParameter.AddParameterInteger("localsupplierid", inVo.LocalSupplierId);
            sqlParameter.AddParameterInteger("itemid", inVo.ItemId);

            LocalSupplierCavityVo outVo = new LocalSupplierCavityVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
