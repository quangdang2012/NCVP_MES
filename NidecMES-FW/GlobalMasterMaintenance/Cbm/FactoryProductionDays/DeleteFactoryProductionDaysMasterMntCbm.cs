using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteFactoryProductionDaysMasterMntCbm : CbmController
    {
        private readonly DataAccessObject deleteFactoryProductionDaysMasterMntCbm = new DeleteFactoryProductionDaysMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return deleteFactoryProductionDaysMasterMntCbm.Execute(trxContext, vo);
        }
    }
}
