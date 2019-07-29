using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetWorkContentMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            WorkContentVo inVo = (WorkContentVo)arg;

            WorkContentVo outVo = new WorkContentVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select distinct * from m_work_content  ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.WorkContentCode != null)
            {
                sqlQuery.Append(" and work_content_cd like :workcontentcd ");
            }

            if (inVo.WorkContentId  > 0)
            {
                sqlQuery.Append(" and work_content_id = :workcontentid ");
            }

            if (inVo.WorkContentName  != null)
            {
                sqlQuery.Append(" and work_content_name like :workcontentname ");
            }

            if (inVo.WorkContentTypeId > 0)
            {
                sqlQuery.Append(" and work_content_type_id = :workcontenttypeid ");
            }

            sqlQuery.Append(" order by display_order ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("workcontenttypeid", inVo.WorkContentTypeId);

            if (inVo.WorkContentCode != null)
            {
                sqlParameter.AddParameterString("workcontentcd", inVo.WorkContentCode  + "%");
            }

            if (inVo.WorkContentName != null)
            {
                sqlParameter.AddParameterString("workcontentname", inVo.WorkContentName  + "%");
            }

            if (inVo.WorkContentId != 0)
            {
                sqlParameter.AddParameterInteger("workcontentid", inVo.WorkContentId );
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                WorkContentVo  currOutVo = new WorkContentVo
                {
                    WorkContentId  = Convert.ToInt32(dataReader["work_content_id"]),
                    WorkContentCode  = dataReader["work_content_cd"].ToString(),
                    WorkContentName  = dataReader["work_content_name"].ToString(),
                    DisplayOrder  = Convert.ToInt32(dataReader["display_order"].ToString())
                };

                outVo.WorkContentListVo .Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
