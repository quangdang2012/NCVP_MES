using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetRoleAuthorityControlMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getRoleAuthorityControlDao = new GetRoleAuthorityControlMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getRoleAuthorityControlDao.Execute(trxContext, vo);


        }
    }
}
