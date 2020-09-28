using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Bahrain.Common;

namespace Bahrain.API
{

    public class VatsimSSOTokenInput
    {
        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; }
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        private int _expiresIn { get; set; }
        private DateTime _creationDate = DateTime.Now;
        public DateTime ExpiryDate {
            get
            {
                return _creationDate.AddSeconds((double)_expiresIn);
            }
        }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }

    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }

        private IAuthService _authService;

        [HttpGet]
        public RedirectResult VatsimSSOToken(VatsimSSOTokenInput input)
        {
            
            return new RedirectResult("https://bahrainvacc.com");
        }

    }
}