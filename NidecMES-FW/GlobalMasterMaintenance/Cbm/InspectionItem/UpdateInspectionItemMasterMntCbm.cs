using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateInspectionItemMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateInspectionItemMasterMntDao = new UpdateInspectionItemMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateInspectionItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
