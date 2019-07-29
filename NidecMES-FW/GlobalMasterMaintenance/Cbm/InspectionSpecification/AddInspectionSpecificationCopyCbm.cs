using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionSpecificationCopyCbm : CbmController
    {

        private readonly DataAccessObject addInspectionSpecificationCopyDao = new AddInspectionSpecificationCopyDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionSpecificationCopyDao.Execute(trxContext, vo);
        }
    }
}
