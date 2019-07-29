using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddLineDefectiveReasonMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addProcessDefectiveReasonDao = new AddLineDefectiveReasonMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addProcessDefectiveReasonDao.Execute(trxContext, vo);

        }
    }
}
