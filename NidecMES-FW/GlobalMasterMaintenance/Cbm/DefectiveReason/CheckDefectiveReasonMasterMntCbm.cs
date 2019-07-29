using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckDefectiveReasonMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkDefectiveReasonDao = new CheckDefectiveReasonMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkDefectiveReasonDao.Execute(trxContext, vo);

        }
    }
}
