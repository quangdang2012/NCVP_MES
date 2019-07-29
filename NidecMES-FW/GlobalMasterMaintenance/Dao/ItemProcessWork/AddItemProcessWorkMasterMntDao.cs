using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddItemProcessWorkMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemProcessWorkVo inVo = (ItemProcessWorkVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_item_process_work");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" item_id, ");
            sqlQuery.Append(" process_work_id, ");
            sqlQuery.Append(" process_work_sequence, ");
            sqlQuery.Append(" is_optional_process, ");
            sqlQuery.Append(" skip_prevention_flg, ");
            sqlQuery.Append(" work_order, ");
            sqlQuery.Append(" process_flow_rule_id, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :itemid ,");
            sqlQuery.Append(" :processworkid ,");
            sqlQuery.Append(" :processworkseq ,");
            sqlQuery.Append(" :optionalflg ,");
            sqlQuery.Append(" :skippreventionflg ,");
            sqlQuery.Append(" :workorder ,");
            sqlQuery.Append(" :processflowruleid ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factorycd ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("itemid", inVo.ItemId);
            sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);
            sqlParameter.AddParameterInteger("processworkseq", inVo.ProcessWorkSeq);
            sqlParameter.AddParameterString("optionalflg", inVo.OptionalProcessFlag);
            sqlParameter.AddParameterString("skippreventionflg", inVo.SkipPreventionFlag);
            sqlParameter.AddParameterInteger("workorder", inVo.WorkOrder);
            sqlParameter.AddParameterInteger("processflowruleid", inVo.ProcessFlowRuleId);
            sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycd", UserData.GetUserData().FactoryCode);

            ItemProcessWorkVo outVo = new ItemProcessWorkVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
