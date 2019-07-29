using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionTestInstructionMasterCbm : CbmController
    {
        private readonly DataAccessObject getInspectionTestInstructionDao = new GetInspectionTestInstructionMasterDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionTestInstructionDao.Execute(trxContext, vo);

        }
    }
}
