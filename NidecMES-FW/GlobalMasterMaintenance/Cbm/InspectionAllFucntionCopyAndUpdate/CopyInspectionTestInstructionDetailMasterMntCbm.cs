using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CopyInspectionTestInstructionDetailMasterMntCbm : CbmController
    {
        private readonly CbmController getInspectionTestInstructionDetailCbm = new GetInspectionTestInstructionDetailCbm();
        private readonly CbmController addInspectionTestInstructionDetailCopyCbm = new AddInspectionTestInstructionDetailCopyCbm();

        private InspectionTestInstructionVo UpdateTestInstDetailVo = null;
        private ValueObjectList<InspectionTestInstructionVo> inspectionTestInstructionListInVo;
        private InspectionReturnVo outVo = null;

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            ValueObjectList<ValueObjectList<ValueObject>> inVo = (ValueObjectList<ValueObjectList<ValueObject>>)vo;
            if (inVo == null || inVo.GetList() == null || inVo.GetList().Count == 0)
            {
                return outVo;
            }

            ValueObjectList<ValueObject> UpdateInstTestDetailListVo = new ValueObjectList<ValueObject>();
            UpdateResultVo returnInstTestDetailInsertedVo = null;

            UpdateInstTestDetailListVo = inVo.GetList()[inVo.GetList().Count - 1];
            if (UpdateInstTestDetailListVo != null && UpdateInstTestDetailListVo.GetList() != null && UpdateInstTestDetailListVo.GetList().Count > 0)
            {
                UpdateTestInstDetailVo = new InspectionTestInstructionVo();
                UpdateTestInstDetailVo = (InspectionTestInstructionVo)UpdateInstTestDetailListVo.GetList()[0];
            }

            inVo.GetList().RemoveAt(inVo.GetList().Count - 1);

            //get inspection Selection Value list for the above fetched itemlist
            inspectionTestInstructionListInVo = (ValueObjectList<InspectionTestInstructionVo>)getInspectionTestInstructionDetailCbm.Execute(trxContext, inVo);
            if (inspectionTestInstructionListInVo == null || inspectionTestInstructionListInVo.GetList() == null || inspectionTestInstructionListInVo.GetList().Count == 0)
            {
                return outVo;
            }

            if (UpdateTestInstDetailVo != null && UpdateTestInstDetailVo.InspectionTestInstructionDetailId > 0)
            {
                if (UpdateTestInstDetailVo.DeleteFlag)
                {
                    inspectionTestInstructionListInVo.GetList().Remove(inspectionTestInstructionListInVo.GetList().Single(v => v.InspectionTestInstructionDetailId == UpdateTestInstDetailVo.InspectionTestInstructionDetailId));
                }
                else
                {
                    foreach (InspectionTestInstructionVo ItemVo in inspectionTestInstructionListInVo.GetList().Where(v => v.InspectionTestInstructionDetailId == UpdateTestInstDetailVo.InspectionTestInstructionDetailId))
                    {
                        ItemVo.InspectionTestInstructionDetailCode = UpdateTestInstDetailVo.InspectionTestInstructionDetailCode;
                        ItemVo.InspectionTestInstructionDetailText = UpdateTestInstDetailVo.InspectionTestInstructionDetailText;
                        ItemVo.InspectionTestInstructionDetailResultCount = UpdateTestInstDetailVo.InspectionTestInstructionDetailResultCount;
                        ItemVo.InspectionTestInstructionDetailMachine = UpdateTestInstDetailVo.InspectionTestInstructionDetailMachine;
                    }
                }
            }

            foreach (ValueObjectList<ValueObject> getTestInstructionVo in inVo.GetList())
            {
                InspectionTestInstructionVo OldTestInstVo = (InspectionTestInstructionVo)getTestInstructionVo.GetList()[0];
                InspectionTestInstructionVo NewTestInstVo = (InspectionTestInstructionVo)getTestInstructionVo.GetList()[1];

                int InspTestInstructionDetailCount = 1;
                foreach (InspectionTestInstructionVo inspectionTestInstructionVo in inspectionTestInstructionListInVo.GetList().Where(v => v.InspectionTestInstructionId == OldTestInstVo.InspectionTestInstructionId).Distinct())
                {
                    inspectionTestInstructionVo.InspectionTestInstructionId = NewTestInstVo.InspectionTestInstructionId;
                    inspectionTestInstructionVo.InspectionTestInstructionDetailCode = NewTestInstVo.InspectionTestInstructionCode
                                                                         + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue()
                                                                         + GlobalMasterDataTypeEnum.DETAIL_CODE.GetValue()
                                                                         + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue()
                                                                         + InspTestInstructionDetailCount;
                    InspTestInstructionDetailCount += 1;
                }

                if (UpdateTestInstDetailVo != null)
                {
                    if (UpdateTestInstDetailVo.InspectionTestInstructionId == OldTestInstVo.InspectionTestInstructionId)
                    { UpdateTestInstDetailVo.InspectionTestInstructionId = NewTestInstVo.InspectionTestInstructionId; }
                }
            }

            returnInstTestDetailInsertedVo = (UpdateResultVo)addInspectionTestInstructionDetailCopyCbm.Execute(trxContext, inspectionTestInstructionListInVo);

            if (UpdateTestInstDetailVo != null)
            {
                if (outVo == null)
                {
                    outVo = new InspectionReturnVo();
                }
                outVo.InspectionTestInstructionId = UpdateTestInstDetailVo.InspectionTestInstructionId;
            }

            return outVo;
        }
    }
}
