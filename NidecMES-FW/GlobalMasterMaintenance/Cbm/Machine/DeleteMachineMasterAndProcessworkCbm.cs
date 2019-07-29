using Com.Nidec.Mes.Framework;
using System.Collections.Generic;
using System.Linq;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteMachineMasterAndProcessworkCbm : CbmController
    {
        private readonly CbmController deleteMachineMasterMntCbm = new DeleteMachineMasterMntCbm();

        private readonly CbmController deleteProcessWorkMachineMasterMntCbm = new DeleteProcessWorkMachineMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            MachineVo deleteMachineOutVo = (MachineVo)deleteMachineMasterMntCbm.Execute(trxContext, vo);

            if (deleteMachineOutVo.AffectedCount > 0)
            {
                ProcessWorkMachineVo inVo = new ProcessWorkMachineVo();
                inVo.MachineId = ((MachineVo)vo).MachineId;
                ProcessWorkMachineVo deleteProcessWorkMachineOutVo = (ProcessWorkMachineVo)deleteProcessWorkMachineMasterMntCbm.Execute(trxContext, inVo);
            }

            return deleteMachineOutVo;

        }
    }
}
