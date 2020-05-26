using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace sdv701_customer_app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgBrands : Page
    {
        public pgBrands()
        {
            this.InitializeComponent();
        }

        private async void pgBrands_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lstBrands.ItemsSource = await ServiceClient.GetBrandNamesAsync();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.GetBaseException().Message;
            }
        }
    }
}
