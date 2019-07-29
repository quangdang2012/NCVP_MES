using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionSpecificationMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addInspectionSpecificationDao = new AddInspectionSpecificationMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionSpecificationDao.Execute(trxContext, vo);
        }
    }
}
