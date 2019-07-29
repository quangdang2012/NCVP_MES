using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetDisplayOrderNextValForStockLocCbm : CbmController
    {
        private readonly DataAccessObject getDisplayOrderNextValDao = new GetDisplayOrderNextValForStockLocDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getDisplayOrderNextValDao.Execute(trxContext, vo);

        }
    }
}
