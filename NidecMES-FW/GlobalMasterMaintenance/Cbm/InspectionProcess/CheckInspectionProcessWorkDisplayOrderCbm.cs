using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionProcessWorkDisplayOrderCbm : CbmController
    {

        private readonly DataAccessObject checkInspectionProcessWorkDisplayOrderDao = new CheckInspectionProcessWorkDisplayOrderDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionProcessWorkDisplayOrderDao.Execute(trxContext, vo);

        }
    }
}
