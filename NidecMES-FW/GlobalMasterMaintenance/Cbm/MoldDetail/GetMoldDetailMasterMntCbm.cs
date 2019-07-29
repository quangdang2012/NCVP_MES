using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetMoldDetailMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getMolDetDao = new GetMoldDetailMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getMolDetDao.Execute(trxContext, vo);

        }
    }
}
