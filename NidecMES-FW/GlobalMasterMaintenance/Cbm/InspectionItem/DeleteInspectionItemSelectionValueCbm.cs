using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInspectionItemSelectionValueCbm : CbmController
    {

        private readonly DataAccessObject deleteInspectionItemSelectionValueDao = new DeleteInspectionItemSelectionValueDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteInspectionItemSelectionValueDao.Execute(trxContext, vo);

        }
    }
}
