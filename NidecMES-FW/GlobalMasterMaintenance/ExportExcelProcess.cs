using System;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Com.Nidec.Mes.Framework;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public class ExportExcelProcess
    {

        #region Variables

        /// <summary>
        /// excel application
        /// </summary>
        private Excel.Application xlApp;

        /// <summary>
        /// excel workbook
        /// </summary>
        private Excel.Workbook xlWorkBook;

        /// <summary>
        /// excel worksheet object
        /// </summary>
        private Excel.Worksheet xlWorksheet;

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ExportExcelProcess));

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();


        #endregion

        #region PrivateMethods


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="worksheet"></param>
        private void ExportDataToText(DataTable data, Excel.Worksheet worksheet, bool isLowerRange = false)
        {
            string path = Path.GetTempFileName();
            //StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
            //using (FileStream fs = File.Open(path, FileMode.Append, FileAccess.Write, FileShare.None))
            //{
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode))
            {
                for (int i = 0; i <= data.Rows.Count - 1; i++)
                {
                    StringBuilder dataStringBuilder = new StringBuilder();

                    foreach (DataColumn col in data.Columns)
                    {

                        dataStringBuilder.Append(data.Rows[i][col.ColumnName.ToString()] + "\t");
                    }
                    dataStringBuilder.Append("\r\n");

                    sw.Write(dataStringBuilder.ToString());
                   

                    //byte[] info = new UTF8Encoding(true).GetBytes(dataStringBuilder.ToString());

                    //fs.Write(info, 0, info.Length);
                }
                sw.Close();
            }
            //}
            TextToExcelReport(path, worksheet, 0, isLowerRange);
        }

        /// <summary>
        /// insert rows
        /// </summary>
        /// <param name="xlSheet"></param>
        /// <param name="rowCount"></param>
        /// <param name="range"></param>
        private void InsertBlankRows(Excel.Worksheet xlSheet, int rowCount, int range)
        {
            xlSheet.Range[range + ":" + (range + rowCount - 1)].Insert(0);
        }

        /// <summary>
        /// Formats Excel column contrnts
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="worksheet"></param>
        /// <param name="colCount"></param>
        private void TextToExcelReport(string pFileName, Excel.Worksheet worksheet, int colCount = 0, bool isLowerRange = false)
        {
            Excel.Worksheet wkSheet = worksheet;

            object[] obj = new object[10 + (2 * colCount) + colCount + 1];

            if (colCount > 0)
            {
                for (int i = 0; i <= (10 + (2 * colCount) + colCount); i++)
                {
                    if (i >= 11 + (2 * colCount))
                    {
                        obj[i] = 2;
                    }
                    else
                    {
                        obj[i] = 1;
                    }
                }
            }

            string range = "$A$2";

            if (isLowerRange)
            {
                range = "$A$1";
            }

            Excel.QueryTable qryTable = wkSheet.QueryTables.Add("TEXT;" + pFileName, wkSheet.Range[range]);
            qryTable.FieldNames = true;
            qryTable.RowNumbers = false;
            qryTable.FillAdjacentFormulas = false;
            qryTable.PreserveFormatting = true;
            qryTable.RefreshOnFileOpen = false;
            qryTable.RefreshStyle = Excel.XlCellInsertionMode.xlOverwriteCells;
            qryTable.SavePassword = false;
            qryTable.SaveData = true;
            qryTable.AdjustColumnWidth = false;
            qryTable.RefreshPeriod = 0;
            qryTable.TextFilePromptOnRefresh = false;
            qryTable.TextFilePlatform = 932;
            qryTable.TextFileStartRow = 1;
            qryTable.TextFileParseType = Excel.XlTextParsingType.xlDelimited;
            qryTable.TextFileTextQualifier = Excel.XlTextQualifier.xlTextQualifierNone;
            qryTable.TextFileConsecutiveDelimiter = false;
            qryTable.TextFileTabDelimiter = true;
            qryTable.TextFileSemicolonDelimiter = false;
            qryTable.TextFileCommaDelimiter = false;
            qryTable.TextFileSpaceDelimiter = false;
            if (colCount > 0)
            {
                qryTable.TextFileColumnDataTypes = obj;
            }
            qryTable.TextFileTrailingMinusNumbers = true;
            qryTable.Refresh(false);

            wkSheet.Range["1:1"].Font.Bold = true;
            wkSheet.Columns.AutoFit();
        }

        #endregion

        #region PublicMethods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="outputdata"></param>
        /// <param name="sheetName"></param>
        public void ExportDataToExcel(string filename, DataTable outputdata, string sheetName, bool isLowerRange = false)
        {
            try
            {
                xlApp = new Excel.Application();

                xlWorkBook = xlApp.Workbooks.Open(filename);

                xlWorksheet = (Excel.Worksheet)xlWorkBook.Worksheets[sheetName];

                if (xlWorksheet == null) return;

                xlApp.Application.DisplayAlerts = false;

                for (int i = xlApp.Worksheets.Count; i >= 1; i--)
                {
                    if ((Excel.Worksheet)xlApp.Worksheets[i] != xlWorksheet)
                    {
                        ((Excel.Worksheet)xlApp.Worksheets[i]).Delete();
                    }
                }


                if (outputdata.Rows.Count > 2)
                {
                    InsertBlankRows(xlWorksheet, outputdata.Rows.Count - 2, 3);
                }


                ExportDataToText(outputdata, xlWorksheet, isLowerRange);

                xlWorkBook.Save();
            }
            catch (Framework.ApplicationException appEx)
            {
                logger.Error(appEx.GetMessageData());
                throw;
            }
            finally
            {
                xlApp.ScreenUpdating = true;
                xlApp.Application.Visible = true;
                xlApp.DisplayAlerts = true;

                xlApp = null;
                xlWorkBook = null;
                xlWorksheet = null;
            }
        }

        /// <summary>
        /// Download Master Excel Template
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="sheetName"></param>
        public void DownloadExcel(string filename, string sheetName)
        {
            try
            {
                xlApp = new Excel.Application();

                xlWorkBook = xlApp.Workbooks.Open(filename);

                xlWorksheet = (Excel.Worksheet)xlWorkBook.Worksheets[sheetName];

                if (xlWorksheet == null) return;

                xlApp.Application.DisplayAlerts = false;

                for (int i = xlApp.Worksheets.Count; i >= 1; i--)
                {
                    if ((Excel.Worksheet)xlApp.Worksheets[i] != xlWorksheet)
                    {
                        ((Excel.Worksheet)xlApp.Worksheets[i]).Delete();
                    }
                }
                xlWorkBook.Save();
            }
            catch (Framework.ApplicationException appEx)
            {
                logger.Error(appEx.GetMessageData());
                throw;
            }
            finally
            {
                xlApp.ScreenUpdating = true;
                xlApp.Application.Visible = true;
                xlApp.DisplayAlerts = true;

                xlApp = null;
                xlWorkBook = null;
                xlWorksheet = null;
            }
        }

        public void DownloadExcel(string filename, List<string> sheetNameList)
        {
            try
            {
                xlApp = new Excel.Application();

                xlWorkBook = xlApp.Workbooks.Open(filename);

                List<Excel.Worksheet> xlWorksheetList = new List<Excel.Worksheet>();

                bool sheetnamecheck = false;
                foreach (string sheetName in sheetNameList)
                {
                    sheetnamecheck = false;

                    for (int i = xlApp.Worksheets.Count; i >= 1; i--)
                    {
                        Excel.Worksheet worksheet = (Excel.Worksheet)xlApp.Worksheets[i];

                        if (sheetName.Equals(worksheet.Name))
                        {
                            sheetnamecheck = true;
                            xlWorksheetList.Add(worksheet);
                        }
                    }

                    if (sheetnamecheck == false)
                    {
                        MessageData messageData = new MessageData("mmci00020", Properties.Resources.mmci00020, sheetName);
                        throw new Framework.ApplicationException(messageData);
                    }
                }
                

                xlApp.Application.DisplayAlerts = false;

                for (int i = xlApp.Worksheets.Count; i >= 1; i--)
                {
                    if (!xlWorksheetList.Contains((Excel.Worksheet)xlApp.Worksheets[i]))
                    {
                        ((Excel.Worksheet)xlApp.Worksheets[i]).Delete();
                    }
                }

                xlWorkBook.Save();

                xlApp.ScreenUpdating = true;
                xlApp.Application.Visible = true;
                xlApp.DisplayAlerts = true;
            }
            catch (Framework.ApplicationException appEx)
            {
                logger.Error(appEx.GetMessageData());
                throw;
            }
            finally
            {
                xlApp = null;
                xlWorkBook = null;
                xlWorksheet = null;
            }
        }

        public bool WriteToExcel(DataSet ds, string pathfile)
        {

            if(File.Exists(Path.GetFullPath(pathfile)))
            {
                MessageData messageData = new MessageData("mmci00013", Properties.Resources.mmci00013, pathfile);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationYesNoCancel(messageData, "");
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(pathfile);
                    }
                    catch (System.Exception ex)
                    {
                        MessageData msgData = new MessageData("mmcc00001", Properties.Resources.mmcc00001, ex.Message);
                        logger.Error(msgData);
                        popUpMessage.SystemError(msgData, string.Empty);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            string sqlValues = "";
            string colCaption = "";
            string sqlText = "";
            string sqlCreate = "";

            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + pathfile + ";Extended Properties=Excel 8.0;";
            OleDbConnection cn = new OleDbConnection(sConnectionString);
            OleDbCommand cmd = null;
            try
            {
                cn.Open();
            }
            catch
            {
                sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + pathfile + ";Extended Properties=Excel 12.0;";
                cn = new OleDbConnection(sConnectionString);
                cn.Open();
            }
            foreach (DataTable table in ds.Tables)
            {
                sqlText = "";
                colCaption = "";

                for (int ii = 0; ii < table.Columns.Count; ii++)
                {
                    if (ii != 0)
                    {
                        sqlText += " , ";
                        colCaption += " , ";
                    }
                    sqlText += "[" + table.Columns[ii].Caption.ToString() + "] VarChar";//Éú³É´øVarCharÁÐµÄ±êÌâ
                    colCaption += "[" + table.Columns[ii].Caption.ToString() + "]";//Éú³ÉÁÐµÄ±êÌâ
                }

                //sqlCreate = "CREATE TABLE [Sheet" + (i + 1).ToString() + "] (" + sqlText + ")";
                sqlCreate = "CREATE TABLE [" + table.TableName.ToString() + "] (" + sqlText + ")";

                cmd=  new OleDbCommand(sqlCreate, cn);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageData messageData = new MessageData("mmcc00001", Properties.Resources.mmcc00001, ex.Message);
                    logger.Error(messageData);
                    popUpMessage.SystemError(messageData, string.Empty);
                    cmd.Dispose();
                    cn.Close();
                    return false;
                }

                for (int rowcou = 0; rowcou < table.Rows.Count; rowcou++)
                {
                    sqlValues = "";
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        if (col != 0)
                        {
                            sqlValues += " , ";
                        }

                        sqlValues += "'" + (table.Rows[rowcou][col].ToString().Replace("'", "''").Replace("\\", "\\") + "                                                  ").Substring(0, 50) + "'";//Æ´½ÓValueÓï¾ä
                    }

                    String queryString = "INSERT INTO [" + table.TableName.ToString() + "] (" + colCaption + ") VALUES (" + sqlValues + ")";
                    cmd.CommandText = queryString;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        MessageData messageData = new MessageData("mmcc00001", Properties.Resources.mmcc00001, ex.Message);
                        logger.Error(messageData);
                        popUpMessage.SystemError(messageData, string.Empty);
                        cmd.Dispose();
                        cn.Close();
                        return false;
                    }
                }
            }
            cmd.Dispose();
            cn.Close();

            return true;

        }

        #endregion

    }
}
