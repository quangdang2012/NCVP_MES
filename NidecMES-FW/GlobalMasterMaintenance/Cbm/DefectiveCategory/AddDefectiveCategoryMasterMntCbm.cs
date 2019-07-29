using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddDefectiveCategoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addDefectiveCategoryDao = new AddDefectiveCategoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addDefectiveCategoryDao.Execute(trxContext, vo);

        }
    }
}
