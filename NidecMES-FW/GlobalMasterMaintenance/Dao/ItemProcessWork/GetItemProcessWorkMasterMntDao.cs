using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetItemProcessWorkMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemProcessWorkVo inVo = (ItemProcessWorkVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select ipw.item_process_work_id, ipw.item_id, ipw.process_work_id,ipw.process_work_sequence, ");
            sqlQuery.Append(" ipw.is_optional_process, ipw.skip_prevention_flg, ");
            sqlQuery.Append(" ipw.process_flow_rule_id,");
            sqlQuery.Append(" li.item_name,");
            sqlQuery.Append(" pw.process_work_name, pw.process_work_cd,");
            sqlQuery.Append(" pfr.comment, ipw.work_order");
            sqlQuery.Append(" from m_item_process_work ipw ");
            sqlQuery.Append(" inner join m_local_item li on ipw.item_id = li.item_id ");
            sqlQuery.Append(" inner join m_process_work pw on ipw.process_work_id = pw.process_work_id ");
            //sqlQuery.Append(" inner join m_process_flow_rule pfr on ipw.process_flow_rule_id = pfr.process_flow_rule_id");
            sqlQuery.Append(" left outer join m_process_flow_rule pfr on ipw.process_flow_rule_id = pfr.process_flow_rule_id");
            sqlQuery.Append(" where ipw.factory_cd = :faccd ");

            if (inVo.ItemId > 0)
            {
                sqlQuery.Append(" and ipw.item_id = :itemid ");
            }

            if (!string.IsNullOrEmpty(inVo.ItemCd))
            {
                sqlQuery.Append(" and li.item_cd like :itemcd ");
            }

            if (!string.IsNullOrEmpty(inVo.ItemName))
            {
                sqlQuery.Append(" and li.item_name like :itemname ");
            }

            if (inVo.ProcessFlowRuleId > 0)
            {
                sqlQuery.Append(" and ipw.process_flow_rule_id  =:procflowruleid ");
            }

            sqlQuery.Append(" order by ipw.work_order");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.ItemId > 0)
            {
                sqlParameter.AddParameterInteger("itemid", inVo.ItemId);
            }

            if (!string.IsNullOrEmpty(inVo.ItemCd))
            {
                sqlParameter.AddParameterString("itemcd", inVo.ItemCd);
            }

            if (!string.IsNullOrEmpty(inVo.ItemName))
            {
                sqlParameter.AddParameterString("itemname", inVo.ItemName + "%");
            }

            if (inVo.ProcessFlowRuleId > 0)
            {
                sqlParameter.AddParameterInteger("procflowruleid", inVo.ProcessFlowRuleId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ItemProcessWorkVo outVo = new ItemProcessWorkVo();

            while (dataReader.Read())
            {
                ItemProcessWorkVo currOutVo = new ItemProcessWorkVo
                {
                    ItemProcessWorkId = ConvertDBNull<int>(dataReader, "item_process_work_id"),
                    ItemId = ConvertDBNull<int>(dataReader, "item_id"),
                    ProcessWorkId = ConvertDBNull<int>(dataReader, "process_work_id"),
                    ProcessWorkSeq = ConvertDBNull<int>(dataReader, "process_work_sequence"),
                    ProcessFlowRuleId = ConvertDBNull<int>(dataReader, "process_flow_rule_id"),
                    ProcessWorkCode = ConvertDBNull<string>(dataReader, "process_work_cd"),
                    ProcessWorkName = ConvertDBNull<string>(dataReader,"process_work_name"),
                    OptionalProcessFlag = ConvertDBNull<string>(dataReader,"is_optional_process"),
                    SkipPreventionFlag = ConvertDBNull<string>(dataReader,"skip_prevention_flg"),
                    Comment = ConvertDBNull<string>(dataReader,"comment"),
                    WorkOrder = ConvertDBNull<int>(dataReader, "work_order")
                };

                outVo.ItemProcessWorkListVo.Add(currOutVo);

            }
            dataReader.Close();

            return outVo;
        }
    }
}
