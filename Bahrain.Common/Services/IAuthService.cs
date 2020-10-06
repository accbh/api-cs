using Microsoft.Extensions.Logging;

namespace Bahrain.Common
{
    public interface IAuthService
    {
        void HandleSsoToken(string accessToken, string refreshToken, ILogger logger);
    }
}