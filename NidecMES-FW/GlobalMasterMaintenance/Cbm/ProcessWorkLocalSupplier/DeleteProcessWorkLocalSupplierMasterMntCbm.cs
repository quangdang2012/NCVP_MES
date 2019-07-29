using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteProcessWorkLocalSupplierMasterMntCbm : CbmController
    {
        private readonly DataAccessObject deleteProcessWorkLocalSupplierDao = new DeleteProcessWorkLocalSupplierMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteProcessWorkLocalSupplierDao.Execute(trxContext, vo);

        }
    }
}
