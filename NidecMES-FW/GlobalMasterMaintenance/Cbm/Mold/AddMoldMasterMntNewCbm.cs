using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddMoldMasterMntNewCbm : CbmController
    {

        private readonly CbmController addGetMoldIdMasterMntCbm = new AddGetMoldIdMasterMntCbm();

        private readonly CbmController addProcessWorkMoldMasterMntCbm = new AddProcessWorkMoldMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            List<ValueObject> inList = ((ValueObjectList<ValueObject>)vo).GetList();

            MoldVo moldInVo = (MoldVo)inList.FirstOrDefault();

            ProcessWorkMoldVo processWorkMoldInVo = (ProcessWorkMoldVo)inList.Skip(1).FirstOrDefault();

            MoldVo moldOutVo = (MoldVo)addGetMoldIdMasterMntCbm.Execute(trxContext, moldInVo);

            if (moldOutVo != null && moldOutVo.MoldId > 0)
            {
                processWorkMoldInVo.MoldId = moldOutVo.MoldId;

                foreach (ProcessWorkMoldVo processid in processWorkMoldInVo.ProcessWorkMoldListVo)
                {
                    processWorkMoldInVo.ProcessWorkId = processid.ProcessWorkId;

                    ProcessWorkMoldVo processWorkMoldoutVo = (ProcessWorkMoldVo)addProcessWorkMoldMasterMntCbm.Execute(trxContext, processWorkMoldInVo);
                }
            }

            return moldOutVo;

        }
    }
}
