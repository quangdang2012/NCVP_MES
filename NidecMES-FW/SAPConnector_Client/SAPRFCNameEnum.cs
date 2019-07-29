using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.SAPConnector_Client
{
    public class SAPRFCNameEnum
    {
        private string valueName;

        private SAPRFCNameEnum(string valueName)
        {
            this.valueName = valueName;
        }

        public string GetValue()
        {
            return valueName;
        }


        public static readonly SAPRFCNameEnum RFC_MANUFACTURING_ORDER =
                                        new SAPRFCNameEnum(Properties.Settings.Default.RFC_MANUFACTURING_ORDER);

        public static readonly SAPRFCNameEnum RFC_MANUFACTURING_ORDER_CONFIRMATION =
                                new SAPRFCNameEnum(Properties.Settings.Default.RFC_MANUFACTURING_ORDER_CONFIRMATION);

        public static readonly SAPRFCNameEnum RFC_DELIVERY_ORDER =
                                new SAPRFCNameEnum(Properties.Settings.Default.RFC_DELIVERY_ORDER);

        public static readonly SAPRFCNameEnum RFC_PICKING_LIST =
                                new SAPRFCNameEnum(Properties.Settings.Default.RFC_PICKING_LIST);

        public static readonly SAPRFCNameEnum RFC_STOCK =
                                new SAPRFCNameEnum(Properties.Settings.Default.RFC_STOCK);

        public static readonly SAPRFCNameEnum RFC_MATERIAL =
                                new SAPRFCNameEnum(Properties.Settings.Default.RFC_MATERIAL);
    }
}
