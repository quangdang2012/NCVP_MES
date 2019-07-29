using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionTestInstructionMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkInspectionTestInstructionDao = new CheckInspectionTestInstructionMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionTestInstructionDao.Execute(trxContext, vo);

        }
    }
}
