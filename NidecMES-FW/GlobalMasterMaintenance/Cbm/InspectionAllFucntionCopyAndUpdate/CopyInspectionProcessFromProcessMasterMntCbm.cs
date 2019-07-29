using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CopyInspectionProcessFromProcessMasterMntCbm : CbmController
    {
        private readonly CbmController addInspectionProcessMasterMntCbm = new AddInspectionProcessMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InspectionProcessVo inVo = (InspectionProcessVo)vo;

            ValueObjectList<ValueObjectList<ValueObject>> outVo = null;

            //if process data not found return the vo
            if (inVo == null || inVo.InspectionProcessIdCopy == 0)
            {
                return outVo;
            }

            InspectionProcessVo returnProcessVo = null;

            inVo.InspectionProcessCode = inVo.InspectionFormatCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + GlobalMasterDataTypeEnum.PROCESS_CODE.GetValue() + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + inVo.SequenceNo;

            returnProcessVo = (InspectionProcessVo)addInspectionProcessMasterMntCbm.Execute(trxContext, inVo);

            //To get the old record for InspectionItem Insertion
            inVo.InspectionProcessId = inVo.InspectionProcessIdCopy;

            //No records Added
            if (returnProcessVo == null || returnProcessVo.InspectionProcessId == 0) return outVo;

            returnProcessVo.InspectionProcessCode = inVo.InspectionProcessCode;

            ValueObjectList<ValueObject> CombinationVo = new ValueObjectList<ValueObject>();
            CombinationVo.add(inVo);
            CombinationVo.add(returnProcessVo);

            if (outVo == null)
            {
                outVo = new ValueObjectList<ValueObjectList<ValueObject>>();
            }
            outVo.add(CombinationVo);
            return outVo;
        }
    }
}

