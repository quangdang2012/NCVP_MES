using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetLineBuildingMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getLineBuildingMasterMntDao = new GetLineBuildingMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getLineBuildingMasterMntDao.Execute(trxContext, vo);

        }
    }
}
