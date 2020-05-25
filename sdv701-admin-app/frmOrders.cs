using System;
using System.Collections.Generic;
using System.Windows.Forms;

/*
    Author: Gijs de Blauw
    Description: 
        - Displays list of orders from API
        - Shows total value of orders
        - Can delete orders from here
*/

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

        #region Variables 
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               MessageBox.Show(await ServiceClient.DeleteOrderAsync(lstOrders.SelectedItems[0].SubItems[4].Text));
               UpdateDisplay();
            } catch(System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("No order selected");
            }
           
        }
        #endregion

        #region updates
        public async void UpdateDisplay()
        {
            TotalValue = 0;
            // lstOrders.DataSource = null;
            //  lstOrders.DataSource = await ServiceClient.GetOrdersAsync();
            lstOrders.Items.Clear();
            OrderList = await ServiceClient.GetOrdersAsync();
            List<string> lcOrderEntry = new List<string>();
            if (OrderList != null)
            {
                foreach (clsOrder order in OrderList)
                {
                    //lcOrderEntry.Add(order.quantity.ToString() + " " + order.model_name + " @ " + order.price + " for " + order.customer_address);
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = order.quantity.ToString();
                    lvi.SubItems.Add(order.model_name);
                    lvi.SubItems.Add(order.customer_address);
                    lvi.SubItems.Add(order.price.ToString());
                    lvi.SubItems.Add(order.order_id.ToString());
                    lstOrders.Items.Add(lvi);
                    TotalValue = TotalValue + order.price;
                }
            }
            lstOrders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstOrders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lblTotalValue.Text = "Total value: " + TotalValue.ToString();
            // lstOrders.DataSource = lcOrderEntry;
        }
        #endregion

        
    }
}
