using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    class DeleteCavityByMoldIdCbm : CbmController
    {
        private readonly DataAccessObject deleteCavityByMoldIdDao = new DeleteCavityByMoldIdDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return deleteCavityByMoldIdDao.Execute(trxContext, vo);

        }
    }
}
