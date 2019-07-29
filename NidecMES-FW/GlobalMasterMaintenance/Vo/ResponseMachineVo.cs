using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ResponseMachineVo : ValueObject
    {/// <summary>
     /// / get and set ResponseMachineId
     /// </summary>
        public int ResponseMachineId { get; set; }
        public int ProdutionWorkContentId{ get; set; }
        public int MachineId { get; set; }
        /// <summary>


        /// <summary>
        /// / get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }
        /// <summary>
        /// / get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }
        /// <summary>
        /// / get and set FactoryCode
        /// </summary>
        public string FactoryCode { get; set; }
        //public int ModelId { get; internal set; }

        /// <summary>
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;
    }
}
