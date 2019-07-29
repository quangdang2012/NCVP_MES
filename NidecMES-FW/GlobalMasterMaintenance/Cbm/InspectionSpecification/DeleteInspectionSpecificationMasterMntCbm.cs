using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInspectionSpecificationMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteInspectionSpecificationDao = new DeleteInspectionSpecificationMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteInspectionSpecificationDao.Execute(trxContext, vo);

        }
    }
}
