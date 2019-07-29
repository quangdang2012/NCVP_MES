using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteLineRestTimeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineRestTimeVo inVo = (LineRestTimeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_line_rest_time");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" factory_cd = :faccd ");

            if (inVo.LineId > 0)
            {
                sqlQuery.Append(" and line_id = :lineid ");
            }            

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            //sqlParameter.AddParameterInteger("lineSapItemId", inVo.LineItemCycleTimeId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterInteger("lineresttimeid", inVo.LineRestTimeId);

            UpdateResultVo outVo = new UpdateResultVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
