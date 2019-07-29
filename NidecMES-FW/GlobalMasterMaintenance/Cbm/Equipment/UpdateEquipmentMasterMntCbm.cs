using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateEquipmentMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateEquipmentDao = new UpdateEquipmentMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateEquipmentDao.Execute(trxContext, vo);

        }
    }
}
