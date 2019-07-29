using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetMoldDetailMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldDetailVo inVo = (MoldDetailVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select ");
            sqlQuery.Append("   mo.mold_id, ");
            sqlQuery.Append("   mo.mold_cd, ");
            sqlQuery.Append("   mo.mold_name, ");
            sqlQuery.Append("   CONCAT(mo.mold_cd, '-',mo.mold_name) as moldcodename,");
            sqlQuery.Append("   mo.width,  ");
            sqlQuery.Append("   mo.depth, ");
            sqlQuery.Append("   mo.height, ");
            sqlQuery.Append("   mo.weight, ");
            sqlQuery.Append("   mo.production_date_time, ");
            sqlQuery.Append("   mo.life_shot_count,");
            sqlQuery.Append("   mo.comment,");
            sqlQuery.Append("   md.life_alarm_shot_count,");
            sqlQuery.Append("   md.periodic_mnt_alarm_shot_count1,");
            sqlQuery.Append("   md.periodic_mnt_alarm_shot_count2,");
            sqlQuery.Append("   md.periodic_mnt_alarm_shot_count3,");
            sqlQuery.Append("   mc.mold_category_id,");
            sqlQuery.Append("   mc.mold_category_cd,");
            sqlQuery.Append("   mc.mold_category_name, ");
            sqlQuery.Append("   mm.model_id, ");
            sqlQuery.Append("   mm.model_cd, ");
            sqlQuery.Append("   mm.model_name, ");
            sqlQuery.Append("   gi.global_item_cd, ");
            sqlQuery.Append("   mli.item_id, ");
            sqlQuery.Append("   mli.item_cd, ");
            sqlQuery.Append("   mi.drawing_no ");
            sqlQuery.Append(" from m_mold_detail md ");
            sqlQuery.Append(" inner join m_mold mo on md.mold_id = mo.mold_id");
            sqlQuery.Append(" left join m_mold_category mc on mc.mold_category_id=md.mold_category_id ");
            sqlQuery.Append(" left join m_mold_item mi on mi.mold_id = mo.mold_id ");
            sqlQuery.Append(" left join m_global_local_item gli on gli.global_item_id = mi.global_item_id");
            sqlQuery.Append(" left join m_local_item mli on mli.item_id = gli.local_item_id");
            sqlQuery.Append(" left join m_global_item gi on gi.global_item_id = gli.global_item_id ");
            sqlQuery.Append(" left join m_model mm on mm.model_id=mi.model_id ");
            

            sqlQuery.Append(" where mo.factory_cd = :factorycd ");

            if (inVo.MoldCode != null)
            {
                sqlQuery.Append(" and mo.mold_cd like :moldcd ");
            }
            sqlQuery.Append(" order by mo.mold_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("factorycd", trxContext.UserData.FactoryCode);


            if (inVo.MoldCode != null)
            {
                sqlParameter.AddParameterString("moldcd", "%" + inVo.MoldCode + "%");
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
                currOutVo.MoldName = ConvertDBNull<string>(dataReader, "mold_name");
                currOutVo.MoldCodeName = ConvertDBNull<string>(dataReader, "moldcodename");
                currOutVo.Width = ConvertDBNull<decimal?>(dataReader, "width");
                currOutVo.Depth = ConvertDBNull<decimal?>(dataReader, "depth");
                currOutVo.Height = ConvertDBNull<decimal?>(dataReader, "height");
                currOutVo.Weight = ConvertDBNull<decimal?>(dataReader, "weight");
                currOutVo.LifeShotCount = ConvertDBNull<int>(dataReader, "life_shot_count");
                currOutVo.MoldCategoryId = ConvertDBNull<int>(dataReader, "mold_category_id");
                currOutVo.MoldCategoryName = ConvertDBNull<string>(dataReader, "mold_category_name");
                currOutVo.MoldCategoryCode = ConvertDBNull<string>(dataReader, "mold_category_cd");
                currOutVo.LifeAlarmShotCount = ConvertDBNull<int>(dataReader, "life_alarm_shot_count");
                currOutVo.PeriodicAlarmShotCount1 = ConvertDBNull<int?>(dataReader, "periodic_mnt_alarm_shot_count1");
                currOutVo.PeriodicAlarmShotCount2 = ConvertDBNull<int?>(dataReader, "periodic_mnt_alarm_shot_count2");
                currOutVo.PeriodicAlarmShotCount3 = ConvertDBNull<int?>(dataReader, "periodic_mnt_alarm_shot_count3");
                currOutVo.ProductionDate = ConvertDBNull<DateTime>(dataReader, "production_date_time");
                currOutVo.Comment = ConvertDBNull<string>(dataReader, "comment");

                currOutVo.ModelId = ConvertDBNull<int>(dataReader, "model_id");
                currOutVo.ModelName = ConvertDBNull<string>(dataReader, "model_cd");
                currOutVo.ModelCode = ConvertDBNull<string>(dataReader, "model_name");
                currOutVo.MoldItemId = ConvertDBNull<int>(dataReader, "item_id");
                currOutVo.MoldItemCode = ConvertDBNull<string>(dataReader, "item_cd");
                currOutVo.SapItemCode = ConvertDBNull<string>(dataReader, "global_item_cd");
                currOutVo.MoldDrawingNo = ConvertDBNull<string>(dataReader, "drawing_no");


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
