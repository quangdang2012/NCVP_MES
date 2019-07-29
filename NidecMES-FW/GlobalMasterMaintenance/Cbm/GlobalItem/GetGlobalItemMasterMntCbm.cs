using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetGlobalItemMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getGlobalItemMasterMntDao = new GetGlobalItemMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getGlobalItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
