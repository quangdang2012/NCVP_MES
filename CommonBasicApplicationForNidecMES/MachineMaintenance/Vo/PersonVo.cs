using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class PersonVo : ValueObject
    {
        public int PersonId { get; set; }
        public string Model { get; set; }
        public string Line { get; set; }
        public DateTime DateTimes { get; set; }
        public string BuildingCode { get; set; }
        public string LotNumber { get; set; }
        public string LeaderName { get; set; }
        public int Shift { get; set; }
        public int PlanPro { get; set; }
        public double PlanST { get; set; }
        public double ActualSt { get; set; }
        public double DoCo { get; set; }
        public double DoCa { get; set; }
        public double DoBa { get; set; }
        public double DoRa { get; set; }
        public double DoMa { get; set; }
        public double AbsentCo { get; set; }
        public double AbsentCa { get; set; }
        public double AbsentBa { get; set; }
        public double AbsentRa { get; set; }
        public double AbsentMa { get; set; }
        public double TimeOver { get; set; }
        public double TimeOffset { get; set; }
        public double TimeTotal { get; set; }
        public DateTime TimeTo { get; set; }
        public DateTime TimeFrom { get; set; }

        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }
        public List<PersonVo> volist = new List<PersonVo>();
    }
}