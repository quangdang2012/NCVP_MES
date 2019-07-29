using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Dao;

namespace Com.Nidec.Mes.Framework_Batch.Cbm
{
    internal class AddBatchProcessCbm : CbmController
    {
        private readonly DataAccessObject addBatchProcessDao = new AddBatchProcessDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return addBatchProcessDao.Execute(trxContext, vo);
        }
    }
}
