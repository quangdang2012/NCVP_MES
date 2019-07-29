using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class MachineAndEquipmentVo : ValueObject
    {/// <summary>
     /// / get and set ModelId
     /// </summary>
        public int MachineAndEquipmentID { get; set; }
        public int MachineID { get; set; }
        public int EquipmentID { get; set; }
        public int AffectedCount { get; set; }
    }
}
