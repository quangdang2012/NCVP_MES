using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckModelMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkModelDao = new CheckModelMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkModelDao.Execute(trxContext, vo);

        }
    }
}
