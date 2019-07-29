using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetProcessStockLocationMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getProcessStockLocationMasterMntDao = new GetProcessStockLocationMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getProcessStockLocationMasterMntDao.Execute(trxContext, vo);

        }
    }
}
