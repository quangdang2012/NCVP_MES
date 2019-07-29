
namespace Com.Nidec.Mes.Framework
{
   public interface UserDataFactory
    {

        /// <summary>
        /// get the userdata
        /// </summary>
        /// <returns></returns>
        UserData CreateUserData(ValueObject vo);

    }
}
