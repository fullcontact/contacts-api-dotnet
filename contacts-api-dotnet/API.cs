using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Linq;
using FullContact.Contacts.API.Responses;
using System.Threading.Tasks;

namespace FullContact.Contacts.API
{
    public abstract class API
    {
        readonly IDictionary<String, Object> _config;
        protected readonly String _baseUrl;
        protected readonly String _clientId;
        protected readonly String _clientSecret;
        protected readonly HttpClient _client;
        protected readonly String _userAgent;
        protected readonly JsonSerializerSettings _mapperSettings;

        public API(IDictionary<String, Object> config) 
        {
            this._config = config;
            this._baseUrl = (String)config["apiUrl"];
            this._clientId = (String)config["clientId"];
            this._clientSecret = (String)config["clientSecret"];
            this._userAgent = (String)config["userAgent"];

            if(String.IsNullOrWhiteSpace(this._userAgent)) {
                this._userAgent = "Contacts API SDK (.NET)";    
            }

            this._client = new HttpClient();
            this._mapperSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        protected async Task<APIResponse<T>> RequestAsync<T>(String accessToken, HttpMethod method, String uri, Dictionary<String, String> form, Dictionary<String, IEnumerable<String>> headers) where T : class
        {
            String body = String.Join("&", form.Select(pair => String.Format("{0}={1}", pair.Key, Uri.EscapeUriString(pair.Value))));

            if(headers == null) {
                headers = new Dictionary<string, IEnumerable<string>>();
            }

            headers.Add("Content-Type", new List<String> {"application/x-www-form-urlencoded"});

            return await this.RequestAsync<T>(accessToken, method, uri, body, headers);
        }

        protected async Task<APIResponse<T>> RequestAsync<T>(String accessToken, HttpMethod method, String uri, Object obj, Dictionary<String, IEnumerable<String>> headers) where T : class
        {
            String body = JsonConvert.SerializeObject(obj);

            if (headers == null)
            {
                headers = new Dictionary<string, IEnumerable<string>>();
            }

            headers.Add("Content-Type", new List<String> { "application/json" });

            return await this.RequestAsync<T>(accessToken, method, uri, body, headers);
        }

        protected async Task<APIResponse<T>> RequestAsync<T>(String accessToken, HttpMethod method, String uri, String body, Dictionary<String, IEnumerable<String>> headers) where T : class
        {
            HttpRequestMessage req = new HttpRequestMessage();
            req.Method = method;
            req.RequestUri = new Uri(String.Format("{0}{1}", this._baseUrl, uri));

            if(headers != null) {
                headers.ToList().ForEach(pair => req.Headers.Add(pair.Key, pair.Value));    
            }

            if(!String.IsNullOrEmpty(accessToken)) {
                req.Headers.Add("Authorization", new String[] { "Bearer " + accessToken });
            }

            if(!String.IsNullOrWhiteSpace(body)) {
                req.Content = new StringContent(body);    
            }

            req.Headers.Add("User-Agent", this._userAgent);

            HttpResponseMessage r = await this._client.SendAsync(req);
            APIResponse<T> res = new APIResponse<T>();
            res.Body = JsonConvert.DeserializeObject<T>(r.Content.ToString(), this._mapperSettings);
            res.Status = r.StatusCode;
            res.Headers = r.Headers;
            return res;
        }
    }
}
