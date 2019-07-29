using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetUserRoleMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getUserRoleDao = new GetUserRoleMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getUserRoleDao.Execute(trxContext, vo);

        }
    }
}
