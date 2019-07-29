using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetProcessWorkLocalSupplierMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getProcessWorkLocalSupplierDao = new GetProcessWorkLocalSupplierMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getProcessWorkLocalSupplierDao.Execute(trxContext, vo);

        }
    }
}
