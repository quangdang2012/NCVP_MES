using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class EquipmentVo : ValueObject
    {

        /// <summary>
        /// get and set EquipmentId
        /// </summary>
        public int EquipmentId { get; set; }

        /// <summary>
        /// get and set EquipmentCode
        /// </summary>
        public string EquipmentCode { get; set; }

        /// <summary>
        /// get and set EquipmentName
        /// </summary>
        public string EquipmentName { get; set; }

        /// <summary>
        /// get and set InstrationDate
        /// </summary>
        public DateTime InstrationDate { get; set; }

        /// <summary>
        /// get and set AssertNo
        /// </summary>
        public string AssetNo { get; set; }

        /// <summary>
        /// get and set Manufacturer
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// get and set ModelCode
        /// </summary>
        public string ModelCode { get; set; }

        /// <summary>
        /// get and set ModelName
        /// </summary>
        public string ModelName { get; set; }

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
        /// get and set list EquipmentVo
        /// </summary>
        public List<EquipmentVo> EquipmentListVo = new List<EquipmentVo>();

        /// <summary>
        /// get and set Casting Machine Furnace Id
        /// </summary>
        public int CastingMachineFurnaceId;

        /// <summary>
        /// get and set Casting Machine Id
        /// </summary>
        public int CastingMachineId;
    }
}
