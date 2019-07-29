using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddProcessWorkLocalSupplierMasterMntCbm : CbmController
    {
        private readonly DataAccessObject addProcessWorkLocalSupplierDao = new AddProcessWorkLocalSupplierMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addProcessWorkLocalSupplierDao.Execute(trxContext, vo);

        }
    }
}
