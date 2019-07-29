using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateInspectionTestInstructionWithdetailandResultcntMasterMntCbm : CbmController
    {

        private readonly CbmController updateInspectionTestInstructionDetailMasterMntCbm = new UpdateInspectionTestInstructionDetailMasterMntCbm();
        private readonly CbmController updateInstructionDetailResultCntMasterMntCbm = new UpdateInstructionDetailResultCntMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            updateInstructionDetailResultCntMasterMntCbm.Execute(trxContext, vo);
            return updateInspectionTestInstructionDetailMasterMntCbm.Execute(trxContext, vo);
        }
    }
}
