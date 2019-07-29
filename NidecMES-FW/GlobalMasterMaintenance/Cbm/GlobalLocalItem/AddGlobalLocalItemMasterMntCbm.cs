using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddGlobalLocalItemMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addGlobalLocalItemMasterMntDao = new AddGlobalLocalItemMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addGlobalLocalItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
