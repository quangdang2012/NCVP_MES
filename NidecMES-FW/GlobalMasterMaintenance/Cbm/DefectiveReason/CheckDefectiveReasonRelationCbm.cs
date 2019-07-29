using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckDefectiveReasonRelationCbm : CbmController
    {

        private readonly DataAccessObject checkDefectiveCheckReasonDao = new CheckDefectiveReasonRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkDefectiveCheckReasonDao.Execute(trxContext, vo);

        }
    }
}
