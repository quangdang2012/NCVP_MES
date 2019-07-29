using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;


namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class SeachMachineWorkingStatusVo : ValueObject
    {
        public string STMachine { get; set; }
        public double STData { get; set; }
        public string STRemark { get; set; }
        public DateTime STDateTimeLoad { get; set; }

        public string TDMachine { get; set; }
        public double TDData { get; set; }
        public string TDRemark { get; set; }
        public DateTime TDDateTimeLoad { get; set; }

        public double MACData { get; set; }
        public string MACMachine { get; set; }
        public string MACRemark { get; set; }
        public DateTime MACDateTimeLoad { get; set; }

        public double SPData { get; set; }
        public string SPMachine { get; set; }
        public string SPRemark { get; set; }    
        public DateTime SPDateTimeLoad { get; set; }

        public string MOLDMachine { get; set; }
        public double MOLDData { get; set; }
        public string MOLDRemark { get; set; }
        public DateTime MOLDDateTimeLoad { get; set; }

        public string NameTbl { get; set; } //??


        public List<SeachMachineWorkingStatusVo> AssetListVo = new List<SeachMachineWorkingStatusVo>();
    }
}
