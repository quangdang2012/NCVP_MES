using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetModelMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getModelDao = new GetModelMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getModelDao.Execute(trxContext, vo);

        }
    }
}
