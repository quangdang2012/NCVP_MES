using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetCavityMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CavityVo inVo = (CavityVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select ct.cavity_id, ct.cavity_cd, ct.cavity_name, md.mold_id, md.mold_cd ");
            sqlQuery.Append(" from m_cavity ct ");
            sqlQuery.Append(" inner join m_mold md on md.mold_id = ct.mold_id ");

            sqlQuery.Append(" where ct.factory_cd = :faccd ");

            if (inVo.CavityCode != null)
            {
                sqlQuery.Append(" and ct.cavity_cd like :cavitycd ");
            }

            if (inVo.CavityName != null)
            {
                sqlQuery.Append(" and ct.cavity_name like :cavityname ");
            }

            if (inVo.MoldId != 0)
            {
                sqlQuery.Append(" and md.mold_id = :moldid ");
            }

            if (!string.IsNullOrEmpty(inVo.MoldCode))
            {
                sqlQuery.Append(" and md.mold_cd = :moldcd ");
            }

            sqlQuery.Append(" order by ct.cavity_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (!string.IsNullOrEmpty(inVo.FactoryCode))
            {
                sqlParameter.AddParameterString("faccd", inVo.FactoryCode);
            }
            else
            {
                sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            }
            

            if (inVo.CavityCode != null)
            {
                sqlParameter.AddParameterString("cavitycd", inVo.CavityCode + "%");
            }

            if (inVo.CavityName != null)
            {
                sqlParameter.AddParameterString("cavityname", inVo.CavityName + "%");
            }
            if (inVo.MoldId != 0)
            {
                sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            }

            if (!string.IsNullOrEmpty(inVo.MoldCode))
            {
                sqlParameter.AddParameterString("moldcd", inVo.MoldCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<CavityVo> outVo =null;

            while (dataReader.Read())

            {
                CavityVo currOutVo = new CavityVo
                {
                    CavityId =  ConvertDBNull<Int32>(dataReader, "cavity_id"),
                    CavityCode = ConvertDBNull<string>(dataReader, "cavity_cd"),
                    CavityName = ConvertDBNull<string>(dataReader, "cavity_name"),
                    MoldId = ConvertDBNull<Int32>(dataReader, "mold_id"),
                    MoldCode = ConvertDBNull<string>(dataReader,"mold_cd")
                };

                if(outVo ==null)
                {
                    outVo = new ValueObjectList<CavityVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
