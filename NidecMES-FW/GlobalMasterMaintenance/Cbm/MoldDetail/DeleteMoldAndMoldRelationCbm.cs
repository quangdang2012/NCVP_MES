using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    class DeleteMoldAndMoldRelationCbm : CbmController
    {
        private readonly CbmController deleteMoldDetailMasterMntCbm = new DeleteMoldDetailMasterMntCbm();

        private readonly CbmController deleteMoldItemCbm = new DeleteMoldItemCbm();

        private readonly CbmController deleteCavityByMoldIdCbm = new DeleteCavityByMoldIdCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            MoldDetailVo inVo = (MoldDetailVo)vo;

            MoldItemVo moldItemInVo = new MoldItemVo();

            moldItemInVo.MoldId = inVo.MoldId;

            deleteMoldItemCbm.Execute(trxContext, moldItemInVo);

            CavityVo cavityInVo = new CavityVo();

            cavityInVo.MoldId = inVo.MoldId;

            deleteCavityByMoldIdCbm.Execute(trxContext, cavityInVo);

            return deleteMoldDetailMasterMntCbm.Execute(trxContext, inVo);

        }
    }
}
