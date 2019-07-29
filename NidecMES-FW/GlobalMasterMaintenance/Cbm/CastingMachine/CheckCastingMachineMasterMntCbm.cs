using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckCastingMachineMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkCastingMachineDao = new CheckCastingMachineMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkCastingMachineDao.Execute(trxContext, vo);

        }
    }
}
