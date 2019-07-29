
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetSapItemSearchCbm : CbmController
    {
        private readonly DataAccessObject getSapItemSearchDao = new GetSapItemSearchDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getSapItemSearchDao.Execute(trxContext, vo);
        }
    }
}
