using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddStockLocationMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addStockLocationDao = new AddStockLocationMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addStockLocationDao.Execute(trxContext, vo);

        }
    }
}
