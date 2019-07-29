using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckRoleMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkRoleDao = new CheckRoleMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkRoleDao.Execute(trxContext, vo);

        }
    }
}
