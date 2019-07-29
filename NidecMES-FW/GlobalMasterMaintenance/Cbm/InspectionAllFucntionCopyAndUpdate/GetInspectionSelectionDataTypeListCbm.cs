using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionSelectionDataTypeListCbm : CbmController
    {
        private readonly DataAccessObject getInspectionSelectionDataTypeListDao = new GetInspectionSelectionDataTypeListDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionSelectionDataTypeListDao.Execute(trxContext, vo);

        }
    }
}
