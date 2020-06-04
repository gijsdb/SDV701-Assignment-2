using System;
using Windows.UI.Xaml.Controls;
using static sdv701_customer_app.clsDTO;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace sdv701_customer_app
{
    public sealed partial class ucPointNShoot : UserControl, ICameraControl
    {
        public ucPointNShoot()
        {
            this.InitializeComponent();
        }

        public void PushData(clsAllCameras prCamera)
        {
            throw new NotImplementedException();
        }

        public void UpdateControl(clsAllCameras prCamera)
        {
            lblZoomRange.Text = prCamera.zoom_range.ToString();
        }
    }
}
