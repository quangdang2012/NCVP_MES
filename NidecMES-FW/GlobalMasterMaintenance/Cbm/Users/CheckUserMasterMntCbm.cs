using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class CheckUserMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkUserDao = new CheckUserMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkUserDao.Execute(trxContext, vo);
  
        }
    }
}
