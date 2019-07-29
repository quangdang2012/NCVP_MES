using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class SupplierVo:ValueObject
    {
        public string OutMatnr { get; set; }

        public string OutWerks { get; set; }

        public string OutEkorg { get; set; }

        public DateTime OutValidFrom { get; set; }

        public DateTime OutValidTo { get; set; }

        public string OutVendor { get; set; }

        public string OutName { get; set; }
    }
}
