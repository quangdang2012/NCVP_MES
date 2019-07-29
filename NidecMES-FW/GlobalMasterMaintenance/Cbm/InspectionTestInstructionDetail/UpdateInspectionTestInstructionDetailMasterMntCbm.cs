using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateInspectionTestInstructionDetailMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateInspectionTestInstructionDetailDao = new UpdateInspectionTestInstructionDetailMasterMntDao();
        
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateInspectionTestInstructionDetailDao.Execute(trxContext, vo);

        }
    }
}
