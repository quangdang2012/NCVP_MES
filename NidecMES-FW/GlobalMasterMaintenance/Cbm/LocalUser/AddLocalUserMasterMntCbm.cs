using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class AddLoginPasswordMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addLoginPasswordMasterMntDao = new AddLoginPasswordMasterMntDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            CbmController targetUserCbm = new AddUserMasterMntCbm();
            targetUserCbm.Execute(trxContext, vo);

            return addLoginPasswordMasterMntDao.Execute(trxContext, vo);

        }
    }
}
