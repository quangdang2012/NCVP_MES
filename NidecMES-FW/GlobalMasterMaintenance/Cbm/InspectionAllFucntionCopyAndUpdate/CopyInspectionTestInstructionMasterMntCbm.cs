using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CopyInspectionTestInstructionMasterMntCbm : CbmController
    {
        private readonly CbmController getInspectionTestInstructionListCbm = new GetInspectionTestInstructionListCbm();
        private readonly CbmController addInspectionTestInstructionCopyCbm = new AddInspectionTestInstructionCopyCbm();
        private readonly CbmController getInspectionTestInstructionInsertedListCbm = new GetInspectionTestInstructionInsertedListCbm();

        private InspectionTestInstructionVo UpdateTestInstructionVo = null;
        private ValueObjectList<InspectionTestInstructionVo> InspectionTestInstructionListInVo;
        private ValueObjectList<InspectionTestInstructionVo> InspectionTestInstructionInsertedListInVo;
        private ValueObjectList<ValueObjectList<ValueObject>> outVo = null;
        //private int intSerial = 0;

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            ValueObjectList<ValueObjectList<ValueObject>> inVo = (ValueObjectList<ValueObjectList<ValueObject>>)vo;
            if (inVo == null || inVo.GetList() == null || inVo.GetList().Count == 0)
            {
                return outVo;
            }

            ValueObjectList<ValueObject> updateTestInstListVo = new ValueObjectList<ValueObject>();
            string InspTestInstCode = string.Empty;
            UpdateResultVo returnTestInstInsertedVo = null;

            updateTestInstListVo = inVo.GetList()[inVo.GetList().Count - 1];
            if (updateTestInstListVo != null && updateTestInstListVo.GetList() != null && updateTestInstListVo.GetList().Count > 0)
            {
                UpdateTestInstructionVo = new InspectionTestInstructionVo();
                UpdateTestInstructionVo = (InspectionTestInstructionVo)updateTestInstListVo.GetList()[0];
            }

            inVo.GetList().RemoveAt(inVo.GetList().Count - 1);

            //get inspection Specification list for the above fetched itemlist
            InspectionTestInstructionListInVo = (ValueObjectList<InspectionTestInstructionVo>)getInspectionTestInstructionListCbm.Execute(trxContext, inVo);
            if (InspectionTestInstructionListInVo == null || InspectionTestInstructionListInVo.GetList() == null || InspectionTestInstructionListInVo.GetList().Count == 0)
            {
                return outVo;
            }

            if (UpdateTestInstructionVo != null && UpdateTestInstructionVo.InspectionTestInstructionId > 0)
            {
                if (UpdateTestInstructionVo.DeleteFlag)
                {
                    InspectionTestInstructionListInVo.GetList().Remove(InspectionTestInstructionListInVo.GetList().Single(v => v.InspectionTestInstructionId == UpdateTestInstructionVo.InspectionTestInstructionId));
                }
                else
                {
                    foreach (InspectionTestInstructionVo ItemVo in InspectionTestInstructionListInVo.GetList().Where(v => v.InspectionTestInstructionId == UpdateTestInstructionVo.InspectionTestInstructionId))
                    {
                        ItemVo.InspectionTestInstructionCode = UpdateTestInstructionVo.InspectionTestInstructionCode;
                        ItemVo.InspectionTestInstructionText = UpdateTestInstructionVo.InspectionTestInstructionText;
                    }
                }
            }

            foreach (ValueObjectList<ValueObject> getitemVo in inVo.GetList())
            {
                InspectionItemVo OldInsProcessVo = (InspectionItemVo)getitemVo.GetList()[0];
                InspectionItemVo NewInsProcessVo = (InspectionItemVo)getitemVo.GetList()[1];

                if (InspTestInstCode.Equals(string.Empty)) { InspTestInstCode = NewInsProcessVo.InspectionItemCode; }
                foreach (InspectionTestInstructionVo inspectionSpecificationVo in InspectionTestInstructionListInVo.GetList().Where(v => v.InspectionItemId == OldInsProcessVo.InspectionItemId).Distinct())
                {
                    inspectionSpecificationVo.InspectionItemId = NewInsProcessVo.InspectionItemId;
                    inspectionSpecificationVo.InspectionTestInstructionCode = NewInsProcessVo.InspectionItemCode +
                                                                            GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() +
                                                                            GlobalMasterDataTypeEnum.TEST_INST_CODE.GetValue();
                }

                if (UpdateTestInstructionVo != null)
                {
                    if (UpdateTestInstructionVo.InspectionItemId == OldInsProcessVo.InspectionItemId)
                    { UpdateTestInstructionVo.InspectionItemId = NewInsProcessVo.InspectionItemId; }
                }
            }
            
            returnTestInstInsertedVo = (UpdateResultVo)addInspectionTestInstructionCopyCbm.Execute(trxContext, InspectionTestInstructionListInVo);

            InspectionTestInstructionInsertedListInVo = (ValueObjectList<InspectionTestInstructionVo>)getInspectionTestInstructionInsertedListCbm.Execute(trxContext, InspectionTestInstructionListInVo);

            foreach (InspectionTestInstructionVo OldInspectionTestInstructioVo in InspectionTestInstructionListInVo.GetList())
            {
                InspectionTestInstructionVo NewInspectionTestInstructioVo = null;
                ValueObjectList<ValueObject> CombinationVo = new ValueObjectList<ValueObject>();
                
                foreach (InspectionTestInstructionVo ItemVo in InspectionTestInstructionInsertedListInVo.GetList().Where(v => v.InspectionTestInstructionCode == OldInspectionTestInstructioVo.InspectionTestInstructionCode && v.InspectionItemId == OldInspectionTestInstructioVo.InspectionItemId))
                {
                    NewInspectionTestInstructioVo = ItemVo;
                }
                
                CombinationVo.add(OldInspectionTestInstructioVo);
                CombinationVo.add(NewInspectionTestInstructioVo);
                if (outVo == null)
                {
                    outVo = new ValueObjectList<ValueObjectList<ValueObject>>();
                }
                outVo.add(CombinationVo);
            }

            if (UpdateTestInstructionVo != null)
            {
                ValueObjectList<ValueObject> returnOutListVo = new ValueObjectList<ValueObject>();
                returnOutListVo.add(UpdateTestInstructionVo);
                outVo.add(returnOutListVo);
            }
            
            return outVo;
        }

    }
}
