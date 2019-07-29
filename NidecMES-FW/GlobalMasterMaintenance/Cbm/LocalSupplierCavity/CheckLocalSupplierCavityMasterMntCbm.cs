using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckLocalSupplierCavityMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkLocalSupplierCavityDao = new CheckLocalSupplierCavityMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkLocalSupplierCavityDao.Execute(trxContext, vo);

        }
    }
}
