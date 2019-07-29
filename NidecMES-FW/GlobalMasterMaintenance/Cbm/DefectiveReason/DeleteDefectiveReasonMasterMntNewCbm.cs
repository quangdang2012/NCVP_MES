using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteDefectiveReasonMasterMntNewCbm : CbmController
    {

        private readonly CbmController deleteDefectiveReasonMasterMntCbm = new DeleteDefectiveReasonMasterMntCbm();

        private readonly CbmController deleteProcessDefectiveReasonMasterMntCbm = new DeleteProcessDefectiveReasonMasterMntCbm();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            DefectiveReasonVo deleteOutVo = (DefectiveReasonVo)deleteDefectiveReasonMasterMntCbm.Execute(trxContext, vo);

            if (deleteOutVo.AffectedCount > 0)
            {
                ProcessDefectiveReasonVo inVo = new ProcessDefectiveReasonVo();
                inVo.DefectiveReasonId = ((DefectiveReasonVo)vo).DefectiveReasonId;
                ProcessDefectiveReasonVo deleteProcessDefectiveReasonOutVo = (ProcessDefectiveReasonVo)deleteProcessDefectiveReasonMasterMntCbm.Execute(trxContext, inVo);
            }

            return deleteOutVo;

        }
    }
}
