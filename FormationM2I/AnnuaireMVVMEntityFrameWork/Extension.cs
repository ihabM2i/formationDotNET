using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireMVVMEntityFrameWork
{
    public static class Extension
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, string url, object objet)
        {
            return client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(objet),
            Encoding.UTF8, "application/json"));
        }
    }
}
