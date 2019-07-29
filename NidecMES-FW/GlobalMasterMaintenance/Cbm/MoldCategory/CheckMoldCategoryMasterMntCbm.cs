using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckMoldCategoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkMoldCategoryDao = new CheckMoldCategoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkMoldCategoryDao.Execute(trxContext, vo);

        }
    }
}
