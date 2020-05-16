using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdv701_admin_app
{
    public sealed partial class frmOrders : Form
    {
        #region Singleton  
        private frmOrders()
        {
            InitializeComponent();
        }
        public static readonly frmOrders Instance = new frmOrders();
        #endregion

        #region ##### VARIABLES #####
        private List<clsOrder> _OrderList = new List<clsOrder>();
        private decimal TotalValue;
        public List<clsOrder> OrderList { get => _OrderList; set => _OrderList = value; }
        #endregion

        #region  Methods
        private void frmOrders_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        #endregion

        #region  Buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
        #endregion

        #region updates
        public async void UpdateDisplay()
        {
            lstOrders.DataSource = null;
            lstOrders.DataSource = await ServiceClient.GetOrdersAsync();

            OrderList = await ServiceClient.GetOrdersAsync();
            List<string> lcOrderEntry = new List<string>();
            
            foreach (clsOrder order in OrderList)
            {
                lcOrderEntry.Add(order.quantity.ToString() + " " + order.model_name + " @ " + order.price + " for " + order.customer_address);
                TotalValue = TotalValue + order.price;
            }
            lblTotalValue.Text = "Total value: " + TotalValue.ToString();
            lstOrders.DataSource = lcOrderEntry;
        }
        #endregion
    }
}
