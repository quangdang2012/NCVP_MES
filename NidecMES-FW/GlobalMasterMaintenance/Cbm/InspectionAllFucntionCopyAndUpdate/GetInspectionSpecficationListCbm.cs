using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionSpecficationListCbm : CbmController
    {
        private readonly DataAccessObject getInspectionSpecficationListDao = new GetInspectionSpecficationListDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionSpecficationListDao.Execute(trxContext, vo);

        }
    }
}
