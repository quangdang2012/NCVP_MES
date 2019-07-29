using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetGlobalItemSapItemCbm : CbmController
    {
        private readonly DataAccessObject getGlobalItemSapItemDao = new GetGlobalItemSapItemDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getGlobalItemSapItemDao.Execute(trxContext, vo);

        }
    }
}
