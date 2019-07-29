using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using System.Data.OleDb;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public class ExcelUpload
    {
        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ExcelUpload));

        public DataTable ReadExcel(string fileName, string sheetName)
        {
            DataTable dtExport = new DataTable();

            DataTable dtXlSheets = new DataTable();

            OleDbConnection oleDbConnection = null;
            OleDbDataAdapter oledbCommand;

            try
            {


                oleDbConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + fileName + "';Extended Properties='Excel 8.0;HDR=No;IMEX=1;'");


                try
                {
                    oleDbConnection.Open();
                }
                catch
                {
                    oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1;'");
                    oleDbConnection.Open();
                }


                dtXlSheets = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                DataRow[] dr = dtXlSheets.Select("TABLE_NAME = '" + sheetName + "$" + "'");

                if (dr == null || dr.Length ==0)
                {
                    MessageData msgData = new MessageData("mmce00008", Properties.Resources.mmce00008, sheetName);

                    throw new Framework.ApplicationException(msgData);

                }
                oledbCommand = new OleDbDataAdapter("select * from [" + sheetName + "$]", oleDbConnection);

                oledbCommand.FillSchema(dtExport, SchemaType.Source);


                oledbCommand.Fill(dtExport);

                if(dtExport!=null && dtExport.Rows.Count>0)
                {
                    DataRow headerRow = dtExport.Rows[0];

                    foreach (DataColumn column in dtExport.Columns)
                    {
                        if(!string.IsNullOrWhiteSpace(headerRow[column.ColumnName.ToString()].ToString()))
                        {
                            column.ColumnName = headerRow[column.ColumnName.ToString()].ToString();
                        }
                        
                    }
                    headerRow.Delete();
                    dtExport.AcceptChanges();

                    foreach (DataRow dataRow in dtExport.Rows)
                    {
                        foreach (var colValue in dataRow.ItemArray)
                        {
                            if (!string.IsNullOrEmpty(colValue.ToString()))
                                break;

                            dataRow.Delete();
                        }
                    }

                    dtExport.AcceptChanges();
                }

                oleDbConnection.Close();
            }
            catch (Framework.ApplicationException exception)
            {
                throw exception;
            }
            catch (Framework.SystemException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if(oleDbConnection != null)
                {
                    oleDbConnection.Close();
                    oleDbConnection.Dispose();

                }
            }

            return dtExport;
        }        
        
    }
}
