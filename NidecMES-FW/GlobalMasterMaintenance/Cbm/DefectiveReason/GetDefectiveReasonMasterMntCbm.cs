using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetDefectiveReasonMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getDefectiveReasonDao = new GetDefectiveReasonMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getDefectiveReasonDao.Execute(trxContext, vo);

        }
    }
}
