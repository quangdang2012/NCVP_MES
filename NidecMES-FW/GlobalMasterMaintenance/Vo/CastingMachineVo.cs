using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class CastingMachineVo : ValueObject
    {
        /// <summary>
        /// get and set CastingMachineId
        /// </summary>
        public int CastingMachineId { get; set; }

        /// <summary>
        /// get and set CastingMachineCode
        /// </summary>
        public string CastingMachineCode { get; set; }

        /// <summary>
        /// get and set CastingMachineName
        /// </summary>
        public string CastingMachineName { get; set; }

        /// <summary>
        /// get and set CastingMachineFurnaceId
        /// </summary>
        public int CastingMachineFurnaceId { get; set; }

        /// <summary>
        /// get and set CastingMachineFurnaceName
        /// </summary>
        public string CastingMachineFurnaceName { get; set; }

        /// <summary>
        /// get and set EquipmentId
        /// </summary>
        public int EquipmentId { get; set; }

        /// <summary>
        /// get and set EquipmentName
        /// </summary>
        public string EquipmentName { get; set; }

        /// <summary>
        /// get and set FactoryCode
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set list CastingMachineVo
        /// </summary>
        public List<CastingMachineVo> CastingMachineListVo = new List<CastingMachineVo>();
    }
}
