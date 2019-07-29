using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionSpecificationSeqCbm : CbmController
    {
        private readonly DataAccessObject getInspectionSpecificationSeqDao = new GetInspectionSpecificationSeqDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionSpecificationSeqDao.Execute(trxContext, vo);

        }
    }
}
