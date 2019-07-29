using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class MoConfirmationHeaderVo : ValueObject
    {
        //public string PlantCode { get; set; }
        public string OrderNumber { get; set; }
        public string SapUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string Supervisor { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal ManHour { get; set; }
        public decimal MachineHour { get; set; }
        public string WorkTimeUnit { get; set; }
        public DateTime PostingDate { get; set; }
        public string CancellationFlag { get; set; }
        public string EndFlag { get; set; }
        public int ConfirmationNumber { get; set; }
        public int ConfirmationCounter { get; set; }
        public string MultiFlag { get; set; }
        public int MaterialCount { get; set; }
        public decimal MaterialQuantityTotal { get; set; }

        public decimal TotalOfUsers { get; set; }
        public string LotNoOfUsers { get; set; }
        public int ProductionOfUsers { get; set; }
    }
}
