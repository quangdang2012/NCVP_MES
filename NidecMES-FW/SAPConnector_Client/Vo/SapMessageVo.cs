using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class SapMessageVo:ValueObject
    {
        public string OrderNumber { get; set; }

        public string MessageType { get; set; }
        public string MessageClassId { get; set; }

        public string MessageCode { get; set; }
        public string Message { get; set; }
        public string MessageNumber { get; set; }
        public string LogNumber { get; set; }
        public string LogMessageNumber { get; set; }
        public string MessageVariable1 { get; set; }
        public string MessageVariable2 { get; set; }
        public string MessageVariable3 { get; set; }
        public string MessageVariable4 { get; set; }

        public string Parameter { get; set; }
        public string Row { get; set; }
        public string Field { get; set; }
        public string System { get; set; }

    }
}
