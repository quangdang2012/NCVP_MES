using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateMoldCategoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateMoldCategoryDao = new UpdateMoldCategoryMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateMoldCategoryDao.Execute(trxContext, vo);

        }
    }
}
