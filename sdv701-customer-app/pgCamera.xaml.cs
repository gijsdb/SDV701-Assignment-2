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
            lblStatus.Text = ctcInheritance.Content.ToString();
        }
        #endregion

        #region Buttons
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgModels), Camera.camera_brand);
        }
        #endregion
    }
}
