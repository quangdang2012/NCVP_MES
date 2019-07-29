using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionItemWorkDisplayOrderCbm : CbmController
    {

        private readonly DataAccessObject checkInspectionItemWorkDisplayOrderDao = new CheckInspectionItemWorkDisplayOrderDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionItemWorkDisplayOrderDao.Execute(trxContext, vo);

        }
    }
}
