using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class UpdateCustomerMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateCusDao = new UpdateCustomerMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            CustomerVo inVo = (CustomerVo)vo;
           
            return updateCusDao.Execute(trxContext, vo);

        }
    }
}
