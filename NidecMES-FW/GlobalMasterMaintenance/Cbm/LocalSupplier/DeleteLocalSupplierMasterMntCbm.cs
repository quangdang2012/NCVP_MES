using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteLocalSupplierMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteLocalSupplierDao = new DeleteLocalSupplierMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteLocalSupplierDao.Execute(trxContext, vo);

        }
    }
}
