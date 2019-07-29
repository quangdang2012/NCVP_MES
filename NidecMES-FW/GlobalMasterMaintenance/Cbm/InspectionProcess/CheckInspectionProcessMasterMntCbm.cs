using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionProcessMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkInspectionProcessDao = new CheckInspectionProcessMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionProcessDao.Execute(trxContext, vo);

        }
    }
}
