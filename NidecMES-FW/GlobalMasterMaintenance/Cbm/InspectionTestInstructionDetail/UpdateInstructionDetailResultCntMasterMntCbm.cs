using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateInstructionDetailResultCntMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateInstructionDetailResultCntMasterMntDao = new UpdateInstructionDetailResultCntMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateInstructionDetailResultCntMasterMntDao.Execute(trxContext, vo);

        }
    }
}
