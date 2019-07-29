using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionItemSelectionDatatypeValueCbm : CbmController
    {
        private readonly DataAccessObject getInspectionItemSelectionDatatypeValueDao = new GetInspectionItemSelectionDatatypeValueDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getInspectionItemSelectionDatatypeValueDao.Execute(trxContext, vo);

        }
    }
}
