using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo
{
    public class AccountMainVo : ValueObject
    {
        /// <summary>
        /// get and set AssetId
        /// </summary>
        public int AcountMainId { get; set; }
        public int AssetNoTem { get; set; }
        public string UserTem { get; set; }
        public int AssetId { get; set; }
        public int QTY { get; set; }
        public int AccountCodeId { get; set; }
        public int AccountLocationId { get; set; }
        public int RankId { get; set; }
        public int LocationId { get; set; } //from mes location form.
        public int UserLocationId { get; set; }
        public string UserLocationName { get; set; }

        public string LabelStatus { get; set; }//to search by label status
        public string Net_Value { get; set; }//to search by net value

        public string CommnetsData { get; set; }

        public DateTime StartDepreciation { get; set; }
        public DateTime EndDepreciation { get; set; }

        public double CurrentDepreciation { get; set; }

        public double MonthlyDepreciation { get; set; }
        public double AccumDepreciation { get; set; }

        public double NetValue { get; set; }

        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string Invertory { get; set; }
        public int InvertoryId { get; set; }

        //bien
        public int MonthCounter { get; set; }
        public string AssetCode { get; set; }
        public int AssetNo { get; set; }
        public string AssetName { get; set; }
        public string AssetModel { get; set; }
        public string AssetSerial { get; set; }
        public string AssetSupplier { get; set; }
        public string AccountCodeCode { get; set; }
        public string AccountLocationCode { get; set; }
        public string RankCode { get; set; }
        public string AccountLocationName { get; set; }
        public int AssetLife { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public double AcquisitionCost { get; set; }
        public string AssetInvoice { get; set; }
        public string AssetPO { get; set; }

        //end

        //giao dien
        public string AssetType { get; set; }
        public string LocationCode { get; set; }

        //form deprecation
        public double TotalAcquisitionCose{get; set;}
        public double TotalCurrentDepreication { get; set; }
        public double TotalMonthlyDepreication { get; set; }
        public double TotalAccumDepreication { get; set; }
        public double TotalNetBook { get; set; }
        public string AccountCodeName { get; set; }
        /// <summary>
        /// get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set FactoryCode
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount { get; set; }

        /// <summary>
        /// list of AssetVo
        /// </summary>
        public List<AccountMainVo> AcountMainListVo = new List<AccountMainVo>();

    }
}
