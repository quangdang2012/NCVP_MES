using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class CheckInspectionProcessRelationCbm : CbmController
    {

        private readonly DataAccessObject checkInspProcessRelationDao = new CheckInspectionProcessRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspProcessRelationDao.Execute(trxContext, vo);

        }
    }
}
