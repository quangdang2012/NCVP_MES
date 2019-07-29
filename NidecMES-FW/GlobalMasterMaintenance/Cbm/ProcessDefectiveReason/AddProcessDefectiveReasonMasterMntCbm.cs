using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddProcessDefectiveReasonMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addProcessDefectiveReasonDao = new AddProcessDefectiveReasonMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addProcessDefectiveReasonDao.Execute(trxContext, vo);

        }
    }
}
