using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.PQMConnector_Client
{
    internal class PQMWebServiceNameEnum
    {
        private string valueName;

        private PQMWebServiceNameEnum(string valueName)
        {
            this.valueName = valueName;
        }

        public string GetValue()
        {
            return valueName;
        }


        internal static readonly PQMWebServiceNameEnum SAMPLE_SERVICE_MODEL = 
                                        new PQMWebServiceNameEnum(Properties.Settings.Default.SAMPLE_SERVICE_MODEL);


    }
}
