using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteUserLineBuildingMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            UserLineBuildingVo inVo = (UserLineBuildingVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete from m_user_line_building");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.LineBuildingId > 0)
            {
                sqlQuery.Append(" AND line_building_id = :linebuildingid");
            }           
            if (inVo.UserCode != null)
            {
                sqlQuery.Append(" AND user_cd = :usercd");
            }

            if (inVo.LineBuildingidList.Count > 0)
            {
                sqlQuery.Append(" AND line_building_id = ANY(:idlist) ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            sqlParameter.AddParameterInteger("linebuildingid", inVo.LineBuildingId);
            sqlParameter.AddParameterString("usercd", inVo.UserCode);
            sqlParameter.AddParameter("idlist", inVo.LineBuildingidList);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
