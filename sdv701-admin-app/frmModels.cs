using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace sdv701_admin_app
{
    public sealed partial class frmModels : Form
    {
        #region Singleton
        public static readonly frmModels _Instance = new frmModels();
        private frmModels()
        {
            InitializeComponent();
        }
        public static frmModels Instance
        {
            get { return frmModels._Instance; }
        }

        #endregion

        #region Data fields

        private clsBrand _Brand;
        private List<clsAllCameras> _ModelList;

        public clsBrand Brand { get => _Brand; set => _Brand = value; }
        public List<clsAllCameras> ModelList { get => _ModelList; set => _ModelList = value; }

        #endregion

        #region Methods

        private void frmModels_Load(object sender, EventArgs e)
        {
           
        }

        public static void Run(string prBrandName)
        {
            if (string.IsNullOrEmpty(prBrandName))
            {
                Instance.SetDetails(new clsBrand());
            }
            else
            {
                Instance.refreshFormFromDB(prBrandName);
            }
            Instance.Show();
        }

        private async void refreshFormFromDB(string prBrand)
        {
            SetDetails(await ServiceClient.GetBrandAsync(prBrand));
        }

        public async void SetDetails(clsBrand prBrand)
        {
            Brand = prBrand;
            ModelList = await ServiceClient.GetBrandModelObjectsAsync(Brand.camera_brand);
            UpdateForm();
            Show();
        }

        #endregion

        #region Form updates

        public void UpdateForm()
        {
            Text = Brand.camera_brand;
            //txtDescription.Text = Model.description;
            UpdateDisplay();
        }

        private async void UpdateDisplay()
        {
            lstCameraModels.DataSource = null;
            ModelList = await ServiceClient.GetBrandModelObjectsAsync(Brand.camera_brand);
            List<string> lcModelNames = new List<string>();
            foreach (clsAllCameras item in ModelList)
            {
                lcModelNames.Add(item.model_name.ToString() + " " + item.price);
            }
            lstCameraModels.DataSource = lcModelNames;
        }

        #endregion

    }
}
