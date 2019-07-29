using System;
using System.Collections.Generic;
using System.Data;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class OvenBarcodeVo : ValueObject
    {
        public DateTime DateTimeForm { get; set; }
        public DateTime DateTimeTo { get; set; }
        public string Lower { get; set; }
        public string Upper { get; set; }

        public DateTime Date { get; set; }
        public string Times { get; set; }
        public string Model { get; set; }
        public string Process { get; set; }
        public string Line { get; set; }
        public string FactoryCode { get; set; }
        public string Temperature { get; set; }
        public int Drying { get; set; }
        public string Barcode { get; set; }
        public string Status { get; set; }
        public DataTable Table { get; set; }
        public int AffectedCount { get; set; }
        public List<OvenBarcodeVo> ovenbarcodevo = new List<OvenBarcodeVo>();
    }
}