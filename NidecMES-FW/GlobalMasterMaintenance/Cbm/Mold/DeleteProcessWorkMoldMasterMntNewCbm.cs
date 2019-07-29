using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteProcessWorkMoldMasterMntNewCbm : CbmController
    {

        private readonly CbmController deleteMoldMasterMntCbm = new DeleteMoldMasterMntCbm();

        private readonly CbmController deleteProcessWorkMoldMasterMntCbm = new DeleteProcessWorkMoldMasterMntCbm();
        
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            MoldVo deleteOutVo = (MoldVo)deleteMoldMasterMntCbm.Execute(trxContext, vo);

            if (deleteOutVo.AffectedCount > 0)
            {
                ProcessWorkMoldVo inVo = new ProcessWorkMoldVo();
                inVo.MoldId = ((MoldVo)vo).MoldId;
                ProcessWorkMoldVo deleteProcessWorkMoldOutVo = (ProcessWorkMoldVo)deleteProcessWorkMoldMasterMntCbm.Execute(trxContext, inVo);
            }

            return deleteOutVo;

        }
    }
}
