﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;
using static sdv701_customer_app.clsDTO;

/*
    Author: Gijs de Blauw
    Description: 
        - Can place an order for a specific camera
        - Updates quantity to check availability, if successful an order is placed
        - On succesful order, option to navigate back to camera brands page
*/

namespace sdv701_customer_app
{
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
        
        private async Task PostOrder()
        {
            clsOrder lcOrder = new clsOrder
            {
                order_date = DateTime.Today,
                price = Camera.price,
                quantity = Convert.ToInt16(txtOrderQuantity.Text),
                customer_name = txtCustName.Text,
                customer_address = txtCustAddress.Text,
                model_name = Camera.model_name,
            };

            try
            {
                string lcQuantity = txtOrderQuantity.Text;

                if (isValidQuantity(lcQuantity))
                {
                    int validQuantity = Convert.ToInt16(lcQuantity);
                    string isAvailable = await ServiceClient.GetOrder(Camera.model_name, validQuantity);

                    if (isAvailable == "Amount available")
                    {
                        string lcresult = await ServiceClient.InsertOrder(lcOrder);
                        lblStatus.Text = lcresult;
                        MessageDialog lcMessageBox = new MessageDialog("Your order has been placed. Navigate backt to Camera brands?");
                        lcMessageBox.Commands.Add(new UICommand("Yes", async x =>
                        {
                            Frame.Navigate(typeof(pgBrands));
                        }));
                        lcMessageBox.Commands.Add(new UICommand("Cancel"));
                        await lcMessageBox.ShowAsync();
                    }
                    else
                    {
                        lblStatus.Text = isAvailable;
                    }
                }             
            }
            catch (Exception ex)
            {
                // To do implement feedback from server
                lblStatus.Text = ex.GetBaseException().Message;
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
            MessageDialog lcMessageBox = new MessageDialog("Are you sure you want to place an order? You cannot revert this.");
            lcMessageBox.Commands.Add(new UICommand("Yes", async x =>
            {
                try
                {
                    await PostOrder();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ex.GetBaseException().Message;
                }
            }));
            lcMessageBox.Commands.Add(new UICommand("Cancel"));
            await lcMessageBox.ShowAsync();
        }
        #endregion

        #region Input validations
        private bool isValidQuantity(string prQuantity)
        {
            if (string.IsNullOrWhiteSpace(prQuantity))
            {
                lblStatus.Text = "You have not entered a quantity value.";
                return false;
            }

            if (!prQuantity.All(char.IsDigit))
            {
                lblStatus.Text = "Your order quantity contains invalid characters.";
                return false;
            }

            if (Convert.ToInt16(prQuantity) <= 0)
            {
                lblStatus.Text = "The order quantity is not valid";
                return false;
            }

            return true;
        }
        #endregion
    }
}
