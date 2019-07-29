using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Framework_Batch
{
    internal class DefaultBatchUserfactory : UserDataFactory
    {
        /// <summary>
        /// instance of the DefaultBatchUserfactory class
        /// </summary>
        private static readonly DefaultBatchUserfactory instance = new DefaultBatchUserfactory();

        /// <summary>
        /// private constructor
        /// </summary>
        private DefaultBatchUserfactory() { }

        /// <summary>
        /// return instance of DefaultBatchUserfactory class
        /// </summary>
        /// <returns></returns>
        internal static UserDataFactory GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// get userdata instance and set value
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public UserData CreateUserData(ValueObject vo)
        {
            //do not check null, because it was checked in DefaultBatchApplicationInitializer
            UserData usrdata = UserData.GetUserData();
            usrdata.UserCode = BatchConfigurationDataTypeEnum.DEFAULT_BATCH_USER.GetValue();
            usrdata.FactoryCode = BatchConfigurationDataTypeEnum.DEFAULT_BATCH_FACTORYCODE.GetValue();
            usrdata.SessionId = usrdata.UserCode + System.Guid.NewGuid().ToString();

            return usrdata;
        }
    }
}
