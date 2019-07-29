using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateDefectiveReasonMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateDefectiveReasonDao = new UpdateDefectiveReasonMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateDefectiveReasonDao.Execute(trxContext, vo);

        }
    }
}
