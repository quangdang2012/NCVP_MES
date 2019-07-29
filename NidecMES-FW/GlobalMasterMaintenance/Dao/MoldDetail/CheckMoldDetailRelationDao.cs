using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckMoldDetailRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldDetailVo inVo = (MoldDetailVo)arg;

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("select mc.mold_id,cv.cavity_id,gmi.mold_item_id from m_mold_detail md");
            sqlQuery.Append(" inner join m_mold mc on mc.mold_id = md.mold_id");
            sqlQuery.Append(" left outer join m_cavity cv on cv.mold_id = mc.mold_id");
            sqlQuery.Append(" left outer join m_mold_item gmi on gmi.mold_id = mc.mold_id");

            sqlQuery.Append(" where mc.factory_cd =:faccd ");

            if (inVo.MoldCode != null)
            {
                sqlQuery.Append(" and UPPER(mc.mold_cd) = UPPER(:moldcd) ");
            }
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", trxContext.UserData.FactoryCode);

            if (inVo.MoldCode != null)
            {
                sqlParameter.AddParameterString("moldcd", inVo.MoldCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            MoldDetailVo outVo = new MoldDetailVo();

            while (dataReader.Read())
            {
                outVo.CavityId = ConvertDBNull<int?>(dataReader, "cavity_id");
                outVo.MoldItemId = ConvertDBNull<int?>(dataReader, "mold_item_id");
            }

            dataReader.Close();

            return outVo;
        }
    }
}
