using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckDefectiveCategoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkDefectiveCategoryDao = new CheckDefectiveCategoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkDefectiveCategoryDao.Execute(trxContext, vo);

        }
    }
}
