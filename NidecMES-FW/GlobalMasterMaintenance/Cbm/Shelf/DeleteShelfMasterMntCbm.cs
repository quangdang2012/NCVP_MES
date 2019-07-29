using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteShelfMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteShelfDao = new DeleteShelfMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteShelfDao.Execute(trxContext, vo);

        }
    }
}
