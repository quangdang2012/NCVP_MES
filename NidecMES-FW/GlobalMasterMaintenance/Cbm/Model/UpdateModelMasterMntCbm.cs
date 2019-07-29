using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateModelMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateModelDao = new UpdateModelMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateModelDao.Execute(trxContext, vo);

        }
    }
}
