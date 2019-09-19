using System.Data;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    //*********************************************************************************************************************//
    //************************************GET MODEL LIST FOR COMBOBOX******************************************************//
    //*********************************************************************************************************************//
    public class GetModelPQMDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            StringBuilder sql = new StringBuilder();
            ValueObjectList<PQMDataViewerVo> VoList = new ValueObjectList<PQMDataViewerVo>();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            //ADD COMMAND
            sql.Append(@"select distinct model from procinsplink order by model asc");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            //EXECUTE READER FROM COMMAND
            IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (datareader.Read())
            {
                //CREATE OJECT INCLUDE MODEL VALUE
                PQMDataViewerVo outVo = new PQMDataViewerVo()
                {
                    Model = datareader["model"].ToString(),
                };
                VoList.add(outVo);
            }
            datareader.Close();
            return VoList;
        }
    }
}
