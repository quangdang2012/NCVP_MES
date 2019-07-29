using Com.Nidec.Mes.Framework;
using System.Collections.Generic;
using System.Linq;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateMachineMasterAndProcessworkCbm : CbmController
    {
        private readonly CbmController updateMachineMasterMntCbm = new UpdateMachineMasterMntCbm();

        private readonly CbmController addProcessWorkMachineMasterMntCbm = new AddProcessWorkMachineMasterMntCbm();

        private readonly CbmController deleteProcessWorkMachineMasterMntCbm = new DeleteProcessWorkMachineMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            List<ValueObject> inList = ((ValueObjectList<ValueObject>)vo).GetList();

            MachineVo machineInVo = (MachineVo)inList.FirstOrDefault();

            ProcessWorkMachineVo processWorkMachineInVo = (ProcessWorkMachineVo)inList.Skip(1).FirstOrDefault();

            MachineVo machineOutVo = (MachineVo)updateMachineMasterMntCbm.Execute(trxContext, machineInVo);

            if (machineOutVo.AffectedCount > 0)
            {
                ProcessWorkMachineVo deleteInVo = new ProcessWorkMachineVo();
                deleteInVo.MachineId = machineInVo.MachineId;

                ProcessWorkMachineVo deleteOutVo = (ProcessWorkMachineVo)deleteProcessWorkMachineMasterMntCbm.Execute(trxContext, deleteInVo);

                foreach (ProcessWorkMachineVo curInVo in processWorkMachineInVo.ProcessWorkMachineListVo)
                {
                    curInVo.MachineId = machineInVo.MachineId;
                    ProcessWorkMachineVo processWorkLineOutVo = (ProcessWorkMachineVo)addProcessWorkMachineMasterMntCbm.Execute(trxContext, curInVo);
                }
                    
            }

            return machineOutVo;
        }
    }
}
