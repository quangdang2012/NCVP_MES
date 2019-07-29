using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddDefectiveReasonMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addDefectiveReasonDao = new AddDefectiveReasonMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addDefectiveReasonDao.Execute(trxContext, vo);

        }
    }
}
