using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.MachineMaintenance.Vo
{
    public class ProcessWorksVo : ValueObject
    {
        /// <summary>
        /// get and set ProcessWorkId
        /// </summary>
        public int ProcessWorkId { get; set; }

        /// <summary>
        /// get and set ProcessWorkCode
        /// </summary>
        public string ProcessWorkCode { get; set; }

        /// <summary>
        /// get and set ProcessWorkName
        /// </summary>
        public string ProcessWorkName { get; set; }
        public int ModelID { get; set; }
        public int AssyID { get; set; }
        public int MachineID { get; set; }

        public string Model { get; set; }
        public string Assy { get; set; }
        public string Machine { get; set; }
        /// <summary>
        /// get and set ProcessId
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        /// get and set ProcessCode
        /// </summary>
        public string ProcessCode { get; set; }

        /// <summary>
        /// get and set ProcessName
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// get and set LineMachineSelection
        /// </summary>
        public int LineMachineSelection { get; set; }      

        /// <summary>
        /// get and set LineMachineSelectionDisplay
        /// </summary>
        public string LineMachineSelectionDisplay { get; set; }

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
        /// get and set IsPhantom
        /// </summary>
        public string IsPhantom { get; set; }

        /// <summary>
        /// get and set IsPhantom
        /// </summary>
        public string IsPhantomDisplay { get; set; }

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// store Mode
        /// </summary>
        public string Mode = string.Empty;


        /// <summary>
        /// store DefectiveId Count
        /// </summary>
        public int DefectiveIdCount = 0;

        /// <summary>
        /// store ItemProcessWorkId Count
        /// </summary>
        public int ItemProcessWorkIdCount = 0;

        /// <summary>
        /// store ProcessSupplierId Count
        /// </summary>
        public int ProcessSupplierIdCount = 0;

        /// <summary>
        /// store Process Flag
        /// </summary>
        public string ProcessFlag = string.Empty;

        /// <summary>
        /// list of ProcessWorkVo
        /// </summary>
        public List<ProcessWorksVo> ProcessWorkListVo = new List<ProcessWorksVo>();

    }
}
