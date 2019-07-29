using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionProcessDisplayOrderNextValCbm : CbmController
    {
        private readonly DataAccessObject getInspectionProcessDisplayOrderNextValDao = new GetInspectionProcessDisplayOrderNextValDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getInspectionProcessDisplayOrderNextValDao.Execute(trxContext, vo);

        }
    }
}
