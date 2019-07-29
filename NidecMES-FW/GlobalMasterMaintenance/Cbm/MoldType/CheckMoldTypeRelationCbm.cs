using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckMoldTypeRelationCbm : CbmController
    {

        private readonly DataAccessObject checkMoldTypeRelationDao = new CheckMoldTypeRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkMoldTypeRelationDao.Execute(trxContext, vo);

        }
    }
}
