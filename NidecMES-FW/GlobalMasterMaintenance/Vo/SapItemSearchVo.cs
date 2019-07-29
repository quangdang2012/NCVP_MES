using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class SapItemSearchVo : ValueObject
    {       
        /// <summary>
        /// get and set SapItemCode
        /// </summary>
        public string SapItemCode { get; set; }

        /// <summary>
        /// get and set SapItemName
        /// </summary>
        public string SapItemName { get; set; }

        /// <summary>
        /// get and set SapMaterialGroupId
        /// </summary>
        public string SapMaterialGroupId { get; set; }

        /// <summary>
        /// get and set IsSapitemSelected
        /// </summary>
        public bool IsSapitemSelected { get; set; }

        /// <summary>
        /// get and set SapItemLocalName
        /// </summary>
        public string SapItemLocalName { get; set; }

        /// <summary>
        /// get and set SapItemLocalNameId
        /// </summary>
        public int SapItemLocalNameId { get; set; }

        /// <summary>
        /// get and set FactoryCode
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set SapItemCodeList
        /// </summary>
        public List<string> SapItemCodeList = new List<string>();

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

    }
}
