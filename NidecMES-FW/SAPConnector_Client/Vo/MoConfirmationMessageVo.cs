using Com.Nidec.Mes.Framework;
using System;
namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class MoConfirmationMessageVo : ValueObject
    {
        public string OrderNumber { get; set; }
        public string MessageType { get; set; }
        public string MessageClassId { get; set; }
        public string MessageNumber { get; set; }
        public string LogNumber { get; set; }
        public string LogMessageNumber { get; set; }
        public string MessageVariable1 { get; set; }
        public string MessageVariable2 { get; set; }
        public string MessageVariable3 { get; set; }
        public string MessageVariable4 { get; set; }
    }
}
