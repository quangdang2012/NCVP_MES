using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ReportDownTimeCbm.ProcessWork
{
    public class AddProcessWorkCbm : CbmController
    {
        private readonly DataAccessObject addProcessWorkDao = new AddProcessWorkDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return addProcessWorkDao.Execute(trxContext, vo);
        }
    }
}