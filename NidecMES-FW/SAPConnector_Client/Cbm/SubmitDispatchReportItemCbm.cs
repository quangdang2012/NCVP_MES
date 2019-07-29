using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Dao;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class SubmitDispatchReportItemCbm : CbmController
    {
        private readonly DataAccessObject submitDispatchReportItemDao = new SubmitDispatchReportDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return submitDispatchReportItemDao.Execute(trxContext, vo);
        }

    }
}
