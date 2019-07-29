using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateInspectionSpecificationMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateInspectionSpecificationDao = new UpdateInspectionSpecificationMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateInspectionSpecificationDao.Execute(trxContext, vo);

        }
    }
}
