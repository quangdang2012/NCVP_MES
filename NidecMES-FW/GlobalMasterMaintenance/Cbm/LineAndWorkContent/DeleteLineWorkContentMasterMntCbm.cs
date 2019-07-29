using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteLineWorkContentMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteLineWorkContentMasterMntDao = new DeleteLineWorkContentMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteLineWorkContentMasterMntDao.Execute(trxContext, vo);

        }
    }
}
