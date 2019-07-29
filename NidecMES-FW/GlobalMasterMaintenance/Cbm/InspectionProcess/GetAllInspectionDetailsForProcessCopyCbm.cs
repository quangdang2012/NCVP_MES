using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetAllInspectionDetailsForProcessCopyCbm : CbmController
    {   
        private readonly CbmController getInspectionItemListCbm = new GetInspectionItemListCbm();
        private readonly CbmController getInspectionSpecficationListCbm = new GetInspectionSpecficationListCbm();
        private readonly CbmController getInspectionTestInstructionListCbm = new GetInspectionTestInstructionListCbm();
        private readonly CbmController getInspectionTestInstructionDetailListCbm = new GetInspectionTestInstructionDetailListCbm();
        private readonly CbmController getInspectionSelectionDataTypeListCbm = new GetInspectionSelectionDataTypeListCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InspectionProcessVo inVo = (InspectionProcessVo)vo;

            ValueObjectList<InspectionProcessVo> inspectionProcessListInVo = new ValueObjectList<InspectionProcessVo>();
            ValueObjectList<InspectionItemVo> inspectionItemListInVo = new ValueObjectList<InspectionItemVo>();
            ValueObjectList<InspectionItemSelectionDatatypeValueVo> inspectionDataTypeSelectionListInVo = new ValueObjectList<InspectionItemSelectionDatatypeValueVo>();
            ValueObjectList<InspectionSpecificationVo> inspectionSpecificationListInVo = new ValueObjectList<InspectionSpecificationVo>();
            ValueObjectList<InspectionTestInstructionVo> inspectionTestInstructionListInVo = new ValueObjectList<InspectionTestInstructionVo>();
            ValueObjectList<InspectionTestInstructionVo> inspectionTestInstructionDetailListInVo = new ValueObjectList<InspectionTestInstructionVo>();

            ValueObjectList<ValueObject> OutVo = new ValueObjectList<ValueObject>();

            inspectionProcessListInVo.add(inVo);

            // Create the Vo to get the Inspection Process
            ValueObjectList<InspectionProcessVo> GetProcessinVoList = new ValueObjectList<InspectionProcessVo>();
            InspectionProcessVo ProcessVo = new InspectionProcessVo();
            ProcessVo.InspectionProcessId = inVo.InspectionProcessIdCopy;
            GetProcessinVoList.add(ProcessVo);

            //get inspection item list for the above fetched processlist
            inspectionItemListInVo = (ValueObjectList<InspectionItemVo>)getInspectionItemListCbm.Execute(trxContext, GetProcessinVoList);

            if (inspectionItemListInVo != null && inspectionItemListInVo.GetList() != null && inspectionItemListInVo.GetList().Count > 0)
            {
                //get  inspectionSelectionDataType for the above fetched itemlist
                inspectionDataTypeSelectionListInVo = (ValueObjectList<InspectionItemSelectionDatatypeValueVo>)getInspectionSelectionDataTypeListCbm.Execute(trxContext, inspectionItemListInVo);
                
                //get  inspectionspecification for the above fetched itemlist
                inspectionSpecificationListInVo = (ValueObjectList<InspectionSpecificationVo>)getInspectionSpecficationListCbm.Execute(trxContext, inspectionItemListInVo);

                //get  inspectiontestinstruction for the above fetched itemlist
                inspectionTestInstructionListInVo = (ValueObjectList<InspectionTestInstructionVo>)getInspectionTestInstructionListCbm.Execute(trxContext, inspectionItemListInVo);
            }

            if (inspectionTestInstructionListInVo != null && inspectionTestInstructionListInVo.GetList() != null && inspectionTestInstructionListInVo.GetList().Count > 0)
            {
                //get  inspectiontestinstructiondetail for the above fetched inspectiontestinstruction
                inspectionTestInstructionDetailListInVo = (ValueObjectList<InspectionTestInstructionVo>)getInspectionTestInstructionDetailListCbm.Execute(trxContext, inspectionTestInstructionListInVo);
            }

            OutVo.add(null);
            OutVo.add(inspectionProcessListInVo);
            OutVo.add(inspectionItemListInVo);
            OutVo.add(inspectionDataTypeSelectionListInVo);
            OutVo.add(inspectionSpecificationListInVo);
            OutVo.add(inspectionTestInstructionListInVo);
            OutVo.add(inspectionTestInstructionDetailListInVo);

            return OutVo;
        }
    }
}
