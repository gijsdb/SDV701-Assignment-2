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
        #region Brand

        // RETRIEVE 
        // Used in frmBrands
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

        #region Camera Models

        // Only retrieve names
        internal async static Task<List<clsAllCameras>> GetBrandModelNamesAsync(string prBrandName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAllCameras>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/camera/getbrandmodels?Brand=" + prBrandName));
        }

        // All cameras by brand
        internal async static Task<List<clsAllCameras>> GetBrandModelObjectsAsync(string prBrandName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAllCameras>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/camera/getbrandmodelobjects?Brand=" + prBrandName));
        }

        // Specific camera by ID
        internal async static Task<clsAllCameras> GetCameraAsync(string camera_model)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsAllCameras>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/camera/getcamera?camera_model=" + camera_model));
        }
        #endregion

        #region Orders
        internal async static Task<List<clsOrder>> GetOrdersAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrder>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/camera/GetOrders"));
        }
        #endregion

    }
}
