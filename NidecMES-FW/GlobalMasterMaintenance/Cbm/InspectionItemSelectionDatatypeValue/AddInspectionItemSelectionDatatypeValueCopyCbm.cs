using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionItemSelectionDatatypeValueCopyCbm : CbmController
    {

        private readonly DataAccessObject addInspectionItemSelectionDatatypeValueCopyDao = new AddInspectionItemSelectionDatatypeValueCopyDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionItemSelectionDatatypeValueCopyDao.Execute(trxContext, vo);

        }
    }
}
