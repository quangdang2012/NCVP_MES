using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddItemLineInspectionFormatMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addItemLineInspectionFormatDao = new AddItemLineInspectionFormatMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addItemLineInspectionFormatDao.Execute(trxContext, vo);
        }
    }
}
