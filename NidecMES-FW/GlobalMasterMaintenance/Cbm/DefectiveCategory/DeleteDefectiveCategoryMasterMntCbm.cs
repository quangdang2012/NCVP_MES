using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteDefectiveCategoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteDefectiveCategoryDao = new DeleteDefectiveCategoryMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteDefectiveCategoryDao.Execute(trxContext, vo);

        }
    }
}
