using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.PQMConnector_Client
{
    public class PQMParameter
    {

        private string name;

        private object value;

        /// <summary>
        /// get and set the parameters
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// get and set the parameters
        /// </summary>
        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }

        /// <summary>
        /// get and set the parameters
        /// </summary>
        public void SetValue(string pname, object pvalue)
        {
            this.name = pname;

            this.value = pvalue;
        }

    }
}
