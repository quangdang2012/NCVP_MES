using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionItemRelationCbm : CbmController
    {

        private readonly DataAccessObject checkInspectionItemRelationDao = new CheckInspectionItemRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionItemRelationDao.Execute(trxContext, vo);

        }
    }
}
