using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckGlobalLocalItemMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkGlobalLocalItemMasterMntDao = new CheckGlobalLocalItemMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return checkGlobalLocalItemMasterMntDao.Execute(trxContext, vo);
        }
    }
}
