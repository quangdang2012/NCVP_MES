using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ModelVo : ValueObject
    {
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
