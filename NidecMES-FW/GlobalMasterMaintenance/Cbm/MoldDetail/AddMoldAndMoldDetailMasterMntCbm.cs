using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddMoldAndMoldDetailMasterMntCbm : CbmController
    {

        private readonly CbmController addMoldMasterMntCbm = new AddGetMoldIdMasterMntCbm();

        private readonly CbmController addMoldDetailMasterMntCbm = new AddMoldDetailMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            MoldDetailVo inVo = (MoldDetailVo)vo;

            MoldVo moldVo = new MoldVo();
            moldVo.MoldCode = inVo.MoldCode;
            moldVo.MoldName = inVo.MoldName;
            moldVo.Weight = inVo.Weight;
            moldVo.Height = inVo.Height;
            moldVo.Depth = inVo.Depth;
            moldVo.Width = inVo.Width;
            moldVo.Comment = inVo.Comment;
            moldVo.LifeShotCount = inVo.LifeShotCount;
            moldVo.ProductionDate = inVo.ProductionDate;

            MoldVo moldOutVo = (MoldVo)addMoldMasterMntCbm.Execute(trxContext, moldVo);

            MoldDetailVo moldDetailOutVo = null;
            if (moldOutVo.MoldId > 0)
            {
                inVo.MoldId = moldOutVo.MoldId;
                moldDetailOutVo = (MoldDetailVo)addMoldDetailMasterMntCbm.Execute(trxContext, inVo);
                moldDetailOutVo.MoldId = moldOutVo.MoldId;
            }

            return moldDetailOutVo;

        }
    }
}
