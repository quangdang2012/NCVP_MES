using Com.Nidec.Mes.Framework;
using System;
using System.Collections.Generic;

namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class MoConfirmationResultVo : ValueObject
    {
        public string OutSapFlag { get; set; }
        public int ConfirmationNumber { get; set; }
        public int ConfirmationCount { get; set; }
        public string OutMesFlag { get; set; }

        public List<SapMessageVo> MessageList = new List<SapMessageVo>();
    }
}
