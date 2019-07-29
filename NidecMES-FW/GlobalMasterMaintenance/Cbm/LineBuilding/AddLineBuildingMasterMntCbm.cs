using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddLineBuildingMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addLineBuildingMasterMntDao = new AddLineBuildingMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addLineBuildingMasterMntDao.Execute(trxContext, vo);

        }
    }
}
