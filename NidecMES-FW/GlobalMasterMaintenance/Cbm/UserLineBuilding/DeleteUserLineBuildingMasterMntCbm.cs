using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteUserLineBuildingMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteUserLineBuildingMasterMntDao = new DeleteUserLineBuildingMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return deleteUserLineBuildingMasterMntDao.Execute(trxContext, vo);
        }
    }
}
