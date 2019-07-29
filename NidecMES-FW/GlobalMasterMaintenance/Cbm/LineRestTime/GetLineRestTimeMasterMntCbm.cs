using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetLineRestTimeMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getLineRestTimeMasterMntDao = new GetLineRestTimeMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getLineRestTimeMasterMntDao.Execute(trxContext, vo);

        }
    }
}
