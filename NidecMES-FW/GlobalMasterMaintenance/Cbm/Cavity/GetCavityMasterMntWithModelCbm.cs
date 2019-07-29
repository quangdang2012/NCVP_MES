using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetCavityMasterMntWithModelCbm : CbmController
    {
        private readonly DataAccessObject getCavityDao = new GetCavityMasterMntWithModelDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getCavityDao.Execute(trxContext, vo);

        }
    }
}
