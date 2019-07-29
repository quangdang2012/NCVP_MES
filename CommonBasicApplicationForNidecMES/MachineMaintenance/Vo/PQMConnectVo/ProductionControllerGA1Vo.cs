using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class ProductionControllerGA1Vo : ValueObject
    {

        /// <summary>
        //
        /// from m_model table
        public int ModelId { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }

        public bool change { get; set; }

        // m_line
        public int LineId { get; set; }
        public string LineCode { get; set; }
        public string LineName { get; set; }

        public string Serno { get; set; }
        public DateTime InspectDate { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Data { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool grDate { get; set; }
        public string Date { get; set; }         

        public string TableName { get; set; }

        //common
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }
        public DataTable dt { get; set; }

        public string InspecData { get; set; }
        //Frame
        public string InPut1 { get; set; }
        public string OUtput1 { get; set; }
        public string TotalNG1 { get; set; }
        public string NGF1 { get; set; }
        public string NGF2 { get; set; }
        public string NGF3 { get; set; }

        //Gear Case
        public string InPut2 { get; set; }
        public string OUtput2 { get; set; }
        public string TotalNG2 { get; set; }
        public string NGG1 { get; set; }
        public string NGG2 { get; set; }
        public string NGG3 { get; set; }
        public string NGG4 { get; set; }
        public string NGG5 { get; set; }
        public string NGG6 { get; set; }
        public string NGG7 { get; set; }
        //Motor 
        public string InPut3 { get; set; }
        public string OUtput3 { get; set; }
        public string TotalNG3 { get; set; }
        public string NGM1 { get; set; }
        public string NGM2 { get; set; }
        public string NGM3 { get; set; }
        public string NGM4 { get; set; }
        public string NGM5 { get; set; }
        public string NGM7 { get; set; }
        public string NGM6 { get; set; }
        public string NGThurst { get; set; }

        public List<ProductionControllerGA1Vo> volist = new List<ProductionControllerGA1Vo>();
    }
}
