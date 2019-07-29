using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetCustomerLineMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getCustomerLineMasterMntDao = new GetCustomerLineMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getCustomerLineMasterMntDao.Execute(trxContext, vo);

        }
    }
}
