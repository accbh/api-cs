namespace Bahrain.Common {
    public class UserService : IUserService {
        public bool hasCidBeenCaptured(string cid) 
        {
            // TODO - use userService to get a user by this cid
            // if void is returned, user does not exist/has been captured
            // if a user is returned, user exists/has been captured
            return false;
        }

        public void CaptureNewUser(VatsimUser user) 
        {
            
        }

        public void UpdateUsersTokens(string cid, string accessToken, string refreshToken)
        {
            
        }
    }
}