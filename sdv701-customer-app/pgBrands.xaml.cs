using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

/*
    Author: Gijs de Blauw
    Description: 
        - Contains the brand list from API
        - UI controls for navigating to models page
*/

namespace sdv701_customer_app
{
    public sealed partial class pgBrands : Page
    {
        #region Constructor
        public pgBrands()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Initilization
        private async void pgBrands_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lstBrands.ItemsSource = await ServiceClient.GetBrandNamesAsync();
                lblStatus.Text = "Data has been retrieved.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.GetBaseException().Message;
            }
        }
        #endregion

        #region Methods
        public void OpenModels()
        {
            try
            {
                Frame.Navigate(typeof(pgModels), lstBrands.SelectedItem);
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.GetBaseException().Message;
            }
        }
        #endregion

        #region Buttons
        private void btnOpenSelectedModel_Click(object sender, RoutedEventArgs e)
        {
            if (lstBrands.SelectedItem != null)
            {
                OpenModels();
            }
            else
            {
                lblStatus.Text = "Please select a Brand from the list.";
            }
        }

        private void lstBrands_DoubleTapped(object sender, RoutedEventArgs e)
        {
            OpenModels();          
        }
        #endregion

    }
}
