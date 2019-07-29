using System;
using System.Data;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.SAPConnector_Client
{
    public abstract class AbstractSAPDataAccessObject : DataAccessObject
    {

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AbstractSAPDataAccessObject));

        /// <summary>
        /// method definition for Execute
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public abstract ValueObject Execute(TransactionContext trxContext, ValueObject vo);

        //
        /// <summary>
        /// get DefaultNpgCommandAdaptor
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        protected SAPCommandAdapter GetSAPCommandAdaptor(TransactionContext trxContext, String sqlText)
        {
            SAPCommandAdapter sapCommandAdapter = new DefaultSAPCommandAdaptor(trxContext, sqlText);

            return sapCommandAdapter;
        }

        protected Type ConvertNull<Type>(DataRow dr, String columName)
        {
            return (Type)(dr[columName].Equals(null) ? default(Type) : dr[columName]);
        }


        protected bool IsValid(string datetime)
        {
            DateTime outDate;

            if (DateTime.TryParse(datetime, out outDate))
            {
                return true;
            }
            return false;
        }

    }
}
