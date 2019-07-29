using System.Xml.Serialization;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
     class MasterMntCommonCbm : CbmController
    {
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            MasterMntCommonInVo inVo = (MasterMntCommonInVo)vo;

            CbmController targetCbm = inVo.TargetCbm;

            ValueObject targetInVo = inVo.TargetInVo;

            ValueObject outVo = targetCbm.Execute(trxContext, targetInVo);

            //invoke master mnt log DAO
            if (inVo.IsLogging)
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(outVo.GetType());
                serializer.Serialize(stringwriter, outVo);

                //MasterMntUpdatedRecord logInVo = new MasterMntUpdatedRecord
                //{
                //    TableName = "user",
                //    LogContents = stringwriter.ToString()
                //};
                // UpdateLogMasterMntCbm updateLogCbm = new UpdateLogMasterMntCbm();

                //MasterMntUpdatedRecord logOutVo = (MasterMntUpdatedRecord)updateLogCbm.Execute(trxContext, logInVo);
                
            }

            return outVo;
        }
    }
}
