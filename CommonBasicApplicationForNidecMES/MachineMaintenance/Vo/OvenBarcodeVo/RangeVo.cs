using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class RangeVo : ValueObject
    {
        public int RangeId { get; set; }
        public string Process { get; set; }
        public string Model { get; set; }
        public string Line { get; set; }
        public string Barcode { get; set; }
        public string Lower { get; set; }
        public string Upper { get; set; }
        public string RegistrationUser { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public int AffectedCount { get; set; }
        public int Count { get; set; }
        public List<RangeVo> ovenbarcodevo = new List<RangeVo>();
    }
}