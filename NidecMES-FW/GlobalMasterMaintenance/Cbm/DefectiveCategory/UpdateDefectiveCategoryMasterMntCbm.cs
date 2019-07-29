using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateDefectiveCategoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateDefectiveCategoryDao = new UpdateDefectiveCategoryMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateDefectiveCategoryDao.Execute(trxContext, vo);

        }
    }
}
