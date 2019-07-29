using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetMoldTypeMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getMoldTypeDao = new GetMoldTypeMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getMoldTypeDao.Execute(trxContext, vo);

        }
    }
}
