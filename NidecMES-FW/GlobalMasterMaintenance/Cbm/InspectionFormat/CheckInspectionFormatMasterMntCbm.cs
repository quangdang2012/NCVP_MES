using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionFormatMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkInspectionFormatDao = new CheckInspectionFormatMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionFormatDao.Execute(trxContext, vo);

        }
    }
}
