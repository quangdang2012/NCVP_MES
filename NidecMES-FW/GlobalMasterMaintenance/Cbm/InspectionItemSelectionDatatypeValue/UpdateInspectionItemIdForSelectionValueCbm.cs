using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateInspectionItemIdForSelectionValueCbm : CbmController
    {

        private readonly DataAccessObject updateInspectionItemIdForSelectionValueDao = new UpdateInspectionItemIdForSelectionValueDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateInspectionItemIdForSelectionValueDao.Execute(trxContext, vo);

        }
    }
}
