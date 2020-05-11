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
        public List<string> GetCameraBrands()
        {
            Console.Write("Retrieving Camera Brands");
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM tblCameraBrand", null);
            List<string> lcCameraBrands = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcCameraBrands.Add((string)dr[0]);
            return lcCameraBrands;
        }
    }
}
