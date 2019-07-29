using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetLocationMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getLocationDao = new GetLocationMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getLocationDao.Execute(trxContext, vo);

        }
    }
}
