using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionItemListCbm : CbmController
    {
        private readonly DataAccessObject getInspectionItemListDao = new GetInspectionItemListDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionItemListDao.Execute(trxContext, vo);

        }
    }
}
