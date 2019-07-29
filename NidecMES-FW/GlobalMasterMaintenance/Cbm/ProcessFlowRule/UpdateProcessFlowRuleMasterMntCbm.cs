using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateProcessFlowRuleMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateProcessFlowRuleDao = new UpdateProcessFlowRuleMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateProcessFlowRuleDao.Execute(trxContext, vo);

        }
    }
}
