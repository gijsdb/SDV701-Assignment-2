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
        #region Singleton

        private static readonly frmBrands _Instance = new frmBrands();
        private frmBrands()
        {
            InitializeComponent();
        }
        public static frmBrands Instance
        {
            get { return frmBrands._Instance; }
        }

        #endregion

        #region Methods

        private void frmBrands_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        public async void UpdateDisplay()
        {
            try
            {
                lstCameraBrands.DataSource = null;
                lstCameraBrands.DataSource = await ServiceClient.GetBrandNamesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not connect to server");
            }

        }

        private void OpenModelForm()
        {
            if (lstCameraBrands.SelectedItem != null)
            {
                frmModels.Run(lstCameraBrands.SelectedItem as string);
            }
        }

        #endregion


        #region Form buttons

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Other GUI components

        private void lstCameraBrands_DoubleClick(object sender, EventArgs e)
        {
            OpenModelForm();
        }

        #endregion

        private void btnViewModels_Click(object sender, EventArgs e)
        {
            OpenModelForm();
        }
    }
}
