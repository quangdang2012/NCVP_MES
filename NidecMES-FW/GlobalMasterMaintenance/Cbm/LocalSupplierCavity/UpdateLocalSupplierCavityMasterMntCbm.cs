using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateLocalSupplierCavityMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateLocalSupplierCavityDao = new UpdateLocalSupplierCavityMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateLocalSupplierCavityDao.Execute(trxContext, vo);

        }
    }
}
