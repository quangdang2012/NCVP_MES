using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateProcessFlowRuleMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessFlowRuleVo inVo = (ProcessFlowRuleVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_process_flow_rule");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" comment = :comment ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" process_flow_rule_id = :processflowruleid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("processflowruleid", inVo.ProcessFlowRuleId);
            sqlParameter.AddParameterString("comment", inVo.Comment);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            ProcessFlowRuleVo outVo = new ProcessFlowRuleVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
