using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionItemMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkInspectionItemMasterMntDao = new CheckInspectionItemMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
