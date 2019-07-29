using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateGlobalItemMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateGlobalItemMasterMntDao = new UpdateGlobalItemMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateGlobalItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
