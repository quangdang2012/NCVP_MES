using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetCastingMachineMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getCastingMachineDao = new GetCastingMachineMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getCastingMachineDao.Execute(trxContext, vo);

        }
    }
}
