using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInspectionFormatMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteInspectionFormatDao = new DeleteInspectionFormatMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteInspectionFormatDao.Execute(trxContext, vo);

        }
    }
}
