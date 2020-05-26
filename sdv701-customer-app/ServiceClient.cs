﻿using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using static sdv701_customer_app.clsDTO;

namespace sdv701_customer_app
{
    public static class ServiceClient
    {
        #region Brands
        internal async static Task<List<string>> GetBrandNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/camera/getcamerabrand"));
        }

        //used in frmModels
        internal async static Task<clsBrand> GetBrandAsync(string prBrandName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsBrand>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/camera/getbrand?Name=" + prBrandName));
        }
        #endregion

        #region Models

        #endregion
    }
}
