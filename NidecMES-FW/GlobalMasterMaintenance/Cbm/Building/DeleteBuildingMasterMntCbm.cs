using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteBuildingMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteBuildingDao = new DeleteBuildingMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteBuildingDao.Execute(trxContext, vo);

        }
    }
}
