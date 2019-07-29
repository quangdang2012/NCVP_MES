using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CopyInspectionProcessMasterMntCbm : CbmController
    {
        private readonly CbmController getInspectionProcessMasterMntCbm = new GetInspectionProcessMasterMntCbm();
        private readonly CbmController addInspectionProcessMasterMntCbm = new AddInspectionProcessCopyCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ValueObjectList<ValueObject> inVo = (ValueObjectList<ValueObject>)vo;

            InspectionFormatVo FormatVo = (InspectionFormatVo)inVo.GetList()[0];
            InspectionProcessVo UpdateProcessVo = (InspectionProcessVo)inVo.GetList()[1];

            ValueObjectList<InspectionProcessVo> inspectionProcessListInVo = new ValueObjectList<InspectionProcessVo>();
            ValueObjectList<InspectionProcessVo> inspectionProcessInsertedListInVo = new ValueObjectList<InspectionProcessVo>();
            ValueObjectList<ValueObjectList<ValueObject>> outVo = null;
            InspectionProcessVo returnProcessInsertedVo = null;
            int InspFormatId = 0;

            //get inspection process master data for the formatid
            InspectionProcessVo ProcessInVo = new InspectionProcessVo();
            ProcessInVo.InspectionFormatId = FormatVo.InspectionFormatIdCopy;
            inspectionProcessListInVo = (ValueObjectList<InspectionProcessVo>)getInspectionProcessMasterMntCbm.Execute(trxContext, ProcessInVo);
            //if process data not found return the vo
            if (inspectionProcessListInVo == null || inspectionProcessListInVo.GetList() == null || inspectionProcessListInVo.GetList().Count == 0)
            {
                return outVo;
            }

            int processCount = 1;            
            inspectionProcessListInVo.GetList().ForEach(v => {
                v.InspectionProcessCode = FormatVo.InspectionFormatCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + 
                                    GlobalMasterDataTypeEnum.PROCESS_CODE.GetValue() + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + processCount;
                v.InspectionFormatId = FormatVo.InspectionFormatId;
                processCount += 1;
            });

            if (UpdateProcessVo != null && UpdateProcessVo.InspectionProcessId > 0)
            {
                if (UpdateProcessVo.DeleteFlag)
                {
                    inspectionProcessListInVo.GetList().Remove(inspectionProcessListInVo.GetList().Single(v => v.InspectionProcessId == UpdateProcessVo.InspectionProcessId));
                }
                else
                {
                    foreach (InspectionProcessVo processVo in inspectionProcessListInVo.GetList().Where(v => v.InspectionProcessId == UpdateProcessVo.InspectionProcessId))
                    {
                        processVo.InspectionProcessName = UpdateProcessVo.InspectionProcessName;
                    }
                }
            }            

            returnProcessInsertedVo = (InspectionProcessVo)addInspectionProcessMasterMntCbm.Execute(trxContext, inspectionProcessListInVo);

            ProcessInVo.InspectionFormatId = FormatVo.InspectionFormatId;
            inspectionProcessInsertedListInVo = (ValueObjectList<InspectionProcessVo>)getInspectionProcessMasterMntCbm.Execute(trxContext, ProcessInVo);
            
            foreach (InspectionProcessVo OldProcessVo in inspectionProcessListInVo.GetList())
            {
                InspectionProcessVo NewProcessVo = null;
                ValueObjectList<ValueObject> CombinationVo = new ValueObjectList<ValueObject>();

                foreach (InspectionProcessVo processVo in inspectionProcessInsertedListInVo.GetList().Where(v => v.InspectionProcessCode == OldProcessVo.InspectionProcessCode))
                {
                    NewProcessVo = processVo;
                }

                if (InspFormatId == 0) { InspFormatId = NewProcessVo.InspectionFormatId; }
                CombinationVo.add(OldProcessVo);
                CombinationVo.add(NewProcessVo);               
                if (outVo == null)
                {
                    outVo = new ValueObjectList<ValueObjectList<ValueObject>>();
                }
                outVo.add(CombinationVo);
            }

            if (UpdateProcessVo != null)
            {
                ValueObjectList<ValueObject> returnOutListVo = new ValueObjectList<ValueObject>();
                UpdateProcessVo.InspectionFormatId = InspFormatId;
                returnOutListVo.add(UpdateProcessVo);
                outVo.add(returnOutListVo);
            }

            return outVo;
        }        
    }
}
