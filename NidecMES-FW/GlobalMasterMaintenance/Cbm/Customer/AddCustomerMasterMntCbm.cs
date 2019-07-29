using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class AddCustomerMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addCusDao = new AddCustomerMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            CustomerVo inVo = (CustomerVo)vo;
           
            return addCusDao.Execute(trxContext, vo);

        }
    }
}
