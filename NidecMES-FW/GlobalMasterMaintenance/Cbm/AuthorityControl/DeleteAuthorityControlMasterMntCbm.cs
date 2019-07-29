using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteAuthorityControlMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteAuthorityControlDao = new DeleteAuthorityControlMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteAuthorityControlDao.Execute(trxContext, vo);

        }
    }
}
