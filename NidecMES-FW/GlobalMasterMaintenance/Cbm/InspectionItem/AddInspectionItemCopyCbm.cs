using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionItemCopyCbm : CbmController
    {

        private readonly DataAccessObject addInspectionItemCopyDao = new AddInspectionItemCopyDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionItemCopyDao.Execute(trxContext, vo);

        }
    }
}
