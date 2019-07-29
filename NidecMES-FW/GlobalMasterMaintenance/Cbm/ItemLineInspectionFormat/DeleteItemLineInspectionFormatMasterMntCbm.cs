using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteItemLineInspectionFormatMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteItemLineInspectionFormatDao = new DeleteItemLineInspectionFormatMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteItemLineInspectionFormatDao.Execute(trxContext, vo);

        }
    }
}
