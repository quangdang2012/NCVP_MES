using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckModelRelationCbm : CbmController
    {

        private readonly DataAccessObject checkMoldRelDao = new CheckModelRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkMoldRelDao.Execute(trxContext, vo);

        }
    }
}
