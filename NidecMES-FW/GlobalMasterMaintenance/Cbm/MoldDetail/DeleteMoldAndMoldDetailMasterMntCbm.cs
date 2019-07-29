using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteMoldAndMoldDetailMasterMntCbm : CbmController
    {

        private readonly CbmController deleteMoldDetailMasterMntCbm = new DeleteMoldDetailMasterMntCbm();

        private readonly CbmController deleteMoldMasterMntCbm = new DeleteMoldMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            MoldDetailVo outVo = (MoldDetailVo)deleteMoldDetailMasterMntCbm.Execute(trxContext, vo);


            if (outVo.AffectedCount > 0)
            {

                MoldDetailVo inVo = (MoldDetailVo)vo;

                MoldVo moldInVo = new MoldVo();
                moldInVo.MoldId = inVo.MoldId;

                deleteMoldMasterMntCbm.Execute(trxContext, moldInVo);

            }

            return outVo;

        }
    }
}
