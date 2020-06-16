using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using static sdv701_customer_app.clsDTO;

/*
    Author: Gijs de Blauw
    Description: 
        - Displays specific Camera with different user controls for DSLR / PointNShoot attribute
        - Retrieves camera data from API
        - Can navigate back and to order 
*/

namespace sdv701_customer_app
{
    public sealed partial class pgCamera : Page
    {
        #region Constructor
        public pgCamera()
        {
            this.InitializeComponent();
            _CameraContent = new Dictionary<string, Delegate>
            {
                {"DSLR", new SetUserControlDelegate(SetDSLR)},
                {"PointNShoot", new SetUserControlDelegate(SetPointNShoot)}
            };
        }
        #endregion

        #region Variables
        private clsAllCameras _Camera;
        public clsAllCameras Camera { get => _Camera; set => _Camera = value; }
        #endregion

        #region SetUserControl
        private delegate void SetUserControlDelegate(clsAllCameras prCamera);
        private Dictionary<string, Delegate> _CameraContent;
        private void LoadCameraDetail(clsAllCameras prCamera)
        {
            _CameraContent[prCamera.camera_type].DynamicInvoke(prCamera);
            UpdateForm();
        }
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
                    LoadCameraDetail(Camera as clsAllCameras);
                    // UpdateForm();
                }
                catch (Exception ex)
                {
                    // To do implement feedback from server
                    lblStatus.Text = ex.GetBaseException().Message;
                }
            }
            else
            {
                lblStatus.Text = "Failed to load";
            }

        }
        #endregion

        #region UserControls
        private void SetDSLR(clsAllCameras prCam)
        {
            ctcInheritance.Content = new ucDSLR();
        }

        private void SetPointNShoot(clsAllCameras prCam)
        {
            ctcInheritance.Content = new ucPointNShoot();
        }
        #endregion

        #region Updates
        public void UpdateForm()
        {
            lblModel.Text = Camera.model_name;
            lblPrice.Text = "NZD" + Camera.price.ToString();
            lblDescription.Text = Camera.description;
            lblQuantity.Text = Camera.quantity.ToString();
            (ctcInheritance.Content as ICameraControl).UpdateControl(Camera);
        }
        #endregion

        #region Buttons
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgModels), Camera.camera_brand);
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgOrder), Camera.model_name);
        }
        #endregion
    }
}
