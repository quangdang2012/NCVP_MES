using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckProcessFlowRuleMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkProcessFlowRuleDao = new CheckProcessFlowRuleMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkProcessFlowRuleDao.Execute(trxContext, vo);

        }
    }
}
