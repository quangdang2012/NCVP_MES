using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddProcessFlowRuleMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addProcessFlowRuleDao = new AddProcessFlowRuleMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addProcessFlowRuleDao.Execute(trxContext, vo);

        }
    }
}
