using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetProcessDefectiveReasonMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getProcessDefectiveReasonDao = new GetProcessDefectiveReasonMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getProcessDefectiveReasonDao.Execute(trxContext, vo);

        }
    }
}
