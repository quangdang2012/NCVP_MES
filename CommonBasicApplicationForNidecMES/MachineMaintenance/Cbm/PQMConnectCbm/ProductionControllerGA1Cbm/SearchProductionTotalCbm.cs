using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.PQMConnectCbm.ProductionControllerGA1Cbm
{
    public class SearchProductionTotalCbm : CbmController
    {
        private static readonly DataAccessObject getDao = new SearchProductionTotalDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            if (vo == null)
            {
                return null;
            }

            return getDao.Execute(trxContext, vo);
        }
    }
}