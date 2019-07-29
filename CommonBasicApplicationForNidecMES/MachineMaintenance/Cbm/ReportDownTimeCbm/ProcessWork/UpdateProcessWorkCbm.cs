using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ReportDownTimeCbm.ProcessWork
{
    public class UpdateProcessWorkCbm : CbmController
    {
        private readonly DataAccessObject updateProcessWorkDao = new UpdateProcessWorkDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return updateProcessWorkDao.Execute(trxContext, vo);
        }
    }
}