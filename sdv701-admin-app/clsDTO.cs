using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdv701_admin_app
{
    public class clsBrand
    {
        //pk
        public string camera_brand { get; set; }
        public string description { get; set; }
    }


    public class clsAllCameras
    {
        // pk
        public string model_name { get; set; }
        public string description { get; set; }
        public DateTime release_year { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string lens_mount { get; set; }
        public string zoom_range { get; set; }
        public DateTime last_modified { get; set; }
        public string camera_type { get; set; }
        public byte[] image { get; set; }
        //FK
        public string camera_brand { get; set; }
    }

    public class clsOrder
    {
        //pk
        public int order_id { get; set; }
        public DateTime order_date { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        // FK
        public string model_name { get; set; }
    }
}
