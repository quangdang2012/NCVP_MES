using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInspectionItemMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteInspectionItemMasterMntDao = new DeleteInspectionItemMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteInspectionItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
