using System.Collections.Generic;
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
        internal async static Task<List<clsAllCameras>> GetBrandModelObjectsAsync(string prBrandName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAllCameras>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/camera/getbrandmodelobjects?Brand=" + prBrandName));
        }

        internal async static Task<clsAllCameras> GetCameraAsync(string camera_model)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsAllCameras>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/camera/getcamera?camera_model=" + camera_model));
        }

        // Testing stored procedure
        internal async static Task<List<string>> PostOrder(string camera_model)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/camera/postorder?camera_model=" + camera_model));
        }
        #endregion
    }
}
