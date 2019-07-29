using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class InspectionItemSelectionDatatypeValueVo : ValueObject
    {
        /// <summary>
        /// get and set InspectionItemSelectionDatatypeValueId
        /// </summary>
        public int InspectionItemSelectionDatatypeValueId { get; set; }

        /// <summary>
        /// get and set InspectionItemSelectionDatatypeValueCode
        /// </summary>
        public string InspectionItemSelectionDatatypeValueCode { get; set; }

        /// <summary>
        /// get and set InspectionItemSelectionDatatypeValueText
        /// </summary>
        public string InspectionItemSelectionDatatypeValueText { get; set; }

        /// <summary>
        /// get and set InspectionItemId
        /// </summary>
        public int InspectionItemId { get; set; }

        /// <summary>
        /// get and set InspectionItemCode
        /// </summary>
        public string InspectionItemCode { get; set; }

        /// <summary>
        /// get and set InspectionItemName
        /// </summary>
        public string InspectionItemName { get; set; }
        
        /// <summary>
        /// get and set DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

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
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;
        

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set DeleteFlag
        /// </summary>
        public bool DeleteFlag = false;

    }
}
