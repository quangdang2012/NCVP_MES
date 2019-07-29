using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CopyInspectionItemFromItemMasterMntCbm : CbmController
    {
        private readonly CbmController addInspectionItemMasterMntCbm = new AddInspectionItemMasterMntCbm();

        private readonly CbmController updateInspectionItemIdForSelectionValueCbm = new UpdateInspectionItemIdForSelectionValueCbm();
        
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InspectionItemVo inVo = (InspectionItemVo)vo;

            ValueObjectList<ValueObjectList<ValueObject>> outVo = null;

            //if process data not found return the vo
            if (inVo == null || inVo.InspectionItemIdCopy == 0)
            {
                return outVo;
            }
            
            InspectionItemVo returnItemVo = null;

            returnItemVo = (InspectionItemVo)addInspectionItemMasterMntCbm.Execute(trxContext, inVo);

            //To get the old record for InspectionItem Insertion
            inVo.InspectionItemId = inVo.InspectionItemIdCopy;

            //No records Added
            if (returnItemVo == null || returnItemVo.InspectionItemId == 0) return outVo;

            returnItemVo.InspectionItemCode = inVo.InspectionItemCode;

            if(inVo.InspectionItemDataType.ToString() == GlobalMasterDataTypeEnum.DATATYPE_SELECTION.GetValue().ToString())
            {
                //To insert selection value.
                InspectionItemSelectionDatatypeValueVo inspectionItemSelectionDatatypeValueVo = new InspectionItemSelectionDatatypeValueVo();
                inspectionItemSelectionDatatypeValueVo.InspectionItemCode = inVo.InspectionItemCode;
                inspectionItemSelectionDatatypeValueVo.InspectionItemId = returnItemVo.InspectionItemId;

                UpdateResultVo updateResultVo = (UpdateResultVo)updateInspectionItemIdForSelectionValueCbm.Execute(trxContext, inspectionItemSelectionDatatypeValueVo);
            }

            ValueObjectList<ValueObject> CombinationVo = new ValueObjectList<ValueObject>();
            CombinationVo.add(inVo);
            CombinationVo.add(returnItemVo);

            if (outVo == null)
            {
                outVo = new ValueObjectList<ValueObjectList<ValueObject>>();
            }
            outVo.add(CombinationVo);
            return outVo;
        }
    }
}

