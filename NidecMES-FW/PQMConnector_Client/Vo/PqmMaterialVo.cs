using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.PQMConnector_Client.Vo
{
    [Serializable]
   public class PqmMaterialVo : ValueObject
    {

        public string Cmd { get; set; }

        public string MONumber { get; set; }

        public string Model { get; set; }

        public string Line { get; set; }

        public string PartNo { get; set; }

        public string LotNo { get; set; }

        public int Quantity { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public DateTime InputTime { get; set; }

        public List<PqmMaterialVo> PqmMaterialListVo { get; set; } = new List<PqmMaterialVo>();
    }
}
