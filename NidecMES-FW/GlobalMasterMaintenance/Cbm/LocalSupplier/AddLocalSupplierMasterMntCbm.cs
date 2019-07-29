using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddLocalSupplierMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addLocalSupplierDao = new AddLocalSupplierMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addLocalSupplierDao.Execute(trxContext, vo);

        }
    }
}
