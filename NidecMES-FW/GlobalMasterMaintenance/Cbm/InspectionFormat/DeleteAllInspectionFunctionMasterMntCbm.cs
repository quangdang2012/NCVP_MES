using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteAllInspectionFunctionMasterMntCbm : CbmController
    {
        private readonly CbmController getInspectionItemMasterCbm = new GetInspectionItemMasterCbm();
        private readonly CbmController getInspectionTestInstructionMasterMntCbm = new GetInspectionTestInstructionMasterMntCbm();
        private readonly CbmController getInspectionTestInstructionDetailMasterMntCbm = new GetInspectionTestInstructionDetailMasterMntCbm();
        
        private readonly CbmController deleteInspectionProcessMasterMntCbm = new DeleteInspectionProcessMasterMntCbm();
        private readonly CbmController deleteInspectionItemSelectionDatatypeValueCbm = new DeleteInspectionItemSelectionDatatypeValueCbm();
        private readonly CbmController deleteInspectionItemMasterMntCbm = new DeleteInspectionItemMasterMntCbm();
        private readonly CbmController deleteInspectionSpecificationMasterMntCbm = new DeleteInspectionSpecificationMasterMntCbm();
        private readonly CbmController deleteInspectionTestInstructionMasterMntNewCbm = new DeleteInspectionTestInstructionMasterMntNewCbm();
        private readonly CbmController deleteInspectionTestInstructionDetailMasterMntCbm = new DeleteInspectionTestInstructionDetailMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InspectionFormatVo inVo = new InspectionFormatVo();
            ValueObjectList<ValueObject> inListVo = (ValueObjectList<ValueObject>)vo;
            InspectionReturnVo outVo = null;

            if (inListVo == null && inListVo.GetList() == null && inListVo.GetList().Count == 0)
            {
                return null;
            }

            InspectionFormatVo updateFormatVo = (InspectionFormatVo)inListVo.GetList()[0];
            InspectionProcessVo updateprocessVo = (InspectionProcessVo)inListVo.GetList()[1];
            InspectionItemVo updateitemVo = (InspectionItemVo)inListVo.GetList()[2];
            InspectionItemSelectionDatatypeValueVo updateSelectionDataTypeValueVo = (InspectionItemSelectionDatatypeValueVo)inListVo.GetList()[3];
            InspectionSpecificationVo updateSpecificationVo = (InspectionSpecificationVo)inListVo.GetList()[4];
            InspectionTestInstructionVo updateTestInstructionVo = (InspectionTestInstructionVo)inListVo.GetList()[5];
            InspectionTestInstructionVo updateTestInstructionDetailVo = (InspectionTestInstructionVo)inListVo.GetList()[6];

            outVo = new InspectionReturnVo();
            
            if (updateprocessVo != null && updateprocessVo.DeleteFlag)
            {
                InspectionProcessVo inspectionProcessVo = new InspectionProcessVo();
                //delete inspectionprocess
                inspectionProcessVo = (InspectionProcessVo)deleteInspectionProcessMasterMntCbm.Execute(trxContext, updateprocessVo);

                InspectionItemVo InItemVo = new InspectionItemVo();
                InItemVo.InspectionProcessId = updateprocessVo.InspectionProcessId;

                //get inspection item id
                ValueObjectList<InspectionItemVo> InspectionItemVo = (ValueObjectList<InspectionItemVo>)getInspectionItemMasterCbm.Execute(trxContext, InItemVo);

                if (InspectionItemVo == null || InspectionItemVo.GetList() == null || InspectionItemVo.GetList().Count == 0)
                {
                    outVo.AffectedCount = inspectionProcessVo.AffectedCount;
                    outVo.InspectionFormatId = updateFormatVo.InspectionFormatIdCopy;
                    return outVo;
                }

                foreach (InspectionItemVo getitemVo in InspectionItemVo.GetList())
                {
                    InspectionItemSelectionDatatypeValueVo deleteInspectionItemSelectionDatatypeValueVo = new InspectionItemSelectionDatatypeValueVo();
                    deleteInspectionItemSelectionDatatypeValueVo.InspectionItemId = getitemVo.InspectionItemId;

                    //delete inspectionitemselectionvalue
                    UpdateResultVo inspectionItemSelectionDatatypeValueVo = (UpdateResultVo)deleteInspectionItemSelectionDatatypeValueCbm.Execute(trxContext, deleteInspectionItemSelectionDatatypeValueVo);

                    InspectionSpecificationVo deleteSpecInVo = new InspectionSpecificationVo();
                    deleteSpecInVo.InspectionItemId = getitemVo.InspectionItemId;

                    //delete inspectionspecification
                    InspectionSpecificationVo inspectionSpecificationVo = (InspectionSpecificationVo)deleteInspectionSpecificationMasterMntCbm.Execute(trxContext, deleteSpecInVo);

                    InspectionTestInstructionVo inTestVo = new InspectionTestInstructionVo();
                    inTestVo.InspectionItemId = getitemVo.InspectionItemId;

                    //get inspectiontestinstruction id
                    ValueObjectList<InspectionTestInstructionVo> inspectionTestInstructionVo = (ValueObjectList<InspectionTestInstructionVo>)getInspectionTestInstructionMasterMntCbm.Execute(trxContext, inTestVo);
                    if (inspectionTestInstructionVo != null && inspectionTestInstructionVo.GetList() != null && inspectionTestInstructionVo.GetList().Count > 0)
                    {
                        //delete inspectiontestinstruction
                        InspectionTestInstructionVo deleteInspectionTestInstructionVo = (InspectionTestInstructionVo)deleteInspectionTestInstructionMasterMntNewCbm.Execute(trxContext, inspectionTestInstructionVo.GetList()[0]);
                    }

                    //delete inspectionitem
                    InspectionItemVo deleteinspectionItemVo = (InspectionItemVo)deleteInspectionItemMasterMntCbm.Execute(trxContext, getitemVo);
                }

                outVo.AffectedCount = inspectionProcessVo.AffectedCount;
                outVo.InspectionFormatId = updateFormatVo.InspectionFormatIdCopy;
                return outVo;
            }
            else if (updateitemVo != null && updateitemVo.DeleteFlag)
            {

                InspectionItemSelectionDatatypeValueVo deleteInspectionItemSelectionDatatypeValueVo = new InspectionItemSelectionDatatypeValueVo();
                deleteInspectionItemSelectionDatatypeValueVo.InspectionItemId = updateitemVo.InspectionItemId;

                //delete inspectionitemselectionvalue
                UpdateResultVo inspectionItemSelectionDatatypeValueVo = (UpdateResultVo)deleteInspectionItemSelectionDatatypeValueCbm.Execute(trxContext, deleteInspectionItemSelectionDatatypeValueVo);
                
                InspectionSpecificationVo deleteSpecInVo = new InspectionSpecificationVo();
                deleteSpecInVo.InspectionItemId = updateitemVo.InspectionItemId;

                //delete inspectionspecification
                InspectionSpecificationVo inspectionSpecificationVo = (InspectionSpecificationVo)deleteInspectionSpecificationMasterMntCbm.Execute(trxContext, deleteSpecInVo);

                InspectionTestInstructionVo inTestVo = new InspectionTestInstructionVo();
                inTestVo.InspectionItemId = updateitemVo.InspectionItemId;

                //get inspectiontestinstruction id
                ValueObjectList<InspectionTestInstructionVo> inspectionTestInstructionVo = (ValueObjectList<InspectionTestInstructionVo>)getInspectionTestInstructionMasterMntCbm.Execute(trxContext, inTestVo);
                if (inspectionTestInstructionVo != null && inspectionTestInstructionVo.GetList() != null && inspectionTestInstructionVo.GetList().Count > 0)
                {
                    //delete inspectiontestinstruction
                    InspectionTestInstructionVo deleteInspectionTestInstructionVo = (InspectionTestInstructionVo)deleteInspectionTestInstructionMasterMntNewCbm.Execute(trxContext, inspectionTestInstructionVo.GetList()[0]);
                }

                //delete inspectionitem
                InspectionItemVo deleteinspectionItemVo = (InspectionItemVo)deleteInspectionItemMasterMntCbm.Execute(trxContext, updateitemVo);

                outVo.AffectedCount = deleteinspectionItemVo.AffectedCount;
                outVo.InspectionProcessId = updateitemVo.InspectionProcessId;
                return outVo;

            }
            else if (updateSelectionDataTypeValueVo != null && updateSelectionDataTypeValueVo.DeleteFlag)
            {
                //delete inspectionitemselectionvalue
                UpdateResultVo inspectionItemSelectionDatatypeValueVo = (UpdateResultVo)deleteInspectionItemSelectionDatatypeValueCbm.Execute(trxContext, updateSelectionDataTypeValueVo);

                outVo.AffectedCount = inspectionItemSelectionDatatypeValueVo.AffectedCount;
                outVo.InspectionItemId = updateSelectionDataTypeValueVo.InspectionItemId;
                return outVo;
            }
            else if (updateSpecificationVo != null && updateSpecificationVo.DeleteFlag)
            {
                //delete inspectionspecification
                InspectionSpecificationVo deleteinspectionSpecificationVo = (InspectionSpecificationVo)deleteInspectionSpecificationMasterMntCbm.Execute(trxContext, updateSpecificationVo);
                

                outVo.AffectedCount = deleteinspectionSpecificationVo.AffectedCount;
                outVo.InspectionItemId = updateSpecificationVo.InspectionItemId;
                return outVo;
            }
            else if (updateTestInstructionVo != null && updateTestInstructionVo.DeleteFlag)
            {
                //delete inspectiontestinstruction
                InspectionTestInstructionVo deleteinspectionTestInstructionVo = (InspectionTestInstructionVo)deleteInspectionTestInstructionMasterMntNewCbm.Execute(trxContext, updateTestInstructionVo);

                outVo.AffectedCount = deleteinspectionTestInstructionVo.AffectedCount;
                outVo.InspectionItemId = updateTestInstructionVo.InspectionItemId;
                outVo.InspectionTestInstructionId = updateTestInstructionVo.InspectionTestInstructionId;
                return outVo;
            }
            else if (updateTestInstructionDetailVo != null && updateTestInstructionDetailVo.DeleteFlag)
            {
                //delete inspectiontestinstructiondetail
                InspectionTestInstructionVo deleteInspectionTestInstructionDetailVo = (InspectionTestInstructionVo)deleteInspectionTestInstructionDetailMasterMntCbm.Execute(trxContext, updateTestInstructionDetailVo);

                outVo.AffectedCount = deleteInspectionTestInstructionDetailVo.AffectedCount;
                outVo.InspectionTestInstructionId = updateTestInstructionDetailVo.InspectionTestInstructionId;
                return outVo;
            }
                        
            return outVo;
        }
    }
}
