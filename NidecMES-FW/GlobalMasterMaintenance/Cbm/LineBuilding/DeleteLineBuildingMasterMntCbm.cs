using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteLineBuildingMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteLineBuildingMasterMntDao = new DeleteLineBuildingMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteLineBuildingMasterMntDao.Execute(trxContext, vo);

        }
    }
}
