using System;

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

        public void HandleSsoToken(string accessToken, string refreshToken) 
        {
            try 
            {
                VatsimUser vatsimUser = _vatsimApi.GetUser(accessToken, refreshToken);
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
            catch (AccessTokenRejectedException accessTokenRejectedException) {
                // TODO - try get new access token
                string newAccessToken = _vatsimApi.GetNewAccessToken(refreshToken);
                HandleSsoToken(newAccessToken, refreshToken);
                return;
            }
        }
    }
}