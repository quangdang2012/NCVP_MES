using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CopyInspectionSelectionDataTypeMasterMntCbm : CbmController
    {  
        private readonly CbmController getInspectionSelectionDataTypeListCbm = new GetInspectionSelectionDataTypeListCbm();
        private readonly CbmController addInspectionItemSelectionDatatypeValueCopyCbm = new AddInspectionItemSelectionDatatypeValueCopyCbm();

        private InspectionItemSelectionDatatypeValueVo UpdateSelectionValueVo = null;
        private ValueObjectList<InspectionItemSelectionDatatypeValueVo> inspectionSelectionValueListInVo;
        private InspectionReturnVo outVo = null;

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            ValueObjectList<ValueObjectList<ValueObject>> inVo = (ValueObjectList<ValueObjectList<ValueObject>>)vo;
            if (inVo == null || inVo.GetList() == null || inVo.GetList().Count == 0)
            {
                return outVo;
            }

            ValueObjectList<ValueObject> updateSelectionValueListVo = new ValueObjectList<ValueObject>();
            UpdateResultVo returnitemSelectionInsertedVo = null;

            updateSelectionValueListVo = inVo.GetList()[inVo.GetList().Count - 1];
            if (updateSelectionValueListVo != null && updateSelectionValueListVo.GetList() != null && updateSelectionValueListVo.GetList().Count > 0)
            {
                UpdateSelectionValueVo = new InspectionItemSelectionDatatypeValueVo();
                UpdateSelectionValueVo = (InspectionItemSelectionDatatypeValueVo)updateSelectionValueListVo.GetList()[0];
            }

            inVo.GetList().RemoveAt(inVo.GetList().Count - 1);

            //get inspection Selection Value list for the above fetched itemlist
            inspectionSelectionValueListInVo = (ValueObjectList<InspectionItemSelectionDatatypeValueVo>)getInspectionSelectionDataTypeListCbm.Execute(trxContext, inVo);
            if (inspectionSelectionValueListInVo == null || inspectionSelectionValueListInVo.GetList() == null || inspectionSelectionValueListInVo.GetList().Count == 0)
            {
                return outVo;
            }

            if (UpdateSelectionValueVo != null && UpdateSelectionValueVo.InspectionItemSelectionDatatypeValueId > 0)
            {
                if (UpdateSelectionValueVo.DeleteFlag)
                {
                    inspectionSelectionValueListInVo.GetList().Remove(inspectionSelectionValueListInVo.GetList().Single(v => v.InspectionItemSelectionDatatypeValueId == UpdateSelectionValueVo.InspectionItemSelectionDatatypeValueId));
                }
                else
                {
                    foreach (InspectionItemSelectionDatatypeValueVo ItemVo in inspectionSelectionValueListInVo.GetList().Where(v => v.InspectionItemSelectionDatatypeValueId == UpdateSelectionValueVo.InspectionItemSelectionDatatypeValueId))
                    {
                        ItemVo.InspectionItemSelectionDatatypeValueText = UpdateSelectionValueVo.InspectionItemSelectionDatatypeValueText;
                        ItemVo.DisplayOrder = UpdateSelectionValueVo.DisplayOrder;
                    }
                }
            }

            int returnProcessId = 0;
            foreach (ValueObjectList<ValueObject> getitemVo in inVo.GetList())
            {
                InspectionItemVo OldInsProcessVo = (InspectionItemVo)getitemVo.GetList()[0];
                InspectionItemVo NewInsProcessVo = (InspectionItemVo)getitemVo.GetList()[1];

                int ItemSelectionCount = 1;
                foreach (InspectionItemSelectionDatatypeValueVo itemVo in inspectionSelectionValueListInVo.GetList().Where(v => v.InspectionItemId == OldInsProcessVo.InspectionItemId).Distinct())
                {
                    itemVo.InspectionItemId = NewInsProcessVo.InspectionItemId;
                    itemVo.InspectionItemSelectionDatatypeValueCode = NewInsProcessVo.InspectionItemCode +
                                          GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() +
                                          GlobalMasterDataTypeEnum.SELECTION_VALUE_CODE.GetValue() +
                                          GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + ItemSelectionCount;
                    ItemSelectionCount += 1;
                }

                if (UpdateSelectionValueVo != null)
                {
                    if (UpdateSelectionValueVo.InspectionItemId == OldInsProcessVo.InspectionItemId)
                    { UpdateSelectionValueVo.InspectionItemId = NewInsProcessVo.InspectionItemId; returnProcessId = NewInsProcessVo.InspectionProcessId; }
                }

            }

            returnitemSelectionInsertedVo = (UpdateResultVo)addInspectionItemSelectionDatatypeValueCopyCbm.Execute(trxContext, inspectionSelectionValueListInVo);

            if (UpdateSelectionValueVo != null)
            {
                if (outVo == null)
                {
                    outVo = new InspectionReturnVo();
                }
                outVo.InspectionItemId = UpdateSelectionValueVo.InspectionItemId;
                outVo.InspectionProcessId = returnProcessId;
            }

            return outVo;
        }        
        
    }
}
