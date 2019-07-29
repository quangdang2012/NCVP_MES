using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateMoldDetailMasterMntCbm : CbmController
    {
       
        private readonly DataAccessObject updateMolDetDao = new UpdateMoldDetailMasterMntDao();
        private readonly DataAccessObject updateLocalItemDao = new UpdateLocalItemMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

         
            MoldDetailVo inVo = (MoldDetailVo)vo;

            MoldVo moldInVo = new MoldVo();
            moldInVo.MoldId = inVo.MoldId;
            moldInVo.MoldCode = inVo.MoldCode;
            moldInVo.MoldName = inVo.MoldName;
            moldInVo.Weight = inVo.Weight;
            moldInVo.Height = inVo.Height;
            moldInVo.Depth = inVo.Depth;
            moldInVo.Width = inVo.Width;

            moldInVo.Comment = inVo.Comment;
            moldInVo.LifeShotCount = inVo.LifeShotCount;
            moldInVo.ProductionDate = inVo.ProductionDate;

            CbmController targetCbm = new UpdateMoldMasterMntCbm();

            MoldVo moldOutVo = (MoldVo)targetCbm.Execute(trxContext, moldInVo);

            if (moldOutVo.AffectedCount > 0)
            {
                //MoldModelVo modetOutVo = (MoldModelVo)updateMoldModelCbm.Execute(trxContext, inVo);

                updateLocalItemDao.Execute(trxContext, vo);

                return updateMolDetDao.Execute(trxContext, vo);
            }

            return null;
        }
    }
}
