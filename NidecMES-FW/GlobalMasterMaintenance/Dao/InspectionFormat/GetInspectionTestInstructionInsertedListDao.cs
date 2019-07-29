using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionTestInstructionInsertedListDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            //InspectionItemVo inspectionItemVo = (InspectionItemVo)arg;

            ValueObjectList<InspectionTestInstructionVo> inVo = (ValueObjectList<InspectionTestInstructionVo>)arg;
            List<int> ItemList = new List<int>();

            ItemList = inVo.GetList().Select(v => v.InspectionItemId).Distinct().ToList();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select * ");
            sqlQuery.Append(" from m_inspection_test_instruction");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_item_id = ANY (:inspectionItemId) ");

            sqlQuery.Append(" order by inspection_test_instruction_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameter("inspectionItemId", ItemList);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionTestInstructionVo> outVo = null;

            while (dataReader.Read())
            {
                InspectionTestInstructionVo currOutVo = new InspectionTestInstructionVo();

                currOutVo.InspectionTestInstructionId = ConvertDBNull<Int32>(dataReader, "inspection_test_instruction_id");
                currOutVo.InspectionTestInstructionCode = ConvertDBNull<string>(dataReader, "inspection_test_instruction_cd");
                currOutVo.InspectionTestInstructionText = ConvertDBNull<string>(dataReader, "inspection_test_instruction_text");
                currOutVo.InspectionItemId = ConvertDBNull<Int32>(dataReader, "inspection_item_id");

                if (outVo == null)
                {
                    outVo = new ValueObjectList<InspectionTestInstructionVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
