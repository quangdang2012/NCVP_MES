using Com.Nidec.Mes.Framework;
using System.Collections.Generic;
using System.Linq;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateLineMasterAndProcessworkCbm : CbmController
    {
        private readonly CbmController updateLineMasterMntCbm = new UpdateLineMasterMntCbm();

        private readonly CbmController addProcessWorkLineMasterMntCbm = new AddProcessWorkLineMasterMntCbm();

        private readonly CbmController deleteProcessWorkLineMasterMntCbm = new DeleteProcessWorkLineMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            List<ValueObject> inList = ((ValueObjectList<ValueObject>)vo).GetList();

            LineVo lineInVo = (LineVo)inList.FirstOrDefault();

            ProcessWorkLineVo processWorkLineInVo = (ProcessWorkLineVo)inList.Skip(1).FirstOrDefault();

            LineVo lineOutVo = (LineVo)updateLineMasterMntCbm.Execute(trxContext, lineInVo);

            if (lineOutVo.AffectedCount > 0)
            {
                ProcessWorkLineVo deleteInVo = new ProcessWorkLineVo();
                deleteInVo.LineId = lineInVo.LineId;

                ProcessWorkLineVo deleteOutVo = (ProcessWorkLineVo)deleteProcessWorkLineMasterMntCbm.Execute(trxContext, deleteInVo);

                foreach (ProcessWorkLineVo curInVo in processWorkLineInVo.ProcessWorkLineListVo)
                {
                    curInVo.LineId = lineInVo.LineId;
                    ProcessWorkLineVo processWorkLineOutVo = (ProcessWorkLineVo)addProcessWorkLineMasterMntCbm.Execute(trxContext, curInVo);
                }
            }

            return lineOutVo;

        }
    }
}
