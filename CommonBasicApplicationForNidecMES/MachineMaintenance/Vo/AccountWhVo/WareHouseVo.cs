using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo
{
    public class WareHouseVo : ValueObject
    {
        public int WareHouseId { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
        public string AfterLocation { get; set; }
        public string BeforeLocation { get; set; }
        public DateTime TimeStart { get; set; }
        public string UserTem { get; set; }
     //   public string UserTemAdd { get; set; }
        public DateTime TimeTo { get; set; }
        public DateTime  TimeFrom { get; set; }
        public string Comments { get; set; }
        public string AssetType { get; set; }
        public string Invoice { get; set; }
       
        
        //from asset table
        public int AssetId { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string AssetModel { get; set; }
        public string AssetSupplier { get; set; }


        //from rank table
        public int RankId { get; set; }
        public string RankCode { get; set; }
        public string RankName { get; set; }
        //from userlocation table
        public int UserLocationId { get; set; }
        public string UserLocationCode { get; set; }
        public string UserLocationName { get; set; }
        //from Location master
   


        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }

        //public List<WareHouseVo> WHListVo = new List<WareHouseVo>();

    }
}
