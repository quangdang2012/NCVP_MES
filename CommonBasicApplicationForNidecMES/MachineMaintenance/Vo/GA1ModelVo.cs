using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class GA1ModelVo : ValueObject
    {

        /// <summary>
        //
        /// from m_model table
        public int ModelId { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }

        /// <summary>
        /// from BoxID
        /// </summary>
        public string BoxID { get; set; }
        public string User { get; set; }
        public DateTime PrintDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Format { get; set; }
        public string ShipStatus { get; set; }

        // m_line
        public int LineId { get; set; }
        public string LineCode { get; set; }
        public string LineName { get; set; }

        //from main a90
        public int A90Id { get; set; }
        public string A90Model { get; set; }
        public string A90Line { get; set; }
        public string A90Barcode { get; set; }
        public string A90ThurstStatus { get; set; }
        public string A90NoiseStatus { get; set; }
        public string ReplaceSerial { get; set; }
        public string A90OQCStatus { get; set; }
        public string A90OQCData { get; set; }
        public bool A90Shipping { get; set; }
        public string Lot { get; set; }
        public string Thurst_MC { get; set; }
        public DateTime DateTimeTo { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public string STT { get; set; }
        public bool DaTa { get; set; }

        //form noise a90
        public string Noise_eq_id { get; set; }
        public string Noise_model { get; set; }
        public string Noise_line { get; set; }
        public string Noise_serial_id { get; set; }
        public string Noise_id { get; set; }
        public DateTime Noise_date_check { get; set; }
        public string Noise_judgment { get; set; }
        public string Noise_l1_v_cw { get; set; }
        public string Noise_l1_v_ccw { get; set; }
        public string Noise_e1_v_cw { get; set; }
        public string Noise_e2_v_cw { get; set; }
        public string Noise_e3_v_cw { get; set; }
        public string Noise_e4_v_cw { get; set; }
        public string Noise_e5_v_cw { get; set; }
        public string Noise_e1_v_ccw { get; set; }
        public string Noise_e2_v_ccw { get; set; }
        public string Noise_e3_v_ccw { get; set; }
        public string Noise_e4_v_ccw { get; set; }
        public string Noise_e5_v_ccw { get; set; }
        public string Noise_barcode { get; set; }
        public string Noise_registration_user_cd { get; set; }
        public DateTime Noise_registration_date_time { get; set; }
        public string Noise_factory_cd { get; set; } 

        //common
        public bool Status { get; set; }
        public string UserCd { get; set; }
        public string UserName { get; set; }
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }
        public List<GA1ModelVo> volist = new List<GA1ModelVo>();
        public DataTable dt { get; set; }
    }
}
