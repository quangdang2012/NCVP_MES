using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public  class ReportDownTimeVo : ValueObject
    {
        public int DowntimeReportId { get; set; }
        //public int GroupProcessWorkId { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public string CauseName { get; set; }
        public string ResponseMachineName { get; set; }
        public string Remakes { get; set; }

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

        //From m_process_work
        public int ProcessWorkId { get; set; }
        public string ProcessWorkCode { get; set; }
        public string ProcessWorkName { get; set; }

        //From m_line table
        public int LineId { get; set; }
        public string LineCode { get; set; }
        public string LineName { get; set; }

        //From m_machine table
        public int MachineId { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }

        //From m_defective_reason table
        public int DefectiveReasonId { get; set; }
        public string DefectiveReasonCode { get; set; }
        public string DefectiveReasonName { get; set; }


        //From m_prodution_work_content
        public int ProductionWorkContentId { get; set; }
        public string ProductionWorkContentCode { get; set; }
        public string ProductionWorkContentName { get; set; }


        //common
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }
        public string UserName { get; set; }
    }
}
