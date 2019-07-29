using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInspectionTestInstructionMasterMntNewCbm : CbmController
    {
        private readonly CbmController deleteInspTestInstructionDetailMasterMntCbm = new DeleteInspectionTestInstructionDetailMasterCbm();

        private readonly CbmController deleteInspTestInstructionMasterMntCbm = new DeleteInspectionTestInstructionMasterMntCbm();          

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InspectionTestInstructionVo deleteOutVo = (InspectionTestInstructionVo)deleteInspTestInstructionMasterMntCbm.Execute(trxContext, vo);

            if (deleteOutVo.AffectedCount > 0)
            {
                InspectionTestInstructionVo deleteDetailVo = (InspectionTestInstructionVo)deleteInspTestInstructionDetailMasterMntCbm.Execute(trxContext, vo);
            }

            return deleteOutVo;
        }
    }
}
