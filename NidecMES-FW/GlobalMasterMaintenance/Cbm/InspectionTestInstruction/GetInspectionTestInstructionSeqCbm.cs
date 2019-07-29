using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionTestInstructionSeqCbm : CbmController
    {
        private readonly DataAccessObject getInspectionTestInstructionSeqDao = new GetInspectionTestInstructionSeqDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionTestInstructionSeqDao.Execute(trxContext, vo);

        }
    }
}
