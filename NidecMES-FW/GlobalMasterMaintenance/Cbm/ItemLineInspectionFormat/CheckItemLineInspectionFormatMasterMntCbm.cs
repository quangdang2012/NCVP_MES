using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckItemLineInspectionFormatMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkItemLineInspectionFormatDao = new CheckItemLineInspectionFormatMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkItemLineInspectionFormatDao.Execute(trxContext, vo);

        }
    }
}
