using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteItemProcessWorkMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemProcessWorkVo inVo = (ItemProcessWorkVo)arg;         

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete from m_item_process_work");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" item_id = :itemid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            //sqlQuery.Append(" and ");
            //sqlQuery.Append(" process_flow_rule_id = :workflowid ");


            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("itemid", inVo.ItemId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            //sqlParameter.AddParameterInteger("workflowid", inVo.ProcessFlowRuleId);
            ItemProcessWorkVo outVo = new ItemProcessWorkVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
