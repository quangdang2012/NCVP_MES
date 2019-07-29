using System;
using System.Data;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;
using Com.Nidec.Mes.SAPConnector_Client.Vo;
using System.Linq;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.SAPConnector_Client.Dao
{
    class AddMoConfirmationDao : AbstractSAPDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            Decimal AllowableToError = 0.5M;

            MoConfirmationMaterialVo inVo = (MoConfirmationMaterialVo)vo;

            MoConfirmationHeaderVo header = (MoConfirmationHeaderVo)inVo.MoConfirmationHeaderVo;
            //MoConfirmationMaterialVo materialsVo = (MoConfirmationMaterialVo)inVo.MoConfirmationMaterialListVo.FirstOrDefault();
            List<MoConfirmationMaterialVo> materials = inVo.MoConfirmationMaterialListVo;


            if (header.CancellationFlag != "CAL")
            {
                MoConfirmationResultVo FrontResultVo = new MoConfirmationResultVo();
                List<SapMessageVo> FrontMessageList = new List<SapMessageVo>();
                bool DataIsOk = true;
                MoConfirmationMaterialVo materialProduct = materials.Find(s => s.MovementType == Properties.Resources.MOVEMENT_TYPE);

                if (materialProduct == null)
                {
                    DataIsOk = false;
                    SapMessageVo NullMessage = new SapMessageVo
                    {
                        OrderNumber = header.OrderNumber,
                        MessageType = Properties.Resources.ErrorMessageCategory,
                        MessageClassId = "000",
                        MessageNumber = "000",
                        LogNumber = Properties.Resources.scce00036,
                        LogMessageNumber = "000",
                        MessageVariable1 = "",
                        MessageVariable2 = "",
                        MessageVariable3 = "",
                        MessageVariable4 = ""
                    };
                    FrontResultVo.MessageList.Add(NullMessage);
                }
                else
                {
                    if (materialProduct.SapBatchNumber != header.LotNoOfUsers)
                    {
                        DataIsOk = false;
                        SapMessageVo BatchDifferentMessage = new SapMessageVo
                        {
                            OrderNumber = header.OrderNumber,
                            MessageType = Properties.Resources.ErrorMessageCategory,
                            MessageClassId = "000",
                            MessageNumber = "000",
                            LogNumber = Properties.Resources.scce00037,
                            LogMessageNumber = "001",
                            MessageVariable1 = "",
                            MessageVariable2 = "",
                            MessageVariable3 = "",
                            MessageVariable4 = ""
                        };
                        FrontResultVo.MessageList.Add(BatchDifferentMessage);
                    }
                    if (materialProduct.Quantity != header.ProductionOfUsers)
                    {
                        DataIsOk = false;
                        SapMessageVo BatchDifferentMessage = new SapMessageVo
                        {
                            OrderNumber = header.OrderNumber,
                            MessageType = Properties.Resources.ErrorMessageCategory,
                            MessageClassId = "000",
                            MessageNumber = "000",
                            LogNumber = Properties.Resources.scce00038,
                            LogMessageNumber = "002",
                            MessageVariable1 = "",
                            MessageVariable2 = "",
                            MessageVariable3 = "",
                            MessageVariable4 = ""
                        };
                        FrontResultVo.MessageList.Add(BatchDifferentMessage);
                    }
                }
                Decimal MaterQtyAll = materials.Where(r => r.MovementType != Properties.Resources.MOVEMENT_TYPE).Sum(t => t.Quantity);
                if (header.TotalOfUsers >= MaterQtyAll - AllowableToError && header.TotalOfUsers <= MaterQtyAll + AllowableToError)
                {
                }
                else
                {
                    DataIsOk = false;
                    SapMessageVo BatchDifferentMessage = new SapMessageVo
                    {
                        OrderNumber = header.OrderNumber,
                        MessageType = Properties.Resources.ErrorMessageCategory,
                        MessageClassId = "000",
                        MessageNumber = "000",
                        LogNumber = Properties.Resources.scce00039,
                        LogMessageNumber = "003",
                        MessageVariable1 = "",
                        MessageVariable2 = "",
                        MessageVariable3 = "",
                        MessageVariable4 = ""
                    };
                    FrontResultVo.MessageList.Add(BatchDifferentMessage);
                }

                if (!DataIsOk)
                {
                    FrontResultVo.OutSapFlag = Properties.Resources.ErrorMessageCategory;
                    return FrontResultVo;
                }
            }
            SAPCommandAdapter sapCommandAdapter = base.GetSAPCommandAdaptor(trxContext, SAPRFCNameEnum.RFC_MANUFACTURING_ORDER_CONFIRMATION.GetValue());

            //get the sapuser from cache memory
            SapUserVo sapUserVo = sapCommandAdapter.GetSapUser(trxContext);

            DateTime dbTime = trxContext.ProcessingDBDateTime;

            SAPParameterList sapParameter = sapCommandAdapter.CreateParameterList();
            sapParameter.AddParameter("PLANT", ServerConfigurationDataTypeEnum.DEFAULT_SAP_PLANT_CODE.GetValue()); // );
            sapParameter.AddParameter("ORDER_NUMBER", header.OrderNumber);
            sapParameter.AddParameter("IMUSER", sapUserVo.SapUser); //set sapuser using using sessionid
            sapParameter.AddParameter("IMDATE", dbTime.ToString("yyyyMMdd")); //submitting datetime "yyyyMMdd"
            sapParameter.AddParameter("IMTIME", dbTime.ToString("HHmmss")); //submitting datetime "HHmmss"
            if(string.IsNullOrEmpty(header.Supervisor))
            {
                sapParameter.AddParameter("SUPERVISOR", trxContext.UserData.UserCode); //nidecmes login user
            }
            else
            {
                sapParameter.AddParameter("SUPERVISOR", header.Supervisor); // trxContext.UserData.UserCode); //nidecmes login user
            }
            sapParameter.AddParameter("ACT_STARTDATE", header.StartDateTime.ToString("yyyyMMdd"));
            sapParameter.AddParameter("ACT_STARTTIME", header.StartDateTime.ToString("HHmmss"));
            sapParameter.AddParameter("ACT_ENDDATE", header.EndDateTime.ToString("yyyyMMdd"));
            sapParameter.AddParameter("ACT_ENDTIME", header.EndDateTime.ToString("HHmmss"));
            sapParameter.AddParameter("MAN_HOUR", header.ManHour.ToString("0.000"));
            sapParameter.AddParameter("MACHINE_HOUR", header.MachineHour.ToString("0.000"));
            sapParameter.AddParameter("WORKUNIT", header.WorkTimeUnit);
            sapParameter.AddParameter("POSTDATE", header.PostingDate.ToString("yyyyMMdd"));
            sapParameter.AddParameter("CAL_FLAG", header.CancellationFlag);
            sapParameter.AddParameter("END_FLAG", header.EndFlag);
            sapParameter.AddParameter("CONF_NO", header.ConfirmationNumber.ToString());
            sapParameter.AddParameter("CONF_CNT", header.ConfirmationCounter.ToString());
            sapParameter.AddParameter("MULTI_FLAG", header.MultiFlag);
            sapParameter.AddParameter("IM_COUNT", header.MaterialCount);
            sapParameter.AddParameter("IM_TOTAL", header.MaterialQuantityTotal.ToString("0.000"));


            SAPParameterList sapParameterTable;

            SAPParameterList sapParameterTableLists = sapCommandAdapter.CreateParameterList();

            foreach (MoConfirmationMaterialVo m in materials)
            {
                //rfcTable.Insert();
                sapParameterTable = sapCommandAdapter.CreateParameterList();

                sapParameterTable.AddParameter("ORDER_NUMBER", m.OrderNumber);
                sapParameterTable.AddParameter("IMDATE", dbTime.ToString("yyyyMMdd"));
                sapParameterTable.AddParameter("IMTIME", dbTime.ToString("HHmmss"));
                sapParameterTable.AddParameter("MATERIAL", m.MaterialNumber);
                sapParameterTable.AddParameter("BATCH", m.SapBatchNumber);
                sapParameterTable.AddParameter("V_BATCH", m.VendorBatchNumber);
                sapParameterTable.AddParameter("MOVETYPE", m.MovementType);
                sapParameterTable.AddParameter("ACT_QUANTITY", m.Quantity.ToString());
                sapParameterTable.AddParameter("LGORT", m.StorageLocation);
                sapParameterTable.AddParameter("UNIT", m.Unit);

                sapParameterTableLists.AddParameterList(sapParameterTable);
            }
            sapParameter.AddParameter("TB_ORDER_MOVEMENT", sapParameterTableLists);

            SAPFunction sapFuntion = sapCommandAdapter.Execute(trxContext, sapParameter);

            MoConfirmationResultVo resultVo = new MoConfirmationResultVo
            {
                OutSapFlag = sapFuntion.GetSAPValue("OUT_SAPFLAG")
            };

            List<SapMessageVo> messageList = new List<SapMessageVo>();
            DataTable sapTable = sapFuntion.GetSAPTable("TB_RETURN");

            foreach (DataRow dr in sapTable.Rows)
            {
                SapMessageVo message = new SapMessageVo
                {
                    OrderNumber = ConvertNull<string>(dr, "AUFNR"),
                    MessageType = ConvertNull<string>(dr, "TYPE"),
                    MessageClassId = ConvertNull<string>(dr, "ID"),
                    MessageNumber = ConvertNull<string>(dr, "NUMBER"),
                    LogNumber = ConvertNull<string>(dr, "MESSAGE"),
                    LogMessageNumber = ConvertNull<string>(dr, "LOG_NO"),
                    MessageVariable1 = ConvertNull<string>(dr, "MESSAGE_V1"),
                    MessageVariable2 = ConvertNull<string>(dr, "MESSAGE_V2"),
                    MessageVariable3 = ConvertNull<string>(dr, "MESSAGE_V3"),
                    MessageVariable4 = ConvertNull<string>(dr, "MESSAGE_V4")
                };

                resultVo.MessageList.Add(message);
            }


            return resultVo;

        }
    }
}
