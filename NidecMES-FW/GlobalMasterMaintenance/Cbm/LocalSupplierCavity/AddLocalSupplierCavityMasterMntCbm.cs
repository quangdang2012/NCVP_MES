using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddLocalSupplierCavityMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addLocalSupplierCavityDao = new AddLocalSupplierCavityMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addLocalSupplierCavityDao.Execute(trxContext, vo);

        }
    }
}
