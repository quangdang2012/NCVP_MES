using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteProcessDefectiveReasonMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteProcessDefectiveReasonDao = new DeleteProcessDefectiveReasonMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteProcessDefectiveReasonDao.Execute(trxContext, vo);

        }
    }
}
