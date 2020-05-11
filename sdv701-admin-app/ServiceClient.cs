using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace sdv701_admin_app
{
    class ServiceClient
    {
        internal async static Task<List<string>> GetBrandsAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/camera/getcamerabrands"));
        }
    }
}
