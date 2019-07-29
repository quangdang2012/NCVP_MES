using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetFactoryProductionDaysMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getFactoryProductionDaysMasterMntCbm = new GetFactoryProductionDaysDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
                return getFactoryProductionDaysMasterMntCbm.Execute(trxContext, vo);
        }
    }
}
