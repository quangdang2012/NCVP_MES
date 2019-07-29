using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Vo;

namespace Com.Nidec.Mes.Framework_Batch.Dao
{
    internal class DeleteBatchProcessDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AddBatchProcessVo inVo = (AddBatchProcessVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Delete FROM t_batch_process");         
            sqlQuery.Append(" Where batch_process_cd = :batchprocesscd");
            sqlQuery.Append(" and factory_cd = :factorycd ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("batchprocesscd", inVo.BatchProcessCode);
            sqlParameter.AddParameterString("factorycd", trxContext.UserData.FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
