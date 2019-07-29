using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateStockLocationMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateStockLocationDao = new UpdateStockLocationMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateStockLocationDao.Execute(trxContext, vo);

        }
    }
}
