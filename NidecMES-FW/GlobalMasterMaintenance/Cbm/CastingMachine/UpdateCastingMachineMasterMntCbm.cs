using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateCastingMachineMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateCastingMachineDao = new UpdateCastingMachineMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateCastingMachineDao.Execute(trxContext, vo);

        }
    }
}
