using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

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

        private void OpenCameraForm(clsAllCameras prCamera)
        {
            if (prCamera != null)
            {
                switch (prCamera.camera_type)
                {
                    case "DSLR":
                        frmDSLR.Run(prCamera);
                        break;
                    case "PointNShoot":
                        frmPointNShoot.Run(prCamera);
                        break;
                }
            }
        }

        #endregion

        #region Form updates

        public void UpdateForm()
        {
            Text = Brand.camera_brand;
            lblModelsFor.Text = "Showing models for brand " + Brand.camera_brand;
            UpdateDisplay();
        }

        private async void UpdateDisplay()
        {
            lstCameraModels.DataSource = null;
            ModelList = await ServiceClient.GetBrandModelObjectsAsync(Brand.camera_brand);
            List<string> lcModelNames = new List<string>();
            if(ModelList != null)
            {
                foreach (clsAllCameras item in ModelList)
                {
                    lcModelNames.Add(item.model_name.ToString() + "   " + item.price + "   " + item.camera_type);
                }
            }
            lstCameraModels.DataSource = lcModelNames;
        }

        #endregion

        #region buttons

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            clsAllCameras lcCamera = new clsAllCameras();
            switch (cbAddItemType.Text)
            {
                case "DSLR":
                    lcCamera.camera_type = "DSLR";
                    lcCamera.camera_brand = Brand.camera_brand;
                    frmDSLR.Run(lcCamera);
                    break;
                case "PointNShoot":
                    lcCamera.camera_type = "PointNShoot";
                    lcCamera.camera_brand = Brand.camera_brand;
                    //frmPointNShoot.Run(lcCamera);
                    break;
                default:
                    MessageBox.Show("Please select a camera type");
                    break;
            }
            UpdateDisplay();
        }

        private async void btnEditModel_Click(object sender, EventArgs e)
        {
            string model_name = ModelList[lstCameraModels.SelectedIndex].model_name.ToString();
            clsAllCameras lcCamera = await ServiceClient.GetCameraAsync(model_name);
            OpenCameraForm(lcCamera);
        }

        private async void btnDeleteModel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(await ServiceClient.DeleteCameraAsync(ModelList[lstCameraModels.SelectedIndex].model_name));
            UpdateDisplay();
        }
        #endregion
    }
}
