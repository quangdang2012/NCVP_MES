using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionItemSelectionDatatypeValueCbm : CbmController
    {

        private readonly DataAccessObject checkInspectionItemSelectionDatatypeValueDao = new CheckInspectionItemSelectionDatatypeValueDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionItemSelectionDatatypeValueDao.Execute(trxContext, vo);

        }
    }
}
