using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class FactoryProductionDaysVo : ValueObject
    {
        public int FactoryProductionDaysId { get; set; }
        public int iYear { get; set; }
        public int iMonth { get; set; }
        public int iDays { get; set; }
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public string RegistrationDate { get; set; }
        public int AffectedCount { get; set; }

        public List<FactoryProductionDaysVo> FactoryProductionDaysListVo = new List<FactoryProductionDaysVo>();
    }
}
