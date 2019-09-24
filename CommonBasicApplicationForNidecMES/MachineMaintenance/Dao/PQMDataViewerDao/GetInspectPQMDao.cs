using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetInspectPQMDao : AbstractDataAccessObject
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
            sql.Append(@"select distinct inspect from procinsplink where 1=1");
            if (!string.IsNullOrEmpty(InVo.Process))
            {
                sql.Append(@" and process = :process ");
                sqlParameter.AddParameterString("process", InVo.Process);
            }
            sql.Append(@"order by inspect asc");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (datareader.Read())
            {
                //CREATE OJECT INCLUDE MODEL VALUE
                PQMDataViewerVo outVo = new PQMDataViewerVo()
                {
                    Inspect = datareader["inspect"].ToString(),
                };
                VoList.add(outVo);
            }
            datareader.Close();
            return VoList;
        }
    }
}
