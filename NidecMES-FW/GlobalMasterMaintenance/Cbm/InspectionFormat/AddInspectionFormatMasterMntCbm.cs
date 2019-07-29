using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionFormatMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addInspectionFormatDao = new AddInspectionFormatMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionFormatDao.Execute(trxContext, vo);
        }
    }
}
