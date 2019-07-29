using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionItemSeqCbm : CbmController
    {
        private readonly DataAccessObject getInspectionItemSeqDao = new GetInspectionItemSeqDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionItemSeqDao.Execute(trxContext, vo);

        }
    }
}
