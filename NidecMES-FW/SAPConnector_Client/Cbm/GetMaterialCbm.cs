using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Dao;
namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class GetMaterialCbm : CbmController
    {
        private readonly DataAccessObject getMaterialDao = new GetMaterialDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getMaterialDao.Execute(trxContext, vo);

        }
    }
}
