using Com.Nidec.Mes.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class SubmitOutBoundVo : ValueObject
    {

        public string IM_GOODSMVT_CODE = "04";

        public DateTime IM_PSTNG_DATE { get; set; }

        public string IM_PR_UNAME { get; set; }

        public string IM_HEADER_TXT { get; set; }

        public string MATERIAL { get; set; }

        public string PLANT { get; set; }

        public string STGE_LOC { get; set; }

        public string BATCH { get; set; }

        public string MOVE_TYPE { get; set; }

        public decimal ENTRY_QNT { get; set; }

        public string ENTRY_UOM { get; set; }

        public string MOVE_STLOC { get; set; }

        public string ZROW { get; set; }

        public List<SubmitOutBoundVo> SubmitOutBoundVoList = new List<SubmitOutBoundVo>();

        public List<SapMessageVo> SubmitOutBoundVoMessageList = new List<SapMessageVo>();

    }
}
