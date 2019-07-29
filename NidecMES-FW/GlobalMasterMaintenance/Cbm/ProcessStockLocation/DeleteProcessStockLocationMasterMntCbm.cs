using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteProcessStockLocationMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteProcessStockLocationMasterMntDao = new DeleteProcessStockLocationMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return deleteProcessStockLocationMasterMntDao.Execute(trxContext, vo);
        }
    }
}
