using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Linq;
using FullContact.Contacts.API.Responses;
using System.Threading.Tasks;
using System.Text;

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

            if(config.ContainsKey("apiUrl")) {
                this._baseUrl = (String)config["apiUrl"];    
            }


            if(config.ContainsKey("clientId")) {
                this._clientId = (String)config["clientId"];    
            }

            if(config.ContainsKey("clientSecret")) {
                this._clientSecret = (String)config["clientSecret"];    
            }

            if(config.ContainsKey("userAgent")) {
                this._userAgent = (String)config["userAgent"];    
            }

            this._client = new HttpClient();
        }

        public API(IDictionary<String, Object> config, HttpClient client) : this(config)
        {
            this._client = client;
        }

        protected async Task<APIResponse<T>> RequestAsync<T>(String accessToken, HttpMethod method, String uri, Dictionary<String, String> form, Dictionary<String, IEnumerable<String>> headers) where T : class
        {
            StringContent body = new StringContent(String.Join("&", form.Select(pair => String.Format("{0}={1}", pair.Key, Uri.EscapeUriString(pair.Value)))), Encoding.UTF8, "application/x-www-form-urlencoded");
            return await this.RequestAsync<T>(accessToken, method, uri, body, headers);
        }

        protected async Task<APIResponse<T>> RequestAsync<T>(String accessToken, HttpMethod method, String uri, Object obj, Dictionary<String, IEnumerable<String>> headers) where T : class
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(obj, Config.JsonSerializerSettings), Encoding.UTF8, "application/json");
            return await this.RequestAsync<T>(accessToken, method, uri, body, headers);
        }

        protected async Task<APIResponse<T>> RequestAsync<T>(String accessToken, HttpMethod method, String uri, StringContent body, Dictionary<String, IEnumerable<String>> headers) where T : class
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

            if(body != null) {
                req.Content = body;    
            }

            if(this._userAgent != null) {
                req.Headers.Add("User-Agent", this._userAgent);    
            }

            HttpResponseMessage r = await this._client.SendAsync(req);
            APIResponse<T> res = new APIResponse<T>();

            if(r.Content != null) {
                String content = await r.Content.ReadAsStringAsync();
                if (!String.IsNullOrWhiteSpace(content))
                {
                    res.Body = JsonConvert.DeserializeObject<T>(content, Config.JsonSerializerSettings);
                }    
            }

            res.Status = r.StatusCode;
            res.Headers = r.Headers;
            return res;
        }
    }
}
