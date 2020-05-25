using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

/*
    Author: Gijs de Blauw
    Description: 
        - Used to communicate with SelfHost application
        - Contains all interactions with backend.
*/

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

        // Delete camera on frmModels
        internal async static Task<string> DeleteCameraAsync(string prId)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                    ($"http://localhost:60064/api/camera/DeleteCamera?Id={prId}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }

        }

        //Insert new camera
        internal async static Task<string> InsertCameraAsync(clsAllCameras prCamera)
        {
            return await InsertOrUpdateAsync(prCamera, "http://localhost:60064/api/camera/PostCamera", "POST");
        }

        // Update existing camera
        internal async static Task<string> UpdateCameraAsync(clsAllCameras prCamera)
        {
            return await InsertOrUpdateAsync(prCamera, "http://localhost:60064/api/camera/PutCamera", "PUT");
        }
        #endregion

        #region Orders
        //Retrieve the orders
        internal async static Task<List<clsOrder>> GetOrdersAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrder>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/camera/GetOrders"));
        }

        // Delete an order
        internal async static Task<string> DeleteOrderAsync(string prId)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                    ($"http://localhost:60064/api/camera/DeleteOrder?Id={prId}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }

        }
        #endregion

        #region Others
        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content = new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
        #endregion
    }
}
