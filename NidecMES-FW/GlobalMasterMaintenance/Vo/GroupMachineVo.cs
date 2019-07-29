using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class GroupMachineVo : ValueObject
    {
        /// <summary>
        /// get and set GroupMachineId
        /// </summary>
        public int GroupMachineId { get; set; }

        /// <summary>
        /// get and set GroupMachineCode
        /// </summary>
        public string GroupMachineCode { get; set; }

        /// <summary>
        /// get and set GroupMachineName
        /// </summary>
        public string GroupMachineName { get; set; }

        /// <summary>
        /// get and set MachineId
        /// </summary>
        public int MachineId { get; set; }

        /// <summary>
        /// get and set MachineCode
        /// </summary>
        public string MachineCode { get; set; }

        /// <summary>
        /// get and set MachineName
        /// </summary>
        public string MachineName { get; set; }

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
        /// list of GroupMachineVo
        /// </summary>
        public List<GroupMachineVo> GroupMachineListVo = new List<GroupMachineVo>();

        /// <summary>
        /// store DefectiveId Count
        /// </summary>
        public int DefectiveIdCount = 0;

        /// <summary>
        /// store ItemGroupMachineId Count
        /// </summary>
        public int ItemGroupMachineIdCount = 0;

        /// <summary>
        /// store MachineSupplierId Count
        /// </summary>
        public int MachineSupplierIdCount = 0;

        /// <summary>
        /// store Machine Flag
        /// </summary>
        public string MachineFlag = string.Empty;

    }
}
