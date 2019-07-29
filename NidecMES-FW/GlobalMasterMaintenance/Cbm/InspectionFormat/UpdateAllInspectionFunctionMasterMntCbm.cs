using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateAllInspectionFunctionMasterMntCbm : CbmController
    {

        private readonly CbmController updateInspectionFormatDeleteFlagMasterMntCbm = new UpdateInspectionFormatDeleteFlagMasterMntCbm();
        private readonly CbmController copyInspectionFormatMasterMntCbm = new CopyInspectionFormatMasterMntCbm();

        private readonly CbmController checkInspectionFormatExitInTransactionCbm = new CheckInspectionFormatExitInTransactionCbm();
        private readonly CbmController updateInspectionFormatMasterMntCbm = new UpdateInspectionFormatMasterMntCbm();
        private readonly CbmController deleteInspectionProcessMasterMntCbm = new DeleteInspectionProcessMasterMntCbm();
        private readonly CbmController updateInspectionProcessMasterMntCbm = new UpdateInspectionProcessMasterMntCbm();
        private readonly CbmController deleteInspectionItemSelectionDatatypeValueCbm = new DeleteInspectionItemSelectionDatatypeValueCbm();
        private readonly CbmController updateInspectionItemSelectionDatatypeValueCbm = new UpdateInspectionItemSelectionDatatypeValueCbm();
        private readonly CbmController deleteInspectionItemMasterMntCbm = new DeleteInspectionItemMasterMntCbm();
        private readonly CbmController updateInspectionItemMasterMntCbm = new UpdateInspectionItemMasterMntCbm();
        private readonly CbmController deleteInspectionSpecificationMasterMntCbm = new DeleteInspectionSpecificationMasterMntCbm();
        private readonly CbmController updateInspectionSpecificationMasterMntCbm = new UpdateInspectionSpecificationMasterMntCbm();
        private readonly CbmController deleteInspectionTestInstructionMasterMntNewCbm = new DeleteInspectionTestInstructionMasterMntNewCbm();
        private readonly CbmController updateInspectionTestInstructionMasterMntCbm = new UpdateInspectionTestInstructionMasterMntCbm();
        private readonly CbmController deleteInspectionTestInstructionDetailMasterMntCbm = new DeleteInspectionTestInstructionDetailMasterMntCbm();
        private readonly CbmController updateInspectionTestInstructionDetailMasterMntCbm = new UpdateInspectionTestInstructionDetailMasterMntCbm();
        private readonly CbmController deleteAllInspectionFunctionMasterMntCbm = new DeleteAllInspectionFunctionMasterMntCbm();
        
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InspectionFormatVo inVo = new InspectionFormatVo();
            ValueObjectList<ValueObject> inListVo = (ValueObjectList<ValueObject>)vo;
            InspectionReturnVo outVo = null;

            if (inListVo ==null && inListVo.GetList() == null && inListVo.GetList().Count == 0)
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

            if (!(updateprocessVo != null && updateprocessVo.InspectionProcessIdCopy > 0 && updateitemVo != null && updateitemVo.InspectionItemIdCopy > 0)) 
            {
                InspectionFormatVo inspFormatVo = new InspectionFormatVo();
                inspFormatVo.InspectionFormatId = updateFormatVo.InspectionFormatIdCopy;
                inspFormatVo.InspectionFormatCode = updateFormatVo.InspectionFormatCode;
                inspFormatVo.InspectionFormatName = updateFormatVo.InspectionFormatName;

                UpdateResultVo updateResultVo = (UpdateResultVo)checkInspectionFormatExitInTransactionCbm.Execute(trxContext, inspFormatVo);
                if (updateResultVo.AffectedCount == 0)
                {
                    outVo = new InspectionReturnVo();

                    if (updateFormatVo.Mode == CommonConstants.MODE_UPDATE)
                    {
                        //update inspectionformat
                        InspectionFormatVo inspectionFormatVo = (InspectionFormatVo)updateInspectionFormatMasterMntCbm.Execute(trxContext, inspFormatVo);

                        outVo.AffectedCount = inspectionFormatVo.AffectedCount;
                        outVo.InspectionFormatId = inspFormatVo.InspectionFormatId;
                        return outVo;
                    }                    

                    if (updateprocessVo != null)
                    {
                        InspectionProcessVo inspectionProcessVo = new InspectionProcessVo();

                        if (updateprocessVo.DeleteFlag)
                        {
                            //delete inspectionprocess
                            return (InspectionReturnVo)deleteAllInspectionFunctionMasterMntCbm.Execute(trxContext, vo);
                        }
                        else
                        {
                            //update inspectionprocess
                            inspectionProcessVo = (InspectionProcessVo)updateInspectionProcessMasterMntCbm.Execute(trxContext, updateprocessVo);
                        }

                        outVo.AffectedCount = inspectionProcessVo.AffectedCount;
                        outVo.InspectionProcessId = updateprocessVo.InspectionProcessId;
                        outVo.InspectionFormatId = inspFormatVo.InspectionFormatId;
                        return outVo;
                    }
                    if (updateSelectionDataTypeValueVo != null)
                    {
                        if (updateSelectionDataTypeValueVo.DeleteFlag)
                        {
                            //delete inspectionitemselectionvalue
                            return (InspectionReturnVo)deleteAllInspectionFunctionMasterMntCbm.Execute(trxContext, vo);
                        }
                        else
                        {
                            //update inspectionitemselectionvalue
                            UpdateResultVo inspectionItemSelectionDatatypeValueVo = (UpdateResultVo)updateInspectionItemSelectionDatatypeValueCbm.Execute(trxContext, updateSelectionDataTypeValueVo);

                            outVo.AffectedCount = inspectionItemSelectionDatatypeValueVo.AffectedCount;
                            outVo.InspectionItemId = updateSelectionDataTypeValueVo.InspectionItemId;
                            return outVo;
                        }                        
                    }
                    if (updateitemVo != null)
                    {
                        InspectionItemVo inspectionItemVo = new InspectionItemVo();

                        if (updateitemVo.DeleteFlag)
                        {
                            //delete inspectionitem
                            return (InspectionReturnVo)deleteAllInspectionFunctionMasterMntCbm.Execute(trxContext, vo);
                        }
                        else
                        {
                            //update inspectionitem
                            inspectionItemVo = (InspectionItemVo)updateInspectionItemMasterMntCbm.Execute(trxContext, updateitemVo);
                        }

                        outVo.AffectedCount = inspectionItemVo.AffectedCount;
                        outVo.InspectionItemId = updateitemVo.InspectionItemId;
                        outVo.InspectionProcessId = updateitemVo.InspectionProcessId;
                        return outVo;
                    }
                    if (updateSpecificationVo != null)
                    {
                        InspectionSpecificationVo inspectionSpecificationVo = new InspectionSpecificationVo();

                        if (updateSpecificationVo.DeleteFlag)
                        {
                            //delete inspectionspecification
                            return (InspectionReturnVo)deleteAllInspectionFunctionMasterMntCbm.Execute(trxContext, vo);
                        }
                        else
                        {
                            //update inspectionspecification
                            inspectionSpecificationVo = (InspectionSpecificationVo)updateInspectionSpecificationMasterMntCbm.Execute(trxContext, updateSpecificationVo);
                        }

                        outVo.AffectedCount = inspectionSpecificationVo.AffectedCount;
                        outVo.InspectionItemId = updateSpecificationVo.InspectionItemId;
                        return outVo;
                    }
                    if (updateTestInstructionVo != null)
                    {
                        InspectionTestInstructionVo inspectionTestInstructionVo = new InspectionTestInstructionVo();

                        if (updateTestInstructionVo.DeleteFlag)
                        {
                            //delete inspectiontestinstruction
                            return (InspectionReturnVo)deleteAllInspectionFunctionMasterMntCbm.Execute(trxContext, vo);
                        }
                        else
                        {
                            //update inspectiontestinstruction
                            inspectionTestInstructionVo = (InspectionTestInstructionVo)updateInspectionTestInstructionMasterMntCbm.Execute(trxContext, updateTestInstructionVo);
                        }

                        outVo.AffectedCount = inspectionTestInstructionVo.AffectedCount;
                        outVo.InspectionItemId = updateTestInstructionVo.InspectionItemId;
                        outVo.InspectionTestInstructionId = updateTestInstructionVo.InspectionTestInstructionId;
                        return outVo;
                    }
                    if (updateTestInstructionDetailVo != null)
                    {
                        InspectionTestInstructionVo inspectionTestInstructionDetailVo = new InspectionTestInstructionVo();

                        if (updateTestInstructionDetailVo.DeleteFlag)
                        {
                            //delete inspectiontestinstructiondetail
                            return (InspectionReturnVo)deleteAllInspectionFunctionMasterMntCbm.Execute(trxContext, vo);
                        }
                        else
                        {
                            //update inspectiontestinstructiondetail
                            inspectionTestInstructionDetailVo = (InspectionTestInstructionVo)updateInspectionTestInstructionDetailMasterMntCbm.Execute(trxContext, updateTestInstructionDetailVo);
                        }

                        outVo.AffectedCount = inspectionTestInstructionDetailVo.AffectedCount;
                        outVo.InspectionTestInstructionId = updateTestInstructionDetailVo.InspectionTestInstructionId;
                        return outVo;
                    }
                }
            }

            inVo = (InspectionFormatVo)inListVo.GetList()[0];
            inVo.InspectionFormatId = inVo.InspectionFormatIdCopy;

            updateInspectionFormatDeleteFlagMasterMntCbm.Execute(trxContext, inVo);
            return copyInspectionFormatMasterMntCbm.Execute(trxContext, vo);
        }
    }
}
