using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetUserAuthorityCbm : CbmController
    {
        private readonly DataAccessObject getUserRoleAuthorityDao = new GetUserAuthorityDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getUserRoleAuthorityDao.Execute(trxContext, vo);

        }
    }
}
