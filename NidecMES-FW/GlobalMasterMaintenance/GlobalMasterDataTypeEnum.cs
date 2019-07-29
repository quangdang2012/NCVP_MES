using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    internal class GlobalMasterDataTypeEnum
    {
        private string valueName;

        private string key;

        private GlobalMasterDataTypeEnum(string valueName)
        {
            this.valueName = valueName;
        }
        private GlobalMasterDataTypeEnum(string key, string valueName)
        {
            this.key = key;

            this.valueName = valueName;
        }

        public override string ToString()
        {
            return key;
        }

        public string GetValue()
        {
            return valueName;
        }

        public static readonly GlobalMasterDataTypeEnum SINGLE_LINE = new GlobalMasterDataTypeEnum(Properties.Resources.SINGLE_LINE, "1");

        public static readonly GlobalMasterDataTypeEnum SINGLE_MACHINE = new GlobalMasterDataTypeEnum(Properties.Resources.SINGLE_MACHINE, "2");

        public static readonly GlobalMasterDataTypeEnum SINGLE_LINE_MACHINE = new GlobalMasterDataTypeEnum(Properties.Resources.SINGLE_LINE_MACHINE, "3");

        public static readonly GlobalMasterDataTypeEnum LOCATION_TYPE_PROCESS = new GlobalMasterDataTypeEnum(Properties.Resources.LOCATION_TYPE_PROCESS, "0");

        public static readonly GlobalMasterDataTypeEnum LOCATION_TYPE_WAREHOUSE = new GlobalMasterDataTypeEnum(Properties.Resources.LOCATION_TYPE_WAREHOUSE, "1");


        //DataTypes for Instruction detail
        public static readonly GlobalMasterDataTypeEnum DATATYPE_DECIMAL = new GlobalMasterDataTypeEnum("Decimal", "1");
        public static readonly GlobalMasterDataTypeEnum DATATYPE_OK_NG = new GlobalMasterDataTypeEnum("OK / NG", "2");
        public static readonly GlobalMasterDataTypeEnum DATATYPE_STRING = new GlobalMasterDataTypeEnum("String", "3");
        public static readonly GlobalMasterDataTypeEnum DATATYPE_IMAGE = new GlobalMasterDataTypeEnum("Image", "4");
        public static readonly GlobalMasterDataTypeEnum DATATYPE_NUMBER = new GlobalMasterDataTypeEnum("Number", "5");
        public static readonly GlobalMasterDataTypeEnum DATATYPE_DATETIME = new GlobalMasterDataTypeEnum("DateTime", "6");
        public static readonly GlobalMasterDataTypeEnum DATATYPE_SELECTION = new GlobalMasterDataTypeEnum("Selection", "7");

        //Operator Values for Inspection Specification

        public static readonly GlobalMasterDataTypeEnum OPERATOR_GREATERTHAN = new GlobalMasterDataTypeEnum(">","1");
        public static readonly GlobalMasterDataTypeEnum OPERATOR_LESSTHAN = new GlobalMasterDataTypeEnum("<","2");
        public static readonly GlobalMasterDataTypeEnum OPERATOR_EQUAL = new GlobalMasterDataTypeEnum("=","3");
        public static readonly GlobalMasterDataTypeEnum OPERATOR_MIN = new GlobalMasterDataTypeEnum("MIN","4");
        public static readonly GlobalMasterDataTypeEnum OPERATOR_MAX = new GlobalMasterDataTypeEnum("MAX","5");
        //public static readonly GlobalMasterDataTypeEnum OPERATOR_OK_NG = new GlobalMasterDataTypeEnum("OK/NG", "6");

        public static readonly GlobalMasterDataTypeEnum CODE_SEPARATOR = new GlobalMasterDataTypeEnum("_");

        public static readonly GlobalMasterDataTypeEnum PROCESS_CODE = new GlobalMasterDataTypeEnum("PROCESS");
        public static readonly GlobalMasterDataTypeEnum ITEM_CODE = new GlobalMasterDataTypeEnum("ITEM");
        public static readonly GlobalMasterDataTypeEnum SPECIFICATION_CODE = new GlobalMasterDataTypeEnum("SPEC");
        public static readonly GlobalMasterDataTypeEnum TEST_INST_CODE = new GlobalMasterDataTypeEnum("TESTINST");
        public static readonly GlobalMasterDataTypeEnum DETAIL_CODE = new GlobalMasterDataTypeEnum("DETAIL");
        public static readonly GlobalMasterDataTypeEnum SELECTION_VALUE_CODE = new GlobalMasterDataTypeEnum("VALUE");

        //Below flag is commonly used for (True, false) or Value (1 , 0)
        public static readonly GlobalMasterDataTypeEnum FLAG_ON = new GlobalMasterDataTypeEnum("1");
        public static readonly GlobalMasterDataTypeEnum FLAG_OFF = new GlobalMasterDataTypeEnum("0");

        //sap_matkl_material_grp_id / Sap_item
        public static readonly GlobalMasterDataTypeEnum CODE_MMC = new GlobalMasterDataTypeEnum("MMC", "1");
        public static readonly GlobalMasterDataTypeEnum CODE_MDCM = new GlobalMasterDataTypeEnum("MDCM", "2");
        public static readonly GlobalMasterDataTypeEnum CODE_CMC = new GlobalMasterDataTypeEnum("CMC", "3");
        public static readonly GlobalMasterDataTypeEnum CODE_FAN = new GlobalMasterDataTypeEnum("FAN", "4");
        public static readonly GlobalMasterDataTypeEnum CODE_PSC = new GlobalMasterDataTypeEnum("PSC", "5");
        public static readonly GlobalMasterDataTypeEnum CODE_COMMON = new GlobalMasterDataTypeEnum("COMMON", "0");

        public static readonly GlobalMasterDataTypeEnum SHIFT_DAY = new GlobalMasterDataTypeEnum("Day", "1");
        public static readonly GlobalMasterDataTypeEnum SHIFT_NIGHT = new GlobalMasterDataTypeEnum("Night", "2");

    }
}
