using Com.Nidec.Mes.Framework;
using System.Collections.Generic;
using System.Linq;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddLineMasterAndProcessworkCbm : CbmController
    {
        private readonly CbmController addLineMasterMntCbm = new AddLineMasterMntCbm();

        private readonly CbmController addProcessWorkLineMasterMntCbm = new AddProcessWorkLineMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            List<ValueObject> inList = ((ValueObjectList<ValueObject>)vo).GetList();

            LineVo lineInVo = (LineVo)inList.FirstOrDefault();

            ProcessWorkLineVo processWorkLineInVo = (ProcessWorkLineVo)inList.Skip(1).FirstOrDefault();

            LineVo lineOutVo = (LineVo)addLineMasterMntCbm.Execute(trxContext, lineInVo);

            int count = 0;

            if (lineOutVo != null && lineOutVo.LineId > 0)
            {
                count += 1;
                foreach (ProcessWorkLineVo curInVo in processWorkLineInVo.ProcessWorkLineListVo)
                {
                    curInVo.LineId = lineOutVo.LineId;
                    ProcessWorkLineVo processWorkLineOutVo = (ProcessWorkLineVo)addProcessWorkLineMasterMntCbm.Execute(trxContext, curInVo);
                }
            }

            lineOutVo.AffectedCount = count;

            return lineOutVo;

        }
    }
}
