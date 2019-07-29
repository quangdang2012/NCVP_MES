using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateLocalSupplierMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LocalSupplierVo inVo = (LocalSupplierVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_local_supplier");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" local_supplier_name = :localsuppliername ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" local_supplier_id = :localsupplierid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("localsupplierid", inVo.LocalSupplierId);
            sqlParameter.AddParameterString("localsuppliername", inVo.LocalSupplierName);

            LocalSupplierVo outVo = new LocalSupplierVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
