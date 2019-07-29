using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetStockLocationMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getStockLocationDao = new GetStockLocationMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getStockLocationDao.Execute(trxContext, vo);

        }
    }
}
