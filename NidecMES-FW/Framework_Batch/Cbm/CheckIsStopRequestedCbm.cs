using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Dao;

namespace Com.Nidec.Mes.Framework_Batch.Cbm
{
    internal class CheckIsStopRequestedCbm : CbmController
    {
        private readonly DataAccessObject checkIsStopRequestedDao = new CheckIsStopRequestedDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return checkIsStopRequestedDao.Execute(trxContext, vo);
        }
    }
}
