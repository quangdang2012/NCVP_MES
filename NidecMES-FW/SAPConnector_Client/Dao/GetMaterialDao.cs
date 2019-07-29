using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Vo;

namespace Com.Nidec.Mes.SAPConnector_Client.Dao
{
    class GetMaterialDao : AbstractSAPDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            MaterialInVo inVo = (MaterialInVo)vo;

            //create command
            SAPCommandAdapter sapCommandAdapter = base.GetSAPCommandAdaptor(trxContext, SAPRFCNameEnum.RFC_MATERIAL.GetValue());

            //create parameter
            SAPParameterList sapParameter = sapCommandAdapter.CreateParameterList();
            sapParameter.AddParameter("IM_WERKS", ServerConfigurationDataTypeEnum.DEFAULT_SAP_PLANT_CODE.GetValue()); // inVo.ImWerks); // "1100");
            sapParameter.AddParameter("IM_PERIOD_FROM", inVo.ImPeriodFrom); // "20160323");
            sapParameter.AddParameter("IM_PERIOD_TO", inVo.ImPeriodTo); // "20160323");
            sapParameter.AddParameter("IM_MATERIAL_FROM", inVo.ImMaterialFrom); // "ZP01");
            sapParameter.AddParameter("IM_MATERIAL_TO", inVo.ImMaterialTo); // "ZP01");
            sapParameter.AddParameter("IM_SOURCE", inVo.ImSource); // "1");

            SAPFunction sapFuntion = sapCommandAdapter.Execute(trxContext, sapParameter);

            DataTable sapMaterial = sapFuntion.GetSAPTable("TB_MATERIAL_DATA");

            DataTable sapVendor = sapFuntion.GetSAPTable("TB_VENDOR_DATA");

            DataTable sapReturn = sapFuntion.GetSAPTable("TB_RETURN");

            MaterialOutVo outVo = new MaterialOutVo();


            ////getting material detail
            outVo.MaterialListVo = new List<Vo.MaterialOutVo>();

            foreach (DataRow dr in sapMaterial.Rows)
            {
                MaterialOutVo currOutVo = new MaterialOutVo();

                currOutVo.outmatnr = ConvertNull<string>(dr, "OUT_MATNR");
                currOutVo.outmaktx = ConvertNull<string>(dr, "OUT_MAKTX");
                currOutVo.outmtart = ConvertNull<string>(dr, "OUT_MTART");
                if (IsValid(ConvertNull<string>(dr, "OUT_ERSDA")))
                {
                    currOutVo.outersda = Convert.ToDateTime(ConvertNull<string>(dr, "OUT_ERSDA"));
                }
                if (IsValid(ConvertNull<string>(dr, "OUT_LAEDA")))
                {
                    currOutVo.outlaeda = Convert.ToDateTime(ConvertNull<string>(dr, "OUT_LAEDA"));
                }

                currOutVo.outlvorm1 = ConvertNull<string>(dr, "OUT_LVORM1");
                currOutVo.outxchpf = ConvertNull<string>(dr, "OUT_XCHPF");
                currOutVo.outmeins = ConvertNull<string>(dr, "OUT_MEINS");
                currOutVo.outbismt = ConvertNull<string>(dr, "OUT_BISMT");
                currOutVo.outmatkl = ConvertNull<string>(dr, "OUT_MATKL");
                currOutVo.outspart = ConvertNull<string>(dr, "OUT_SPART");
                currOutVo.outprdha = ConvertNull<string>(dr, "OUT_PRDHA");
                currOutVo.outmstae = ConvertNull<string>(dr, "OUT_MSTAE");
                currOutVo.outmtpos = ConvertNull<string>(dr, "OUT_MTPOS");
                currOutVo.outntgew = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_NTGEW"));
                currOutVo.outgewei = ConvertNull<string>(dr, "OUT_GEWEI");
                currOutVo.outvolum = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_VOLUM"));
                currOutVo.outvoleh = ConvertNull<string>(dr, "OUT_VOLEH");
                currOutVo.outgroes = ConvertNull<string>(dr, "OUT_GROES");
                currOutVo.outzeinr = ConvertNull<string>(dr, "OUT_ZEINR");
                currOutVo.outwerks = ConvertNull<string>(dr, "OUT_WERKS");
                currOutVo.outlvorm2 = ConvertNull<string>(dr, "OUT_LVORM2");
                currOutVo.outdisgr = ConvertNull<string>(dr, "OUT_DISGR");
                currOutVo.outekgrp = ConvertNull<string>(dr, "OUT_EKGRP");
                currOutVo.outmmsta = ConvertNull<string>(dr, "OUT_MMSTA");
                currOutVo.outdismm = ConvertNull<string>(dr, "OUT_DISMM");
                currOutVo.outminbe = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_MINBE"));
                currOutVo.outfxhor = Convert.ToInt32(ConvertNull<string>(dr, "OUT_FXHOR"));
                currOutVo.outdispo = ConvertNull<string>(dr, "OUT_DISPO");
                currOutVo.outdsnam = ConvertNull<string>(dr, "OUT_DSNAM");
                currOutVo.outdisls = ConvertNull<string>(dr, "OUT_DISLS");
                currOutVo.outbstmi = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_BSTMI"));
                currOutVo.outbstma = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_BSTMA"));
                currOutVo.outbstfe = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_BSTFE"));
                currOutVo.outmabst = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_MABST"));
                currOutVo.outrdprf = ConvertNull<string>(dr, "OUT_RDPRF");
                currOutVo.outbstrf = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_BSTRF"));
                currOutVo.outbeskz = ConvertNull<string>(dr, "OUT_BESKZ");
                currOutVo.outsobsl = ConvertNull<string>(dr, "OUT_SOBSL");
                currOutVo.outlgpro = ConvertNull<string>(dr, "OUT_LGPRO");
                currOutVo.outusequ = ConvertNull<string>(dr, "OUT_USEQU");
                currOutVo.outvspvb = ConvertNull<string>(dr, "OUT_VSPVB");
                currOutVo.outrgekz = ConvertNull<string>(dr, "OUT_RGEKZ");
                currOutVo.outlgfsb = ConvertNull<string>(dr, "OUT_LGFSB");
                currOutVo.outdzeit = Convert.ToInt32(ConvertNull<string>(dr, "OUT_DZEIT"));
                currOutVo.outplifz = Convert.ToInt32(ConvertNull<string>(dr, "OUT_PLIFZ"));
                currOutVo.outwebaz = Convert.ToInt32(ConvertNull<string>(dr, "OUT_WEBAZ"));
                currOutVo.outmrppp = ConvertNull<string>(dr, "OUT_MRPPP");
                currOutVo.outfhori = ConvertNull<string>(dr, "OUT_FHORI");
                currOutVo.outeisbe = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_EISBE"));
                currOutVo.outlgrad = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_LGRAD"));
                currOutVo.outeislo = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_EISLO"));
                currOutVo.outrwpro = ConvertNull<string>(dr, "OUT_RWPRO");
                currOutVo.outshflg = ConvertNull<string>(dr, "OUT_SHFLG");
                currOutVo.outshzet = Convert.ToInt32(ConvertNull<string>(dr, "OUT_SHZET"));
                currOutVo.outshpro = ConvertNull<string>(dr, "OUT_SHPRO");
                currOutVo.outstrgr = ConvertNull<string>(dr, "OUT_STRGR");
                currOutVo.outvrmod = ConvertNull<string>(dr, "OUT_VRMOD");
                currOutVo.outvint1 = Convert.ToInt32(ConvertNull<string>(dr, "OUT_VINT1"));
                currOutVo.outvint2 = Convert.ToInt32(ConvertNull<string>(dr, "OUT_VINT2"));
                currOutVo.outmiskz = ConvertNull<string>(dr, "OUT_MISKZ");
                currOutVo.outmtvfp = ConvertNull<string>(dr, "OUT_MTVFP");
                currOutVo.outaltsl = ConvertNull<string>(dr, "OUT_ALTSL");
                currOutVo.outkausf = Convert.ToDecimal(ConvertNull<string>(dr, "OUT_KAUSF"));
                currOutVo.outkzaus = ConvertNull<string>(dr, "OUT_KZAUS");
                if (IsValid(ConvertNull<string>(dr, "OUT_AUSDT")))
                {
                    currOutVo.outausdt = Convert.ToDateTime(ConvertNull<string>(dr, "OUT_AUSDT"));
                }
                currOutVo.outnfmat = ConvertNull<string>(dr, "OUT_NFMAT");

                outVo.MaterialListVo.Add(currOutVo);
            }

