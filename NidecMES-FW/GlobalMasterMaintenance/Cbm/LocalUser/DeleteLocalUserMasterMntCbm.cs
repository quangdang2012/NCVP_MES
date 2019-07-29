using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class DeleteLocalUserMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteLoginPasswordMasterMntDao = new DeleteLoginPasswordMasterMntDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            deleteLoginPasswordMasterMntDao.Execute(trxContext, vo);

            CbmController targetUserCbm = new DeleteUserMasterMntCbm();
            return targetUserCbm.Execute(trxContext, vo);           

        }
    }
}
