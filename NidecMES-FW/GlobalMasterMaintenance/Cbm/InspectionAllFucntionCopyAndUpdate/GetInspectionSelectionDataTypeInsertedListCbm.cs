using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionSelectionDataTypeInsertedListCbm : CbmController
    {
        private readonly DataAccessObject getInspectionSelectionDataTypeInsertedListDao = new GetInspectionSelectionDataTypeInsertedListDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionSelectionDataTypeInsertedListDao.Execute(trxContext, vo);

        }
    }
}
