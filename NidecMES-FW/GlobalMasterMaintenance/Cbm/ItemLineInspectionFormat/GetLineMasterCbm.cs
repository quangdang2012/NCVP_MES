using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetLineMasterCbm : CbmController
    {
        private readonly DataAccessObject getLineDao = new GetLineMasterDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getLineDao.Execute(trxContext, vo);

        }
    }
}
