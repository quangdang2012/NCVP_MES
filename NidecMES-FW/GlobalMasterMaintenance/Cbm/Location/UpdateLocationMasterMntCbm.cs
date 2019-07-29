using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateLocationMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateLocationDao = new UpdateLocationMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateLocationDao.Execute(trxContext, vo);

        }
    }
}
