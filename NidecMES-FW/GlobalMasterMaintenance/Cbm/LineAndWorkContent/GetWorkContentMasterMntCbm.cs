using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetWorkContentMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getWorkContentMasterMntDao = new GetWorkContentMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getWorkContentMasterMntDao.Execute(trxContext, vo);

        }
    }
}
