using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public  class JigRepairInformationVo : ValueObject
    {
        public int JigRepairId { get; set; }
        public string JigRepairCode { get; set; }
       // public int GroupProcessWorkId { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public string JigCurrentStatus { get; set; }
        public string JigAfterRepairStatus { get; set; }
        public string JigRepairResult { get; set; }
        public string JigPlace { get; set; }


        /// <summary>
        //
        /// from m_model table
        public int ModelId { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }

        //From m_process tabel
        public int ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }

        //From m_line table
        public int LineId { get; set; }
        public string LineCode { get; set; }
        public string LineName { get; set; }

        //From Jig causemaster
        public int JigCauseId { get; set; }
        public string JigCauseCode { get; set; }
        public string JigCauseName { get; set; }


        //From m
        public int JigResponseId { get; set; }
        public string JigResponseCode { get; set; }
        public string JigResponseName { get; set; }


        //common
        public string RegistrationUserCode { get; set; }    
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }


       
        
    }
}
