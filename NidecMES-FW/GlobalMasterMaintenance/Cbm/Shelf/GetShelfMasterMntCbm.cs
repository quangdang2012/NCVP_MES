using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetShelfMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getShelfDao = new GetShelfMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getShelfDao.Execute(trxContext, vo);

        }
    }
}
