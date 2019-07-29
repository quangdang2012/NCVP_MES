using System;
using System.Data;

namespace Com.Nidec.Mes.Framework
{
    public abstract class AbstractDataAccessObject : DataAccessObject
    {
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
        protected DbCommandAdaptor GetDbCommandAdaptor(TransactionContext trxContext, String sqlText)
        {
            
//            if (trxContext == null) throw new SystemException(new NullReferenceException());
            IDbConnection dbConnection = trxContext.DbConnection;
            DbCommandAdaptor dbCommandAdapter = new DefaultNpgCommandAdaptor(sqlText, dbConnection);


            return dbCommandAdapter;
        }

        protected Type ConvertDBNull<Type>(IDataReader dr, String columName)
        {
            return (Type)(dr[columName].Equals(DBNull.Value) ? default(Type) : dr[columName]);
        }
    }
}
