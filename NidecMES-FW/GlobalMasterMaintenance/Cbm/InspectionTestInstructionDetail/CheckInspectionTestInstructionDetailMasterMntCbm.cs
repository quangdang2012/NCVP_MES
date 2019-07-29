using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionTestInstructionDetailMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkInspectionTestInstructionDetailDao = new CheckInspectionTestInstructionDetailMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionTestInstructionDetailDao.Execute(trxContext, vo);

        }
    }
}
