using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionItemMasterCbm : CbmController
    {
        private readonly DataAccessObject getInspectionItemDao = new GetInspectionItemMasterDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionItemDao.Execute(trxContext, vo);

        }
    }
}
