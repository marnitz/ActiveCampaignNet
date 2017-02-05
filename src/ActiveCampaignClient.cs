using System;
using System.Collections.Specialized;
using System.Dynamic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using ActiveCampaignNet.AccountView;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace ActiveCampaignNet
{
    public partial class ActiveCampaignClient
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public AccountViewWrapper AccountView { get; private set; }
        public ActiveCampaignNet.Contact.ContactWrapper Contact { get; private set; }
        public ActiveCampaignNet.Tags.TagWrapper Tags { get; private set; }

        public ActiveCampaignClient(string apiKey, string baseUrl)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException("apiKey");

            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentNullException("baseUrl");

            _apiKey = apiKey;
            _baseUrl = baseUrl;

            AccountView = new AccountViewWrapper(this);
            Contact = new Contact.ContactWrapper(this);
            Tags = new Tags.TagWrapper(this);
        }



        private string CreateBaseUrl(string apiAction)
        {
            return string.Format("{0}/admin/api.php?api_action={1}&api_key={2}&api_output=json", _baseUrl, apiAction, _apiKey);
        }

        private string PreparePayload(NameValueCollection payloads)
        {
            if (payloads == null) return "";
            StringBuilder postData = new StringBuilder();

            foreach (var keyValue in payloads.AllKeys)
            {
                postData.AppendUrlEncoded(keyValue, payloads[keyValue]);
            }

            return postData.ToString();
        }

        public T[] ApiArray<T>(string apiAction, NameValueCollection parameters) where T : ApiResult
        {
            var payload = PreparePayload(parameters);
            var uri = CreateBaseUrl(apiAction);

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                var rawData = wc.UploadString(uri, payload);

                var result = JsonConvert.DeserializeObject<T[]>(rawData,new JsonSerializerSettings {ContractResolver = new CustomDateContractResolver()});
                
                //result.Data = rawData;

                return result;
            }
        }

        public T Api<T> (string apiAction, NameValueCollection parameters) where T:ApiResult
        {
            var payload = PreparePayload(parameters);
            var uri = CreateBaseUrl(apiAction);

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                var rawData = wc.UploadString(uri, payload);

                var result = JsonConvert.DeserializeObject<T>(rawData,new JsonSerializerSettings {ContractResolver = new CustomDateContractResolver()});

                result.Data = rawData;

                return result;
            }
        }

        internal class CustomDateContractResolver : DefaultContractResolver
        {
            protected override JsonContract CreateContract(Type objectType)
            {
                JsonContract contract = base.CreateContract(objectType);
                bool b = (objectType == typeof(DateTime) || objectType == typeof(DateTime?));
                if (b)
                {
                    contract.Converter = new ZerosDateConverter();
                }
                return contract;
            }
        }
    }

    public class ZerosDateConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.Value == null) return null;
            return reader.Value.ToString().Equals("0000-00-00 00:00:00") || reader.Value.ToString().Equals("0000-00-00")
                ? null
                : base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}
