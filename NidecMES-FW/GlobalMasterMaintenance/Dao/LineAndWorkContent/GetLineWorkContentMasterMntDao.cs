using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetLineWorkContentMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineWorkContentVo inVo = (LineWorkContentVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select");
            sqlQuery.Append(" lwc.line_work_content_id,");
            sqlQuery.Append(" lwc.work_content_id,");
            sqlQuery.Append(" lwc.line_id,");
            sqlQuery.Append(" wc.work_content_name,");
            sqlQuery.Append(" l.line_name");
            sqlQuery.Append(" from m_line_work_content lwc");
            sqlQuery.Append(" inner join m_line l on lwc.line_id = l.line_id");
            sqlQuery.Append(" inner join m_work_content wc on lwc.work_content_id = wc.work_content_id");
            sqlQuery.Append(" where lwc.factory_cd = :faccd ");

            if (inVo.WorkContentId > 0)
            {
                sqlQuery.Append(" and lwc.work_content_id = :wcid");
            }

            if (inVo.LineId > 0)
            {
                sqlQuery.Append(" and lwc.line_id = :lid");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("wcid", inVo.WorkContentId);
            sqlParameter.AddParameterInteger("lid", inVo.LineId);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<LineWorkContentVo> outVo = null;

            while (dataReader.Read())
            {
                LineWorkContentVo currOutVo = new LineWorkContentVo
                {
                    LineWorkContentId = Convert.ToInt32(dataReader["line_work_content_id"]),
                    WorkContentId = Convert.ToInt32(dataReader["work_content_id"]),
                    LineId = Convert.ToInt32(dataReader["line_id"]),
                    LineName = dataReader["line_name"].ToString(),
                    WorkContentName = dataReader["work_content_name"].ToString()
                };
                if (outVo == null)
                {
                    outVo = new ValueObjectList<LineWorkContentVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
