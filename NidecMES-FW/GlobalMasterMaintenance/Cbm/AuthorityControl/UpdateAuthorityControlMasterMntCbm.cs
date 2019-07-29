using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateAuthorityControlMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateAuthorityControlDao = new UpdateAuthorityControlMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateAuthorityControlDao.Execute(trxContext, vo);

        }
    }
}
