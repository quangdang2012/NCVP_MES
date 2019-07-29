using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetFactoryMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getFactoryDao = new GetFactoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
                return getFactoryDao.Execute(trxContext, vo);

        }
    }
}
