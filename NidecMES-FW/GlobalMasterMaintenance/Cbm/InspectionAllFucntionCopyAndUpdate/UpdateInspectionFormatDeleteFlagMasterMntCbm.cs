using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateInspectionFormatDeleteFlagMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateInspectionFormatdeleteflagDao = new UpdateInspectionFormatDeleteFlagMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return updateInspectionFormatdeleteflagDao.Execute(trxContext, vo);
        }
    }
}
