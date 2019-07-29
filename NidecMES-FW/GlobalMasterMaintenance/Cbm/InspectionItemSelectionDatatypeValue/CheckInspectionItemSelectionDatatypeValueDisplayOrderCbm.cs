using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionItemSelectionDatatypeValueDisplayOrderCbm : CbmController
    {

        private readonly DataAccessObject checkInspectionItemSelectionDatatypeValueDisplayOrderDao = new CheckInspectionItemSelectionDatatypeValueDisplayOrderDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionItemSelectionDatatypeValueDisplayOrderDao.Execute(trxContext, vo);

        }
    }
}
