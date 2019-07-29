using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddProcessStockLocationMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addProcessStockLocationMasterMntDao = new AddProcessStockLocationMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addProcessStockLocationMasterMntDao.Execute(trxContext, vo);

        }
    }
}
