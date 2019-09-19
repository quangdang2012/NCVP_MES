using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Com.Nidec.Mes.Framework;


namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    class PQMDataViewerVo : ValueObject
    {
        public DataTable InspectDataTable { get; set; }
        public DataTable SernoDataTable { get; set; }
        public DataTable JoinedTable { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public string Model { get; set; }
        public string Process { get; set; }
        public string Inspect { get; set; }
        public string InspectList { get; set; }
        public string SernoList { get; set; }
        public string OpenPath { get; set; }
        public string SavePath { get; set; }
        public List<string> SernoDBList { get; set; }
        public int Timer_Counter { get; set; }
        public bool ThreadComplete { get; set; }
        public List<PQMDataViewerVo> pqmdataviewervo = new List<PQMDataViewerVo>();
    }
}
