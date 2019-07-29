using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Framework_Batch.Vo
{
    internal class AddBatchProcessVo : ValueObject
    {
        /// <summary>
        /// Get and Set BatchProcessId
        /// </summary>
        public int BatchProcessId { get; set; }

        /// <summary>
        /// Get and Set BatchProcessCode
        /// </summary>
        public string BatchProcessCode { get; set; }
        
        public string Status
        {
            get
            {
                return IsStopRequested ? "Sent Stop Request" : "Running";
            }
            set { }
        }

        /// <summary>
        /// Get and Set IsStopRequested
        /// </summary>
        public bool IsStopRequested { get; set; }

        /// <summary>
        /// Get and Set RegistrationUserCode 
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// Get and Set RegistrationDateTime 
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// Get and Set FactoryCode 
        /// </summary>
        public string FactoryCode { get; set; }
    }
}
