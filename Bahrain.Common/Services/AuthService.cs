using System;
using Microsoft.Extensions.Logging;

namespace Bahrain.Common
{
    public class AuthService : IAuthService
    {
        public AuthService(IUserService userService, IVatsimApi vatsimApi) 
        {
            _vatsimApi = vatsimApi;
            _userService = userService;
        }

        private IUserService _userService;
        private IVatsimApi _vatsimApi;

        public void HandleSsoToken(string accessToken, string refreshToken, ILogger logger) 
        {
            try 
            {
                VatsimUser vatsimUser = _vatsimApi.GetUser(accessToken, refreshToken, logger);
                bool cidHasBeenCaptured = _userService.hasCidBeenCaptured(vatsimUser.Cid);
                
                if (cidHasBeenCaptured) 
                {
                    _userService.UpdateUsersTokens(vatsimUser.Cid, accessToken, refreshToken);
                } 
                else 
                {
                    _userService.CaptureNewUser(vatsimUser);
                }
            }
            catch (AccessTokenRejectedException) {
                // TODO - try get new access token
                string newAccessToken = _vatsimApi.GetNewAccessToken(refreshToken);
                HandleSsoToken(newAccessToken, refreshToken, logger);
                return;
            }
        }
    }
}