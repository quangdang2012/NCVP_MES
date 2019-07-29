using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetLineWorkContentMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getLineWorkContentMasterMntDao = new GetLineWorkContentMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getLineWorkContentMasterMntDao.Execute(trxContext, vo);

        }
    }
}
