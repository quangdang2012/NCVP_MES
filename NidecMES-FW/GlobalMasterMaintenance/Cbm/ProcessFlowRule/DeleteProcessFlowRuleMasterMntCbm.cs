using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteProcessFlowRuleMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteProcessFlowRuleDao = new DeleteProcessFlowRuleMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteProcessFlowRuleDao.Execute(trxContext, vo);

        }
    }
}
