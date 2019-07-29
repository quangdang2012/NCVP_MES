using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetAreaMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getAreaDao = new GetAreaMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getAreaDao.Execute(trxContext, vo);

        }
    }
}
