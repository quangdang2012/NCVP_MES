using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetParentInspectionItemIdMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getParentInspectionItemIdMasterMntDao = new GetParentInspectionItemIdMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getParentInspectionItemIdMasterMntDao.Execute(trxContext, vo);

        }
    }
}
