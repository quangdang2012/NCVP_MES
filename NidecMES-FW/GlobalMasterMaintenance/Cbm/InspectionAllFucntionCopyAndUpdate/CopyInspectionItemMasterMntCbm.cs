using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CopyInspectionItemMasterMntCbm : CbmController
    {
        private readonly CbmController addInspectionItemCopyCbm = new AddInspectionItemCopyCbm();
        private readonly CbmController getInspectionItemListCbm = new GetInspectionItemListCbm();
        private readonly CbmController getInspectionItemInsertedListCbm = new GetInspectionItemInsertedListCbm();
        private readonly CbmController updateInspectionItemMasterMntCbm = new UpdateInspectionItemMasterMntCbm();
        
        private ValueObjectList<InspectionItemVo> inspectionItemListInVo;
        private ValueObjectList<InspectionItemVo> inspectionItemInsertedListInVo;
        private ValueObjectList<ValueObjectList<ValueObject>> outVo = null;
        private InspectionItemVo updateItemVo = null;

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            ValueObjectList<ValueObjectList<ValueObject>> inVo = (ValueObjectList<ValueObjectList<ValueObject>>)vo;
            
            if (inVo == null || inVo.GetList() == null || inVo.GetList().Count == 0)
            {
                return null;
            }

            ValueObjectList<ValueObject> updateItemListVo = new ValueObjectList<ValueObject>();
            updateItemListVo = inVo.GetList()[inVo.GetList().Count - 1];
            if (updateItemListVo != null && updateItemListVo.GetList() != null && updateItemListVo.GetList().Count > 0)
            {
                updateItemVo = new InspectionItemVo();
                updateItemVo = (InspectionItemVo)updateItemListVo.GetList()[0];
            }
            inVo.GetList().RemoveAt(inVo.GetList().Count - 1);
                        
            //get inspection item list for the above fetched processlist
            inspectionItemListInVo = (ValueObjectList<InspectionItemVo>)getInspectionItemListCbm.Execute(trxContext, inVo);
            //if item data not found return the vo
            if (inspectionItemListInVo == null || inspectionItemListInVo.GetList() == null || inspectionItemListInVo.GetList().Count == 0)
            {
                return outVo;
            }

            InspectionItemVo returnitemInsertedVo = null;

            if (updateItemVo != null && updateItemVo.InspectionProcessId > 0)
            {
                if (updateItemVo.DeleteFlag)
                {
                    inspectionItemListInVo.GetList().Remove(inspectionItemListInVo.GetList().Single(v => v.InspectionItemId == updateItemVo.InspectionItemId));
                }
                else
                {
                    foreach (InspectionItemVo ItemVo in inspectionItemListInVo.GetList().Where(v => v.InspectionItemId == updateItemVo.InspectionItemId))
                    {
                        ItemVo.InspectionItemName = updateItemVo.InspectionItemName;
                        ItemVo.ParentInspectionItemId = updateItemVo.ParentInspectionItemId;
                        ItemVo.InspectionProcessId = updateItemVo.InspectionProcessId;
                        ItemVo.InspectionItemMandatory = updateItemVo.InspectionItemMandatory;
                        ItemVo.InspectionEmployeeMandatory = updateItemVo.InspectionEmployeeMandatory;
                        ItemVo.InspectionMachineMandatory = updateItemVo.InspectionMachineMandatory;
                        ItemVo.InspectionItemDataType = updateItemVo.InspectionItemDataType;
                        ItemVo.DisplayOrder = updateItemVo.DisplayOrder;
                        ItemVo.InspectionResultItemDecimalDigits = updateItemVo.InspectionResultItemDecimalDigits;
                    }
                }
            }

            foreach (ValueObjectList<ValueObject> getitemVo in inVo.GetList())
            {                
                InspectionProcessVo OldInsProcessVo = (InspectionProcessVo)getitemVo.GetList()[0];
                InspectionProcessVo NewInsProcessVo = (InspectionProcessVo)getitemVo.GetList()[1];

                int ItemCount = 1;
                foreach (InspectionItemVo itemVo in inspectionItemListInVo.GetList().Where(v => v.InspectionProcessId == OldInsProcessVo.InspectionProcessId).Distinct())
                {
                    itemVo.InspectionProcessId = NewInsProcessVo.InspectionProcessId;
                    itemVo.InspectionItemCode = NewInsProcessVo.InspectionProcessCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + GlobalMasterDataTypeEnum.ITEM_CODE.GetValue() + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + ItemCount;
                    ItemCount += 1;
                }

                if (updateItemVo != null)
                {
                    if (updateItemVo.InspectionProcessId == OldInsProcessVo.InspectionProcessId) { updateItemVo.InspectionProcessId = NewInsProcessVo.InspectionProcessId; }
                }                    
            }
            
            returnitemInsertedVo = (InspectionItemVo)addInspectionItemCopyCbm.Execute(trxContext, inspectionItemListInVo);
            
            inspectionItemInsertedListInVo = (ValueObjectList<InspectionItemVo>)getInspectionItemInsertedListCbm.Execute(trxContext, inspectionItemListInVo);


            ValueObjectList<InspectionItemVo> updateItemParentVo = null;
            foreach (InspectionItemVo OldItemVo in inspectionItemListInVo.GetList())
            {
                InspectionItemVo NewItemVo = null;
                ValueObjectList<ValueObject> CombinationVo = new ValueObjectList<ValueObject>();

                foreach (InspectionItemVo ItemVo in inspectionItemInsertedListInVo.GetList().Where(v => v.InspectionItemCode == OldItemVo.InspectionItemCode && v.InspectionProcessId == OldItemVo.InspectionProcessId))
                {
                    NewItemVo = ItemVo;
                }

                foreach (InspectionItemVo ItemParentVo in inspectionItemInsertedListInVo.GetList().Where(v => v.ParentInspectionItemId == OldItemVo.InspectionItemId && v.InspectionProcessId == OldItemVo.InspectionProcessId))
                {
                    ItemParentVo.ParentInspectionItemId = NewItemVo.InspectionItemId;
                }
                
                if (updateItemParentVo == null)
                {
                    updateItemParentVo = new ValueObjectList<InspectionItemVo>();
                }

                if(NewItemVo.ParentInspectionItemId > 0)
                {
                    updateItemParentVo.add(NewItemVo);
                }

                CombinationVo.add(OldItemVo);
                CombinationVo.add(NewItemVo);
                if (outVo == null)
                {
                    outVo = new ValueObjectList<ValueObjectList<ValueObject>>();
                }
                outVo.add(CombinationVo);
            }

            foreach (InspectionItemVo updateitemVo in updateItemParentVo.GetList())
            {
                updateInspectionItemMasterMntCbm.Execute(trxContext, updateitemVo);
            }

            if (updateItemVo != null)
            {
                ValueObjectList<ValueObject> returnOutListVo = new ValueObjectList<ValueObject>();
                returnOutListVo.add(updateItemVo);
                outVo.add(returnOutListVo);
            }
            
            return outVo;

        }
    }
}
