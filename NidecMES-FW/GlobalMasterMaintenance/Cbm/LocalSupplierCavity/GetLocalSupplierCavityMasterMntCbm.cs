using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetLocalSupplierCavityMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getLocalSupplierCavityDao = new GetLocalSupplierCavityMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getLocalSupplierCavityDao.Execute(trxContext, vo);

        }
    }
}
