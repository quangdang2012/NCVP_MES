using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateGlobalLocalItemMasterMntCbm : CbmController
    {
        private readonly DataAccessObject deleteGlobalLocalItemMasterMntDao = new DeleteGlobalLocalItemMasterMntDao();

        private readonly DataAccessObject addGlobalLocalItemMasterMntDao = new AddGlobalLocalItemMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            deleteGlobalLocalItemMasterMntDao.Execute(trxContext, vo);
            return addGlobalLocalItemMasterMntDao.Execute(trxContext, vo);
        }
    }
}
