
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetSapItemMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getSapItemForMESItemDao = new GetSapItemMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getSapItemForMESItemDao.Execute(trxContext, vo);
        }
    }
}
