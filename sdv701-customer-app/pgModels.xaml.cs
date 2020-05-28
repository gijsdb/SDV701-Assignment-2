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
                        lcModelNames.Add(camera.model_name + " " + camera.camera_type);
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
                string lcCameraType = ModelList[lstModels.SelectedIndex].camera_type;
                string lcCameraId = ModelList[lstModels.SelectedIndex].model_name;

                if(lcCameraType == "DSLR")
                {
                    Frame.Navigate(typeof(pgDSLR), lcCameraId);
                } else
                {
                   Frame.Navigate(typeof(pgPointNShoot), lcCameraId);
                }
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
