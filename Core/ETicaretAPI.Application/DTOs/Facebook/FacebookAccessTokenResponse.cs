using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs.Facebook
{
    public class FacebookAccessTokenResponse
    {
        [JsonPropertyName("access-token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token-type")]
        public string TokenType { get; set; }
    }
}
