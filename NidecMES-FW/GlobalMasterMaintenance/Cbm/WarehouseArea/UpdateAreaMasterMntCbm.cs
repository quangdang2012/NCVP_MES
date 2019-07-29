using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateAreaMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateAreaDao = new UpdateAreaMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateAreaDao.Execute(trxContext, vo);

        }
    }
}
