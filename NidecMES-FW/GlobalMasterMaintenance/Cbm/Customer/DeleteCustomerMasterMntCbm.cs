using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class DeleteCustomerMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteCusDao = new DeleteCustomerMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            CustomerVo inVo = (CustomerVo)vo;
            
            return deleteCusDao.Execute(trxContext, vo);

        }
    }
}
