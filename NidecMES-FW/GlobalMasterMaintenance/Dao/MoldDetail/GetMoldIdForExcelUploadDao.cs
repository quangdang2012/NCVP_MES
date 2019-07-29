using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetMoldIdForExcelUploadDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldDetailVo inVo = (MoldDetailVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select ");
            sqlQuery.Append("   mo.mold_id, ");
            sqlQuery.Append("   mo.mold_cd ");
            sqlQuery.Append(" from m_mold_detail md ");
            sqlQuery.Append(" inner join m_mold mo on md.mold_id = mo.mold_id");
            sqlQuery.Append(" where mo.factory_cd = :factorycd ");

            if (inVo.MoldCode != null)
            {
                sqlQuery.Append(" and UPPER(mo.mold_cd) = UPPER(:moldcd) ");
            }
           
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("factorycd", trxContext.UserData.FactoryCode);


            if (inVo.MoldCode != null)
            {
                sqlParameter.AddParameterString("moldcd", inVo.MoldCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<MoldDetailVo> outVo = null;

            while (dataReader.Read())
            {


                //if (outVo == null || !outVo.GetList().Exists(t => t.MoldId == ConvertDBNull<Int32>(dataReader, "mold_id")))
                //{
                MoldDetailVo currOutVo = new MoldDetailVo();
                currOutVo.MoldId = ConvertDBNull<int>(dataReader, "mold_id");
                currOutVo.MoldCode = ConvertDBNull<string>(dataReader, "mold_cd");

                if (outVo == null)
                {
                    outVo = new ValueObjectList<MoldDetailVo>();
                }
                outVo.add(currOutVo);
                // }
            }
            dataReader.Close();

            return outVo;
        }
    }
}
