using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionProcessSeqCbm : CbmController
    {
        private readonly DataAccessObject getInspectionProcessSeqDao = new GetInspectionProcessSeqDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionProcessSeqDao.Execute(trxContext, vo);

        }
    }
}
