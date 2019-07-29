using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ProdutionWorkContentVo : ValueObject
    {
        /// <summary>
        /// / get and set ProdutionWorkContentId
        /// </summary>
        public int ProdutionWorkContentId { get; set; }
        /// <summary>
        /// / get and set ProdutionWorkContentCode
        /// </summary>
        public string ProdutionWorkContentCode { get; set; }
        /// <summary>
        /// / get and set ProdutionWorkContentName
        /// </summary>
        public string ProdutionWorkContentName { get; set; }
        /// <summary>
        /// / get and set DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// get and set Remark
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// / get and set ProdutionWorkContentTypeId
        /// </summary>
        public int ProdutionWorkContentTypeId { get; set; }

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
        /// <summary>
        /// list of ProductionWorkContentVo
        /// </summary>
        public List<ProdutionWorkContentVo> ProductListVo = new List<ProdutionWorkContentVo>();
    }
}
