using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteRoleMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteRoleDao = new DeleteRoleMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteRoleDao.Execute(trxContext, vo);

        }
    }
}
