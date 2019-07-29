using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionItemDisplayOrderNextValCbm : CbmController
    {
        private readonly DataAccessObject getInspectionItemDisplayOrderNextValDao = new GetInspectionItemDisplayOrderNextValDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getInspectionItemDisplayOrderNextValDao.Execute(trxContext, vo);

        }
    }
}
