using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class CheckUserRelationCbm : CbmController
    {

        private readonly DataAccessObject checkUserRelDao = new CheckUserRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkUserRelDao.Execute(trxContext, vo);
  
        }
    }
}
