﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ActiveCampaignNet
{
    public class ApiResult
    {
        [JsonProperty("result_code")]
        public int Code { get; set; }

        [JsonProperty("result_message")]
        public string Message { get; set; }

        [JsonProperty("result_output")]
        public string Output { get; set; }

        public string Data { get; set; }

        public bool IsSuccessful { get { return Code == 1; } }
    }
}
