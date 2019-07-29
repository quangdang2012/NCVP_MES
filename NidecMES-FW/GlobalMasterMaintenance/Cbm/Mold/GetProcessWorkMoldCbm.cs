using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetProcessWorkMoldMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getProcessWorkMoldDao = new GetProcessWorkMoldMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getProcessWorkMoldDao.Execute(trxContext, vo);

        }
    }
}
