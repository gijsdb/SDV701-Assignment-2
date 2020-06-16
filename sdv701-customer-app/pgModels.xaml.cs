using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using static sdv701_customer_app.clsDTO;

/*
    Author: Gijs de Blauw
    Description: 
        - Retrieves camera models for a brand from API 
        - Can navigate back to brands and to a specific camera
*/

namespace sdv701_customer_app
{
    public sealed partial class pgModels : Page
    {
        #region Variables
        private clsBrand _Brand;
        private List<clsAllCameras> _ModelList;

        public clsBrand Brand { get => _Brand; set => _Brand = value; }
        public List<clsAllCameras> ModelList { get => _ModelList; set => _ModelList = value; }
        #endregion

        #region Constructor
        public pgModels()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Methods
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            try
            {
                if (e.Parameter != null)
                {
                    string lcBrandName = e.Parameter.ToString();
                    Brand = await ServiceClient.GetBrandAsync(lcBrandName);
                    UpdateForm();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.GetBaseException().Message;
            }
        }

        private async void SetModelList()
        {
            lstModels.ItemsSource = null;

            try
            {
                ModelList = await ServiceClient.GetBrandModelObjectsAsync(Brand.camera_brand);

                if (ModelList != null)
                {
                    List<string> lcModelNames = new List<string>();
                    foreach (clsAllCameras camera in ModelList)
                    {
                        lcModelNames.Add(camera.model_name + "   " + camera.price + "   " + camera.camera_type);
                    }
                    lstModels.ItemsSource = lcModelNames;
                }
                else
                {
                    lblStatus.Text = "This brand does currently not contain camera models";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.GetBaseException().Message;
            }
        }

        public void OpenSelectedCamera()
        {
            try
            {
                string lcCameraId = ModelList[lstModels.SelectedIndex].model_name;
                Frame.Navigate(typeof(pgCamera), lcCameraId);
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.GetBaseException().Message;
            }
        }
        #endregion

        #region Updates
        public void UpdateForm()
        {
            lblTitle.Text = Brand.camera_brand + " " + "Models";
           
            lblStatus.Text = "";

            SetModelList();
        }
        #endregion

        #region ListControls
        private void lstModels_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            OpenSelectedCamera();
        }
        #endregion

        #region Buttons
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgBrands));
        }

        private void btnOpenCamera_Click(object sender, RoutedEventArgs e)
        {
            OpenSelectedCamera();
        }
        #endregion
    }
}
