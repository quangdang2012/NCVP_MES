using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionSpecficationListDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ValueObjectList<ValueObjectList<ValueObject>> inVo = (ValueObjectList<ValueObjectList<ValueObject>>)arg;
            List<int> ItemList = new List<int>();

            foreach (ValueObjectList<ValueObject> getItemVo in inVo.GetList())
            {
                if ((((InspectionItemVo)getItemVo.GetList()[0]).InspectionItemId) != 0)
                {
                    ItemList.Add(((InspectionItemVo)getItemVo.GetList()[0]).InspectionItemId);
                }
            }

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select * ");
            sqlQuery.Append(" from m_inspection_specification");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_item_id = ANY (:inspectionItemId) ");

            sqlQuery.Append(" order by inspection_specification_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameter("inspectionItemId", ItemList);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionSpecificationVo> outVo = null;

            while (dataReader.Read())
            {
                InspectionSpecificationVo currOutVo = new InspectionSpecificationVo();

                currOutVo.InspectionSpecificationId = ConvertDBNull<int>(dataReader, "inspection_specification_id");
                currOutVo.InspectionSpecificationCode = ConvertDBNull<string>(dataReader, "inspection_specification_cd");
                currOutVo.InspectionSpecificationText = ConvertDBNull<string>(dataReader, "inspection_specification_text");
                currOutVo.ValueFrom = ConvertDBNull<string>(dataReader, "value_from");
                currOutVo.ValueTo = ConvertDBNull<string>(dataReader, "value_to");
                currOutVo.Unit = ConvertDBNull<string>(dataReader, "unit");
                currOutVo.OperatorFrom = ConvertDBNull<string>(dataReader, "operator_from");
                currOutVo.OperatorTo = ConvertDBNull<string>(dataReader, "operator_to");
                currOutVo.InspectionItemId = ConvertDBNull<int>(dataReader, "inspection_item_id");
                currOutVo.SpecificationResultJudgeType = ConvertDBNull<int>(dataReader, "specification_result_judge_type");

                if (outVo == null)
                {
                    outVo = new ValueObjectList<InspectionSpecificationVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
