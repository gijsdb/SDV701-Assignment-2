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
