using System;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.PQMConnector_Client
{
    internal abstract class AbstractPQMDataAccessObject : DataAccessObject
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
        protected PQMCommandAdapter GetPQMCommandAdaptor(TransactionContext trxContext, String sqlText)
        {
            PQMCommandAdapter pqmCommandAdapter = new DefaultPQMCommandAdaptor(sqlText);

            return pqmCommandAdapter;
        }

        protected Type ConvertNull<Type>(DataRow dr, String columName)
        {
            return (Type)(dr[columName].Equals(null) ? default(Type) : dr[columName]);
        }

    }
}
