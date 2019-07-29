using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class DeleteUserRoleMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteUserRoleDao = new DeleteUserRoleMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteUserRoleDao.Execute(trxContext, vo);

        }
    }
}
