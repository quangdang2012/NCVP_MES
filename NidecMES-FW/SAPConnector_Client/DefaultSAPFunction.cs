using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SAP.Middleware.Connector;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.SAPConnector_Client
{
    public class DefaultSAPFunction:SAPFunction
    {
        private  IRfcFunction rfcFunction;

        public  IRfcFunction Invoke(RfcDestination rfcDestination,IRfcFunction pRfcFuntion)
        {
            rfcFunction = pRfcFuntion;

            rfcFunction.Invoke(rfcDestination);

            return rfcFunction;
        }

        public string GetSAPValue(string name)
        {
            return Convert.ToString(rfcFunction.GetValue(name));
        }

        public string GetSAPValue(int index)
        {
            return Convert.ToString(rfcFunction.GetValue(index));
        }

        public DataTable GetSAPTable(string tableName)
        {

            DataTable data = new DataTable();

            IRfcTable functionRfcTable = this.rfcFunction.GetTable(tableName);

            for (int i = 0; i <= functionRfcTable.ElementCount - 1; i++)
            {
                RfcElementMetadata metadata = functionRfcTable.GetElementMetadata(i);
                data.Columns.Add(metadata.Name);
            }

            //Transfer rows from rfcTable to .Net table.
            foreach (IRfcStructure row in functionRfcTable)
            {
                DataRow rowAdd = data.NewRow();
                for (int j = 0; j <= functionRfcTable.ElementCount - 1; j++)
                {
                    RfcElementMetadata metadata = functionRfcTable.GetElementMetadata(j);
                    rowAdd[metadata.Name] = row.GetString(metadata.Name);
                }
                data.Rows.Add(rowAdd);
            }

            return data;
        }
    }
}
