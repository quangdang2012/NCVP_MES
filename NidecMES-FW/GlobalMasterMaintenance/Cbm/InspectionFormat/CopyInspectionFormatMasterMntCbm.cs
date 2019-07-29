using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CopyInspectionFormatMasterMntCbm : CbmController
    {
        private readonly CbmController addInspectionFormatAndItemLineFormatCbm = new AddInspectionFormatAndItemLineFormatCbm();
        private readonly CbmController copyInspectionProcessMasterMntCbm = new CopyInspectionProcessMasterMntCbm();
        private readonly CbmController copyInspectionItemMasterMntCbm = new CopyInspectionItemMasterMntCbm();
        private readonly CbmController copyInspectionSelectionDataTypeMasterMntCbm = new CopyInspectionSelectionDataTypeMasterMntCbm();
        private readonly CbmController copyInspectionSpecificationMasterMntCbm = new CopyInspectionSpecificationMasterMntCbm();
        private readonly CbmController copyInspectionTestInstructionMasterMntCbm = new CopyInspectionTestInstructionMasterMntCbm();
        private readonly CbmController copyInspectionTestInstructionDetailMasterMntCbm = new CopyInspectionTestInstructionDetailMasterMntCbm();

        //For Process function Copy
        private readonly CbmController copyInspectionProcessFromProcessMasterMntCbm = new CopyInspectionProcessFromProcessMasterMntCbm();

        //For Item function Copy
        private readonly CbmController copyInspectionItemFromItemMasterMntCbm = new CopyInspectionItemFromItemMasterMntCbm();                     

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            ValueObjectList<ValueObject> inListVo = (ValueObjectList<ValueObject>)vo;
            InspectionReturnVo outVo = null;

            if (inListVo == null && inListVo.GetList() == null && inListVo.GetList().Count < 7)
            {
                return outVo;
            }
            InspectionFormatVo updateFormatVo = (InspectionFormatVo)inListVo.GetList()[0];
            InspectionProcessVo updateprocessVo = (InspectionProcessVo)inListVo.GetList()[1];
            InspectionItemVo updateitemVo = (InspectionItemVo)inListVo.GetList()[2];
            InspectionItemSelectionDatatypeValueVo updateSelectionDataTypeValueVo = (InspectionItemSelectionDatatypeValueVo)inListVo.GetList()[3];
            InspectionSpecificationVo updateSpecificationVo = (InspectionSpecificationVo)inListVo.GetList()[4];
            InspectionTestInstructionVo updateTestInstructionVo = (InspectionTestInstructionVo)inListVo.GetList()[5];
            InspectionTestInstructionVo updateTestInstructionDetailVo = (InspectionTestInstructionVo)inListVo.GetList()[6];
            
            //Initialize Vo for Get the new inserted Result
            ValueObjectList<ValueObjectList<ValueObject>> inspectionProcessListInVo = null;
            ValueObjectList<ValueObjectList<ValueObject>> inspectionItemListInVo = null;  

            // Only For Process Copy
            if (updateprocessVo != null && updateprocessVo.InspectionProcessIdCopy > 0)
            {
                //Insert inspection process master data
                inspectionProcessListInVo = (ValueObjectList<ValueObjectList<ValueObject>>)copyInspectionProcessFromProcessMasterMntCbm.Execute(trxContext, updateprocessVo);
                if (inspectionProcessListInVo != null)
                {
                    outVo = new InspectionReturnVo();
                    outVo.InspectionFormatId = updateprocessVo.InspectionFormatId;

                    foreach (ValueObjectList<ValueObject> getProcessVo in inspectionProcessListInVo.GetList())
                    {
                        outVo.InspectionProcessId = ((InspectionProcessVo)getProcessVo.GetList()[1]).InspectionProcessId;
                        outVo.AffectedCount = ((InspectionProcessVo)getProcessVo.GetList()[1]).InspectionProcessId;
                    }

                }
            }
            else if (updateitemVo != null && updateitemVo.InspectionItemIdCopy > 0)  // Only For Item Copy
            {
                //Insert inspection item master data
                inspectionItemListInVo = (ValueObjectList<ValueObjectList<ValueObject>>)copyInspectionItemFromItemMasterMntCbm.Execute(trxContext, updateitemVo);
                if(inspectionItemListInVo != null)
                {
                    outVo = new InspectionReturnVo();
                    outVo.InspectionProcessId = updateitemVo.InspectionProcessId;

                    foreach (ValueObjectList<ValueObject> getItemVo in inspectionItemListInVo.GetList())
                    {
                        outVo.InspectionItemId = ((InspectionItemVo)getItemVo.GetList()[1]).InspectionItemId;
                        outVo.AffectedCount = ((InspectionItemVo)getItemVo.GetList()[1]).InspectionItemId;
                    }

                }                
            }
            else //Format Copy ,update, delete
            {
                //add inspectionformat based on the copied format
                InspectionFormatVo inspectionFormatVo = (InspectionFormatVo)addInspectionFormatAndItemLineFormatCbm.Execute(trxContext, updateFormatVo);
                
                //if inspectionformat data is null return null
                if (inspectionFormatVo == null)
                {
                    return outVo;
                }

                outVo = new InspectionReturnVo();
                outVo.AffectedCount = 1;
                outVo.InspectionFormatId = inspectionFormatVo.InspectionFormatId;

                //To get the Process Details based on the Copied format id
                inspectionFormatVo.InspectionFormatIdCopy = updateFormatVo.InspectionFormatIdCopy;

                // To pass the parameter to get and update the Inspection Process
                ValueObjectList<ValueObject> inVo = new ValueObjectList<ValueObject>();
                inVo.add(inspectionFormatVo);
                inVo.add(updateprocessVo);
                
                //Insert inspection process master data
                inspectionProcessListInVo = (ValueObjectList<ValueObjectList<ValueObject>>)copyInspectionProcessMasterMntCbm.Execute(trxContext, inVo);
                
            }

            if(inspectionItemListInVo == null)
            {           
                if (inspectionProcessListInVo == null || inspectionProcessListInVo.GetList() == null || inspectionProcessListInVo.GetList().Count == 0)
                {
                    return outVo;
                }

                if (outVo == null)
                {
                    outVo = new InspectionReturnVo();
                    outVo.AffectedCount = 1;
                }

                if (updateprocessVo != null && updateprocessVo.InspectionProcessIdCopy == 0)
                {
                    InspectionProcessVo returnProcessVo = (InspectionProcessVo)inspectionProcessListInVo.GetList()[inspectionProcessListInVo.GetList().Count - 1].GetList()[0];
                    if (returnProcessVo != null)
                    {
                        outVo.InspectionFormatId = returnProcessVo.InspectionFormatId;
                        outVo.InspectionProcessId = returnProcessVo.InspectionProcessId;
                    }

                    //To Remove the ReturnVo
                    inspectionProcessListInVo.GetList().RemoveAt(inspectionProcessListInVo.GetList().Count - 1);
                }

                // To pass the parameter to get and update the Inspection Item
                ValueObjectList<ValueObject> updateitemVoList = new ValueObjectList<ValueObject>();
                updateitemVoList.add(updateitemVo);
                inspectionProcessListInVo.add(updateitemVoList);
            
                //Insert inspection Item master data
                inspectionItemListInVo = (ValueObjectList<ValueObjectList<ValueObject>>)copyInspectionItemMasterMntCbm.Execute(trxContext, inspectionProcessListInVo);
            
                if (inspectionItemListInVo == null || inspectionItemListInVo.GetList() == null || inspectionItemListInVo.GetList().Count == 0)
                {
                    return outVo;
                }

                if (updateitemVo != null)
                {
                    InspectionItemVo returnItemVo = (InspectionItemVo)inspectionItemListInVo.GetList()[inspectionItemListInVo.GetList().Count - 1].GetList()[0];
                    if (returnItemVo != null)
                    {
                        outVo.InspectionProcessId = returnItemVo.InspectionProcessId;
                        outVo.InspectionItemId = returnItemVo.InspectionItemId;
                    }

                    //To Remove the ReturnVo
                    inspectionItemListInVo.GetList().RemoveAt(inspectionItemListInVo.GetList().Count - 1);
                }

                // To pass the parameter to get and update the Inspection Selection Value
                ValueObjectList<ValueObject> updateSelectionValueVoList = new ValueObjectList<ValueObject>();
                updateSelectionValueVoList.add(updateSelectionDataTypeValueVo);
                inspectionItemListInVo.add(updateSelectionValueVoList);
            
                //Insert inspection Item Selection DataType Value master data
                InspectionReturnVo returnSelectionVo = (InspectionReturnVo)copyInspectionSelectionDataTypeMasterMntCbm.Execute(trxContext, inspectionItemListInVo);
                if (updateSelectionDataTypeValueVo != null && returnSelectionVo != null) outVo.InspectionItemId = returnSelectionVo.InspectionItemId;

            }

            // To pass the parameter to get and update the Inspection Specification
            ValueObjectList<ValueObject> updateSpecificationVoList = new ValueObjectList<ValueObject>();
            updateSpecificationVoList.add(updateSpecificationVo);
            inspectionItemListInVo.add(updateSpecificationVoList);
            
            //Insert inspection Specification master data
            InspectionReturnVo returnSpecVo = (InspectionReturnVo)copyInspectionSpecificationMasterMntCbm.Execute(trxContext, inspectionItemListInVo);
            if ( updateSpecificationVo != null && returnSpecVo != null) outVo.InspectionItemId = returnSpecVo.InspectionItemId;
            
            // To pass the parameter to get and update the Inspection Test Instruction
            ValueObjectList<ValueObject> updateTestInstVoList = new ValueObjectList<ValueObject>();
            updateTestInstVoList.add(updateTestInstructionVo);
            inspectionItemListInVo.add(updateTestInstVoList);
            

            //Insert inspection Test Instruction master data
            ValueObjectList<ValueObjectList<ValueObject>>  inspectionTestInstructionOutVo = (ValueObjectList<ValueObjectList<ValueObject>>)copyInspectionTestInstructionMasterMntCbm.Execute(trxContext, inspectionItemListInVo);
            
            if (inspectionTestInstructionOutVo == null || inspectionTestInstructionOutVo.GetList() == null || inspectionTestInstructionOutVo.GetList().Count == 0)
            {
                return outVo;
            }

            if (updateTestInstructionVo != null)
            {
                InspectionTestInstructionVo returnTestInstVo = (InspectionTestInstructionVo)inspectionTestInstructionOutVo.GetList()[inspectionTestInstructionOutVo.GetList().Count - 1].GetList()[0];
                if (returnTestInstVo != null) outVo.InspectionItemId = returnTestInstVo.InspectionItemId;

                //To Remove the ReturnVo
                inspectionTestInstructionOutVo.GetList().RemoveAt(inspectionTestInstructionOutVo.GetList().Count - 1);
            }

            // To pass the parameter to get and update the Insepection Test Instruction Details
            ValueObjectList<ValueObject> updateTestInstDetailVoList = new ValueObjectList<ValueObject>();
            updateTestInstDetailVoList.add(updateTestInstructionDetailVo);
            inspectionTestInstructionOutVo.add(updateTestInstDetailVoList);
            
            //Insert inspection Test Instruction detail master data
            InspectionReturnVo returndetailVo = (InspectionReturnVo)copyInspectionTestInstructionDetailMasterMntCbm.Execute(trxContext, inspectionTestInstructionOutVo);
            if (updateTestInstructionDetailVo != null && returndetailVo != null) outVo.InspectionTestInstructionId = returndetailVo.InspectionTestInstructionId;
            
            return outVo;


        }
    }
}
