using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdv701_admin_app
{
    public sealed partial class frmBrands : Form
    {
        private static readonly frmBrands _Instance = new frmBrands();

        public frmBrands()
        {
            InitializeComponent();
        }

        public async void UpdateDisplay()
        {
            try
            {
                lstCameraBrands.DataSource = null;
                lstCameraBrands.DataSource = await ServiceClient.GetBrandsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not connect to server");
            }

        }
        public static frmBrands Instance
        {
            get { return frmBrands._Instance; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBrands_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void lstCameraBrands_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstCameraBrands.SelectedItem);
            if (lcKey != null)
                try
                {
                    //frmModels.Run(lstCameraBrands.SelectedItem as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }
    }
}
