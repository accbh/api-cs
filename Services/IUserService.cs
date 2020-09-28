namespace Bahrain.Common {
    public interface IUserService {
        bool hasCidBeenCaptured(string cid);
        void CaptureNewUser(VatsimUser user);
        void UpdateUsersTokens(string cid, string accessToken, string refreshToken);
    }
}