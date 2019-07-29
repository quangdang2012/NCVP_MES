using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetProcessFlowRuleMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getProcessFlowRuleDao = new GetProcessFlowRuleMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getProcessFlowRuleDao.Execute(trxContext, vo);

        }
    }
}
