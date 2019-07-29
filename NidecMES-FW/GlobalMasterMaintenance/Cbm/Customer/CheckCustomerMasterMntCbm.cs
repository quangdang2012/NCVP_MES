using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class CheckCustomerMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkCusDao = new CheckCustomerMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkCusDao.Execute(trxContext, vo);
  
        }
    }
}
