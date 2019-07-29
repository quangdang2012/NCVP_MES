using System;
using Com.Nidec.Mes.Framework;
using System.Data;
namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public  class AddMachineStatusVo : ValueObject
    {
        public int StatusId { get; set; }
        public string Molde { get; set; }
        public string Site { get; set; }
        public string Factory { get; set; }
        public string Line { get; set; }
        public string Process { get; set; }
        public string InspectItem { get; set; }
        public string Tstatus { get; set; }
        public string TJudge { get; set; }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public DataTable dt { get; set; }
        public int AffectedCount { get; set; }
       
    }
}
