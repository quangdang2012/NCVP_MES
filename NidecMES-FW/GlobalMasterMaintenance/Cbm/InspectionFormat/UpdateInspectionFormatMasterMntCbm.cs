using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateInspectionFormatMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateInspectionFormatDao = new UpdateInspectionFormatMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateInspectionFormatDao.Execute(trxContext, vo);

        }
    }
}
