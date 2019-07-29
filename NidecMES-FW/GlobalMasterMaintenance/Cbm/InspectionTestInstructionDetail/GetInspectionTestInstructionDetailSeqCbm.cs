using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionTestInstructionDetailSeqCbm : CbmController
    {
        private readonly DataAccessObject getInspectionTestInstructionDetailSeqDao = new GetInspectionTestInstructionDetailSeqDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionTestInstructionDetailSeqDao.Execute(trxContext, vo);

        }
    }
}
