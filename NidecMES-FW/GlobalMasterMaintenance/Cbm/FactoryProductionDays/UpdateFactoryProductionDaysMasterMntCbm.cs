using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateFactoryProductionDaysMasterMntCbm : CbmController
    {
        private readonly DataAccessObject updateFactoryProductionDaysMasterMntCbm = new UpdateFactoryProductionDaysMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateFactoryProductionDaysMasterMntCbm.Execute(trxContext, vo);

        }
    }
}
