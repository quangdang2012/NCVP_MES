using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionItemSelectionDatatypeValueSeqCbm : CbmController
    {
        private readonly DataAccessObject getInspectionItemSelectionDatatypeValueSeqDao = new GetInspectionItemSelectionDatatypeValueSeqDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionItemSelectionDatatypeValueSeqDao.Execute(trxContext, vo);

        }
    }
}
