using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckLocalSupplierMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkLocalSupplierDao = new CheckLocalSupplierMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkLocalSupplierDao.Execute(trxContext, vo);

        }
    }
}
