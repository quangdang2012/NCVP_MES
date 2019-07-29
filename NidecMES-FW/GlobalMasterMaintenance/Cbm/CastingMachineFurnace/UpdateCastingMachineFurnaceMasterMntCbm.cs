using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateCastingMachineFurnaceMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateCastingMachineFurnaceDao = new UpdateCastingMachineFurnaceMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateCastingMachineFurnaceDao.Execute(trxContext, vo);

        }
    }
}
