using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteMoldDetailMasterMntCbm : CbmController
    {
        //private readonly DataAccessObject deleteBptsItemDao = new DeleteBptsItemMasterMntDao();
        private readonly DataAccessObject deleteMolDetDao = new DeleteMoldDetailMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            MoldDetailVo outVo = (MoldDetailVo)deleteMolDetDao.Execute(trxContext, vo);
          

            if (outVo.AffectedCount > 0)
            {
                
                MoldDetailVo inVo = (MoldDetailVo)vo;
               
                MoldVo moldInVo = new MoldVo();

                moldInVo.MoldId = inVo.MoldId;
              
                CbmController targetCbm = new DeleteMoldMasterMntCbm();
              
                MoldVo moldOutVo = (MoldVo)targetCbm.Execute(trxContext, moldInVo);

            }

            return outVo;

        }
    }
}
