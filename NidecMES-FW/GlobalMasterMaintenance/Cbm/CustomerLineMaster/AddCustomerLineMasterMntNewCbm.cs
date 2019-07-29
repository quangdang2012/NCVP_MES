using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddCustomerLineMasterMntNewCbm : CbmController
    {

        private readonly DataAccessObject addCustomerLineMasterMntNewDao = new AddCustomerLineMasterMntNewDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addCustomerLineMasterMntNewDao.Execute(trxContext, vo);

        }
    }
}
