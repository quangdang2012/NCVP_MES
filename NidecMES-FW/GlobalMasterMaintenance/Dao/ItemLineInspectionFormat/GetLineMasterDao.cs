using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetLineMasterDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineVo inVo = (LineVo)arg;
            
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select ");
            sqlQuery.Append(" line_id  ");
            sqlQuery.Append(" ,line_cd  ");
            sqlQuery.Append(" ,CONCAT(line_cd, ' - ', line_name) as line_name  ");
            sqlQuery.Append(" from m_line  ");
            sqlQuery.Append(" where factory_cd = :faccd ");
            
            if (inVo.LineCode != null)
            {
                sqlQuery.Append(" and line_cd like :linecd ");
            }

            if (inVo.LineName != null)
            {
                sqlQuery.Append(" and line_name like :linename ");
            }

            sqlQuery.Append(" order by line_name");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.LineCode != null)
            {
                sqlParameter.AddParameterString("linecd", inVo.LineCode + "%");
            }

            if (inVo.LineName != null)
            {
                sqlParameter.AddParameterString("linename", inVo.LineName + "%");
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<LineVo> outVo = null;

            while (dataReader.Read())

            {
                LineVo currOutVo = new LineVo();
                currOutVo.LineId = ConvertDBNull<Int32>(dataReader, "line_id");
                currOutVo.LineCode = ConvertDBNull<string>(dataReader, "line_cd");
                currOutVo.LineName = ConvertDBNull<string>(dataReader, "line_name");
                
                if (outVo == null)
                {
                    outVo = new ValueObjectList<LineVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
