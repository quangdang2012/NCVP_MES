using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateDefectiveReasonMasterMntNewCbm : CbmController
    {
        private readonly CbmController updateDefectiveReasonMasterMntCbm = new UpdateDefectiveReasonMasterMntCbm();

        private readonly CbmController addProcessDefectiveReasonMasterMntNewCbm = new AddProcessDefectiveReasonMasterMntNewCbm();

        private readonly CbmController deleteProcessDefectiveReasonMasterMntCbm = new DeleteProcessDefectiveReasonMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            List<ValueObject> inList = ((ValueObjectList<ValueObject>)vo).GetList();

            DefectiveReasonVo defectiveReasonVoInVo = (DefectiveReasonVo)inList.FirstOrDefault();

            ProcessDefectiveReasonVo processDefectiveReasonVoInVo = (ProcessDefectiveReasonVo)inList.Skip(1).FirstOrDefault();

            DefectiveReasonVo defectiveReasonVoOutVo = (DefectiveReasonVo)updateDefectiveReasonMasterMntCbm.Execute(trxContext, defectiveReasonVoInVo);

            if (defectiveReasonVoOutVo.AffectedCount > 0)
            {
                processDefectiveReasonVoInVo.DefectiveReasonId = defectiveReasonVoInVo.DefectiveReasonId;

                ProcessDefectiveReasonVo deleteInVo = new ProcessDefectiveReasonVo();
                deleteInVo.DefectiveReasonId = defectiveReasonVoInVo.DefectiveReasonId;

                ProcessDefectiveReasonVo deleteOutVo = (ProcessDefectiveReasonVo)deleteProcessDefectiveReasonMasterMntCbm.Execute(trxContext, deleteInVo);

                ProcessDefectiveReasonVo ProcessDefectiveReasonoutVo = (ProcessDefectiveReasonVo)addProcessDefectiveReasonMasterMntNewCbm.Execute(trxContext, processDefectiveReasonVoInVo);
            }

            return defectiveReasonVoOutVo;



        }
    }
}
