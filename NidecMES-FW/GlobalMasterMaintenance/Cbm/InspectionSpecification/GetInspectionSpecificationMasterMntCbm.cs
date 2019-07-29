using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionSpecificationMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getInspectionSpecificationDao = new GetInspectionSpecificationMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionSpecificationDao.Execute(trxContext, vo);

        }
    }
}
