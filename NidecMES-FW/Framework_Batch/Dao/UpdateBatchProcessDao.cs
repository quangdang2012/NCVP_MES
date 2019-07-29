using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Vo;
using System;

namespace Com.Nidec.Mes.Framework_Batch.Dao
{
    internal class UpdateBatchProcessDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AddBatchProcessVo inVo = (AddBatchProcessVo)arg;
           
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update t_batch_process");
            sqlQuery.Append(" Set  ");
            sqlQuery.Append(" is_stop_requested = :request ");
            sqlQuery.Append(" WHERE factory_cd = :factorycd ");
            sqlQuery.Append(" and batch_process_id = :id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
           
            sqlParameter.AddParameter("request", inVo.IsStopRequested);
            sqlParameter.AddParameterInteger("id", inVo.BatchProcessId);
            sqlParameter.AddParameterString("factorycd", trxContext.UserData.FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
