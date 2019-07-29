using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Dao;

namespace Com.Nidec.Mes.Framework_Batch.Cbm
{
    internal class DeleteBatchProcessCbm : CbmController
    {
        private readonly DataAccessObject deleteBatchProcessDao = new DeleteBatchProcessDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return deleteBatchProcessDao.Execute(trxContext, vo);
        }
    }
}
