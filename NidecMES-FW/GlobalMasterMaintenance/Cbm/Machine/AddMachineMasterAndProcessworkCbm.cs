using Com.Nidec.Mes.Framework;
using System.Collections.Generic;
using System.Linq;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddMachineMasterAndProcessworkCbm : CbmController
    {
        private readonly CbmController addMachineMasterMntCbm = new AddMachineMasterMntCbm();

        private readonly CbmController addProcessWorkMachineMasterMntCbm = new AddProcessWorkMachineMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            List<ValueObject> inList = ((ValueObjectList<ValueObject>)vo).GetList();

            MachineVo machineInVo = (MachineVo)inList.FirstOrDefault();

            ProcessWorkMachineVo processWorkMachineInVo = (ProcessWorkMachineVo)inList.Skip(1).FirstOrDefault();

            MachineVo machineOutVo = (MachineVo)addMachineMasterMntCbm.Execute(trxContext, machineInVo);

            int count = 0;

            if (machineOutVo != null && machineOutVo.MachineId > 0)
            {
                count += 1;
                foreach (ProcessWorkMachineVo curInVo in processWorkMachineInVo.ProcessWorkMachineListVo)
                {
                    curInVo.MachineId = machineOutVo.MachineId;
                    ProcessWorkMachineVo processWorkMachineOutVo = (ProcessWorkMachineVo)addProcessWorkMachineMasterMntCbm.Execute(trxContext, curInVo);
                }
                                
            }

            machineOutVo.AffectedCount = count;

            return machineOutVo;

        }
    }
}
