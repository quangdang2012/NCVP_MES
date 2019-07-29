using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetLocalUserMasterMntCbm : CbmController
    {

        private readonly DataAccessObject getLoginPasswordMasterMntDao = new GetLoginPasswordMasterMntDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getLoginPasswordMasterMntDao.Execute(trxContext, vo);

        }
    }
}
