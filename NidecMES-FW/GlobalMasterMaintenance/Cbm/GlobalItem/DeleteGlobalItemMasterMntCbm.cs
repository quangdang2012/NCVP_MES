using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteGlobalItemMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteGlobalItemMasterMntDao = new DeleteGlobalItemMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteGlobalItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
