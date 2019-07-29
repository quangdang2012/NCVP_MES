using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetGlobalLocalItemMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getGlobalLocalItemMasterMntDao = new GetGlobalLocalItemMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getGlobalLocalItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
