using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetAllInspectionIDMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getAllInspectionIdMasterMntDao = new GetAllInspectionIdMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getAllInspectionIdMasterMntDao.Execute(trxContext, vo);

        }
    }
}
