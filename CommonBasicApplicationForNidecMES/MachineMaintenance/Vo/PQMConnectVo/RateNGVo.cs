using System.Collections.Generic;
using Com.Nidec.Mes.Framework;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class RateNGVo : ValueObject
    {
        public int RatelId { get; set; }
        public string RateCode { get; set;}
        public string RateModel { get; set;}
        public string RateLine { get; set;}
        public string RateRatio { get; set;}
        public DataTable dt { get; set;}
        public int AffectedCount { get; set;}
        public List<RateNGVo> volist = new List<RateNGVo>();
    }
}
