using System.Collections.Generic;
using System.Data;
using System;

namespace Com.Nidec.Mes.Framework
{
    public class TransactionContext
    {

        /// <summary>
        /// get and set the userdata
        /// </summary>
        public UserData UserData { set; get; }

        /// <summary>
        /// get processing datetime. This is DB server date time (not PC).
        /// </summary>
        public DateTime ProcessingDBDateTime { internal set; get; }

        /// <summary>
        /// get and set dbconnection
        /// </summary>
        internal IDbConnection DbConnection { set; get; }


   
    }
}
