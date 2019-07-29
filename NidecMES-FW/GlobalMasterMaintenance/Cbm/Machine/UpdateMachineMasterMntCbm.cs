using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateMachineMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateMachineDao = new UpdateMachineMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateMachineDao.Execute(trxContext, vo);

        }
    }
}
