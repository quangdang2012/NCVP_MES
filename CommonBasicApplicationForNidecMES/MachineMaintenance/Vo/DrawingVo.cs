using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class DrawingVo : ValueObject
    {
        public int DeviceID { get; set; }
        public string DeviceCode { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public string Department { get; set; }
        public string Revision { get; set; }

        /// <summary>
        //
        /// from m_model table
        public int ModelId { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }

        /// <summary>
        //
        /// from m_draw table
        public int DrawId { get; set; }
        public string DrawCode { get; set; }
        public string DrawName { get; set; }
        public string DrawType { get; set; }

        /// <summary>
        //
        /// from m_machine table
        public int MachineID { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }

        /// </summary>
        //common
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }
    }
}