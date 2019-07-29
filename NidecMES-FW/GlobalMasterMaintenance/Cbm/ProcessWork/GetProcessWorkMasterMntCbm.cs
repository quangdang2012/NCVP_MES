using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetProcessWorkMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getProcessWorkDao = new GetProcessWorkMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getProcessWorkDao.Execute(trxContext, vo);

        }
    }
}
