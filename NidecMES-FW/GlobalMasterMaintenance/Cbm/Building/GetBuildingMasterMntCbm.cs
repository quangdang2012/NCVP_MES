using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetBuildingMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getBuildingDao = new GetBuildingMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getBuildingDao.Execute(trxContext, vo);

        }
    }
}
