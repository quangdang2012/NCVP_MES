using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckMoldCategoryRelationCbm : CbmController
    {

        private readonly DataAccessObject checkMoldRelDao = new CheckMoldCategoryRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkMoldRelDao.Execute(trxContext, vo);

        }
    }
}
