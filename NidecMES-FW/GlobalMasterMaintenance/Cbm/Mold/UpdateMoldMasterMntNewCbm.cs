using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateMoldMasterMntNewCbm : CbmController
    {
        private readonly CbmController updateMoldMasterMntCbm = new UpdateMoldMasterMntCbm();

        private readonly CbmController addProcessWorkMoldMasterMntCbm = new AddProcessWorkMoldMasterMntCbm();

        private readonly CbmController deleteProcessWorkMoldMasterMntCbm = new DeleteProcessWorkMoldMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            List<ValueObject> inList = ((ValueObjectList<ValueObject>)vo).GetList();

            MoldVo moldInVo = (MoldVo)inList.FirstOrDefault();

            ProcessWorkMoldVo processWorkMoldInVo = (ProcessWorkMoldVo)inList.Skip(1).FirstOrDefault();

            MoldVo moldOutVo = (MoldVo)updateMoldMasterMntCbm.Execute(trxContext, moldInVo);

            if (moldOutVo.AffectedCount > 0)
            {
                processWorkMoldInVo.MoldId = moldInVo.MoldId;

                ProcessWorkMoldVo deleteInVo = new ProcessWorkMoldVo();
                deleteInVo.MoldId = moldInVo.MoldId;

                ProcessWorkMoldVo deleteOutVo = (ProcessWorkMoldVo)deleteProcessWorkMoldMasterMntCbm.Execute(trxContext, deleteInVo);

                foreach (ProcessWorkMoldVo processid in processWorkMoldInVo.ProcessWorkMoldListVo)
                {
                    processWorkMoldInVo.ProcessWorkId = processid.ProcessWorkId;   

                    ProcessWorkMoldVo ProcessWorkMoldoutVo = (ProcessWorkMoldVo)addProcessWorkMoldMasterMntCbm.Execute(trxContext, processWorkMoldInVo);
                }
            }

            return moldOutVo;



        }
    }
}
