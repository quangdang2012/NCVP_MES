using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class MRPControllerRangeVo : ValueObject
    {
        /// get and set Sign
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// get and set High
        /// </summary>
        public string High { get; set; }

        /// <summary>
        /// get and set Low
        /// </summary>
        public string Low { get; set; }

        /// <summary>
        /// get and set Option
        /// </summary>
        public string Option { get; set; }
               

    }
}
