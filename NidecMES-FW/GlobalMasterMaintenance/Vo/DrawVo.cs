using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class DrawVo : ValueObject
    {/// <summary>
     /// get and set DrawId
     /// </summary>
        public int DrawId { get; set; }
        /// <summary>
        /// / get and set DrawCode
        /// </summary>
        public string DrawCode { get; set; }
        /// <summary>
        /// / get and set DrawName
        /// </summary>
        public string DrawName { get; set; }
    

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

        public List<DrawVo> DrawListVo = new List<DrawVo>();
    }
}
