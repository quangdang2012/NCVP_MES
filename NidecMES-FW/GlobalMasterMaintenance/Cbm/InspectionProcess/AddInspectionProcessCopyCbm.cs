using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionProcessCopyCbm : CbmController
    {

        private readonly DataAccessObject addInspectionProcessCopyDao = new AddInspectionProcessCopyDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionProcessCopyDao.Execute(trxContext, vo);
        }
    }
}
