using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteCastingMachineMasterMntCbm : CbmController
    {
        private readonly DataAccessObject deleteCastingMachineDao = new DeleteCastingMachineMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteCastingMachineDao.Execute(trxContext, vo);

        }
    }
}
