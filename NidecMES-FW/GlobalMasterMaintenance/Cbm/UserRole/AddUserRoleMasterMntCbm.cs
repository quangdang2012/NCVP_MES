using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class AddUserRoleMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addUserRoleDao = new AddUserRoleMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addUserRoleDao.Execute(trxContext, vo);

        }
    }
}
