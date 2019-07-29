using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckMachineMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkMachineDao = new CheckMachineMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkMachineDao.Execute(trxContext, vo);

        }
    }
}
