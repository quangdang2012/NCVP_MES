using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteStockLocationMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteStockLocationDao = new DeleteStockLocationMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteStockLocationDao.Execute(trxContext, vo);

        }
    }
}
