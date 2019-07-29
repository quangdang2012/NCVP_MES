using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteProcessWorkLocalSupplierMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkLocalSupplierVo inVo = (ProcessWorkLocalSupplierVo)arg;         

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete from m_process_work_local_supplier");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" local_supplier_id = :suppid ");
            sqlQuery.Append(" and ");
            sqlQuery.Append(" process_work_id = :workid ");


            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("suppid", inVo.LocalSupplierId);
            sqlParameter.AddParameterInteger("workid", inVo.ProcessWorkId);
            ProcessWorkLocalSupplierVo outVo = new ProcessWorkLocalSupplierVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
