using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionSpecificationMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkInspectionSpecificationDao = new CheckInspectionSpecificationMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionSpecificationDao.Execute(trxContext, vo);

        }
    }
}
