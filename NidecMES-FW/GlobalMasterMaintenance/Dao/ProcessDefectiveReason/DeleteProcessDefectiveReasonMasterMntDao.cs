using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteProcessDefectiveReasonMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessDefectiveReasonVo inVo = (ProcessDefectiveReasonVo)arg;      

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_process_work_defective_reason");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" defective_reason_id = :defrsnid ");
            sqlQuery.Append(" and factory_cd = :faccd ");
            if (inVo.ProcessWorkId > 0)
            {
                sqlQuery.Append(" and process_work_id = :prcwid");
            }
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("defrsnid", inVo.DefectiveReasonId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.ProcessWorkId > 0)
            {
                sqlParameter.AddParameterInteger("prcwid", inVo.ProcessWorkId);
            }

            ProcessDefectiveReasonVo outVo = new ProcessDefectiveReasonVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
