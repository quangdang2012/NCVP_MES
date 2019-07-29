using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetCustomerMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getCusDao = new GetCustomerMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getCusDao.Execute(trxContext, vo);

        }
    }
}
