using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateShelfMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateShelfDao = new UpdateShelfMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateShelfDao.Execute(trxContext, vo);

        }
    }
}
