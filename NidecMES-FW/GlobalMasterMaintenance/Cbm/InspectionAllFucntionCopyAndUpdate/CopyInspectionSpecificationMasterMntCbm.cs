using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CopyInspectionSpecificationMasterMntCbm : CbmController
    {
        private readonly CbmController getInspectionSpecficationListCbm = new GetInspectionSpecficationListCbm();
        private readonly CbmController addInspectionSpecificationCopyCbm = new AddInspectionSpecificationCopyCbm();

        private InspectionSpecificationVo UpdateSpecificationVo = null;
        private ValueObjectList<InspectionSpecificationVo> InspectionSpecificationListInVo;
        private InspectionReturnVo outVo = null;
        
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            ValueObjectList<ValueObjectList<ValueObject>> inVo = (ValueObjectList<ValueObjectList<ValueObject>>)vo;
            if (inVo == null || inVo.GetList() == null || inVo.GetList().Count == 0)
            {
                return outVo;
            }

            ValueObjectList<ValueObject> updateSpecificationListVo = new ValueObjectList<ValueObject>();
            UpdateResultVo returnitemSpecificationInsertedVo = null;

            updateSpecificationListVo = inVo.GetList()[inVo.GetList().Count - 1];
            if (updateSpecificationListVo != null && updateSpecificationListVo.GetList() != null && updateSpecificationListVo.GetList().Count > 0)
            {
                UpdateSpecificationVo = new InspectionSpecificationVo();
                UpdateSpecificationVo = (InspectionSpecificationVo)updateSpecificationListVo.GetList()[0];
            }

            inVo.GetList().RemoveAt(inVo.GetList().Count - 1);

            //get inspection Specification list for the above fetched itemlist
            InspectionSpecificationListInVo = (ValueObjectList<InspectionSpecificationVo>)getInspectionSpecficationListCbm.Execute(trxContext, inVo);
            if (InspectionSpecificationListInVo == null || InspectionSpecificationListInVo.GetList() == null || InspectionSpecificationListInVo.GetList().Count == 0)
            {
                return outVo;
            }

            if (UpdateSpecificationVo != null && UpdateSpecificationVo.InspectionSpecificationId > 0)
            {
                if (UpdateSpecificationVo.DeleteFlag)
                {
                    InspectionSpecificationListInVo.GetList().Remove(InspectionSpecificationListInVo.GetList().Single(v => v.InspectionSpecificationId == UpdateSpecificationVo.InspectionSpecificationId));
                }
                else
                {
                    foreach (InspectionSpecificationVo ItemVo in InspectionSpecificationListInVo.GetList().Where(v => v.InspectionSpecificationId == UpdateSpecificationVo.InspectionSpecificationId))
                    {
                        ItemVo.InspectionSpecificationCode = UpdateSpecificationVo.InspectionSpecificationCode;
                        ItemVo.InspectionSpecificationText = UpdateSpecificationVo.InspectionSpecificationText;
                        ItemVo.ValueFrom = UpdateSpecificationVo.ValueFrom;
                        ItemVo.ValueTo = UpdateSpecificationVo.ValueTo;
                        ItemVo.Unit = UpdateSpecificationVo.Unit;
                        ItemVo.OperatorFrom = UpdateSpecificationVo.OperatorFrom;
                        ItemVo.OperatorTo = UpdateSpecificationVo.OperatorTo;
                        ItemVo.InspectionItemId = UpdateSpecificationVo.InspectionItemId;
                        ItemVo.SpecificationResultJudgeType = UpdateSpecificationVo.SpecificationResultJudgeType;
                    }
                }
            }


            foreach (ValueObjectList<ValueObject> getitemVo in inVo.GetList())
            {
                InspectionItemVo OldInsProcessVo = (InspectionItemVo)getitemVo.GetList()[0];
                InspectionItemVo NewInsProcessVo = (InspectionItemVo)getitemVo.GetList()[1];
                
                foreach (InspectionSpecificationVo inspectionSpecificationVo in InspectionSpecificationListInVo.GetList().Where(v => v.InspectionItemId == OldInsProcessVo.InspectionItemId).Distinct())
                {
                    inspectionSpecificationVo.InspectionItemId = NewInsProcessVo.InspectionItemId;
                    inspectionSpecificationVo.InspectionSpecificationCode = NewInsProcessVo.InspectionItemCode + 
                                                                            GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + 
                                                                            GlobalMasterDataTypeEnum.SPECIFICATION_CODE.GetValue();
                }

                if (UpdateSpecificationVo != null)
                {
                    if (UpdateSpecificationVo.InspectionItemId == OldInsProcessVo.InspectionItemId)
                    { UpdateSpecificationVo.InspectionItemId = NewInsProcessVo.InspectionItemId; }
                }
            }

            returnitemSpecificationInsertedVo = (UpdateResultVo)addInspectionSpecificationCopyCbm.Execute(trxContext, InspectionSpecificationListInVo);
            
            if (UpdateSpecificationVo != null)
            {
                if (outVo == null)
                {
                    outVo = new InspectionReturnVo();
                }
                outVo.InspectionItemId = UpdateSpecificationVo.InspectionItemId;
            }
            
            return outVo;
        }
    }
}
