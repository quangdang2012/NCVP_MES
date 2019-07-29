using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetDefectiveCategoryMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getDefectiveCategoryDao = new GetDefectiveCategoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getDefectiveCategoryDao.Execute(trxContext, vo);

        }
    }
}
