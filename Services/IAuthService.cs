namespace Bahrain.Common
{
    public interface IAuthService
    {
        void HandleSsoToken(string accessToken, string refreshToken);
    }
}