using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class DefectiveCategoryVo : ValueObject
    {
        /// <summary>
        /// get and set DefectiveCategoryId
        /// </summary>
        public int DefectiveCategoryId { get; set; }

        /// <summary>
        /// get and set DefectiveCategoryCode
        /// </summary>
        public string DefectiveCategoryCode { get; set; }

        /// <summary>
        /// get and set DefectiveCategoryName
        /// </summary>
        public string DefectiveCategoryName { get; set; }

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
        public string FactoryCode { get; set; }

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount { get; set; }

        /// <summary>
        /// list of DefectiveCategoryVo
        /// </summary>
        public List<DefectiveCategoryVo> DefectiveCategoryListVo = new List<DefectiveCategoryVo>();

    }
}
