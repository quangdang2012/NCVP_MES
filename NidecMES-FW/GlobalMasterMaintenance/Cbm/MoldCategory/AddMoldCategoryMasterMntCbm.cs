using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddMoldCategoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addMoldCategoryDao = new AddMoldCategoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addMoldCategoryDao.Execute(trxContext, vo);
        }
    }
}
