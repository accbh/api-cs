using Newtonsoft.Json;

namespace Bahrain.Common
{
    public class VatsimUser
    {
        [JsonProperty("cid")]
        public string Cid;
    }
}