using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckEquipmentMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkEquipmentDao = new CheckEquipmentMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkEquipmentDao.Execute(trxContext, vo);

        }
    }
}
