using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionTestInstructionDetailMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getInspectionTestInstructionDetailDao = new GetInspectionTestInstructionDetailMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionTestInstructionDetailDao.Execute(trxContext, vo);

        }
    }
}
