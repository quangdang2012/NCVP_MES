using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckCastingMachineFurnaceMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkCastingMachineFurnaceDao = new CheckCastingMachineFurnaceMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkCastingMachineFurnaceDao.Execute(trxContext, vo);

        }
    }
}
