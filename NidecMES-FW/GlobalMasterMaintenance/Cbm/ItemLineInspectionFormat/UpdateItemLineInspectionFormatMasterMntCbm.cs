using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateItemLineInspectionFormatMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateItemLineInspectionFormatDao = new UpdateItemLineInspectionFormatMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateItemLineInspectionFormatDao.Execute(trxContext, vo);

        }
    }
}
