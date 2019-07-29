using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddEquipmentMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addEquipmentDao = new AddEquipmentMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addEquipmentDao.Execute(trxContext, vo);

        }
    }
}
