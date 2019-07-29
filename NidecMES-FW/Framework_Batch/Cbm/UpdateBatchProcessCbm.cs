using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Dao;

namespace Com.Nidec.Mes.Framework_Batch.Cbm
{
    internal class UpdateBatchProcessCbm : CbmController
    {
        private readonly DataAccessObject updateBatchProcessDao = new UpdateBatchProcessDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return updateBatchProcessDao.Execute(trxContext, vo);
        }
    }
}
