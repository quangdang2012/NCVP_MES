using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Text;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckDisplayRecordMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkDisplayReDao = new CheckDisplayRecordMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return checkDisplayReDao.Execute(trxContext, vo);
        }
    }
}
