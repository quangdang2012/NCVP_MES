using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class WorkContentVo : ValueObject
    {
        /// <summary>
        /// get and set WorkContentId
        /// </summary>
        public int WorkContentId { get; set; }

        /// <summary>
        /// get and set WorkContentCode
        /// </summary>
        public string WorkContentCode { get; set; }

        /// <summary>
        /// get and set WorkContentName
        /// </summary>
        public string WorkContentName { get; set; }

        /// <summary>
        /// get and set WorkContentTypeId
        /// </summary>
        public int WorkContentTypeId { get; set; }

        /// <summary>
        /// get and set DispalyOrder
        /// </summary>
        public int DisplayOrder { get; set; }

        ///// <summary>
        ///// get and set WorkContentTypeCode
        ///// </summary>
        //public string WorkContentTypeCode { get; set; }

        ///// <summary>
        ///// get and set WorkContentTypeCodeName
        ///// </summary>
        //public string WorkContentTypeCodeName { get; set; }

        /// <summary>
        /// get and set Remarks
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set FactoryCode
        /// </summary>
        public string  FactoryCode { get; set; }

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set list WorkContentVo
        /// </summary>
        public List<WorkContentVo> WorkContentListVo = new List<WorkContentVo>();
    }
}
