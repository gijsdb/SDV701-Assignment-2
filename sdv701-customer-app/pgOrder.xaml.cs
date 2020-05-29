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

        private clsAllCameras _Camera;
        public clsAllCameras Camera { get => _Camera; set => _Camera = value; }

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

        private void UpdateForm()
        {
            lblModel.Text = Camera.model_name;
            lblDescription.Text = Camera.description;
            lblPrice.Text = Camera.price.ToString();
            lblQuantity.Text = Camera.quantity.ToString();
        }
    }
}
