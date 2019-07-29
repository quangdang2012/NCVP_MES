using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteMoldCategoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteMoldCategoryDao = new DeleteMoldCategoryMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteMoldCategoryDao.Execute(trxContext, vo);

        }
    }
}
