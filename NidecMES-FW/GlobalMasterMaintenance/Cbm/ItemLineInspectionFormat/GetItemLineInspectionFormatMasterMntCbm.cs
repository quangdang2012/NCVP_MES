using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetItemLineInspectionFormatMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getItemLineInspectionFormatDao = new GetItemLineInspectionFormatMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getItemLineInspectionFormatDao.Execute(trxContext, vo);

        }
    }
}
