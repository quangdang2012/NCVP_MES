using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetDisplayOrderNextValCbm : CbmController
    {
        private readonly DataAccessObject getDisplayOrderNextValDao = new GetDisplayOrderNextValDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getDisplayOrderNextValDao.Execute(trxContext, vo);

        }
    }
}
