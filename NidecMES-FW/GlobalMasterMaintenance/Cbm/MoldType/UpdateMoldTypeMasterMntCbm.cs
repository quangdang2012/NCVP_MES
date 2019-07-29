using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateMoldTypeMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateMoldTypeDao = new UpdateMoldTypeMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateMoldTypeDao.Execute(trxContext, vo);

        }
    }
}
