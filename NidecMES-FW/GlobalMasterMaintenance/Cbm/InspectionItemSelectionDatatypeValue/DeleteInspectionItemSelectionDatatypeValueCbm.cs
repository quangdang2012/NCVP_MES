using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInspectionItemSelectionDatatypeValueCbm : CbmController
    {

        private readonly DataAccessObject deleteInspectionItemSelectionDatatypeValueDao = new DeleteInspectionItemSelectionDatatypeValueDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteInspectionItemSelectionDatatypeValueDao.Execute(trxContext, vo);

        }
    }
}
