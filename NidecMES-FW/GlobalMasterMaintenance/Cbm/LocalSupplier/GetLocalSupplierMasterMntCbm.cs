using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetLocalSupplierMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getLocalSupplierDao = new GetLocalSupplierMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getLocalSupplierDao.Execute(trxContext, vo);

        }
    }
}
