using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static sdv701_customer_app.clsDTO;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace sdv701_customer_app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgOrder : Page
    {
        public pgOrder()
        {
            this.InitializeComponent();
        }

        #region Variables
        private clsAllCameras _Camera;
        public clsAllCameras Camera { get => _Camera; set => _Camera = value; }
        #endregion

        #region Methods
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                try
                {
                    Camera = await ServiceClient.GetCameraAsync(e.Parameter.ToString());
                    UpdateForm();
                }
                catch (Exception ex)
                {
                    // To do implement feedback from server
                    //lblStatus.Text = ex.GetBaseException().Message;
                }
            }
            else
            {
                //lblStatus.Text = "Failed to load";
            }
        }
        #endregion

        #region Update
        private void UpdateForm()
        {
            lblModel.Text = Camera.model_name;
            lblDescription.Text = Camera.description;
            lblPrice.Text = Camera.price.ToString();
            lblQuantity.Text = Camera.quantity.ToString();
            if (Camera.camera_type == "DSLR")
            {
                lblInheritance.Text = "Lens mount";
                lblInheritanceVal.Text = Camera.lens_mount;
            }
            else
            {
                lblInheritance.Text = "Zoom range";
                lblInheritanceVal.Text = Camera.zoom_range;
            }
        }

        #endregion

        #region Buttons
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgCamera), Camera.model_name);
        }

        private async void btnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int lcQuantity = Convert.ToInt16(txtOrderQuantity.Text);
                int isAvailable = await ServiceClient.GetItemAvailable(Camera.model_name, lcQuantity);
                lblStatus.Text = isAvailable.ToString();
                // After item is available call create order procedure 
            }
            catch (Exception ex)
            {
                // To do implement feedback from server
                lblStatus.Text = ex.GetBaseException().Message;
            }
        }
        #endregion
    }
}
