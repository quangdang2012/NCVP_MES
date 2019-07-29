using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetMoldMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldVo inVo = (MoldVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select md.mold_id, md.mold_cd, md.mold_name, mt.mold_type_id, mt.mold_type_cd, ");
            sqlQuery.Append(" md.width , md.depth , md.height , md.weight , ");
            sqlQuery.Append(" md.production_date_time , md.life_shot_count, ");
            sqlQuery.Append(" md.comment ");
            sqlQuery.Append(" from m_mold md ");
            sqlQuery.Append("left join m_mold_type mt on md.mold_type_id = mt.mold_type_id ");
            sqlQuery.Append(" where md.factory_cd = :faccd ");

            if (inVo.MoldId > 0)
            {
                sqlQuery.Append(" and md.mold_id = :moldid ");
            }

            if (inVo.MoldCode != null)
            {
                sqlQuery.Append(" and md.mold_cd like :moldcd ");
            }

            if (inVo.MoldName != null)
            {
                sqlQuery.Append(" and md.mold_name like :moldname ");
            }

            if (inVo.MoldTypeId != 0)
            {
                sqlQuery.Append(" and mt.mold_type_id = :moldtypeid ");
            }

            sqlQuery.Append(" order by md.mold_cd");

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

            if (inVo.MoldId != 0)
            {
                sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            }

            if (inVo.MoldCode != null)
            {
                sqlParameter.AddParameterString("moldcd", inVo.MoldCode + "%");
            }

            if (inVo.MoldName != null)
            {
                sqlParameter.AddParameterString("moldname", inVo.MoldName + "%");
            }
            if (inVo.MoldTypeId != 0)
            {
                sqlParameter.AddParameterInteger("moldtypeid", inVo.MoldTypeId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            MoldVo outVo = new MoldVo();

            while (dataReader.Read())
            {
                MoldVo currOutVo = new MoldVo();

                currOutVo.MoldId = ConvertDBNull<Int32>(dataReader, "mold_id");
                currOutVo.MoldCode = ConvertDBNull<string>(dataReader, "mold_cd");
                currOutVo.MoldName = ConvertDBNull<string>(dataReader, "mold_name");
                currOutVo.MoldTypeId = ConvertDBNull<Int32>(dataReader, "mold_type_id");
                currOutVo.MoldTypeCode = ConvertDBNull<string>(dataReader, "mold_type_cd");
                currOutVo.Width = ConvertDBNull<decimal>(dataReader, "width");
                currOutVo.Depth = ConvertDBNull<decimal>(dataReader, "depth");
                currOutVo.Height = ConvertDBNull<decimal>(dataReader, "height");
                currOutVo.Weight = ConvertDBNull<decimal>(dataReader, "weight");
                currOutVo.ProductionDate = ConvertDBNull<DateTime>(dataReader, "production_date_time");
                currOutVo.Comment = ConvertDBNull<string>(dataReader, "comment");
                currOutVo.LifeShotCount = ConvertDBNull<Int32>(dataReader, "life_shot_count");               

                outVo.MoldListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;

        }
    }
}
