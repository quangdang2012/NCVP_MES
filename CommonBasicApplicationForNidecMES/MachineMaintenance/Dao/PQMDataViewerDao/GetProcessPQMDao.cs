using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetProcessPQMDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            PQMDataViewerVo InVo = (PQMDataViewerVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<PQMDataViewerVo> VoList = new ValueObjectList<PQMDataViewerVo>();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            //ADD COMMAND
            if (!string.IsNullOrEmpty(InVo.Model))
            {
                sql.Append(@"select distinct process from processtbl where 1=1");
                sql.Append(@" and model = :model ");
                sqlParameter.AddParameterString("model", InVo.Model);
                sql.Append(@"order by process asc");
            }
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (datareader.Read())
            {
                //CREATE OJECT INCLUDE MODEL VALUE
                PQMDataViewerVo outVo = new PQMDataViewerVo()
                {
                    Process = datareader["process"].ToString(),
                };
                VoList.add(outVo);
            }
            datareader.Close();
            return VoList;
        }
    }
}
