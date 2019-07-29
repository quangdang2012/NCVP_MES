using Com.Nidec.Mes.Framework;
using System.Collections.Generic;
using System.Linq;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteLineMasterAndProcessworkCbm : CbmController
    {
        private readonly CbmController deleteLineMasterMntCbm = new DeleteLineMasterMntCbm();

        private readonly CbmController deleteProcessWorkLineMasterMntCbm = new DeleteProcessWorkLineMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            LineVo deleteLineOutVo = (LineVo)deleteLineMasterMntCbm.Execute(trxContext, vo);

            if (deleteLineOutVo.AffectedCount > 0)
            {
                ProcessWorkLineVo inVo = new ProcessWorkLineVo();
                inVo.LineId = ((LineVo)vo).LineId;
                ProcessWorkLineVo deleteProcessWorkLineOutVo = (ProcessWorkLineVo)deleteProcessWorkLineMasterMntCbm.Execute(trxContext, inVo);
            }

            return deleteLineOutVo;

        }
    }
}
