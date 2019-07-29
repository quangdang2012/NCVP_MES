using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteMachineMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteMachineDao = new DeleteMachineMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteMachineDao.Execute(trxContext, vo);

        }
    }
}
