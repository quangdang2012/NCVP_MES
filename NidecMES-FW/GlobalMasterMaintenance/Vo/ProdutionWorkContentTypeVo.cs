using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ProdutionWorkContentTypeVo : ValueObject
    {
        /// <summary>
        /// / get and set ProdutionWorkContentTypeId
        /// </summary>
        public int ProdutionWorkContentTypeId { get; set; }
        /// <summary>
        /// / get and set ProdutionWorkContentTypeCode
        /// </summary>
        public string ProdutionWorkContentTypeCode { get; set; }
        /// <summary>
        /// / get and set ProdutionWorkContentTypeName
        /// </summary>
        public string ProdutionWorkContentTypeName { get; set; }

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
