using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddDefectiveReasonMasterMntNewCbm : CbmController
    {
        private readonly CbmController addDefectiveReasonMasterMntCbm = new AddDefectiveReasonMasterMntCbm();

        private readonly CbmController addProcessDefectiveReasonMasterMntNewCbm = new AddProcessDefectiveReasonMasterMntNewCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            List<ValueObject> inList = ((ValueObjectList<ValueObject>)vo).GetList();

            DefectiveReasonVo defectiveReasonVoInVo = (DefectiveReasonVo)inList.FirstOrDefault();

            ProcessDefectiveReasonVo processDefectiveReasonInVo = (ProcessDefectiveReasonVo)inList.Skip(1).FirstOrDefault();

            DefectiveReasonVo defectiveReasonVoOutVo = (DefectiveReasonVo)addDefectiveReasonMasterMntCbm.Execute(trxContext, defectiveReasonVoInVo);

            if (defectiveReasonVoOutVo != null && defectiveReasonVoOutVo.DefectiveReasonId > 0)
            {
                processDefectiveReasonInVo.DefectiveReasonId = defectiveReasonVoOutVo.DefectiveReasonId;

                ProcessDefectiveReasonVo processDefectiveReasonoutVo = (ProcessDefectiveReasonVo)addProcessDefectiveReasonMasterMntNewCbm.Execute(trxContext, processDefectiveReasonInVo);
            }

            return defectiveReasonVoOutVo;


        }
    }
}
