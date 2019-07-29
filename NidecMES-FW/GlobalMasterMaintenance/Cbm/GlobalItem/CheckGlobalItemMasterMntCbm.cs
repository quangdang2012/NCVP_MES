using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckGlobalItemMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkGlobalItemMasterMntDao = new CheckGlobalItemMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkGlobalItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
