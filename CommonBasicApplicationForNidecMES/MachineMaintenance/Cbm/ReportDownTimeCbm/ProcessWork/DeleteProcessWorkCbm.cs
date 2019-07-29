using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ReportDownTimeCbm.ProcessWork
{
    public class DeleteProcessWorkCbm : CbmController
    {
        private readonly DataAccessObject deleteProcessWorkDao = new DeleteProcessWorkDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return deleteProcessWorkDao.Execute(trxContext, vo);
        }
    }
}