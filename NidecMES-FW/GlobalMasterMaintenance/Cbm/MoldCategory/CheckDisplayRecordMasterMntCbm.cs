using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using System.Text;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckDisplayRecordMasterMntsCbm : CbmController
    {

        private readonly DataAccessObject checkDisplayReDao = new CheckDisplayRecordMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return checkDisplayReDao.Execute(trxContext, vo);
        }
    }
}
