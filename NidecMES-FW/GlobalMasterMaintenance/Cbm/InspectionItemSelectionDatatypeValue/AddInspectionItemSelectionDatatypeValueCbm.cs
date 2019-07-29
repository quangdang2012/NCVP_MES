using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionItemSelectionDatatypeValueCbm : CbmController
    {

        private readonly DataAccessObject addInspectionItemSelectionDatatypeValueDao = new AddInspectionItemSelectionDatatypeValueDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionItemSelectionDatatypeValueDao.Execute(trxContext, vo);

        }
    }
}
