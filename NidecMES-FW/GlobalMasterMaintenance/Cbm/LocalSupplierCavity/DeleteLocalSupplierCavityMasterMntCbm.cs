using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteLocalSupplierCavityMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteLocalSupplierCavityDao = new DeleteLocalSupplierCavityMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteLocalSupplierCavityDao.Execute(trxContext, vo);

        }
    }
}
