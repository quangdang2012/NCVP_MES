using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionItemMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getInspectionItemMasterMntDao = new GetInspectionItemMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getInspectionItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
