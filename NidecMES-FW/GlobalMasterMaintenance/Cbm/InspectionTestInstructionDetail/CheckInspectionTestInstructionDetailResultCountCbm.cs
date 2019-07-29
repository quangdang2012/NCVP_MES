using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionTestInstructionDetailResultCountCbm : CbmController
    {

        private readonly DataAccessObject checkInspTestInstrDetailResultCountDao = new CheckInspectionTestInstructionDetailResultCountDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspTestInstrDetailResultCountDao.Execute(trxContext, vo);

        }
    }
}
