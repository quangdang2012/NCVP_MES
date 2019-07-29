using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class JigCauseVo : ValueObject
    {/// <summary>
     /// / get and set JigCauseId
     /// </summary>
        public int JigCauseId { get; set; }
        /// <summary>
        /// / get and set JigCauseCode
        /// </summary>
        public string JigCauseCode { get; set; }
        /// <summary>
        /// / get and set JigCauseName
        /// </summary>
        public string JigCauseName { get; set; }
        /// <summary>
        /// / get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }
        /// <summary>
        /// / get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }
        /// <summary>
        /// / get and set FactoryCode
        /// </summary>
        public string FactoryCode { get; set; }
        /// <summary>
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

    }
}
