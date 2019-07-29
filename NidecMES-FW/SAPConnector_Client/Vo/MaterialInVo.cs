using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class MaterialInVo : ValueObject
    {
        /// <summary>
        /// get and set outmatnr
        /// </summary>
        public string ImWerks { get; set; }

        /// <summary>
        /// get and set outmaktx
        /// </summary>
        public string ImPeriodFrom { get; set; }

        /// <summary>
        /// get and set outmtart
        /// </summary>
        public string ImPeriodTo { get; set; }

        /// <summary>
        /// get and set outersda
        /// </summary>
        public string ImMaterialFrom { get; set; }

        /// <summary>
        /// get and set outlaeda
        /// </summary>
        public string ImMaterialTo { get; set; }

        /// <summary>
        /// get and set outlvorm1
        /// </summary>
        public string ImSource { get; set; }

    }
}
