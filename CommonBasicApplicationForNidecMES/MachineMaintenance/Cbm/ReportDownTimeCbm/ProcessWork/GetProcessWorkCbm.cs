using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ReportDownTimeCbm.ProcessWork
{
    public class GetAllProcessWorkCbm : CbmController
    {
        private readonly DataAccessObject getProcessWorkDao = new GetAllProcessWorkDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getProcessWorkDao.Execute(trxContext, vo);
        }
    }
}