using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddUserLineBuildingMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addUserLineBuildingMasterMntDao = new AddUserLineBuildingMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return addUserLineBuildingMasterMntDao.Execute(trxContext, vo);
        }
    }
}
