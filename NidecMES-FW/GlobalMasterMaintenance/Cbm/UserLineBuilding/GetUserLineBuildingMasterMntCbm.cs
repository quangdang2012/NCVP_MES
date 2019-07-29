using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetUserLineBuildingMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getUserLineBuildingMasterMntDao = new GetUserLineBuildingMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getUserLineBuildingMasterMntDao.Execute(trxContext, vo);

        }
    }
}
