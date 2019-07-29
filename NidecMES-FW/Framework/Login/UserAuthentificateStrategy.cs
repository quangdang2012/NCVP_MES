
namespace Com.Nidec.Mes.Framework
{
    internal interface UserAuthentificateStrategy
    {
        bool Authentificate(string user, string pass);

    }
}
