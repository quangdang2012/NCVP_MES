using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetMoldCategoryMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getMoldCategoryDao = new GetMoldCategoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getMoldCategoryDao.Execute(trxContext, vo);

        }
    }
}
