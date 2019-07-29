using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Dao;

namespace Com.Nidec.Mes.Framework_Batch.Cbm
{
    internal class GetBatchProcessDataCompletelyCbm : CbmController
    {
        private readonly DataAccessObject getBatchProcessDataCompletelyDao = new GetBatchProcessDataCompletelyDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getBatchProcessDataCompletelyDao.Execute(trxContext, vo);
        }
    }
}
