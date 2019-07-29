using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteCavityMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteCavityDao = new DeleteCavityMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteCavityDao.Execute(trxContext, vo);

        }
    }
}
