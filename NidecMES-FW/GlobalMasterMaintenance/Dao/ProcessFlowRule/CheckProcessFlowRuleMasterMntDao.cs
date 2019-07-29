using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckProcessFlowRuleMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessFlowRuleVo inVo = (ProcessFlowRuleVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as RuleCount from m_process_flow_rule ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.ProcessFlowRuleCode != null)
            {
                sqlQuery.Append(" and UPPER(process_flow_rule_cd) = UPPER(:processflowrulecd)");
            }
                        
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.ProcessFlowRuleCode != null)
            {
                sqlParameter.AddParameterString("processflowrulecd", inVo.ProcessFlowRuleCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ProcessFlowRuleVo outVo = new ProcessFlowRuleVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["RuleCount"]);
            }

            dataReader.Close();

            return outVo;
        } 
    }
}
