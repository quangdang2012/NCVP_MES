using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateBuildingMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateBuildingDao = new UpdateBuildingMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateBuildingDao.Execute(trxContext, vo);

        }
    }
}
