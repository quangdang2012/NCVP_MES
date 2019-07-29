using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
   public class MoldItemVo : ValueObject
    {
        /// <summary>
        /// get and set StdCycleTime
        /// </summary>
        public decimal StdCycleTime { get; set; }

        /// <summary>
        /// get and set globalitemsapitemid
        /// </summary>
        public int GlobalLocalItemId { get; set; }

        /// <summary>
        /// get and set MoldId
        /// </summary>
        public int MoldId { get; set; }

        /// <summary>
        /// get and set MoldCode
        /// </summary>
        public string MoldCode { get; set; }

        /// <summary>
        /// get and set MoldName
        /// </summary>
        public string MoldName { get; set; }

        /// <summary>
        /// / get and set ModelId
        /// </summary>
        public int ModelId { get; set; }
        /// <summary>
        /// / get and set ModelCode
        /// </summary>
        public string ModelCode { get; set; }
        /// <summary>
        /// / get and set ModelName
        /// </summary>
        public string ModelName { get; set; }

        public string DrawingNo { get; set; }

        /// <summary>
        /// get and set GlobalItemId
        /// </summary>
        public int GlobalItemId { get; set; }

        /// <summary>
        /// get and set GlobalItemCode
        /// </summary>
        public string GlobalItemCode { get; set; }

        /// <summary>
        /// get and set GlobalItemName
        /// </summary>
        public string GlobalItemName { get; set; }

        /// <summary>
        /// get and set GlobalItemId
        /// </summary>
        public int LocalItemId { get; set; }

        /// <summary>
        /// get and set GlobalItemName
        /// </summary>
        public string LocalItemCode { get; set; }

        /// <summary>
        /// get and set GlobalItemName
        /// </summary>
        public string LocalItemName { get; set; }

        /// <summary>
        /// get and set ProcessWorkId
        /// </summary>
        public string ProcessWorkCd { get; set; }

        /// <summary>
        /// get and set RegistrationUserCd
        /// </summary>
        public string RegistrationUserCd { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set FactoryCd
        /// </summary>
        public string FactoryCd { get; set; }

        /// <summary>
        /// get and set IsExists
        /// </summary>
        public string IsExists { get; set; }

        /// <summary>
        /// store Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

    }
}
