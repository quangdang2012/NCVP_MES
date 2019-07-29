using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteLineItemCycleTimeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineItemCycleTimeVo inVo = (LineItemCycleTimeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_line_sap_item");
            sqlQuery.Append(" Where	");
            //sqlQuery.Append(" line_sap_item_id = :lineSapItemId ");
            sqlQuery.Append(" line_id = :lineid");
            //sqlQuery.Append(" and sap_matnr_item_cd = :sapMatnrItemCd ");
            sqlQuery.Append(" and factory_cd = :faccd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            //sqlParameter.AddParameterInteger("lineSapItemId", inVo.LineItemCycleTimeId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterString("sapMatnrItemCd", inVo.SapItemCode);

            UpdateResultVo outVo = new UpdateResultVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
