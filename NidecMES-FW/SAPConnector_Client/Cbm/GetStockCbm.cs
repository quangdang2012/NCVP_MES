using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Dao;
using Com.Nidec.Mes.SAPConnector_Client.Vo;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class GetStockCbm : CbmController
    {

        private readonly DataAccessObject getStockDao = new GetStockDao();

        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(GetStockCbm));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            StockVo inVo = (StockVo)vo;

            if (inVo == null)
            {
                MessageData messagedata = new MessageData("scce00040", Properties.Resources.scce00040);

                Exception ex = new NullReferenceException();
                logger.Error(messagedata, ex);
                throw new Framework.ApplicationException(messagedata, ex);
            }

            if (string.IsNullOrWhiteSpace(inVo.FromMaterialNumber))
            {
                MessageData messagedata = new MessageData("scce00041", Properties.Resources.scce00041);

                Exception ex = new NullReferenceException();
                logger.Error(messagedata, ex);
                throw new Framework.ApplicationException(messagedata, ex);

            }
            if (string.IsNullOrWhiteSpace(inVo.ToMaterialNumber))
            {
                MessageData messagedata = new MessageData("scce00042", Properties.Resources.scce00042);

                Exception ex = new NullReferenceException();
                logger.Error(messagedata, ex);
                throw new Framework.ApplicationException(messagedata, ex);
            }

            return getStockDao.Execute(trxContext, vo);

        }
    }
}
