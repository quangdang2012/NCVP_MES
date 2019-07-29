using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Dao;

namespace Com.Nidec.Mes.Framework_Batch.Cbm
{
    internal class GetBatchProcessCbm : CbmController
    {
        private readonly DataAccessObject getBatchProcessDao = new GetBatchProcessDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getBatchProcessDao.Execute(trxContext, vo);
        }
    }
}
