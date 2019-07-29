using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetProcessFlowRuleMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessFlowRuleVo inVo = (ProcessFlowRuleVo)arg;

            ProcessFlowRuleVo outVo = new ProcessFlowRuleVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select * from m_process_flow_rule ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.ProcessFlowRuleCode != null)
            {
                sqlQuery.Append(" and process_flow_rule_cd like :processflowrulecd ");
            }

            if (inVo.Comment != null)
            {
                sqlQuery.Append(" and comment like :comment ");
            }

            sqlQuery.Append(" order by process_flow_rule_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.ProcessFlowRuleCode != null)
            {
                sqlParameter.AddParameterString("processflowrulecd", inVo.ProcessFlowRuleCode + "%");
            }

            if (inVo.Comment != null)
            {
                sqlParameter.AddParameterString("comment", inVo.Comment + "%");
            }


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProcessFlowRuleVo currOutVo = new ProcessFlowRuleVo
                {
                    ProcessFlowRuleId = Convert.ToInt32(dataReader["process_flow_rule_id"]),
                    ProcessFlowRuleCode = dataReader["process_flow_rule_cd"].ToString(),
                    Comment = dataReader["comment"].ToString(),
                };

                outVo.ProcessFlowRuleListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
