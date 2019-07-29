using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateItemProcessWorkMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemProcessWorkVo inVo = (ItemProcessWorkVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_item_process_work");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" item_id = :itemid, ");
            sqlQuery.Append(" is_optional_process = :optionalflg, ");
            sqlQuery.Append(" skip_prevention_flg = :skippreventionflg, ");
            sqlQuery.Append(" work_order = :workorder, ");
            sqlQuery.Append(" process_flow_rule_id = :processflowruleid ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" item_process_work_id = :itemprocessworkid");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("itemid", inVo.ItemId);
            sqlParameter.AddParameterString("optionalflg", inVo.OptionalProcessFlag);
            sqlParameter.AddParameterInteger("skippreventionflg", inVo.SkipPreventionFlag);
            sqlParameter.AddParameterInteger("workorder", inVo.WorkOrder);
            sqlParameter.AddParameterInteger("processflowruleid", inVo.ProcessFlowRuleId);
            sqlParameter.AddParameterInteger("itemprocessworkid", inVo.ItemProcessWorkId);

            ItemProcessWorkVo outVo = new ItemProcessWorkVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
