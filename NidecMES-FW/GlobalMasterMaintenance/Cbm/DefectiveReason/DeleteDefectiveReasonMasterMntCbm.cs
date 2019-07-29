using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteDefectiveReasonMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteDefectiveReasonDao = new DeleteDefectiveReasonMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteDefectiveReasonDao.Execute(trxContext, vo);

        }
    }
}
