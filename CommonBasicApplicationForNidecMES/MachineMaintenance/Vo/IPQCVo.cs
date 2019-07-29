using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class IPQCVo : ValueObject
    {
        public string Model { get; set; }
        public string Line { get; set; }
        public string DBPlace { get; set; }
        public string No { get; set; }
        public string Process { get; set; }
        public string Inspect { get; set; }
        public string Description { get; set; }
        public int ClmSet { get; set; }
        public int RowSet { get; set; }
        public double Upper { get; set; }
        public double Lower { get; set; }
        public string Instrument { get; set; }
        public DateTime Lot { get; set; }
        public DateTime LotLast { get; set; }
        public DateTime Inspectdate { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public double m1 { get; set; }
        public double m2 { get; set; }
        public double m3 { get; set; }
        public double m4 { get; set; }
        public double m5 { get; set; }
        public double x { get; set; }
        public double r { get; set; }
        public DataTable dt { get; set; }
        public int AffectedCount { get; set; }
        public int ins { get; set; }
        public List<GA1ModelVo> volist = new List<GA1ModelVo>();
    }
}