using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace Bahrain.Common {
    public class VatsimApi : IVatsimApi {
        public VatsimApi(string baseUrl) {
            _baseUrl = baseUrl;
        }

        private string _baseUrl;

        public string GetNewAccessToken(string refreshToken) {
            throw new NotImplementedException();
        }

        public VatsimUser GetUser(string accessToken, string refreshToken) {
            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{_baseUrl}/api/user");

                request.Method = HttpMethod.Get.ToString();
                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", $"BEARER {accessToken}");
                request.ContentType = "application/json";
                request.Accept = "application/json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);    
                return JsonConvert.DeserializeObject<VatsimUser>(reader.ReadToEnd());
            }
            catch (Exception ex) {
                // TODO - if the request fails because the accessToken is invalid
                // then throw a VatsimAccessTokenRejectedException
                // The calling service can then catch this exception, and start a
                // process of fetching a new access token using the refresh token
                throw ex;
            }
        }
    }
}