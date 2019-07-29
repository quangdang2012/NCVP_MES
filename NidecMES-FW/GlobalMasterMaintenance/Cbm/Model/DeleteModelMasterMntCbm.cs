using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteModelMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteModelDao = new DeleteModelMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteModelDao.Execute(trxContext, vo);

        }
    }
}
