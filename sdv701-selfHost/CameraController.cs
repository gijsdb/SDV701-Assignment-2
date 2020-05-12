using sdv701_admin_app;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdv701_selfHost
{
    public class CameraController : System.Web.Http.ApiController 
    {
        #region Camera Brands
        public List<string> GetCameraBrand()
        {
            Console.Write("Retrieving Camera Brands");
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT camera_brand FROM tblCameraBrand", null);
            List<string> lcCameraBrands = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcCameraBrands.Add((string)dr[0]);
            return lcCameraBrands;
        }

        public clsBrand GetBrand(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult =
                clsDbConnection.GetDataTable("SELECT * FROM tblCameraBrand WHERE camera_brand = @Name", par);
            if (lcResult.Rows.Count > 0)
                return new clsBrand()
                {
                    camera_brand = (string)lcResult.Rows[0]["camera_brand"],
                    description = (string)lcResult.Rows[0]["description"]
                };
            else
                return null;
        }
        #endregion

        #region Camera Models
        // For retrieving names for list in frmModels
        public List<string> GetBrandModelNames(string Brand)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Brand", Brand);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT model_name FROM tblCameraModel WHERE fk_camera_brand = @Brand", par);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        // For getting the objects 
        public List<clsAllCameras> GetBrandModelObjects(string Brand)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Brand", Brand);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM tblCameraModel WHERE fk_camera_brand = @Brand", par);
            List<clsAllCameras> lcModelList = new List<clsAllCameras>();

            if (lcResult.Rows.Count > 0)
            {
                foreach (DataRow dr in lcResult.Rows)
                {
                    clsAllCameras lcCamera = new clsAllCameras();
                    lcCamera.model_name = (string)dr["model_name"];
                    lcCamera.description = (string)dr["description"];
                    lcCamera.release_year = (DateTime)dr["release_year"];
                    lcCamera.quantity = Convert.ToInt16(dr["quantity"]);
                    lcCamera.price = (decimal)dr["price"];
                    lcCamera.lens_mount = dr["lens_mount"] is DBNull ? (string)null : (string)dr["lens_mount"];
                    lcCamera.zoom_range = dr["zoom_range"] is DBNull ? (string)null : (string)dr["zoom_range"];
                    lcCamera.last_modified = (DateTime)dr["last_modified"];
                    lcCamera.camera_type = (string)dr["camera_type"];
                    lcCamera.camera_brand = (string)dr["fk_camera_brand"];
                    lcModelList.Add(lcCamera);
                }
                return lcModelList;
            }
            else
                return null;
        }
        #endregion

    }
}
