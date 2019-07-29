using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddGlobalItemMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addGlobalItemMasterMntDao = new AddGlobalItemMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addGlobalItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
