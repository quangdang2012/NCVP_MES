using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetCavityMasterMntWithModelDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CavityVo inVo = (CavityVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL

            sqlQuery.Append("Select ct.cavity_id, ct.cavity_cd, ct.cavity_name, md.mold_id, md.mold_cd ");
            sqlQuery.Append(" from m_cavity ct ");
            sqlQuery.Append(" inner join m_mold md on md.mold_id = ct.mold_id ");

            sqlQuery.Append(" inner join m_mold_type mdt on mdt.mold_type_id = md.mold_type_id ");
            sqlQuery.Append(" inner join m_local_item mli on mli.item_id = mdt.item_id ");

            sqlQuery.Append(" where ct.factory_cd = :faccd  ");

            if (inVo.CavityCode != null)
            {
                sqlQuery.Append(" and ct.cavity_cd like :cavitycd ");
            }

            if (inVo.CavityName != null)
            {
                sqlQuery.Append(" and ct.cavity_name like :cavityname ");
            }

            if (inVo.ModelCode != null)
            {
                sqlQuery.Append(" and mli.item_cd = :modelcd ");
            }

            if (inVo.ModelId > 0)
            {
                sqlQuery.Append(" and mli.item_id = :modelid ");
            }
            
            sqlQuery.Append(" order by cavity_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.CavityCode != null)
            {
                sqlParameter.AddParameterString("cavitycd", inVo.CavityCode + "%");
            }

            if (inVo.CavityName != null)
            {
                sqlParameter.AddParameterString("cavityname", inVo.CavityName + "%");
            }

            if (inVo.ModelCode != null)
            {
                sqlParameter.AddParameterString("modelcd", inVo.ModelCode );
            }

            if (inVo.ModelId > 0)
            {
                sqlParameter.AddParameterInteger("modelid", inVo.ModelId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<CavityVo> outVo = null;

            while (dataReader.Read())

            {
                CavityVo currOutVo = new CavityVo();
                {
                    currOutVo.CavityId = Convert.ToInt32(dataReader["cavity_id"]);
                    currOutVo.CavityCode = dataReader["cavity_cd"].ToString();
                    currOutVo.CavityName = dataReader["cavity_name"].ToString();
                    currOutVo.MoldId = Convert.ToInt32(dataReader["mold_id"]);
                    currOutVo.MoldCode = dataReader["mold_cd"].ToString();
                };
                if (outVo == null)
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
