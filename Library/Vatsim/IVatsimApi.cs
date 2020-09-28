namespace Bahrain.Common
{
    public interface IVatsimApi
    {
        string GetNewAccessToken(string refreshToken);
        VatsimUser GetUser(string accessToken, string refreshToken);
    }
}