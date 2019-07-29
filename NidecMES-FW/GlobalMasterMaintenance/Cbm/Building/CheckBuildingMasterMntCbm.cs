using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckBuildingMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkBuildingDao = new CheckBuildingMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkBuildingDao.Execute(trxContext, vo);

        }
    }
}