            ////getting supplier detail
            outVo.SupplierListVo = new List<Vo.SupplierVo>();

            foreach (DataRow dr in sapVendor.Rows)
            {
                SupplierVo currVo = new SupplierVo();
                currVo.OutMatnr = ConvertNull<string>(dr, "OUT_MATNR");
                currVo.OutWerks = ConvertNull<string>(dr, "OUT_WERKS");
                currVo.OutEkorg = ConvertNull<string>(dr, "OUT_EKORG");
                if (IsValid(ConvertNull<string>(dr, "OUT_VALID_FROM")))
                {
                    currVo.OutValidFrom = Convert.ToDateTime(ConvertNull<string>(dr, "OUT_VALID_FROM"));
                }
                if (IsValid(ConvertNull<string>(dr, "OUT_VALID_TO")))
                {
                    currVo.OutValidTo = Convert.ToDateTime(ConvertNull<string>(dr, "OUT_VALID_TO"));
                }

                currVo.OutVendor = ConvertNull<string>(dr, "OUT_VENDOR");
                currVo.OutName = ConvertNull<string>(dr, "OUT_NAME");

                outVo.SupplierListVo.Add(currVo);
            }


            outVo.SapMessageListVo = new List<SapMessageVo>();

            foreach (DataRow dr in sapReturn.Rows)
            {
                SapMessageVo message = new SapMessageVo();

                message.MessageType = ConvertNull<string>(dr, "TYPE");
                message.MessageCode = ConvertNull<string>(dr, "CODE");
                message.Message = ConvertNull<string>(dr, "MESSAGE");
                message.LogNumber = ConvertNull<string>(dr, "LOG_NO");
                message.LogMessageNumber = ConvertNull<string>(dr, "LOG_MSG_NO");
                message.MessageVariable1 = ConvertNull<string>(dr, "MESSAGE_V1");
                message.MessageVariable2 = ConvertNull<string>(dr, "MESSAGE_V2");
                message.MessageVariable3 = ConvertNull<string>(dr, "MESSAGE_V3");
                message.MessageVariable4 = ConvertNull<string>(dr, "MESSAGE_V4");

                outVo.SapMessageListVo.Add(message);
            }
            return outVo;
        }
    }
}
