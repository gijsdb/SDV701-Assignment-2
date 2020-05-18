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

        // For getting all the objects 
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

        // Get ONE camera
        public clsAllCameras GetCamera(string camera_model)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Id", camera_model);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM tblCameraModel WHERE model_name = @Id", par);
            if (lcResult.Rows.Count > 0)
                return new clsAllCameras()
                {
                    model_name = (string)lcResult.Rows[0]["model_name"],
                    description = (string)lcResult.Rows[0]["description"],
                    release_year = (DateTime)lcResult.Rows[0]["release_year"],
                    quantity = Convert.ToInt16(lcResult.Rows[0]["quantity"]),
                    price = (decimal)lcResult.Rows[0]["price"],
                    lens_mount = lcResult.Rows[0]["lens_mount"] is DBNull ? "" : (string)lcResult.Rows[0]["lens_mount"],
                    zoom_range = lcResult.Rows[0]["zoom_range"] is DBNull ? "" : (string)lcResult.Rows[0]["zoom_range"],
                    last_modified = (DateTime)lcResult.Rows[0]["last_modified"],
                    camera_type = (string)lcResult.Rows[0]["camera_type"],
                    camera_brand = (string)lcResult.Rows[0]["fk_camera_brand"]
                };
            else
                return null;
        }

        // Delete camera frmModels
        public string DeleteCamera(string Id)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Id", Id);
            try
            {
                int lcDisableFk = clsDbConnection.Execute(
                    "alter table tblOrder nocheck constraint all", null);
                int lcRecCount = clsDbConnection.Execute(
                    "DELETE FROM tblCameraModel WHERE model_name = @Id", par);
                int lcEnableFk = clsDbConnection.Execute(
                    "alter table tblOrder check constraint all", null);
                if (lcRecCount == 1)
                    return "Camera Deleted.";
                else
                    return "Could not find camera to delete.";
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        #endregion

        #region Orders
        public List<clsOrder> GetOrders()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM tblOrder", null);

            List<clsOrder> lcOrderList = new List<clsOrder>();

            if (lcResult.Rows.Count > 0)
            {
                foreach (DataRow dr in lcResult.Rows)
                {
                    clsOrder lcOrder = new clsOrder();
                    lcOrder.order_id = Convert.ToInt32(dr["order_id"]);
                    lcOrder.order_date = (DateTime)dr["order_date"];
                    lcOrder.customer_name = (string)dr["customer_name"];
                    lcOrder.customer_address = (string)dr["customer_address"];
                    lcOrder.price = (decimal)dr["price"];
                    lcOrder.quantity = Convert.ToInt32(dr["quantity"]);
                    lcOrder.model_name = (string)dr["fk_model_name"];
                    lcOrderList.Add(lcOrder);
                }
                return lcOrderList;
            }
            else
                return null;
        }

        public string DeleteOrder(string Id)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Id", Id);
            try
            {
                /*
                int lcDisableFk = clsDbConnection.Execute(
                    "alter table tblOrder nocheck constraint all", null);
                */
                int lcRecCount = clsDbConnection.Execute(
                    "DELETE FROM tblOrder WHERE order_id = @Id", par);
                /*
                int lcEnableFk = clsDbConnection.Execute(
                    "alter table tblOrder check constraint all", null);
               */
                if (lcRecCount == 1)
                    return "Order Deleted.";
                else
                    return "Could not find order to delete.";
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        #endregion

    }
}
