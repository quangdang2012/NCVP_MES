using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetEquipmentMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getEquipmentDao = new GetEquipmentMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getEquipmentDao.Execute(trxContext, vo);

        }
    }
}
